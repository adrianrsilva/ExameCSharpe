using APICinema2022.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using ProjetoCinema2022.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace APICinema2022.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IWebHostEnvironment hostEnvironment;

        public FilmeController(IWebHostEnvironment environment)
        {
            hostEnvironment = environment;
        }

        [HttpPost]
        [Route("alterar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Post(FilmeDTO obj)
        {

            var model = new FilmeModels();

            return model.salvar(obj);

        }

        [HttpGet]
        [Route("recuperar")]
        public RetornoDTO<FilmeDTO> Get(int id)
        {

            var model = new FilmeModels();

            return model.recuperar(id);

        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<FilmeDTO>> Listar()
        {

            var model = new FilmeModels();

            return model.listar();

        }

        [HttpPut]
        [Route("salvar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Put(FilmeDTO obj)
        {

            var model = new FilmeModels();

            return model.salvar(obj);

        }

        [HttpDelete]
        [Route("deletar")]
        [Authorize(Roles = "Funcionario")]
        public RetornoDTO<bool> Delete(int id)
        {

            var model = new FilmeModels();

            return model.deletar(id);

        }

        [HttpPost]
        [Route("upload")]
        public string Upload([FromForm] FileUploadModels files)
        {
            var model = new FilmeModels();

            return model.salvarImagem(files, hostEnvironment);
        }

        [HttpGet]
        [Route("obterImagem")]
        public IActionResult ObterImagem(string arquivo)
        {
            var urlImagem = @"/uploads/" + arquivo;

            Byte[] fileImagem = System.IO.File
                .ReadAllBytes(@Directory.GetCurrentDirectory() + urlImagem);

            return File(fileImagem, "image/jpeg");
        }

        [HttpGet]
        [Route("lancamento")]
        public RetornoDTO<List<FilmeDTO>> ListarLancamento()
        {
            var model = new FilmeModels();

            return model.listarLancamento();

        }

        [HttpGet]
        [Route("recuperarFilmeIngresso")]
        public RetornoDTO<List<FilmeDTO>> GetIngressoFilme(int idFilme)
        {
            var model = new FilmeModels();

            return model.recuperarFilmes(idFilme);
        }

    }
}
