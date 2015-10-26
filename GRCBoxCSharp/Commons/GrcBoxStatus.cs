using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxStatus
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public StringList supportedMulticastPlugins { get; set; }
        [DataMember]
        public int numIfaces { get; set; }
        [DataMember]
        public int numApps { get; set; }
        [DataMember]
        public int numRules { get; set; }

        public GrcBoxStatus(string name, StringList supportedMulticastPlugins, int numIfaces, int numApps, int numRules)
        {
            this.name = name;
            this.supportedMulticastPlugins = supportedMulticastPlugins;
            this.numIfaces = numIfaces;
            this.numApps = numApps;
            this.numRules = numRules;
        }
    }
}
