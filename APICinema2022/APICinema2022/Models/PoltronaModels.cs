﻿using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class PoltronaModels
    {

        public RetornoDTO<PoltronaDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<PoltronaDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new PoltronaRepositorio(contexto);

                    Poltrona objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new PoltronaDTO
                        {
                            Id = objEntidade.Id,
                            IdSala = objEntidade.IdSala,
                            Nome = objEntidade.Nome,
                            Quantidade = objEntidade.Quantidade


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

        public RetornoDTO<List<PoltronaDTO>> listar()
        {

            var retorno = new RetornoDTO<List<PoltronaDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new PoltronaRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<PoltronaDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<bool> salvar(PoltronaDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new PoltronaRepositorio(contexto);

                        Poltrona objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Poltrona>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar Poltrona.";
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

                    var repositorio = new PoltronaRepositorio(contexto);

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
                retorno.Mensagem = "Erro ao deletar Poltrona";

            }

            return retorno;

        }

        public RetornoDTO<bool> alterar(PoltronaDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new PoltronaRepositorio(contexto);

                        Poltrona objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Poltrona>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Poltrona Alterada com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Poltrona não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Poltrona.";
                retorno.Status = false;
                retorno.Resultado = false;
            }

            return retorno;
        }

    }
}
