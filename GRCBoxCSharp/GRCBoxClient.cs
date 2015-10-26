using System;
using System.Collections.Generic;

namespace GrcBoxCSharp
{
    public class GRCBoxClient
    {
        /// <summary>
        /// The name of the app
        /// </summary>
        public String appName
        {
            get;
        }

        /// <summary>
        /// Create a new GRCBoxClient instance with APP name "name"
        /// </summary>
        /// <param name="name"></param>
        public GRCBoxClient(String name)
        {

        }

        /// <summary>
        /// Register this instance in the server should be called before anything else
        /// </summary>
        public void register()
        {
            //TODO
        }

        /// <summary>
        /// Deregister an app from the server, it should be called when the applications 
        /// is finished. All the rules will be removed.
        /// </summary>
        public void deregister()
        {
            //TODO
        }

        /// <summary>
        /// Returns the list of availbale interfaces
        /// </summary>
        /// <returns></returns>
        public List<GrcBoxInterface> getInterfaces()
        {
            return new List<GrcBoxInterface>();
        }

        /// <summary>
        /// Get a list of my registeres rules
        /// </summary>
        /// <returns></returns>
        public List<GrcBoxRule> getRules()
        {
            return new List<GrcBoxRule>();
        }
        
    }
}
