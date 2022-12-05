using Dados;

namespace Repositorio
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>
    {
        public ClienteRepositorio(Context contexto)
            : base(contexto)
        {

        }
    }
}
