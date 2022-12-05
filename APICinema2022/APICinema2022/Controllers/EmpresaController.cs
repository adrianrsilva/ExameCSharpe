using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using System.Collections.Generic;

namespace APICinema2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {


        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<EmpresaDTO>> listar()
        {
            var model = new EmpresaModels();

            return model.listar();
        }

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<EmpresaDTO> Get(int id)
        {
            var model = new EmpresaModels();

            return model.recuperar(id);
        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(EmpresaDTO obj)
        {
            var model = new EmpresaModels();

            return model.salvar(obj);
        }

        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(EmpresaDTO obj)
        {
            var model = new EmpresaModels();

            return model.alterar(obj);
        }

        [HttpPost]
        [Route("alterarStatus")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> PostStatus(int id)
        {
            var model = new EmpresaModels();

            return model.alterarStatus(id);
        }
    }
}
