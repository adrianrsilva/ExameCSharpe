using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;

namespace ProjetoCinema2022
{
    public class AutoMapperConfig : Profile
    {

        public static MapperConfiguration RegisterMapper()
        {

            var config = new MapperConfiguration(f =>
            {

                f.CreateMap<Cliente, ClienteDTO>();
                f.CreateMap<ClienteDTO, Cliente>();

                f.CreateMap<Usuario, UsuarioDTO>();
                f.CreateMap<UsuarioDTO, Usuario>();

                f.CreateMap<Poltrona, PoltronaDTO>();
                f.CreateMap<PoltronaDTO, Poltrona>();

                f.CreateMap<Sala, SalaDTO>();
                f.CreateMap<SalaDTO, Sala>();

                f.CreateMap<Sessao, SessaoDTO>();
                f.CreateMap<SessaoDTO, Sessao>();

                f.CreateMap<Sexo, SexoDTO>();
                f.CreateMap<SexoDTO, Sexo>();

                f.CreateMap<Empresa, EmpresaDTO>();
                f.CreateMap<EmpresaDTO, Empresa>();

                f.CreateMap<Pessoa, PessoaDTO>();
                f.CreateMap<PessoaDTO, Pessoa>();

                f.CreateMap<Funcionario, FuncionarioDTO>();
                f.CreateMap<FuncionarioDTO, Funcionario>();

                f.CreateMap<Filme, FilmeDTO>();
                f.CreateMap<FilmeDTO, Filme>();

                f.CreateMap<Ingresso, IngressoDTO>();
                f.CreateMap<IngressoDTO, Ingresso>();
                
                f.CreateMap<Avaliacao, AvaliacaoDTO>();
                f.CreateMap<AvaliacaoDTO, Avaliacao>();

            });

            return config;

        }

    }
}
