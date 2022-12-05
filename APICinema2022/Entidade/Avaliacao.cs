using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Avaliacao
    {
        public int Id { get; set; }
        public int IdFilme { get; set; }
        public int IdCliente { get; set; }
        public string Avaliacao1 { get; set; }
        public int TotalAvaliacao { get; set; }
    }
}
