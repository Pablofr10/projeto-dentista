using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Infrastructure.Commom;
using Microsoft.EntityFrameworkCore;

namespace Dentista.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly DentistaDbContext _context;

        public PacienteRepository(DentistaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> Get()
        {
            var pacientes = await _context.Pacientes
                .ToListAsync();

            return pacientes;
        }

        public async Task<Paciente> Get(int idPaciente)
        {
            var paciente = await _context.Pacientes
                .Include(x => x.Consultas)
                .Where(x => x.Id == idPaciente)
                .FirstOrDefaultAsync();

            return paciente;
        }

        public Task<bool> Post(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Put(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}