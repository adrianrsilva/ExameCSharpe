using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class SalaModels
    {
        public RetornoDTO<List<SalaDTO>> listar()
        {

            var retorno = new RetornoDTO<List<SalaDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new SalaRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<SalaDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<SalaDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<SalaDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new SalaRepositorio(contexto);

                    Sala objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new SalaDTO
                        {
                            Id = objEntidade.Id,
                            Ativo = objEntidade.Ativo,
                            Nome = objEntidade.Nome,
                            

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

                    var repositorio = new SalaRepositorio(contexto);

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

        public RetornoDTO<bool> alterar(SalaDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new SalaRepositorio(contexto);

                        Sala objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Sala>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Sala Alterada com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Sala não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Sala.";
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

                    var repositorio = new SalaRepositorio(contexto);
                    var objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (id != 0 && objEntidade != null)
                    {

                        if (objEntidade.Ativo != false)
                        {
                            objEntidade.Ativo = false;
                            retorno.Mensagem = "Sala inativada com Sucesso!";
                        }
                        else
                        {
                            objEntidade.Ativo = true;
                            retorno.Mensagem = "Sala ativada com Sucesso!";
                        }

                        repositorio.alterar(objEntidade);

                        contexto.SaveChanges();

                        retorno.Resultado = true;

                    }
                    else
                    {
                        retorno.Status = false;
                        retorno.Mensagem = "Erro ao desativar Sala: Inexistente!!";
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

        public RetornoDTO<bool> salvar(SalaDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new SalaRepositorio(contexto);

                        Sala objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Sala>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar Sala.";
                retorno.Status = false;
                retorno.Resultado = false;

            }

            return retorno;

        }

    }
}
