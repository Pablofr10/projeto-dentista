using System.Threading.Tasks;
using Dentista.Core.DTOs;

namespace Dentista.Core.Interfaces.Services
{
    public interface IConsultaService
    {
        Task<ConsultaDto> BuscarConsultas();
        Task<ConsultaDto> BuscarConsulta();
        Task<bool> MarcarConsulta();
        Task<bool> AtualizarConsulta();
    }
}