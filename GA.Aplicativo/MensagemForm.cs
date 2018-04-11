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
        public int UsuarioEnviar { get; set; }
        public string UsuarioNomeEnviar { get; set; }
        public int UsuarioReceber { get; set; }        
        public string UsuarioNomeReceber { get; set; }

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

            LblUsuarioEnvio.Text = $"{LblUsuarioEnvio.Text}: {UsuarioNomeEnviar}";
            LblUsuarioReceber.Text = $"{LblUsuarioReceber.Text}: {UsuarioNomeReceber}";
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtEnviar.Text))
            {
                return;
            }

            var mensagemEnviarDados = new EntidadesComunicacao.MensagemEnviar
            {
                ConteudoMensagem = TxtEnviar.Text,
                UsuarioEnviou = UsuarioEnviar,
                UsuarioRecebeu = UsuarioReceber
            };

            Task<List<MensagemDTO>> retornoWeb;
            retornoWeb = GA.Comunicacao.MensagemComunicacao.Enviar(mensagemEnviarDados);

            do
            {
                Thread.Sleep(100);
            } while (retornoWeb.IsCompleted);

            CarregarMensagensEnviadas(TxtEnviar.Text);
            CarregarMensagensRecebidas(retornoWeb.Result);
        }

        private void BtnReceber_Click(object sender, EventArgs e)
        {

        }

        private void CarregarMensagensRecebidas(List<MensagemDTO> mensagens)
        {
            foreach (var item in mensagens)
            {
                if (!(item.UsuarioEnviou.Id == UsuarioEnviar && item.UsuarioRecebeu.Id == UsuarioReceber))
                {
                    continue;
                }

                MensagensRecebidas.AppendLine(item.ConteudoMensagem);
            }
        }

        private void CarregarMensagensEnviadas(string novaMensagem)
        {
            MensagensEnviadas.AppendLine(novaMensagem);

            TxtEnviadas.Text = string.Empty;
            TxtEnviadas.Text = MensagensEnviadas.ToString();
        }
    }
}
