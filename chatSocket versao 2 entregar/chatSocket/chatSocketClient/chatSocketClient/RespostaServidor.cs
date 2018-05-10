using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatSocketClient
{
    public class RespostaServidor
    {
        public List<EnvioCliente> ConteudoServidor { get; set; }
        public bool PararCliente { get; set; }
    }
}
