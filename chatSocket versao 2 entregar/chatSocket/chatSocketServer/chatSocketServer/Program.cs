using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;

namespace chatSocketServer
{
    class Program
    {
        
        public const string IP_SERVIDOR = "10.80.1.97";
        public const Int32 PORTA_SERVIDOR = 13000;
        public static Dictionary<Guid, RecebeServidor> MensagensTrocadas;
        public static Thread instanciaServidorThread = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando servidor.....");

            MensagensTrocadas = new Dictionary<Guid, RecebeServidor>();
            IPAddress localAddr = IPAddress.Parse(IP_SERVIDOR);
            var server = new TcpListener(localAddr, PORTA_SERVIDOR);

            server.Start();

            //PROGRAMADO PARA RECEBER 2 THREAD DE CLIENTES
            for (int index = 1; index <= 2 ; index++)
            {
                var nome = $"instancia:{index}; guid: {GerarGuid()};";
                instanciaServidorThread = new Thread(() => Servidor(server, nome))
                {
                    Name = nome
                };

                instanciaServidorThread.Start();                
            }

            while (instanciaServidorThread.IsAlive)
            {
                Thread.Sleep(100);
            }

            server.Stop();
        }

        private static void Servidor(TcpListener server, string nomeInstancia)
        {
            while (true)
            {
                var conexao = server.AcceptSocket();
                var socketStream = new NetworkStream(conexao);
                var recebeServidor = new BinaryReader(socketStream);
                var enviaServidor = new BinaryWriter(socketStream);

                do
                {
                    Console.WriteLine($"Servidor comunicando com o clinte: {nomeInstancia}");

                    var conteudo = recebeServidor.ReadString();
                    if (string.IsNullOrEmpty(conteudo))
                    {
                        enviaServidor.Write(string.Empty);
                        conexao.Disconnect(true);
                        Console.WriteLine($"Servidor desconectado: {nomeInstancia}");
                        continue;
                    }

                    var recebeCliente = JsonConvert.DeserializeObject<RecebeServidor>(conteudo);

                    if (recebeCliente is null)
                    {
                        enviaServidor.Write(string.Empty);
                        Console.WriteLine($"Servidor desconectado: {nomeInstancia}");
                        continue;
                    }

                    Console.WriteLine($"Conectado ao cliente: {recebeCliente.NomeClienteEnvia}");

                    var idMensagem = GerarGuid();
                    MensagensTrocadas.Add(idMensagem, recebeCliente);

                    List<RecebeServidor> respostaServidor = new List<RecebeServidor>();
                    foreach (var item in MensagensTrocadas)
                    {
                        respostaServidor.Add(item.Value);
                    }

                    enviaServidor.Write(JsonConvert.SerializeObject(respostaServidor));

                } while (conexao.Connected);

                enviaServidor.Close();
                recebeServidor.Close();
                socketStream.Close();
                conexao.Close();
            }
        }

        private static Guid GerarGuid()
        {
            return Guid.Parse(Guid.NewGuid().ToString("B"));
        }
    }
}
