using Microsoft.ServiceBus;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    public class TurmaService : ITurmaService
    {
        public Turma ObterTurma(int idTurma)
        {
            return new Turma
            {
                CodTurma = "CodTurma",
                NumAulaSemana = 2
            };
        }
    }

    [ServiceContract]
    public interface ITurmaService
    {
        [OperationContract]
        Turma ObterTurma(int idTurma);
    }

    public interface ITurmaServiceChannel : ITurmaService, IClientChannel { }

    [DataContract]
    public class Turma
    {
        [DataMember]
        public string CodTurma { get; set; }

        [DataMember]
        public int NumAulaSemana { get; set; }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ServiceHost sh = new ServiceHost(typeof(TurmaService));

    //        sh.AddServiceEndpoint(
    //                typeof(ITurmaService), 
    //                new WebHttpRelayBinding(),
    //                ServiceBusEnvironment.CreateServiceUri("sb", "demotestesb2", "turma"))
    //            .Behaviors.Add(new TransportClientEndpointBehavior
    //            {
    //                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "JK4Ds/evY1oTHUAlQJW5Pm8gM6zIxW0XeppmeXFQFOs=")
    //            });

    //        sh.Open();
    //    }
    //}
}
