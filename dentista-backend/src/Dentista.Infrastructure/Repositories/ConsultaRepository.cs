using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Entities;
using Dentista.Core.Interfaces.Repositories;
using Dentista.Core.Interfaces.Services;
using Dentista.Infrastructure.Commom;
using Microsoft.EntityFrameworkCore;

namespace Dentista.Infrastructure.Repositories
{
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        private readonly DentistaDbContext _context;
        public ConsultaRepository(DentistaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> BuscarConsultas()
        {
            var consultas = _context.Consultas
                .Include(x => x.Profissional)
                .Include(x => x.Paciente)
                .Include(x => x.Especialidade);

            return await consultas.ToListAsync();
        }

        public async Task<Consulta> BuscarConsulta(int IdPaciente)
        {
            throw new System.NotImplementedException();
        }
    }
}