using Dados;

namespace ObjetoTransferenciaDados
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdEmpresa { get; set; }
        public int DuracaoMinutos { get; set; }
        public decimal ValorIngresso { get; set; }
        public bool Lancamento { get; set; }
        public string Imagem { get; set; }
        public bool Destaque { get; set; }
        public int IdSala { get; set; }

        public string NomeEmpresa
        {
            get
            {
                string retorno = "";
                using (var dbcontext = new Context())
                {
                    var empresa = dbcontext.Empresas.Find(this.IdEmpresa);
                    retorno = empresa.Nome;
                }
                return retorno;
            }
        }

        public string NomeSala
        {
            get
            {
                string retornoSala = "";
                using (var dbcontext = new Context())
                {
                    var sala = dbcontext.Salas.Find(this.IdSala);
                    retornoSala = sala.Nome;
                }
                return retornoSala.ToString();
            }
        }

       
    }
}
