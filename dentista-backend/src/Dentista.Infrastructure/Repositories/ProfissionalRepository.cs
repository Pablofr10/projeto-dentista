using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Params;
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

        public async Task<IEnumerable<Profissional>> Get(ProfissionalParams profissionalParams)
        {
            var profissionais = _context.Profissionais
                .Include(x => x.Especialidades).AsQueryable();

            if (!string.IsNullOrEmpty(profissionalParams.Nome))
            {
                var nome = profissionalParams.Nome.Trim().ToLower();
                profissionais = profissionais.Where(x => x.Nome.ToLower().Contains(nome));
            }

            if (profissionalParams.Especialidades != null)
                profissionais = profissionais.Where(x =>
                    x.Especialidades.Any(x => profissionalParams.Especialidades.Contains(x.Id)));

            return await profissionais.ToListAsync();
        }

        public async Task<Profissional> Get(int idProfissional)
        {
            var profissional = await _context.Profissionais
                .Include(x => x.Especialidades)
                .Where(x => x.Id == idProfissional).FirstOrDefaultAsync();

            return profissional;
        }

        public async Task<IEnumerable<EspecialidadeProfissional>> GetEspecialidades(int idProfissional)
        {
            var especiliadades = await _context.EspecialidadesProfissionais
                .Where(x => x.ProfissionalId == idProfissional).ToListAsync();

            return especiliadades;
        }
    }
}