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

        int id { get; set; }
        Protocol protocol { get; set; }
        RuleType type { get; set; }
        int appid { get; set; }
        String ifName { get; set; }
        long expireDate { get; set; }
        int srcPort { get; set; }
        int dstPort { get; set; }
        String srcAddr { get; set; }
        String dstAddr { get; set; }
        String mcastPlugin { get; set; }
        int dstFwdPort { get; set; }
        String dstFwdAddr { get; set; }
    }
}
