using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
            Funcionarios = new HashSet<Funcionario>();
        }

        public int Id { get; set; }
        public string Papel { get; set; }
        public bool Administrador { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
