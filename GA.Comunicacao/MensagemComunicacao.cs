using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using GA.EntidadesComunicacao;

namespace GA.Comunicacao
{
    public class MensagemComunicacao
    {
        private const string uriWebApi = "http://localhost:50772/";
        private const string actionReceberMensagem = "api/Mensagem/Receber/";
        private const string actionEnviarMensagem = "api/Mensagem/Enviar/";
        private static HttpClient conexaoCliente;

        public MensagemComunicacao()
        {

        }

        /// <summary>
        /// abre a conexao com a web-api
        /// </summary>
        private void AbreConexaoWeb()
        {
            conexaoCliente = new HttpClient
            {
                BaseAddress = new Uri(uriWebApi)
            };
            conexaoCliente.DefaultRequestHeaders.Accept.Clear();
            conexaoCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<MensagemDTO>> Enviar(MensagemEnviar mensagem)
        {
            AbreConexaoWeb();

            //post na metodo 'Enviar''da web-api
            var respostaPost = await conexaoCliente.PostAsJsonAsync(actionEnviarMensagem, mensagem);

            //retorno da web-abi
            var ConteudoPost = await respostaPost.Content.ReadAsAsync<List<MensagemDTO>>();

            return ConteudoPost;
        }

        public async Task<List<MensagemDTO>> Receber(MensagemReceber mensagem)
        {
            AbreConexaoWeb();

            //post na metodo 'Enviar''da web-api
            var respostaPost = await conexaoCliente.PostAsJsonAsync(actionReceberMensagem, mensagem);

            //retorno da web-abi
            var ConteudoPost = await respostaPost.Content.ReadAsAsync<List<MensagemDTO>>();

            return ConteudoPost;
        }
    }
}
