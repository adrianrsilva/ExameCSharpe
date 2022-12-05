using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<PessoaDTO> Get(int id)
        {
            var model = new PessoaModels();

            return model.recuperar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<PessoaDTO>> listar()
        {
            var model = new PessoaModels();

            return model.listar();
        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(PessoaDTO obj)
        {
            var model = new PessoaModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new PessoaModels();

            return model.deletar(id);

        }


        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(PessoaDTO obj)
        {
            var model = new PessoaModels();

            return model.alterar(obj);
        }
    }
}
