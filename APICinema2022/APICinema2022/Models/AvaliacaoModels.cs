using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class AvaliacaoModels
    {
        public RetornoDTO<AvaliacaoDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<AvaliacaoDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new AvaliacaoRepositorio(contexto);

                    Avaliacao objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new AvaliacaoDTO
                        {
                            Id = objEntidade.Id,
                            Avaliacao1 = objEntidade.Avaliacao1,
                            TotalAvaliacao = objEntidade.TotalAvaliacao,
                            IdCliente = objEntidade.IdCliente,
                            IdFilme = objEntidade.IdFilme


                        };

                    }
                    else
                    {
                        obj.Resultado = null;
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

        public RetornoDTO<List<AvaliacaoDTO>> listar()
        {

            var retorno = new RetornoDTO<List<AvaliacaoDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new AvaliacaoRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<AvaliacaoDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<bool> salvar(AvaliacaoDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new AvaliacaoRepositorio(contexto);

                        Avaliacao objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Avaliacao>(objDTO);

                        if (objDTO.Id == 0)
                        {
                            repositorio.adicionar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Salvo com sucesso!";
                        }
                        else
                        {
                            retorno.Status = false;
                            retorno.Resultado = false;
                            retorno.Mensagem = "Falha ao salvar!";

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao salvar Avaliação.";
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

                    var repositorio = new AvaliacaoRepositorio(contexto);

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
                retorno.Mensagem = "Erro ao deletar Avaliação";

            }

            return retorno;

        }

        public RetornoDTO<bool> alterar(AvaliacaoDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new AvaliacaoRepositorio(contexto);

                        Avaliacao objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Avaliacao>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Avaliação Alterado com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Avaliação não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Avaliação.";
                retorno.Status = false;
                retorno.Resultado = false;
            }

            return retorno;
        }
    }
}
