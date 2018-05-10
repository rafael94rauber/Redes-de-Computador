

namespace chatSocketClient
{
    public class Program
    {
        // usuario que estao envolvidos na troca de mensagem
        public const string USUARIO_1 = "RAFAEL ALUNO";
        public const string USUARIO_2 = "MARCIO PROFESSOR";
        
        static void Main(string[] args)
        {
            var clinte = new Cliente();
            clinte.ExecutarCliente(USUARIO_1, USUARIO_2);
        }        
    }
}
