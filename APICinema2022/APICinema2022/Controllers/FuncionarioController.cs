using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpGet]
        [Route("recuperar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<FuncionarioDTO> Get(int id)
        {
            var model = new FuncionarioModels();

            return model.recuperar(id);
        }

        [HttpGet]
        [Route("recuperarEmail")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<FuncionarioDTO> GetEmail(string email)
        {
            var model = new FuncionarioModels();

            return model.recuperarEmail(email);
        }

        [HttpGet]
        [Route("listar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<List<FuncionarioDTO>> listar()
        {
            var model = new FuncionarioModels();

            return model.listar();
        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(FuncionarioDTO obj)
        {
            var model = new FuncionarioModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new FuncionarioModels();

            return model.deletar(id);

        }

        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(FuncionarioDTO obj)
        {
            var model = new FuncionarioModels();

            return model.alterar(obj);
        }
    }
}
