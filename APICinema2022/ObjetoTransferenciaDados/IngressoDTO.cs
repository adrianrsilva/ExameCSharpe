using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class IngressoDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public int Quantidade { get; set; }
        public int Sessao { get; set; }
        public int Sala { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
