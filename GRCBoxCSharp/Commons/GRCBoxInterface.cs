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
        String name { get; set; }
        [DataMember]
        String address{ get; set; }
        [DataMember]
        Type type{ get; set; }
        [DataMember]
        String connection { get; set; }
        [DataMember]
        double cost{ get; set; }
        [DataMember]
        double rate{ get; set; }
        [DataMember]
        bool isUp{ get; set; }
        [DataMember]
        bool isMulticast{ get; set; }
        [DataMember]
        bool hasInternet{ get; set; }
        [DataMember]
        bool isDefault{ get; set; }
    }
}
