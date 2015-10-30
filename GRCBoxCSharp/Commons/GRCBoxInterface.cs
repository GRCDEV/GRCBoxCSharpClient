using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxInterface
    {
        public enum Type
        {
            WIFISTA,
            WIFIAH,
            CELLULAR,
            ETHERNET,
            WIMAX,
            OTHERS,
            UNKNOWN
        };

        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string address{ get; set; }
        [DataMember]
        public string type{ get; set; }
        [DataMember]
        public string connection { get; set; }
        [DataMember]
        public double cost{ get; set; }
        [DataMember]
        public double rate{ get; set; }
        [DataMember]
        public bool up{ get; set; }
        [DataMember]
        public bool multicast{ get; set; }
        [DataMember]
        public bool hasInternet{ get; set; }
        [DataMember( Name = "default") ]
        public bool isDefault{ get; set; }


        public override string ToString()
        {
            return String.Format("GRCBox Interface: Name = \"{0}\", Type = \"{1}\", Addr = \"{2}\", HasInternet = \"{3}\","+
                "Multicast = \"{4}\","
                , name, type, address, hasInternet, multicast);
        }
    }
}
