using GA.EntidadesComunicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GA.Aplicativo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UsuarioDTO usuarioLoagoAplicativo = new UsuarioDTO();
            UsuarioDTO usuarioForaAplicativo = new UsuarioDTO();
            
            // ler as propriedades do programa CMD/propriedades vs
            var formView = new MensagemForm();

            if (args.Length > 0)
            {
                usuarioLoagoAplicativo.Id = Convert.ToInt32(args[0]);
            }
            
            if (args.Length > 2)
            {
                usuarioLoagoAplicativo.Nome = args[1];
            }

            if (args.Length > 1)
            {
                usuarioForaAplicativo.Id = Convert.ToInt32(args[2]);
            }

            if (args.Length > 3)
            {
                usuarioForaAplicativo.Nome = args[3];
            }

            formView.Text = $"Mensagens Enviadas do Usuario: {usuarioLoagoAplicativo.Nome};" +
                $" para o Usurio: {usuarioForaAplicativo.Nome}";

            formView.UsuarioLogadoAplicativo = usuarioLoagoAplicativo;
            formView.UsuarioForaAplicativo = usuarioForaAplicativo;            
            Application.Run(formView);
        }
    }
}
