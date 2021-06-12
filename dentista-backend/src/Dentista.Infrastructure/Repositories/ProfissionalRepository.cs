using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Services;
using Dentista.Infrastructure.Commom;

namespace Dentista.Infrastructure.Repositories
{
    public class ProfissionalRepository : BaseRepository, IProfissionalService
    {
        public ProfissionalRepository(DentistaDbContext context) : base(context)
        {
        }

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