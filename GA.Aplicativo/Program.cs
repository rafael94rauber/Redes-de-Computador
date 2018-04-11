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

            // ler as propriedades do programa CMD/propriedades vs
            var formView = new MensagemForm();
            if (args.Length > 0)
            {
                formView.UsuarioEnviar = Convert.ToInt32(args[0]);
            }
            
            if (args.Length > 2)
            {
                formView.UsuarioNomeEnviar = args[1];
            }

            if (args.Length > 1)
            {
                formView.UsuarioReceber = Convert.ToInt32(args[2]);
            }

            if (args.Length > 3)
            {
                formView.UsuarioNomeReceber = args[3];
            }

            formView.Text = $"Usuario: {formView.UsuarioNomeEnviar}";
            
            Application.Run(formView);
        }
    }
}
