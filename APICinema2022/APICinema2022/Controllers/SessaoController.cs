using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessaoController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<SessaoDTO>> listar()
        {
            var model = new SessaoModels();

            return model.listarTodos();
        }

        [HttpGet]
        [Route("listarPorSala")]
        public RetornoDTO<List<SessaoDTO>> listarPorSala(int id)
        {
            var model = new SessaoModels();

            return model.listarPorSala(id);
        }

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<SessaoDTO> Get(int id)
        {
            var model = new SessaoModels();

            return model.recuperar(id);
        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(SessaoDTO obj)
        {
            var model = new SessaoModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new SessaoModels();

            return model.deletar(id);

        }

        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(SessaoDTO obj)
        {
            var model = new SessaoModels();

            return model.alterar(obj);
        }

        [HttpPost]
        [Route("alterarStatus")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> PostStatus(int id)
        {
            var model = new SessaoModels();

            return model.alterarStatus(id);
        }
    }
}
