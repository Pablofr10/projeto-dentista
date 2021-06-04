using System;
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
    public class ConsultaRepository : BaseRepository, IConsultaRepository
    {
        private readonly DentistaDbContext _context;

        public ConsultaRepository(DentistaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consulta>> BuscarConsultas(ConsultaParams consultaParams)
        {
            var consultas = _context.Consultas
                .Include(x => x.Profissional)
                .Include(x => x.Paciente)
                .Include(x => x.Pagamento)
                .Include(x => x.Especialidades).AsQueryable();

            var teste = consultas.ToList();

            if (consultaParams.Data != DateTime.MinValue)
                consultas = consultas.Where(x => x.DataConsulta.Date == consultaParams.Data.Date);

            if (consultaParams.DataInicial != DateTime.MinValue)
                consultas = consultas.Where(x => x.DataConsulta.Date >= consultaParams.DataInicial.Date);

            if (consultaParams.DataFinal != DateTime.MinValue)
                consultas = consultas.Where(x => x.DataConsulta.Date <= consultaParams.DataFinal.Date);

            if (consultaParams.DataFinal != DateTime.MinValue)
                consultas = consultas.Where(x => x.DataConsulta.Date <= consultaParams.DataFinal.Date);

            if ((int) consultaParams.Status > 0)
                consultas = consultas.Where(x => x.Status == (int) consultaParams.Status);

            if (consultaParams.ProfissionalId > 0)
                consultas = consultas.Where(x => x.ProfissionalId == consultaParams.ProfissionalId);

            return await consultas.ToListAsync();
        }

        public async Task<Consulta> BuscarConsulta(int idConsulta)
        {
            var consultas = _context.Consultas
                .Where(x => x.Id == idConsulta)
                .Include(x => x.Profissional)
                .Include(x => x.Paciente)
                .Include(x => x.Pagamento)
                .Include(x => x.Especialidades);

            return await consultas.FirstOrDefaultAsync();
        }
    }
}