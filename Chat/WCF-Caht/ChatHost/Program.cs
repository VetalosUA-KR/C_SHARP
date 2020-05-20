using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCF_Caht.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Hosts is started");
                Console.ReadLine();
            }
        }
    }
}
