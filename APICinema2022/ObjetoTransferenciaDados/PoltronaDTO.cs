using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class PoltronaDTO
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string Nome { get; set; }
        public int? IdSala { get; set; }

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
                return retornoSala;
            }
        }
    }
}
