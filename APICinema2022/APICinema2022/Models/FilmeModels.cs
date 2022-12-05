using AutoMapper;
using Dados;
using Microsoft.AspNetCore.Hosting;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using ProjetoCinema2022.Models;
using Repositorio;
using System;
using System.Collections.Generic;
using System.IO;

namespace APICinema2022.Models
{
    public class FilmeModels
    {
        public RetornoDTO<FilmeDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<FilmeDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new FilmeRepositorio(contexto);

                    Filme objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new FilmeDTO
                        {
                            Id = objEntidade.Id,
                            DuracaoMinutos = objEntidade.DuracaoMinutos,
                            IdEmpresa = objEntidade.IdEmpresa,
                            Imagem = objEntidade.Imagem,
                            Nome = objEntidade.Nome,
                            Destaque = objEntidade.Destaque,
                            IdSala = objEntidade.IdSala,
                            Lancamento = objEntidade.Lancamento,
                            ValorIngresso = objEntidade.ValorIngresso,
                            Descricao = objEntidade.Descricao
                        };

                    }

                }

            }
            catch (Exception ex)
            {

                obj.Erro = ex.Message;

                obj.Status = false;

            }

            return obj;

        }

        public RetornoDTO<List<FilmeDTO>> listar()
        {

            var retorno = new RetornoDTO<List<FilmeDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new FilmeRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<FilmeDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }


        public RetornoDTO<bool> salvar(FilmeDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new FilmeRepositorio(contexto);

                        Filme objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Filme>(objDTO);

                        if (objDTO.Id == 0)
                        {
                            repositorio.adicionar(objEntidade);
                        }
                        else
                        {

                            repositorio.alterar(objEntidade);

                        }

                        contexto.SaveChanges();

                        retorno.Resultado = true;
                        retorno.Mensagem = "Salvo com sucesso!";

                    }

                }

            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao salvar Filme.";
                retorno.Status = false;
                retorno.Resultado = false;

            }

            return retorno;

        }

        public RetornoDTO<bool> deletar(int id)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new FilmeRepositorio(contexto);

                    var objEntidade = repositorio.recuperar(f => f.Id == id);

                    repositorio.deletar(objEntidade);

                    contexto.SaveChanges();

                    retorno.Resultado = true;

                    retorno.Mensagem = "Deletado com sucesso!!";

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao deletar Filme";

            }

            return retorno;

        }

        public string salvarImagem(FileUploadModels files, IWebHostEnvironment _environment)
        {
            if (files.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.ContentRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + "\\uploads\\");
                    }

                    var nomeArq = files.files.FileName.Split('.');

                    var novoNomeArquivo = Guid.NewGuid() + "." + nomeArq[nomeArq.Length - 1];

                    using (FileStream filestream = System.IO.File.Create(_environment.ContentRootPath +
                        "\\uploads\\" + novoNomeArquivo))
                    {
                        files.files.CopyTo(filestream);
                        filestream.Flush();
                        return novoNomeArquivo;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }

        public RetornoDTO<List<FilmeDTO>> listarLancamento()
        {
            var lista = new RetornoDTO<List<FilmeDTO>>();

            lista.Status = true;

            try
            {
                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new FilmeRepositorio(contexto);

                    var ListaEntidade = repositorio.listar(f => f.Lancamento == true);

                    lista.Resultado = mapper.Map<List<FilmeDTO>>(ListaEntidade);

                }
            }
            catch (Exception ex)
            {
                lista.Erro = ex.Message;

                lista.Status = false;
            }



            return lista;
        }

        public RetornoDTO<List<FilmeDTO>> recuperarFilmes(int idFilme)
        {
            var lista = new RetornoDTO<List<FilmeDTO>>();

            lista.Status = true;

            try
            {
                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new FilmeRepositorio(contexto);

                    var ListaEntidade = repositorio.listar(f => f.Id == idFilme);

                    lista.Resultado = mapper.Map<List<FilmeDTO>>(ListaEntidade);

                }
            }
            catch (Exception ex)
            {
                lista.Erro = ex.Message;

                lista.Status = false;
            }



            return lista;
        }

    }
}
