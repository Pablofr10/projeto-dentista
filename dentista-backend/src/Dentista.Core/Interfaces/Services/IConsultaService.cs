

using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;

namespace Dentista.Core.Interfaces.Services
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaDto>> BuscarConsultas();
        Task<ConsultaDto> BuscarConsulta(int idPaciente);
        Task<bool> MarcarConsulta(ConsultaRequest consulta);
        Task<bool> AtualizarConsulta(int idConsulta, ConsultaRequest consulta);
    }
}