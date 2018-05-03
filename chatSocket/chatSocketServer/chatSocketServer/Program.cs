using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;

namespace chatSocketServer
{
    class Program
    {
        public static Thread TipoThread = null;
        static void Main(string[] args)
        {
            for (int i = 0; i < 2; i++)
            {
                TipoThread = new Thread(() => Servidor());

                TipoThread.Start();                
            }

            while (TipoThread.IsAlive)
            {
                Thread.Sleep(100);
            }
        }

        private static void Servidor()
        {
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("10.80.1.97");

            var server = new TcpListener(localAddr, port);

            server.Start();

            while (true)
            {
                var conexao = server.AcceptSocket();

                var socketStream = new NetworkStream(conexao);

                var escreve = new BinaryWriter(socketStream);
                var le = new BinaryReader(socketStream);

                var conteudo = "";

                do
                {
                    conteudo = le.ReadString();

                    var mensagemCliente = conteudo.Split('|');
                    var conteudoClienteEnvio = mensagemCliente[0].Split(';')[0];
                    var conteudoClienteReceber = mensagemCliente[0].Split(';')[1];
                    var conteudoTexto = mensagemCliente[0].Split(';')[2];

                    if (conteudoClienteReceber != conteudoClienteEnvio)
                    {
                        var respostaServidor = $"Cliente:{conteudoClienteReceber};Mensagens: mensagem 1 Mensagens:mensagem 2 Mensagens:mensagem 3 |";

                        escreve.Write(conteudoTexto);
                    }
                    else
                    {
                        escreve.Write("-1");
                    }                    
                } while (conexao.Connected);

                escreve.Close();
                le.Close();
                socketStream.Close();
                conexao.Close();
            }

            server.Stop();
        }
    }
}
