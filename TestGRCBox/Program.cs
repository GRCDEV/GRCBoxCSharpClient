using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Net;
using GrcBoxCSharp;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace TestGRCBox
{
    class Program
    {
        readonly static String GRCBOXBASEURL = "http://192.168.42.1:8080"; //Do not know why grcbox is not properly resolved :S
        static void Main(string[] args)
        {
            Console.WriteLine(GRCBOXBASEURL);
            NetworkInterface mIface = null;
            foreach( NetworkInterface iface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(iface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    mIface = iface;
                    break;
                }
            }
            GRCBoxClient client = new GRCBoxClient("test", GRCBOXBASEURL, mIface);
            Console.Write(client.getStatus());
            client.register();
            Thread.Sleep(10000);
            List<GrcBoxInterface> ifaces = client.getInterfaces();
            client.registerNewRule(GrcBoxRule.Protocol.TCP, GrcBoxRule.RuleType.INCOMING, ifaces[0], 0, 80);
            List<GrcBoxRule> rules = client.getRules();
            client.deregister();
            //Wait for any key
            Console.ReadKey();
        }
    }
}
