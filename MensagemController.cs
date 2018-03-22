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
        public Mensagem msg;


        // GET: api/Mensagem
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Mensagem/5
        public string Get(int idMensagem, int idUsuarioReceber)
        {
            Dictionary<int, string> teste = new Dictionary<int, string>();



            Newtonsoft.Json.JsonConvert.DeserializeObject<Mensagem>(teste);

            return "value";
        }
        
        // POST: api/Mensagem
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
        }
    }
}
