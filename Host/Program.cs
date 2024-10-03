using Service;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:3000");
            WebHttpBinding binding = new WebHttpBinding();

            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1), uri))
            {
                ServiceEndpoint endpoint = serviceHost.AddServiceEndpoint(typeof(IService1), binding, "");
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                serviceHost.Open();
                string kiiras = $"A szerver elindult http://localhost:3000: {DateTime.Now}";
                Console.WriteLine(kiiras);
                Console.WriteLine("A leállításhoz nyomjon entert!");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine($"{kiiras}\nA leállításhoz nyomjon entert!");
                }
                serviceHost.Close();
                Console.WriteLine($"A szerver http://localhost:3000 leállt: {DateTime.Now}");
                Thread.Sleep(3000);
            }
        }

    }
}
