using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> BuscarPacientes(PacienteParams pacienteParams);
        Task<PacienteDto> BuscarPacientePorId(int idPaciente);
        Task<bool> AdicionarPaciente(PacienteDto paciente);
        Task<bool> AtualizarPaciente(int idPaciente, PacienteDto paciente);
        Task<bool> MudarStatusPaciente(int id, bool ativo);
    }
}