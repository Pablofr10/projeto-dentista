using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.Entities;
using Dentista.Core.Enums;

namespace Dentista.API.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Paciente, PacienteDto>();
            CreateMap<PacienteDto, Paciente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.Especialidade, opt => opt.MapFrom(src => src.Especialidade.Nome))
                .ForMember(dest => dest.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome))
                .ForMember(dest => dest.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome));

            CreateMap<ConsultaDto, Consulta>();
        }
        
    }
}