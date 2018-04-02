using GA.EntidadesRequest;
using GA.WebAPI.Controllers.Actions;
using GA.WebAPI.Models;
using System;
using System.Web.Http;

namespace GA.WebAPI.Controllers
{
    public class MensagemController : ApiController
    {
        // GET: api/Mensagem
        [HttpGet]
        [ActionName("Receber")]
        public IHttpActionResult Get(MensagemRequest mensagem)
        {
            GravarMensagemTexto adoMensgem = new GravarMensagemTexto();
            var listaRetorno = adoMensgem.PegarMensagem(mensagem.UsuarioEnvio, mensagem.UsuarioReceber);

            //issue Apagar mensagens recebidas #6 ************************

            return Ok(listaRetorno);
        }

        // POST: api/Mensagem/1/2/'mensagem de texto': exemplo de post
        [HttpPost]
        [ActionName("Enviar")]
        public IHttpActionResult Post(MensagemRequest mensagem)
        {
            //Gerar ID para mensagens enviadas #5 ************************
            Mensagem msg = new Mensagem
            {
                ConteudoMensagem = mensagem.ConteudoMensagem,
                UsuarioEnviou = new Usuario().RetornarUsuario(mensagem.UsuarioEnvio),
                UsuarioRecebeu = new Usuario().RetornarUsuario(mensagem.UsuarioReceber),
                Id = new Random().Next(1000)
            };

            //salvar a mensagem
            GravarMensagemTexto adoMensgem = new GravarMensagemTexto();
            adoMensgem.GravarMensagem(msg);

            // retorna um objeto em forma de estrutura json
            // estudar uma forma de retornar uma classe que seja util retornar
            //issue Classe para retornar post das mensagens #7 ************************
            //return Ok(msg);
            return Ok();
        }
    }
}
