using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<ClienteDTO> Get(int id)
        {
            var model = new ClienteModels();

            return model.recuperar(id);
        }

        [HttpGet]
        [Route("recuperarEmail")]
        public RetornoDTO<ClienteDTO> GetEmail(string email)
        {
            var model = new ClienteModels();

            return model.recuperarEmail(email);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<ClienteDTO>> listar()
        {
            var model = new ClienteModels();

            return model.listar();
        }

        [HttpPut]
        [Route("salvar")]
        public RetornoDTO<bool> Put(ClienteDTO obj)
        {
            var model = new ClienteModels();

            return model.salvar(obj);
        }


        [HttpDelete]
        [Route("deletar")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new ClienteModels();

            return model.deletar(id);

        }

        [HttpPost]
        [Route("alterar")]
        public RetornoDTO<bool> Post(ClienteDTO obj)
        {
            var model = new ClienteModels();

            return model.alterar(obj);
        }

        [HttpPost]
        [Route("alterarStatus")]
        public RetornoDTO<bool> PostStatus(int id)
        {
            var model = new ClienteModels();

            return model.alterarStatus(id);
        }
    }
}
