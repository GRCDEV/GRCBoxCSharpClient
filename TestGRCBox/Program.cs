using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net;
using GrcBoxCSharp;
using System.IO;
using Newtonsoft.Json;

namespace TestGRCBox
{
    class Program
    {
        readonly static String GRCBOXBASEURL = "http://192.168.42.1:8080/";
        static void Main(string[] args)
        {
            Console.WriteLine(GRCBOXBASEURL);
            HttpWebRequest request = WebRequest.Create(GRCBOXBASEURL) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    response.StatusCode,
                    response.StatusDescription));
                GrcBoxStatus status = new GrcBoxStatus("GRCBox Server", new StringList(new List<string>() {"SCAMPI", "NONE"}), 0, 0, 0);
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(GrcBoxStatus));
                MemoryStream stream = new MemoryStream();
                jsonSerializer.WriteObject(stream, status);
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                Console.WriteLine("Serialized Object");
                Console.WriteLine(content);
                reader = new StreamReader(response.GetResponseStream());
                //Console.WriteLine(reader.ReadToEnd());
                GrcBoxStatus statusNet = jsonSerializer.ReadObject(response.GetResponseStream()) as GrcBoxStatus;
            }
        }
    }
}
