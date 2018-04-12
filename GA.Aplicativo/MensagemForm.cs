using GA.EntidadesComunicacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA.Aplicativo
{
    public partial class MensagemForm : Form
    {
        public UsuarioDTO UsuarioLogadoAplicativo;
        public UsuarioDTO UsuarioForaAplicativo;

        private StringBuilder MensagensEnviadas = new StringBuilder();
        private StringBuilder MensagensRecebidas = new StringBuilder();

        public MensagemForm()
        {
            InitializeComponent();
        }

        private void MensagemForm_Load(object sender, EventArgs e)
        {
            MensagensEnviadas = new StringBuilder();
            MensagensRecebidas = new StringBuilder();

            LblUsuarioEnvio.Text = $"{LblUsuarioEnvio.Text}: {UsuarioLogadoAplicativo.Nome}";
            LblUsuarioReceber.Text = $"{LblUsuarioReceber.Text}: {UsuarioForaAplicativo.Nome}";
            lblEnviar.Text = $"De: {UsuarioLogadoAplicativo.Nome} Para: {UsuarioForaAplicativo.Nome}";
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtEnviar.Text))
            {
                return;
            }

            var mensagemEnviarDados = new MensagemEnviar
            {
                ConteudoMensagem = TxtEnviar.Text,
                UsuarioEnviou = UsuarioLogadoAplicativo.Id,
                UsuarioRecebeu = UsuarioForaAplicativo.Id
            };

            var retornoWeb = Enviar(mensagemEnviarDados);
        }

        private void BtnReceber_Click(object sender, EventArgs e)
        {
            var mensagemReceberDados = new MensagemReceber
            {
                UsuarioEnviou = UsuarioLogadoAplicativo.Id,
                UsuarioRecebeu = UsuarioForaAplicativo.Id
            };

            var retornoWeb = Receber(mensagemReceberDados);
        }

        private async Task Enviar(MensagemEnviar mensagemEnviarDados)
        {
            var retornoWeb = new Comunicacao.MensagemComunicacao().Enviar(mensagemEnviarDados);

            await Task.WhenAll(retornoWeb);

            MensagensEnviadas.Clear();
            TxtEnviadas.Text = string.Empty;

            MensagensRecebidas.Clear();
            TxtRecebidas.Text = string.Empty;
            
            TxtEnviar.Text = string.Empty;

            CarregarMensagensEnviadas(retornoWeb.Result);
            CarregarMensagensRecebidas(retornoWeb.Result);
        }

        private async Task Receber(MensagemReceber mensagemEnviarDados)
        {
            var retornoWeb = new Comunicacao.MensagemComunicacao().Receber(mensagemEnviarDados);

            await Task.WhenAll(retornoWeb);

            MensagensRecebidas.Clear();
            TxtRecebidas.Text = string.Empty;

            CarregarMensagensRecebidas(retornoWeb.Result);
        }

        private void CarregarMensagensEnviadas(List<MensagemDTO> mensagens)
        {
            foreach (var item in mensagens)
            {
                if (!(item.UsuarioEnviou.Id == UsuarioLogadoAplicativo.Id && item.UsuarioRecebeu.Id == UsuarioForaAplicativo.Id))
                {
                    continue;
                }

                MensagensEnviadas.AppendLine(item.ConteudoMensagem);
            }                        

            TxtEnviadas.Text = MensagensEnviadas.ToString();            
        }

        private void CarregarMensagensRecebidas(List<MensagemDTO> mensagens)
        {
            foreach (var item in mensagens)
            {
                if (!(item.UsuarioEnviou.Id == UsuarioLogadoAplicativo.Id && item.UsuarioRecebeu.Id == UsuarioForaAplicativo.Id))
                {
                    continue;
                }

                MensagensRecebidas.AppendLine(item.ConteudoMensagem);
            }

            TxtRecebidas.Text = MensagensRecebidas.ToString();
        }
    }
}
