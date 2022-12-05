using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public int IdPessoa { get; set; }
        public int IdSexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdUsuario { get; set; }

        public string Pessoa
        {
            get
            {
                string retornoPessoa = "";
                using (var dbcontext = new Context())
                {
                    var pessoa = dbcontext.Pessoas.Find(this.IdPessoa);
                    retornoPessoa = pessoa.Descricao;
                }
                return retornoPessoa;
            }
        }

        public string Sexo
        {
            get
            {
                string retornoSexo = "";
                using (var dbcontext = new Context())
                {
                    var sexo = dbcontext.Sexos.Find(this.IdSexo);
                    retornoSexo = sexo.Descricao;
                }
                return retornoSexo;
            }
        }

        public string Papel
        {
            get
            {
                string retornoPapel = "";
                using (var dbcontext = new Context())
                {
                    var usuario = dbcontext.Usuarios.Find(this.IdUsuario);
                    retornoPapel = usuario.Papel;
                }
                return retornoPapel;
            }
        }

    }
}
