using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Params;

namespace Dentista.Core.Interfaces.Services
{
    public interface IProfissionalService
    {
        Task<IEnumerable<ProfissionalDto>> BuscarProfissionais(ProfissionalParams profissionalParams);
        Task<ProfissionalDto> BuscarProfissional(int idProfissional);
        Task<bool> AdicionarProfissional(ProfissionalRequest profissional);
        Task<bool> AtualizarProfissional(int idProfissional, ProfissionalDto profissional);
        Task<bool> AdicionarEspecialidade(int idProfissional, EspecialidadeRequest profissional);
    }
}