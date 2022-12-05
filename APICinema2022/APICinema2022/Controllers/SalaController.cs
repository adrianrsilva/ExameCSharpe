using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {


        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<SalaDTO>> listar()
        {
            var model = new SalaModels();

            return model.listar();
        }

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<SalaDTO> Get(int id)
        {
            var model = new SalaModels();

            return model.recuperar(id);
        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(SalaDTO obj)
        {
            var model = new SalaModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new SalaModels();

            return model.deletar(id);

        }

        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(SalaDTO obj)
        {
            var model = new SalaModels();

            return model.alterar(obj);
        }

        [HttpPost]
        [Route("alterarStatus")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> PostStatus(int id)
        {
            var model = new SalaModels();

            return model.alterarStatus(id);
        }
    }
}
