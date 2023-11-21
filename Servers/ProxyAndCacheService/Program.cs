using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ProxyAndCacheService
{
    internal class Program
    {
        const string BASE_ADDRESS = "http://localhost:8001/ProxyAndCacheService";
        public static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(PCServiceImpl), new Uri(BASE_ADDRESS)))
            {

                var smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true,
                    MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
                };


                host.Description.Behaviors.Add(smb);

                host.Open();

                Console.WriteLine("ProxyServer is ready at {0}", BASE_ADDRESS);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}