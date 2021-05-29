
using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Entities;

namespace Dentista.Core.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> BuscarPacientes();
        Task<PacienteDto> BuscarPacientePorId(int idPaciente);
        Task<bool> AdicionarPaciente(Paciente paciente);
        Task<bool> AtualizarPaciente(Paciente paciente);
        Task<bool> DeletarPaciente(int id);

    }

}