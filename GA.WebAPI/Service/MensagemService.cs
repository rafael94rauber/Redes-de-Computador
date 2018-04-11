using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GA.EntidadesComunicacao;
using GA.WebAPI.Models;

namespace GA.WebAPI.Service
{
    /// <summary>
    /// Grava as mensagens trocadas em um arquivo .txt 
    /// cada linha representa uma 'POST' feito do aplicativo para o servidor
    /// cada linha e salvo uma estrutura json da classe de mensagem
    /// no aplicativo precisamos converter essa estrutura para classe para conseguirmos tratar estas mensagens
    /// </summary>
    public class MensagemService
    {
        public const string nomeArquivo = @"C:\WEB_API.txt";

        public static void GravarMensagem(MensagemEnviar mensagem)
        {
            //Gerar ID para mensagens enviadas #5 ************************
            Mensagem mensagemSalvar = new Mensagem
            {
                ConteudoMensagem = mensagem.ConteudoMensagem,
                UsuarioEnviou = UsuarioService.RetornarUsuario(mensagem.UsuarioEnviou),
                UsuarioRecebeu = UsuarioService.RetornarUsuario(mensagem.UsuarioRecebeu),
                Id = new Random().Next(1000)
            };

            StringBuilder conteudo = new StringBuilder();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(nomeArquivo, append: true))
            {
                conteudo.AppendLine($"{Newtonsoft.Json.JsonConvert.SerializeObject(mensagemSalvar)}");

                // escreve no arquivo a mensagem
                file.Write(conteudo.ToString());
                file.Close();
                file.Dispose();
            }
        }

        public static List<Mensagem> ReceberMensagem(MensagemReceber mensagem)
        {
            if (!System.IO.File.Exists(nomeArquivo))
            {
                return null;
            }

            var conteudoTxt = string.Empty;
            List<Mensagem> mensagensRetorno = new List<Mensagem>();            

            using (System.IO.StreamReader file = new System.IO.StreamReader(nomeArquivo))
            {
                while ((conteudoTxt = file.ReadLine()) != null)
                {
                    Mensagem mensagemLinha = Newtonsoft.Json.JsonConvert.DeserializeObject<Mensagem>(conteudoTxt);

                    if (mensagemLinha.UsuarioEnviou.Id == mensagem.UsuarioEnviou &&
                        mensagemLinha.UsuarioRecebeu.Id == mensagem.UsuarioRecebeu)
                    {
                        mensagensRetorno.Add(mensagemLinha);
                    }
                }

                file.Close();
                file.Dispose();
            }            

            return mensagensRetorno;
        }
    }
}