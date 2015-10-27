using System;
using System.Runtime.Serialization;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxAppInfo
    {
        [DataMember]
        public int appId { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public long keepAlivePeriod { get; set;}
    }
}
