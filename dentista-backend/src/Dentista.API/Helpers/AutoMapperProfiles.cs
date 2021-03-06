

using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;
using Dentista.Core.Entities;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Dentista.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Paciente, PacienteDto>();
            CreateMap<PacienteDto, Paciente>();
                
            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.Especialidades,
                    opt => opt.MapFrom(src => src.Especialidades.Select(e => e.Nome)))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome))
                .ForMember(dest => dest.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome));
            
            CreateMap<ConsultaDto, Consulta>()
                .ForMember(x => x.CriadoEm, opt => opt.Ignore());
            CreateMap<Pagamento, PagamentoDto>().ReverseMap();
            
            CreateMap<ConsultaRequest, Consulta>()
                .ForMember(x => x.Especialidades, opt => opt.Ignore())
                .ForMember(dest => dest.Status, src => src.MapFrom(s => (int)s.Status))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Profissional, ProfissionalDto>().ForMember(dest => dest.Especialidades,
                opt => opt.MapFrom(src => src.Especialidades.Select(e => e.Nome)));
            CreateMap<ProfissionalDto, Profissional>();
            CreateMap<Profissional, ProfissionalResponse>();
            CreateMap<ProfissionalRequest, Profissional>()
                .ForMember(x => x.Especialidades, opt => opt.Ignore());
            CreateMap<Especialidade, EspecialidadeResponse>().ReverseMap();
            CreateMap<Especialidade, EspecialidadeProfissionalResponse>();
            CreateMap<EspecialidadeRequest, Especialidade>();
            CreateMap<IdentityRole, PermissaoResponse>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NormalizedName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<IdentityUser, UsuarioResponse>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.UserName));
        }
    }
}