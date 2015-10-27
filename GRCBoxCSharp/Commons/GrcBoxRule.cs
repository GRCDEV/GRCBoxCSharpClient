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
        public int id { get; set; }
        [DataMember]
        public Protocol protocol { get; set; }
        [DataMember]
        public RuleType type { get; set; }
        [DataMember]
        public int appid { get; set; }
        [DataMember]
        public string ifName { get; set; }
        [DataMember]
        public long expireDate { get; set; }
        [DataMember]
        public int srcPort { get; set; }
        [DataMember]
        public int dstPort { get; set; }
        [DataMember]
        public string srcAddr { get; set; }
        [DataMember]
        public string dstAddr { get; set; }
        [DataMember]
        public string mcastPlugin { get; set; }
        [DataMember]
        public int dstFwdPort { get; set; }
        [DataMember]
        public string dstFwdAddr { get; set; }
    }
}
