using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class SessaoModels
    {
        public RetornoDTO<List<SessaoDTO>> listarTodos()
        {

            var retorno = new RetornoDTO<List<SessaoDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new SessaoRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<SessaoDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<List<SessaoDTO>> listarPorSala(int id)
        {
            var lista = new RetornoDTO<List<SessaoDTO>>();

            lista.Status = true;

            try
            {
                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorioSessao = new SessaoRepositorio(contexto);
                    var repositorioSala = new SalaRepositorio(contexto);
                    var sala = repositorioSala.recuperar(f => f.Id == id);
                    var ListaEntidade = repositorioSessao.listar(f => f.IdSala == sala.Id);

                    lista.Resultado = mapper.Map<List<SessaoDTO>>(ListaEntidade);

                }
            }
            catch (Exception ex)
            {
                lista.Erro = ex.Message;

                lista.Status = false;
            }



            return lista;
        }



        public RetornoDTO<SessaoDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<SessaoDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new SessaoRepositorio(contexto);

                    Sessao objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new SessaoDTO
                        {
                            Id = objEntidade.Id,
                            Ativo = objEntidade.Ativo,
                            Data = objEntidade.Data,
                            Horario = objEntidade.Horario,
                            IdSala = objEntidade.IdSala

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

                    var repositorio = new SessaoRepositorio(contexto);

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
                retorno.Mensagem = "Erro ao deletar Sessão";

            }

            return retorno;

        }

        public RetornoDTO<bool> alterar(SessaoDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new SessaoRepositorio(contexto);

                        Sessao objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Sessao>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Sessão Alterada com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Sessão não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Sessão.";
                retorno.Status = false;
                retorno.Resultado = false;
            }

            return retorno;
        }

        public RetornoDTO<bool> alterarStatus(int id)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new SessaoRepositorio(contexto);
                    var objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (id != 0 && objEntidade != null)
                    {

                        if (objEntidade.Ativo != false)
                        {
                            objEntidade.Ativo = false;
                            retorno.Mensagem = "Sessão inativada com Sucesso!";
                        }
                        else
                        {
                            objEntidade.Ativo = true;
                            retorno.Mensagem = "Sessão ativada com Sucesso!";
                        }

                        repositorio.alterar(objEntidade);

                        contexto.SaveChanges();

                        retorno.Resultado = true;

                    }
                    else
                    {
                        retorno.Status = false;
                        retorno.Mensagem = "Erro ao desativar Sessão: Inexistente!!";
                    }
                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao desativar Sala";

            }

            return retorno;

        }

        public RetornoDTO<bool> salvar(SessaoDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new SessaoRepositorio(contexto);

                        Sessao objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Sessao>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar Sessão.";
                retorno.Status = false;
                retorno.Resultado = false;

            }

            return retorno;

        }
    }
}
