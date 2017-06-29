using Microsoft.ServiceBus;
using System;
using System.ServiceModel;
using WebApplication2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf = new ChannelFactory<IService1Channel>(
                new NetTcpRelayBinding(),
                new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb", "testeservicebus2", "service")));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            { TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "Pbhaht1MCX873alTtcJM7GFkt4UrrdSKXgDfJbT9Fdg=") });

            using (var ch = cf.CreateChannel())
            {
                var turma = ch.DoWork();
                Console.WriteLine($"Turma {turma}");
            }
        }
    }
}
