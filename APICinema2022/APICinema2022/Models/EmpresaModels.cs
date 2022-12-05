using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class EmpresaModels
    {
        public RetornoDTO<List<EmpresaDTO>> listar()
        {

            var retorno = new RetornoDTO<List<EmpresaDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new EmpresaRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<EmpresaDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<EmpresaDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<EmpresaDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new EmpresaRepositorio(contexto);

                    Empresa objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new EmpresaDTO
                        {
                            Id = objEntidade.Id,
                            Ativo = objEntidade.Ativo,
                            Cnpj = objEntidade.Cnpj,
                            Nome = objEntidade.Nome

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

        public RetornoDTO<bool> alterar(EmpresaDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new EmpresaRepositorio(contexto);

                        Empresa objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Empresa>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Empresa Alterada com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Empresa não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Empresa.";
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

                    var repositorio = new EmpresaRepositorio(contexto);
                    var objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (id != 0 && objEntidade != null)
                    {

                        if (objEntidade.Ativo != false)
                        {
                            objEntidade.Ativo = false;
                            retorno.Mensagem = "Empresa inativada com Sucesso!";
                        }
                        else
                        {
                            objEntidade.Ativo = true;
                            retorno.Mensagem = "Empresa ativada com Sucesso!";
                        }

                        repositorio.alterar(objEntidade);

                        contexto.SaveChanges();

                        retorno.Resultado = true;

                    }
                    else
                    {
                        retorno.Status = false;
                        retorno.Mensagem = "Erro ao desativar Empresa: Inexistente!!";
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

        public RetornoDTO<bool> salvar(EmpresaDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new EmpresaRepositorio(contexto);

                        Empresa objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Empresa>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar Empresa.";
                retorno.Status = false;
                retorno.Resultado = false;

            }

            return retorno;

        }

    }
}
