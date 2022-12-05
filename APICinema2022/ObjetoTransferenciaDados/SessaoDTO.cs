using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class SessaoDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public bool Ativo { get; set; }
        public int? IdSala { get; set; }

        public string NomeSala
        {
            get
            {
                string retornoSessao = "";
                using (var dbcontext = new Context())
                {
                    var sala = dbcontext.Salas.Find(this.IdSala);
                    retornoSessao = sala.Nome;
                }
                return retornoSessao.ToString();
            }
        }
    }
}
