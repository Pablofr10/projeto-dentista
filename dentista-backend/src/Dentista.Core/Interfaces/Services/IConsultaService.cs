

using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Services
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaDto>> BuscarConsultas(ConsultaParams consultaParams);
        Task<ConsultaDto> BuscarConsulta(int idPaciente);
        Task<bool> MarcarConsulta(ConsultaRequest consulta);
        Task<bool> AtualizarConsulta(int idConsulta, ConsultaRequest consulta);
    }
}