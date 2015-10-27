using System.Collections.Generic;
using System.Runtime.Serialization;


namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxInterfaceList
    {
        [DataMember]
        List<GrcBoxInterface> ifaces { get; set; }
    }
}
