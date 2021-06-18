using Dentista.Core.Interfaces.Repositories;
using Dentista.Infrastructure.Commom;

namespace Dentista.Infrastructure.Repositories
{
    public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
    {
        public EspecialidadeRepository(DentistaDbContext context) : base(context)
        {
        }
    }
}