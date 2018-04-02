using GA.WebAPI.Models;
using System.Collections.Generic;
using System.Text;

namespace GA.WebAPI.Controllers.Actions
{
    public class GravarMensagemTexto
    {
        public const string nomeArquivo = @"C:\WEB_API.txt";

        public void GravarMensagem(Mensagem mensagem)
        {
            StringBuilder conteudo = new StringBuilder();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(nomeArquivo, append: true))
            {
                conteudo.AppendLine($"{Newtonsoft.Json.JsonConvert.SerializeObject(mensagem)}");

                // escreve no arquivo a mensagem
                file.Write(conteudo.ToString());
                file.Close();
                file.Dispose();
            }
        }

        public Dictionary<int, Mensagem> PegarMensagem(int UsuarioEnvio, int UsuarioReceber)
        {
            var conteudoTxt = string.Empty;
            Dictionary<int, Mensagem> mansagemRetorno = null;

            using (System.IO.StreamReader file = new System.IO.StreamReader(nomeArquivo))
            {
                mansagemRetorno = new Dictionary<int, Mensagem>();

                while ((conteudoTxt = file.ReadLine()) != null)
                {
                    var msg = Newtonsoft.Json.JsonConvert.DeserializeObject<Mensagem>(conteudoTxt);
                    if (msg.UsuarioEnviou.Id == UsuarioEnvio && msg.UsuarioRecebeu.Id == UsuarioReceber)
                    {
                        mansagemRetorno.Add(msg.Id, msg);
                    }
                }
                
                file.Close();
                file.Dispose();
            }

            return mansagemRetorno;
        }
    }
}