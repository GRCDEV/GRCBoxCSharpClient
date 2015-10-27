using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxRule
    {
        public enum Protocol
        {
            TCP, UDP
        }

        public enum RuleType
        {
            INCOMING,
            OUTGOING,
            MULTICAST
        }
        [DataMember]
        int id { get; set; }
        [DataMember]
        Protocol protocol { get; set; }
        [DataMember]
        RuleType type { get; set; }
        [DataMember]
        int appid { get; set; }
        [DataMember]
        String ifName { get; set; }
        [DataMember]
        long expireDate { get; set; }
        [DataMember]
        int srcPort { get; set; }
        [DataMember]
        int dstPort { get; set; }
        [DataMember]
        String srcAddr { get; set; }
        [DataMember]
        String dstAddr { get; set; }
        [DataMember]
        String mcastPlugin { get; set; }
        [DataMember]
        int dstFwdPort { get; set; }
        [DataMember]
        String dstFwdAddr { get; set; }
    }
}
