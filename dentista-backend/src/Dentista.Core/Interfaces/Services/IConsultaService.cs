using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;

namespace Dentista.Core.Interfaces.Services
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaDto>> BuscarConsultas();
        Task<ConsultaDto> BuscarConsulta(int idPaciente);
        Task<bool> MarcarConsulta();
        Task<bool> AtualizarConsulta();
    }
}