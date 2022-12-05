using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoltronaController : ControllerBase
    {

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<PoltronaDTO> Get(int id)
        {
            var model = new PoltronaModels();

            return model.recuperar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<PoltronaDTO>> listar()
        {
            var model = new PoltronaModels();

            return model.listar();
        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(PoltronaDTO obj)
        {
            var model = new PoltronaModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new PoltronaModels();

            return model.deletar(id);

        }


        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(PoltronaDTO obj)
        {
            var model = new PoltronaModels();

            return model.alterar(obj);
        }
    }
}
