using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;
using ProjetoCinema2022;
using Repositorio;
using System;
using System.Collections.Generic;

namespace APICinema2022.Models
{
    public class ClienteModels
    {
        public RetornoDTO<ClienteDTO> recuperar(int id)
        {

            var obj = new RetornoDTO<ClienteDTO>();

            obj.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var repositorio = new ClienteRepositorio(contexto);

                    Cliente objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {

                        obj.Resultado = new ClienteDTO
                        {
                            Id = objEntidade.Id,
                            IdPessoa = objEntidade.IdPessoa,
                            Email = objEntidade.Email,
                            Senha = objEntidade.Senha,
                            Ativo = objEntidade.Ativo,
                            Cpf = objEntidade.Cpf,
                            DataNascimento = objEntidade.DataNascimento,
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

        public RetornoDTO<List<ClienteDTO>> listar()
        {

            var retorno = new RetornoDTO<List<ClienteDTO>>();

            retorno.Status = true;

            try
            {

                using (var contexto = new Context())
                {

                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());

                    var repositorio = new ClienteRepositorio(contexto);

                    var listaEntidade = repositorio.listarTodos();

                    retorno.Resultado = mapper.Map<List<ClienteDTO>>(listaEntidade);

                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;

                retorno.Erro = ex.Message;

            }

            return retorno;

        }

        public RetornoDTO<bool> salvar(ClienteDTO objDTO)
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

                        var repositorio = new ClienteRepositorio(contexto);

                        Cliente objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Cliente>(objDTO);

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
                                retorno.Mensagem = "Cliente já existente!";

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
                retorno.Mensagem = "Erro ao salvar Cliente.";
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

                    var repositorio = new ClienteRepositorio(contexto);

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
                retorno.Mensagem = "Erro ao deletar Cliente";

            }

            return retorno;

        }

        public RetornoDTO<bool> alterar(ClienteDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();

            retorno.Status = true;

            try
            {

                if (objDTO != null)
                {

                    using (var contexto = new Context())
                    {

                        var repositorio = new ClienteRepositorio(contexto);

                        Cliente objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Cliente>(objDTO);

                        if (objEntidade.Id != 0)
                        {
                            repositorio.alterar(objEntidade);
                            contexto.SaveChanges();
                            retorno.Resultado = true;
                            retorno.Mensagem = "Cliente Alterado com Sucesso!";
                        }
                        else
                        {
                            retorno.Resultado = false;
                            retorno.Mensagem = "Cliente não existente!";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao alterar Cliente.";
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

                    var repositorio = new ClienteRepositorio(contexto);
                    var objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (id != 0 && objEntidade != null)
                    {

                        if (objEntidade.Ativo != false)
                        {
                            objEntidade.Ativo = false;
                            retorno.Mensagem = "Cliente inativado com Sucesso!";
                        }
                        else
                        {
                            objEntidade.Ativo = true;
                            retorno.Mensagem = "Cliente ativado com Sucesso!";
                        }

                        repositorio.alterar(objEntidade);

                        contexto.SaveChanges();

                        retorno.Resultado = true;

                    }
                    else
                    {
                        retorno.Status = false;
                        retorno.Mensagem = "Erro ao desativar Cliente: Inexistente!!";
                    }
                }

            }
            catch (Exception ex)
            {

                retorno.Status = false;
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao desativar Cliente: Inexistente";

            }

            return retorno;

        }

        public RetornoDTO<ClienteDTO> recuperarEmail(string email)
        {
            var obj = new RetornoDTO<ClienteDTO>();

            obj.Status = true;

            try
            {
                using (var contexto = new Context())
                {
                    var repositorio = new ClienteRepositorio(contexto);

                    Cliente objEntidade = repositorio.recuperar(f => f.Email == email);


                    if (objEntidade != null)
                    {
                        obj.Resultado = new ClienteDTO
                        {
                            Email = objEntidade.Email,

                        };
                    }
                    else
                    {
                        obj.Resultado = null;
                        obj.Status = false;
                        obj.Mensagem = "Cliente não existente";
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