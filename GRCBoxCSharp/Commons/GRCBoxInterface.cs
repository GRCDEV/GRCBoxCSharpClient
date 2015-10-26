using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrcBoxCSharp
{
    [DataContract]
    public class GrcBoxInterface
    {
        public enum Type
        {
            WIFISTA,
            WIFIAH,
            CELLULAR,
            ETHERNET,
            WIMAX,
            OTHERS,
            UNKNOWN
        };

        String name
        {
            get;
        }

        String address
        {
            get;
        }

        Type type
        {
            get;
        }

        String connection
        {
            get;
        }

        double cost
        {
            get;
        }

        double rate
        {
            get;
        }

        bool isUp
        {
            get;
        }

        bool isMulticast
        {
            get;
        }

        bool hasInternet
        {
            get;
        }

        bool isDefault
        {
            get;
        }
    }
}
