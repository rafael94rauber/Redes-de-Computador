using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using GA.EntidadesRequest;

namespace GA.Comunicacao
{
    public class MensagemComunicacao
    {
        private const string uriWebApi = "http://localhost:38104/";
        private const string actionReceberMensagem = "api/Mensagem/Receber/";
        private const string actionEnviarMensagem = "api/Mensagem/Enviar/";




        public MensagemComunicacao()
        {          
                        GetRequest().Wait();
        }

        public async Task<List<MensagemResponse>> GetRequest()
        {
            MensagemRequest mensagem = new MensagemRequest
            {
                UsuarioEnvio = 1,
                UsuarioReceber = 2
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uriWebApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                response = await client.GetAsync($"{actionReceberMensagem}{mensagem}");
                if (response.IsSuccessStatusCode)
                {
                    MensagemResponse[] mensagens = await response.Content.ReadAsAsync<MensagemResponse[]>();
                    return mensagens.ToList();
                }
            }
            return null;
        }

        static async Task Post(string ID)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37641/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var input = new { oldWord = "begin", newWord = "end", blurbText = "begin test begin" };
            Console.WriteLine(client.PostAsJsonAsync("api/templateService/ReplaceBlurbText", input).Result.Content.ReadAsAsync<string>().Result);
            Console.ReadLine();

            MensagemRequest mensagem = new MensagemRequest
            {
                UsuarioEnvio = 1,
                UsuarioReceber = 2,
                ConteudoMensagem = "Conteudo da mensagem enviada da dll de comunicacao"
            };

            HttpClient client2 = new HttpClient
            {
                BaseAddress = new Uri(uriWebApi)
            };

            client2.DefaultRequestHeaders.Accept.Clear();
            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync(actionEnviarMensagem, mensagem);
            var resultado = await response.Content.ReadAsAsync<string>();


            //using (var client = new HttpClient())
            //{

            // client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // HttpResponseMessage response = await client.PostAsJsonAsync(actionEnviarMensagem, mensagem);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        HttpResponseMessage result = await response.Content.ReadAsAsync<bool>();
            //        if (result)
            //            Console.WriteLine("Report Submitted");
            //        else
            //            Console.WriteLine("An error has occurred");
            //    }
            //}
        }
    }
}
