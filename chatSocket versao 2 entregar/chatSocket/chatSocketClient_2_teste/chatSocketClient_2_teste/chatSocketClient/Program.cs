using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatSocketClient
{
    class Program
    {
        // usuario que estao envolvidos na troca de mensagem
        public const string USUARIO_2 = "RAFAEL ALUNO";
        public const string USUARIO_1 = "MARCIO PROFESSOR";

        static void Main(string[] args)
        {
            var clinte = new Cliente();
            clinte.ExecutarCliente(USUARIO_1, USUARIO_2);
        }
    }
}
