using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFServiceWebRole1
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
}
