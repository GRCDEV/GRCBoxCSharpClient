using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxRuleList
    {
        [DataMember]
        List<GrcBoxRule> list { get; set; }
    }
}
