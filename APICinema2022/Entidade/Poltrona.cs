using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Poltrona
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string Nome { get; set; }
        public int? IdSala { get; set; }

        public virtual Sala IdSalaNavigation { get; set; }
    }
}
