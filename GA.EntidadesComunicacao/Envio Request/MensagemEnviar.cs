using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA.EntidadesComunicacao
{
    public class MensagemEnviar
    {
        public int UsuarioEnviou { get; set; }
        public int UsuarioRecebeu { get; set; }        
        public string ConteudoMensagem { get; set; }
    }
}
