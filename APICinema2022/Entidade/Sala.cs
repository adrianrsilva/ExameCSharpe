using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Sala
    {
        public Sala()
        {
            Poltronas = new HashSet<Poltrona>();
            Sessaos = new HashSet<Sessao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Poltrona> Poltronas { get; set; }
        public virtual ICollection<Sessao> Sessaos { get; set; }
    }
}
