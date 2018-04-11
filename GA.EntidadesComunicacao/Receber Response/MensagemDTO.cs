namespace GA.EntidadesComunicacao
{
    public class MensagemDTO
    {
        public int Id { get; set; }
        public UsuarioDTO UsuarioRecebeu { get; set; }
        public UsuarioDTO UsuarioEnviou { get; set; }
        public string ConteudoMensagem { get; set; }
    }
}