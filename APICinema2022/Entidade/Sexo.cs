using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Sexo
    {
        public Sexo()
        {
            Clientes = new HashSet<Cliente>();
            Funcionarios = new HashSet<Funcionario>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
