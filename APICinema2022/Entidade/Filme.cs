using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Filme
    {
        public Filme()
        {
            Ingressos = new HashSet<Ingresso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdEmpresa { get; set; }
        public int DuracaoMinutos { get; set; }
        public decimal ValorIngresso { get; set; }
        public bool Lancamento { get; set; }
        public string Imagem { get; set; }
        public bool Destaque { get; set; }
        public int IdSala { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Ingresso> Ingressos { get; set; }
    }
}
