using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Servers
{
    internal static class Program
    {
        const string BASE_ADDRESS = "http://localhost:8000/RoutingService";
        private static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(RServiceImpl), new Uri(BASE_ADDRESS)))
            {
                try
                {
                    var smb = new ServiceMetadataBehavior
                    {
                        HttpGetEnabled = true,
                        MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
                    };
                    host.Description.Behaviors.Add(smb);

                    host.Open();

                    Console.WriteLine("RoutingService is ready at {0}", BASE_ADDRESS);
                    Console.WriteLine("Press <Enter> to stop the service.");
                    Console.ReadLine();

                    host.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    host.Abort();
                }
            }
        }
    }
}