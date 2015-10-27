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
        public Type type{ get; set; }
        [DataMember]
        public string connection { get; set; }
        [DataMember]
        public double cost{ get; set; }
        [DataMember]
        public double rate{ get; set; }
        [DataMember]
        public bool isUp{ get; set; }
        [DataMember]
        public bool isMulticast{ get; set; }
        [DataMember]
        public bool hasInternet{ get; set; }
        [DataMember]
        public bool isDefault{ get; set; }
    }
}
