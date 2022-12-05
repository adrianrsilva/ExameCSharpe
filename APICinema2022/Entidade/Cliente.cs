using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public int IdUsuario { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdSexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
        public virtual Sexo IdSexoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
