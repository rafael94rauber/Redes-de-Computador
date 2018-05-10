using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace chatSocketClient
{
    public class Cliente
    {
        public const string IP_SERVIDOR = "10.80.1.97";
        public const Int32 PORTA_SERVIDOR = 13000;
        public BinaryWriter enviaServidor;
        public BinaryReader recebeServidor;

        public void ExecutarCliente(string NomeClienteEnvia, string NomeClienteRecebe)
        {
            var servidorLigado = false;
            var contaTentativas = 0;

            IPAddress localAddr = IPAddress.Parse(IP_SERVIDOR);
            TcpClient client = new TcpClient();
            IPEndPoint serverLocation = new IPEndPoint(localAddr, PORTA_SERVIDOR);

            while (!servidorLigado)
            {
                try
                {
                    client.Connect(serverLocation);
                    servidorLigado = true;
                }
                catch (SocketException)
                {
                    contaTentativas += 1;
                    Console.WriteLine("Servidor esta desligado");

                    if (contaTentativas == 10)
                    {
                        client.Close();
                        return;
                    }
                    // Aguardar 2 segundos o servidor ser iniciado
                    System.Threading.Thread.Sleep(2000);
                }
            }


            StringBuilder todasMensagens = new StringBuilder();
            var pararCliente = false;            
            var conexaoClienteServidor = client.GetStream();
            enviaServidor = new BinaryWriter(conexaoClienteServidor);
            recebeServidor = new BinaryReader(conexaoClienteServidor);
            
            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Usuario(De): {NomeClienteEnvia} <---PARA---> Usuario(para): {NomeClienteRecebe}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();
                Console.Write("Mensagem: ");                
                var conteudoMensagem = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(conteudoMensagem))
                {
                    // 60 segundos esperando o outro cliente enviar uma resposata
                    // depois o cliente atual manda uma nova mensagem
                    Thread.Sleep(10000);
                    continue;
                }

                EnvioCliente envioCliente = new EnvioCliente()
                {
                    SomenteListarTodasMensagens = false,
                    DesligarCliente = false,                    
                    Mensagem = conteudoMensagem,
                    NomeClienteEnvia = NomeClienteEnvia,
                    NomeClienteRecebe = NomeClienteRecebe
                };

                var respostaServidor = EnviarParaServidor(envioCliente);

                if (respostaServidor.PararCliente)
                {
                    pararCliente = true;
                    continue;
                }

                pararCliente = EscreverMensagemTela(respostaServidor.ConteudoServidor, NomeClienteEnvia);

                Console.WriteLine("Enviar Mensagem: SIM(1) ou NAO(2)");
                var opcaoUsario = Console.ReadLine();

                if (opcaoUsario.Equals("2") || opcaoUsario.ToUpper().Equals("NAO"))
                {
                    Console.Clear();
                    Console.WriteLine("Listar Mensagem do Servidor: SIM(1) ou NAO(2)");
                    opcaoUsario = Console.ReadLine();

                    if (opcaoUsario.Equals("1") || opcaoUsario.ToUpper().Equals("SIM"))
                    {
                        envioCliente = new EnvioCliente()
                        {
                            SomenteListarTodasMensagens = true,
                            DesligarCliente = false,
                            Mensagem = null,
                            NomeClienteEnvia = NomeClienteEnvia,
                            NomeClienteRecebe = NomeClienteRecebe
                        };

                        respostaServidor = EnviarParaServidor(envioCliente);

                        if (respostaServidor.PararCliente)
                        {
                            pararCliente = true;
                            continue;
                        }

                        pararCliente = EscreverMensagemTela(respostaServidor.ConteudoServidor, NomeClienteEnvia);                       
                    }

                    if (!pararCliente)
                    {
                        //aguarda 10 segundos
                        Thread.Sleep(10000);
                    }
                }
            } while (!pararCliente);

            enviaServidor.Close();
            recebeServidor.Close();
            conexaoClienteServidor.Close();
            client.Close();
        }

        private bool EscreverMensagemTela(List<EnvioCliente> conteudoServidor, string NomeClienteEnvia)
        {
            var pararCliente = false;
            //escreve as mensagens recebidas na tela do cliente
            StringBuilder mensagemTela = new StringBuilder();
            mensagemTela.AppendLine($"Mensagens Recebidas do Servidor:{conteudoServidor.Count}");
            mensagemTela.AppendLine("--------------------BLOCO DE MENSAGENS--------------------");

            var verificaMensagemRecebidas = false;

            foreach (var item in conteudoServidor)
            {
                pararCliente = item.DesligarCliente;
                if (pararCliente)
                {
                    break;
                }

                if (NomeClienteEnvia == item.NomeClienteEnvia)
                {
                    verificaMensagemRecebidas = true;
                    continue;
                }

                mensagemTela.AppendLine("");
                mensagemTela.AppendLine($"Usuario(De): {item.NomeClienteEnvia} <---PARA---> Usuario(para): {item.NomeClienteRecebe}");
                mensagemTela.AppendLine($"Mensagem: {item.Mensagem}");
                mensagemTela.AppendLine("");

                verificaMensagemRecebidas = false;
            }

            if (verificaMensagemRecebidas)
            {
                mensagemTela.AppendLine("");
                mensagemTela.AppendLine("--------------------VOCE NAO TEM MENSAGENS PARA RECEBER DO SERVIDOR--------------------");
                mensagemTela.AppendLine("");
            }

            mensagemTela.AppendLine("--------------------BLOCO DE MENSAGENS--------------------");
            Console.WriteLine(mensagemTela.ToString());

            return pararCliente;
        }

        private RespostaServidor EnviarParaServidor(EnvioCliente envioCliente)
        {
            RespostaServidor retornoServidor = new RespostaServidor();
            // manda para o servidor
            var montaEnvioServidor = JsonConvert.SerializeObject(envioCliente);
            enviaServidor.Write(montaEnvioServidor);

            // resposta do servidor
            var messageRespostaServidor = recebeServidor.ReadString();
            if (string.IsNullOrEmpty(messageRespostaServidor))
            {
                retornoServidor.PararCliente = true;
                retornoServidor.ConteudoServidor = null;
                return retornoServidor;
            }

            var conteudoServidor = JsonConvert.DeserializeObject<List<EnvioCliente>>(messageRespostaServidor);

            if (conteudoServidor is null)
            {
                retornoServidor.PararCliente = true;
                retornoServidor.ConteudoServidor = null;
                return retornoServidor;
            }

            retornoServidor.PararCliente = false;
            retornoServidor.ConteudoServidor = conteudoServidor;
            return retornoServidor;
        }
    }
}
