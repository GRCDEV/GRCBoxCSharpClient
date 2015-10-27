using System.Collections.Generic;
using System.Runtime.Serialization;


namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxInterfaceList
    {
        [DataMember]
        public List<GrcBoxInterface> ifaces { get; set; }
    }
}
