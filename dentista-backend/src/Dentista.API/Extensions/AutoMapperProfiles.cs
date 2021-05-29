using AutoMapper;
using Dentista.Core.DTOs;
using Dentista.Core.Entities;

namespace Dentista.API.Extensions
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PacienteDto, Paciente>().ReverseMap();
        }
    }
}