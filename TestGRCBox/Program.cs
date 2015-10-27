using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net;
using GrcBoxCSharp;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace TestGRCBox
{
    class Program
    {
        readonly static String GRCBOXBASEURL = "http://192.168.42.1:8080";
        static void Main(string[] args)
        {
            Console.WriteLine(GRCBOXBASEURL);
            GRCBoxClient client = new GRCBoxClient("test", GRCBOXBASEURL);
            Console.Write(client.getStatus());
            client.register();
            Thread.Sleep(3000);
            client.deregister();
        }
    }
}
