using GA.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GA.WebAPI.Controllers.Actions
{
    public class GravarMensagemTexto
    {
        public const string nomeArquivo = @"D:\Bem_AnaliseDiaria\WEB_API.txt";
        public void GravarMensagem(Mensagem mensagem)
        {

            StringBuilder conteudo = new StringBuilder();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(nomeArquivo, append: true))
            {
                conteudo.AppendLine($"{Newtonsoft.Json.JsonConvert.SerializeObject(mensagem)}");

                // escreve no arquivo a mensagem
                file.Write(conteudo.ToString());
            }
        }

        public Dictionary<int, string> PegarMensagem(int idMensagem, int idUsuarioReceber)
        {
            var conteudoTxt = string.Empty;
            Dictionary<int, string> mansagemRetorno = null;

            using (System.IO.StreamReader file = new System.IO.StreamReader(nomeArquivo))
            {
                mansagemRetorno = new Dictionary<int, string>();

                while ((conteudoTxt = file.ReadLine()) != null)
                {
                    mansagemRetorno.Add(idMensagem, conteudoTxt);
                }

                file.Close();
            }

            return mansagemRetorno;
        }
    }
}