using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Enums;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Params;
using Dentista.Infrastructure.Commom;
using Microsoft.EntityFrameworkCore;

namespace Dentista.Infrastructure.Repositories
{
    public class EspecialidadeRepository : BaseRepository, IEspecialidadeRepository
    {
        private readonly DentistaDbContext _context;

        public EspecialidadeRepository(DentistaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Especialidade>> BuscarEspecialidades(EspecialidadeParams especialidadeParams)
        {
            var especialidades = _context.Especialidades.AsQueryable();

            if (especialidadeParams.Ativa != StatusEspecialidade.Todos)
            {
                var isAtivos = especialidadeParams.Ativa == StatusEspecialidade.Ativo;
                especialidades = especialidades.Where(x => x.Ativa == isAtivos);
            }

            if (!string.IsNullOrWhiteSpace(especialidadeParams.Nome))
            {
                var nome = especialidadeParams.Nome.ToLower().Trim();
                especialidades = especialidades.Where(x => x.Nome.ToLower().Contains(nome));
            }

            return await especialidades.ToListAsync();
        }

        public async Task<Especialidade> BuscarEspecialidade(int idEspecialidade)
        {
            return await _context.Especialidades
                .Where(x => x.Id == idEspecialidade).FirstOrDefaultAsync();
        }

        public async Task<Especialidade> BuscarEspecialidadeProfissionais(int idEspecialidade)
        {
            return await _context.Especialidades
                .Where(x => x.Id == idEspecialidade)
                .Include(x => x.Profissionais).FirstOrDefaultAsync(); 
        }
    }
}