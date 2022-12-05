using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<AvaliacaoDTO> Get(int id)
        {
            var model = new AvaliacaoModels();

            return model.recuperar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<AvaliacaoDTO>> listar()
        {
            var model = new AvaliacaoModels();

            return model.listar();
        }

        [HttpPut]
        [Route("salvar")]
        public RetornoDTO<bool> Put(AvaliacaoDTO obj)
        {
            var model = new AvaliacaoModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new AvaliacaoModels();

            return model.deletar(id);

        }


        [HttpPost]
        [Route("alterar")]
        public RetornoDTO<bool> Post(AvaliacaoDTO obj)
        {
            var model = new AvaliacaoModels();

            return model.alterar(obj);
        }
    }
}
