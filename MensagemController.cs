using GA.WebAPI.Controllers.Actions;
using GA.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GA.WebAPI.Controllers
{
    public class MensagemController : ApiController
    {
        // GET: api/Mensagem
        [HttpGet]
        [ActionName("Receber")]
        public IEnumerable<string> Get(int UsuarioEnvio, int UsuarioReceber)
        {
            GravarMensagemTexto adoMensgem = new GravarMensagemTexto();
            var listaMensagens = adoMensgem.PegarMensagem(UsuarioEnvio, UsuarioReceber);
            List<string> retorno = new List<string>();

            foreach (var item in listaMensagens)
            {
                if (item.Value.UsuarioEnviou.Id == UsuarioEnvio &&
                    item.Value.UsuarioRecebeu.Id == UsuarioReceber)
                {
                    retorno.Add(item.Value.ConteudoMensagem);
                }
            }

            return retorno.ToList();
        }

        // POST: api/Mensagem/1/2/'mensagem de texto'
        [HttpPost]
        [ActionName("Enviar")]
        public void Post(int UsuarioEnvio, int UsuarioReceber, string conteudoMensagem)
        {
            Mensagem msg = new Mensagem
            {
                ConteudoMensagem = conteudoMensagem,
                UsuarioEnviou = new Usuario().RetornarUsuario(UsuarioEnvio),
                UsuarioRecebeu = new Usuario().RetornarUsuario(UsuarioReceber),
                Id = new Random().Next(100)
            };

            //salvar a mensagem
            GravarMensagemTexto adoMensgem = new GravarMensagemTexto();
            adoMensgem.GravarMensagem(msg);
        }
    }
}
