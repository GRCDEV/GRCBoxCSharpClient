using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrcBoxCSharp
{
    [DataContract]
    public class StringList
    {
        [DataMember]
        public List<string> list { get; set; }

        public StringList(List<string> list)
        {
            this.list = list;
        }
    }
}
