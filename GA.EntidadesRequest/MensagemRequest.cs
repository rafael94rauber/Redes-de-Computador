using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA.EntidadesRequest
{
    public class MensagemRequest
    {
        public int UsuarioEnvio { get; set; }
        public int UsuarioReceber { get; set; }
        public string ConteudoMensagem { get; set; }
    }
}
