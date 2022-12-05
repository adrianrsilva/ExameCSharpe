using Dados;

namespace Repositorio
{
    public class FuncionarioRepositorio : BaseRepositorio<Funcionario>
    {
        public FuncionarioRepositorio(Context contexto)
            : base(contexto)
        {

        }
    }
}
