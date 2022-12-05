using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class IngressoModels
    {
        public RetornoDTO<List<IngressoDTO>> listar()
        {

            var retorno = new RetornoDTO<List<IngressoDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new IngressoRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<IngressoDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<IngressoDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<IngressoDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {
                    //var repositorioFilme = new FilmeRepositorio(contexto);
                    var repositorio = new IngressoRepositorio(contexto);
                    //Filme objEntidadeFilme = repositorioFilme.recuperar(f => f.Id == id);
                    Ingresso objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new IngressoDTO
                        {
                            Id = objEntidade.Id,
                            IdCliente = objEntidade.IdCliente,
                            IdFilme = objEntidade.IdFilme,
                            Quantidade = objEntidade.Quantidade,
                            ValorTotal = objEntidade.ValorTotal,
                            Sala = objEntidade.Sala,
                            Sessao = objEntidade.Sessao


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

        public RetornoDTO<bool> deletar(int id)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new IngressoRepositorio(contexto);

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
                retorno.Mensagem = "Erro ao deletar Sala";

            }

            return retorno;

        }

        public RetornoDTO<bool> alterar(IngressoDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new IngressoRepositorio(contexto);

                        Ingresso objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Ingresso>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Ingresso Alterada com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Ingresso não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Ingresso.";
                retorno.Status = false;
                retorno.Resultado = false;
            }

            return retorno;
        }

        public RetornoDTO<List<IngressoDTO>> recuperarIngresso(int idCliente)
        {
            var lista = new RetornoDTO<List<IngressoDTO>>();

            lista.Status = true;

            try
            {
                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new IngressoRepositorio(contexto);

                    var ListaEntidade = repositorio.listar(f => f.IdCliente == idCliente);

                    lista.Resultado = mapper.Map<List<IngressoDTO>>(ListaEntidade);

                }
            }
            catch (Exception ex)
            {
                lista.Erro = ex.Message;

                lista.Status = false;
            }



            return lista;
        }

        public RetornoDTO<bool> salvar(IngressoDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new IngressoRepositorio(contexto);

                        Ingresso objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Ingresso>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar Ingresso.";
                retorno.Status = false;
                retorno.Resultado = false;

            }

            return retorno;

        }

    }


}