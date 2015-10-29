using System.Runtime.Serialization;


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

        [DataMember(Name = "@class")]
        public string javaclass { get; set; } = "es.upv.grc.grcbox.common.GrcBoxRule";
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string proto { get; set; }
        [DataMember]
        public string type { get; set; }
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

        public GrcBoxRule(int id, string protocol, string t, int appId, string ifName, long expireDate, int srcPort,
            int dstPort, string srcAddr, string dstAddr, string mcastPlugin, int dstFwdPort, string dstFwdAddr)
        {
            this.id = id;
            this.proto = protocol;
            this.type = t;
            this.appid = appId;
            this.ifName = ifName;
            this.expireDate = expireDate;
            this.srcPort = srcPort;
            this.dstPort = dstPort;
            this.srcAddr = srcAddr;
            this.dstAddr = dstAddr;
            this.mcastPlugin = mcastPlugin;
            this.dstFwdPort = dstFwdPort;
            this.dstFwdAddr = dstFwdAddr;
        }
    }
}
