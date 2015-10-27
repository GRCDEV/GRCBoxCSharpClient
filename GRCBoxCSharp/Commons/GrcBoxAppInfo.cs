using System;
using System.Runtime.Serialization;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxAppInfo
    {
        [DataMember]
        int appId { get; set; }
        [DataMember]
        String name { get; set; }
        [DataMember]
        long keepAlivePeriod { get; set;}
    }
}
