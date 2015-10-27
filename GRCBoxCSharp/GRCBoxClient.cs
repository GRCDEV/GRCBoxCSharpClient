using GRCBoxCSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;

namespace GrcBoxCSharp
{
    public class GRCBoxClient
    {
        private readonly string STATUS = "/";
        private readonly string IFACES = "/ifaces";
        private readonly string APPS = "/apps";
        private readonly string RULES = "/rules";

        private readonly string KEEPALIVETHREAD = "Keep Alive Thread";

        /// <summary>
        /// The name of the app
        /// </summary>
        private string appName;
        /// <summary>
        /// The base uri of the GRCBox
        /// </summary>
        private string baseUri;
        /// <summary>
        /// My appId after registration
        /// </summary>
        private int appId;
        /// <summary>
        /// My pass after registering for later communications
        /// </summary>
        private string mPass;
        /// <summary>
        /// A boolean field to 
        /// </summary>
        private bool isRegistered;

        Thread keepAliveThread;
        long keepAliceInterval;
        bool keepAliveBool = false;

        /// <summary>
        /// Create a new GRCBoxClient instance with APP name "name"
        /// </summary>
        /// <param name="name"></param>
        public GRCBoxClient(string name, string baseUri)
        {
            this.appName = name;
            this.baseUri = baseUri;
        }

        /// <summary>
        /// Register this instance in the server should be called before anything else
        /// </summary>
        public void register()
        {
            string uri = baseUri + APPS;
            IdSecret secret = makePostRequest<IdSecret>(uri, appName);
            appId = secret.appId;
            mPass = secret.secret.ToString();
            keepAliceInterval = secret.updatePeriod;
            keepAliveThread = new Thread(new ThreadStart(keepAlive));
            keepAliveThread.Name = KEEPALIVETHREAD;
            isRegistered = true;
            keepAliveBool = true;
            keepAliveThread.Start();
        }

        public void keepAlive()
        {
            while (keepAliveBool)
            {
                string uri = baseUri + APPS + "/" + appId;
                makePostRequest<Object>(uri,"", appId.ToString(), mPass);
                try
                {
                    Thread.Sleep((int)keepAliceInterval / 4);
                }
                catch(ThreadInterruptedException e)
                {
                    if (!keepAliveBool)
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Deregister an app from the server, it should be called when the applications 
        /// is finished. All the rules will be removed.
        /// </summary>
        public void deregister()
        {
            string uri = baseUri + APPS + "/" + appId;
            makeDeleteRequest(uri, appId.ToString(), mPass);
            keepAliveBool = false;
            isRegistered = false;
            keepAliveThread.Interrupt();
        }

        /// <summary>
        /// Returns the list of availbale interfaces
        /// </summary>
        /// <returns></returns>
        public List<GrcBoxInterface> getInterfaces()
        {
            string uri = baseUri + IFACES;
            GrcBoxInterfaceList list = makeGetRequest<GrcBoxInterfaceList>(uri);
            return list.ifaces;
        }

        /// <summary>
        /// Get a list of my registeres rules
        /// </summary>
        /// <returns></returns>
        public List<GrcBoxRule> getRules()
        {
            
        }

        /// <summary>
        /// Get the status of the GRCBox
        /// </summary>
        /// <returns></returns>
        public GrcBoxStatus getStatus()
        {
            string uri = baseUri + STATUS;
            GrcBoxStatus status = makeGetRequest<GrcBoxStatus>(uri);
            return status;
        }

        /// <summary>
        /// Register a new rule
        /// </summary>
        /// <param name="rule">The rule to be registered, the field ID is ignored by the server</param>
        /// <returns>The actual rule registered in the server, with the new ID</returns>
        public GrcBoxRule registerNewRule(GrcBoxRule rule)
        {
            //TODO
            return null;
        }

        /// <summary>
        /// Remove a rule from the server
        /// </summary>
        /// <param name="rule"></param>
        public void removeRule(GrcBoxRule rule)
        {
            //TODO
        }


        private T makeGetRequest<T>(string uri, string authName = null, string authPass = null)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

            if (authName != null && authPass != null)
            {
                SetBasicAuthHeader(request, authName, authPass);
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSerializer.ReadObject(response.GetResponseStream());
            }            
        }

        private T makePostRequest<T>(string uri, string content, string authName = null, string authPass = null)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";

            if (authName != null && authPass != null)
            {
                SetBasicAuthHeader(request, authName, authPass);
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default(T);
                }
                else if ( ! (response.StatusCode == HttpStatusCode.OK) )
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSerializer.ReadObject(response.GetResponseStream());
            }
        }

        private void makeDeleteRequest(string uri, string authName = null, string authPass = null)
        {
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            request.Method = "DELETE";

            if (authName != null && authPass != null)
            {
                SetBasicAuthHeader(request, authName, authPass);
            }
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return;
                }
                else if (!(response.StatusCode == HttpStatusCode.OK))
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                return;
            }
        }

        public void SetBasicAuthHeader(WebRequest req, String userName, String userPassword)
        {
            string authInfo = userName + ":" +userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            req.Headers["Authorization"] = "Basic " +authInfo;
        }
    }
}
