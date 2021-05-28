using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.Entities;

namespace Dentista.Core.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> Get();
        Task<Paciente> Get(int idPaciente);
    }
}