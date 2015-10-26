using System;
using System.Runtime.Serialization;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxAppInfo
    {
        int appId { get; set; }
        String name { get; set; }
        long keepAlivePeriod { get; set;}
    }
}
