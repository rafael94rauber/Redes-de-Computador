namespace GA.WebAPI.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public Usuario UsuarioRecebeu { get; set; }
        public Usuario UsuarioEnviou { get; set; }
        public string ConteudoMensagem { get; set; }
    }
}