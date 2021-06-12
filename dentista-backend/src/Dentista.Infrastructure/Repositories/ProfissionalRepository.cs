using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Infrastructure.Commom;
using Microsoft.EntityFrameworkCore;

namespace Dentista.Infrastructure.Repositories
{
    public class ProfissionalRepository : BaseRepository, IProfissionalRepository
    {
        private readonly DentistaDbContext _context;

        public ProfissionalRepository(DentistaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profissional>> Get()
        {
            var profissionais = _context.Profissionais
                .Include(x => x.Especialidades).AsQueryable();

            return await profissionais.ToListAsync();
        }

        public async Task<Profissional> Get(int idProfissional)
        {
            var profissional = await _context.Profissionais
                .Include(x => x.Especialidades).FirstOrDefaultAsync();

            return profissional;
        }
    }
}