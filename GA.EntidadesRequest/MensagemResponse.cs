using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA.EntidadesRequest
{
    public class MensagemResponse
    {
        public int Id { get; set; }
        public UsuarioResponse UsuarioRecebeu { get; set; }
        public UsuarioResponse UsuarioEnviou { get; set; }
        public string ConteudoMensagem { get; set; }
    }
}
