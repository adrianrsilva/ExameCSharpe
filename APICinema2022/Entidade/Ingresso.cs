using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Ingresso
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public int Quantidade { get; set; }
        public int Sessao { get; set; }
        public int Sala { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Filme IdFilmeNavigation { get; set; }
    }
}
