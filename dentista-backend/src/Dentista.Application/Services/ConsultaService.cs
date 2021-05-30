using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class ConsultaService : IConsultaService
    {
        public Task<ConsultaDto> BuscarConsultas()
        {
            throw new System.NotImplementedException();
        }

        public Task<ConsultaDto> BuscarConsulta()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> MarcarConsulta()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AtualizarConsulta()
        {
            throw new System.NotImplementedException();
        }
    }
}