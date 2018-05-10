using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatSocketServer
{
    class RecebeServidor
    {
        public bool ListarMensagens { get; set; }
        public string NomeClienteRecebe { get; set; }
        public string NomeClienteEnvia { get; set; }
        public string Mensagem { get; set; }
        public bool DesligarCliente { get; set; }
    }
}
