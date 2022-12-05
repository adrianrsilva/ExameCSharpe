using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class AvaliacaoDTO
    {
        public int Id { get; set; }
        public int IdFilme { get; set; }
        public int IdCliente { get; set; }
        public string Avaliacao1 { get; set; }
        public int TotalAvaliacao { get; set; }
    }
}
