using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;

namespace Dentista.Core.Interfaces.Services
{
    public interface IProfissionalService
    {
        Task<IEnumerable<ProfissionalDto>> BuscarProfissionais();
        Task<ProfissionalDto> BuscarProfissional(int idProfissional);
        Task<bool> AdicionarProfissional(ProfissionalDto profissional);
        Task<bool> AtualizarProfissional(int idProfissional, ProfissionalDto profissional);
        Task<bool> AdicionarEspecialidade(EspecialidadeDto profissional);
    }
}