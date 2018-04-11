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

        /// <summary>
        /// abre a conexao com a web-api
        /// </summary>
        private static void AbreConexaoWeb()
        {
            conexaoCliente = new HttpClient
            {
                BaseAddress = new Uri(uriWebApi)
            };
            conexaoCliente.DefaultRequestHeaders.Accept.Clear();
            conexaoCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<List<MensagemDTO>> Enviar(MensagemEnviar mensagem)
        {
            AbreConexaoWeb();

            //post na metodo 'Enviar''da web-api
            var respostaPost = await conexaoCliente.PostAsJsonAsync(actionEnviarMensagem, mensagem);

            //retorno da web-abi
            var ConteudoPost = await respostaPost.Content.ReadAsAsync<List<MensagemDTO>>();            

            return ConteudoPost;
        }

        public static async Task<List<MensagemDTO>> Receber(MensagemReceber mensagem)
        {
            AbreConexaoWeb();

            //post na metodo 'Enviar''da web-api
            var respostaPost = await conexaoCliente.PostAsJsonAsync(actionReceberMensagem, mensagem);

            //retorno da web-abi
            var ConteudoPost = await respostaPost.Content.ReadAsAsync<List<MensagemDTO>>();

            return ConteudoPost;
        }

        //private async Task ProcessWebsocketSession(AspNetWebSocketContext context, MensagemEnviar mensagemEnviar)
        //{            
        //    var ws = context.WebSocket;

        //    new Task(async () =>
        //    {
        //        while (true)
        //        {
        //            // MUST read if we want the state to get updated...
        //            var result = await ws.ReceiveAsync(System.Text.Encoding.UTF8.GetBytes(mensagemEnviar), CancellationToken.None);

        //            if (ws.State != WebSocketState.Open)
        //            {
        //                break;
        //            }
        //        }
        //    }).Start();

        //    while (true)
        //    {
        //        if (ws.State != WebSocketState.Open)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            byte[] binaryData = { 0xde, 0xad, 0xbe, 0xef, 0xca, 0xfe };
        //            var segment = new ArraySegment<byte>(binaryData);
        //            await ws.SendAsync(segment, WebSocketMessageType.Binary,
        //                true, CancellationToken.None);
        //        }
        //    }
        //}
    }
}
