using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Sessao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public int? IdSala { get; set; }
        public bool Ativo { get; set; }

        public virtual Sala IdSalaNavigation { get; set; }
    }
}
