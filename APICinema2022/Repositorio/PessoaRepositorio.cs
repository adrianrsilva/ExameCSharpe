using Dados;

namespace Repositorio
{
    public class PessoaRepositorio : BaseRepositorio<Pessoa>
    {

        public PessoaRepositorio(Context contexto)
            : base(contexto)
        {

        }
    }
}
