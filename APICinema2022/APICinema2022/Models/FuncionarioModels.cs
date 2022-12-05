using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class FuncionarioModels
    {
        public RetornoDTO<FuncionarioDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<FuncionarioDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new FuncionarioRepositorio(contexto);

                    Funcionario objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new FuncionarioDTO
                        {
                            Id = objEntidade.Id,
                            IdPessoa = objEntidade.IdPessoa,
                            Email = objEntidade.Email,
                            Senha = objEntidade.Senha,
                            Cpf = objEntidade.Cpf,
                            IdSexo = objEntidade.IdSexo,
                            IdUsuario = objEntidade.IdUsuario,
                            Nome = objEntidade.Nome,
                            Telefone = objEntidade.Telefone
                           

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

        public RetornoDTO<List<FuncionarioDTO>> listar()
        {

            var retorno = new RetornoDTO<List<FuncionarioDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new FuncionarioRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<FuncionarioDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<bool> salvar(FuncionarioDTO objDTO)
        {

            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {
                        var recuperaEmail = recuperarEmail(objDTO.Email);

                        var validaEmail = "";

                        if (recuperaEmail.Resultado != null)
                        {
                            validaEmail = recuperaEmail.Resultado.Email.ToString();
                        }

                        var repositorio = new FuncionarioRepositorio(contexto);

                        Funcionario objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Funcionario>(objDTO);

                        if (validaEmail != null)
                        {
                            if (objDTO.Id == 0 && validaEmail != objDTO.Email)
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
                                retorno.Mensagem = "Funcionário já existente!";

                            }
                        }
                        else
                        {
                            retorno.Status = false;
                            retorno.Resultado = false;
                            retorno.Mensagem = "E-mail não válido!";

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao salvar Funcionário.";
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

                    var repositorio = new FuncionarioRepositorio(contexto);

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
                retorno.Mensagem = "Erro ao deletar Funcionário";

            }

            return retorno;

        }

        public RetornoDTO<bool> alterar(FuncionarioDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new FuncionarioRepositorio(contexto);

                        Funcionario objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Funcionario>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Funcionário Alterado com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Funcionário não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Funcionário.";
                retorno.Status = false;
                retorno.Resultado = false;
            }

            return retorno;
        }

        public RetornoDTO<FuncionarioDTO> recuperarEmail(string email)
        {
            var obj = new RetornoDTO<FuncionarioDTO>();

            obj.Status = true;

            try
            {
                using (var contexto = new Context())
                {
                    var repositorio = new FuncionarioRepositorio(contexto);

                    Funcionario objEntidade = repositorio.recuperar(f => f.Email == email);


                    if (objEntidade != null)
                    {
                        obj.Resultado = new FuncionarioDTO
                        {
                            Email = objEntidade.Email,

                        };
                    }
                    else
                    {
                        obj.Resultado = null;
                        obj.Status = false;
                        obj.Mensagem = "Funcionário não existente";
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



    }
}