using Dados;

namespace ObjetoTransferenciaDados
{
    public class UsuarioDTO
    {
        private const string CHAVE_CLIENTE = "f013197e-9e2e-4ec7-8c89-4763d6a50e1e";
        private const string CHAVE_FUNCIONARIO = "f0122197e-9e2e-7ec7-8c79-4723d6a60r1e";
        public int Id { get; set; }
        public string Papel { get; set; }
        public bool Administrador { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
      
        public string Senha { get; set; }
      
        public static string obterHashCliente()
        {
            return CHAVE_CLIENTE;
        }
        public static string obterHashFuncionario()
        {
            return CHAVE_FUNCIONARIO;
        }
    }
}
