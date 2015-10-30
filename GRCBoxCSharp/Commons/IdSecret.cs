using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrcBoxCSharp
{   
    [DataContract]
    public class IdSecret
    {
        [DataMember]
        public int appId { get; set; }
        [DataMember]
        public int secret { get; set; }
        [DataMember]
        public long updatePeriod { get; set; }
    }
}
