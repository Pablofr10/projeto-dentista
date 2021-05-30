using System.Linq;
using AutoMapper;
using Dentista.Application.Response;
using Dentista.Core.DTOs;
using Dentista.Core.Entities;
using Dentista.Core.Enums;

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