using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;

namespace chatSocketClient
{
    class Program
    {        
        public static Thread TipoThread;

        public static Dictionary<string, string> ListaClientes;

        static void Main(string[] args)
        {
            ListaClientes = new Dictionary<string, string>();

            string clienteNome = Console.ReadLine();

            ListaClientes.Add(clienteNome, $"Cliente:{clienteNome}; id:{ListaClientes.Count()}");

            ExecutarCliente(clienteNome);
        }

        private static void ExecutarCliente(string NomeCliente)
        {
            IPAddress localAddr = IPAddress.Parse("10.80.1.97");
            TcpClient client = new TcpClient();
            IPEndPoint serverLocation = new IPEndPoint(localAddr, 13000);

            client.Connect(serverLocation);

            //Se preferir altere localhost pelo IP do server

            var sockStream = client.GetStream();

            var escreve = new BinaryWriter(sockStream);

            var le = new BinaryReader(sockStream);

            var messageRespostaServidor = string.Empty;
            StringBuilder todasMensagens = new StringBuilder();

            do
            {
                Console.WriteLine("Mensagem Para enviar para o servidor: ");
                var conteudoMensagem = Console.ReadLine();
                var mensagemEnviarServidor = $"Cliente:{NomeCliente};ClienteReceber:{NomeCliente}-testeReceber;Mensagem:{conteudoMensagem}|";

                Console.WriteLine($"mensagens enviados do cliente: {NomeCliente}");
                Console.WriteLine($"mensagem: {conteudoMensagem}");

                // manda para o servidor
                escreve.Write(mensagemEnviarServidor);

                // resposta do servidor
                messageRespostaServidor = le.ReadString();

                var ConteudoRespostaServidor = messageRespostaServidor.Split('|');

                var ClienteReceber = ConteudoRespostaServidor[0].Split(';')[0];

                string[] separadorMensagens = { "Mensagens:"};

                string[] mensagens = ConteudoRespostaServidor[0].Split(separadorMensagens, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine($"Mensagens enviadas do cliente: {ClienteReceber}");
                for (int i = 0; i < mensagens.Length; i++)
                {
                    Console.WriteLine($"Mensagem: {mensagens[i]}");
                }

                todasMensagens.AppendLine(messageRespostaServidor);

            } while (messageRespostaServidor != "-1");

            escreve.Close();

            le.Close();

            sockStream.Close();

            client.Close();

            TipoThread.Abort();
        }
    }
}
