using GA.EntidadesComunicacao;
using GA.WebAPI.Service;
using GA.WebAPI.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace GA.WebAPI.Controllers
{
    public class MensagemController : ApiController
    {
        // GET: api/Mensagem
        [HttpPost]
        [ActionName("Receber")]
        public IHttpActionResult Receber(MensagemReceber mensagem)
        {
            if (mensagem.UsuarioEnviou == mensagem.UsuarioRecebeu)
            {
                return BadRequest("Usuario nao pode receber mensagem dele mesmo");
            }

            var listaRetorno = MensagemService.ReceberMensagem(mensagem);

            //issue Apagar mensagens recebidas #6 ************************
            return Ok(listaRetorno);
        }

        // POST: api/Mensagem/1/2/'mensagem de texto': exemplo de post
        [HttpPost]
        [ActionName("Enviar")]
        public IHttpActionResult Enviar(MensagemEnviar mensagem)
        {
            if (mensagem.UsuarioEnviou == mensagem.UsuarioRecebeu)
            {
                return BadRequest("Usuario nao pode enviar mensagem para ele mesmo");
            }
            //salvar a mensagem
            MensagemService.GravarMensagem(mensagem);

            // retorna um objeto em forma de estrutura json
            // estudar uma forma de retornar uma classe que seja util retornar
            //issue Classe para retornar post das mensagens #7 ************************
            //return Ok(estruturaRetorno);
            return Receber(new MensagemReceber
            {
                UsuarioEnviou = mensagem.UsuarioEnviou,
                UsuarioRecebeu = mensagem.UsuarioRecebeu
            });
        }
    }
}
