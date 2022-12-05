using Dados;
using APICinema2022.Models;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositorio;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("autenticar")]
        public ActionResult<dynamic> logar([FromBody] UsuarioDTO model)
        {
            var Papel = "";
            var Administrador = "";
            int id = 0;
            bool valido = false;

            string caminho = "";



            if (model.Hash == UsuarioDTO.obterHashCliente())
            {

                using (var contexto = new Context())
                {
                    var repositorio = new ClienteRepositorio(contexto);
                    Cliente cliente = repositorio.recuperar(f => f.Email == model.Email && f.Senha == model.Senha);
                    if (cliente != null && cliente.Ativo == true)
                    {
                        valido = cliente.Email == model.Email && cliente.Senha == model.Senha;
                        id = cliente.Id;
                    }

                }

                if (valido)
                {
                    Papel = model.Papel = "Cliente";
                    model.Administrador = false;
                    caminho = "../Login/HomeLogin";
                    return Ok(new
                    {
                        Papel = Papel,
                        Administrador = Administrador,
                        status = true,
                        mensagem = "",
                        token = Seguranca.gerarToken(model),
                        caminho = caminho,
                        idCliente = id
                    });

                }
                else
                {
                    return Unauthorized(new { status = false, mensagem = "Acesso negado" });
                }


            }
            else
            {

                if (model.Hash == UsuarioDTO.obterHashFuncionario())
                {
                    using (var contexto = new Context())
                    {
                        var repositorio = new FuncionarioRepositorio(contexto);
                        Funcionario funcionario = repositorio.recuperar(f => f.Email == model.Email && f.Senha == model.Senha);
                        if (funcionario != null)
                        {
                            valido = funcionario.Email == model.Email && funcionario.Senha == model.Senha;
                            id = funcionario.Id;
                        }
                    }

                    if (valido)
                    {
                        model.Papel = "Funcionario";
                        model.Administrador = true;
                        caminho = "../Cadastro/CadastroFuncionario";
                        return Ok(new
                        {
                            status = true,
                            mensagem = "",
                            token = Seguranca.gerarToken(model),
                            caminho = caminho,
                            idFuncionario = id
                        });
                    }
                    else
                    {
                        return Unauthorized(new { status = false, mensagem = "Acesso negado" });
                    }



                }

            }
            return Unauthorized(new { status = false, mensagem = "Acesso negado" });
        }
    }
}
