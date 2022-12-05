using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : ControllerBase
    {

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<SexoDTO> Get(int id)
        {
            var model = new SexoModels();

            return model.recuperar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<SexoDTO>> listar()
        {
            var model = new SexoModels();

            return model.listar();
        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(SexoDTO obj)
        {
            var model = new SexoModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new SexoModels();

            return model.deletar(id);

        }


        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(SexoDTO obj)
        {
            var model = new SexoModels();

            return model.alterar(obj);
        }
    }
}
