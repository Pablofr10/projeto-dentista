using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Services;

namespace Dentista.Application.Services
{
    public class ProfissionalService : IProfissionalService
    {
        public Task<IEnumerable<ProfissionalDto>> BuscarProfissionais()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProfissionalDto> BuscarProfissional(int idProfissional)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AdicionarProfissional(ProfissionalDto profissional)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AtualizarProfissional(int idProfissional, ProfissionalDto profissional)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AdicionarEspecialidade(EspecialidadeDto profissional)
        {
            throw new System.NotImplementedException();
        }
    }
}