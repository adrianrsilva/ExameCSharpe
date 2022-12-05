using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngressoController : ControllerBase
    {
        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<IngressoDTO> Get(int id)
        {
            var model = new IngressoModels();

            return model.recuperar(id);
        }


        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<IngressoDTO>> listar()
        {
            var model = new IngressoModels();

            return model.listar();
        }

        [HttpPut]
        [Route("salvar")]
        public RetornoDTO<bool> Put(IngressoDTO obj)
        {
            var model = new IngressoModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new IngressoModels();

            return model.deletar(id);

        }

        [HttpPost]
        [Route("alterar")]
        public RetornoDTO<bool> Post(IngressoDTO obj)
        {
            var model = new IngressoModels();

            return model.alterar(obj);
        }

        [HttpGet]
        [Route("recuperarIngressoCliente")]
        [Authorize(Roles = "Cliente")]
        public RetornoDTO<List<IngressoDTO>> GetIngressoCliente(int idCliente)
        {
            var model = new IngressoModels();

            return model.recuperarIngresso(idCliente);
        }

    }
}
