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
    public class PacienteRepository : BaseRepository , IPacienteRepository
    {
        private readonly DentistaDbContext _context;

        public PacienteRepository(DentistaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> Get(PacienteParams pacienteParam)
        {
            var pacientes = _context.Pacientes
                .AsQueryable();

            if (!string.IsNullOrEmpty(pacienteParam.Cidade))
            {
                var cidade = pacienteParam.Cidade.ToLower().Trim();
                pacientes = pacientes.Where(p => p.Cidade.ToLower().Contains(cidade));
            }
            
            if (pacienteParam.Situacao == "ativo")
            {
                pacientes = pacientes.Where(p => p.Ativo);
            }
            
            if (pacienteParam.Situacao == "inativo")
            {
                pacientes = pacientes.Where(p => !p.Ativo);
            }
            
            return await pacientes.ToListAsync();
        }

        public async Task<Paciente> Get(int idPaciente)
        {
            var paciente = await _context.Pacientes
                .Include(x => x.Consultas)
                .Where(x => x.Id == idPaciente)
                .FirstOrDefaultAsync();

            return paciente;
        }
        
    }
}