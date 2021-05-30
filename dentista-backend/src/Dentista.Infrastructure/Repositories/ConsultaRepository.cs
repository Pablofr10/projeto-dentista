using System.Threading.Tasks;
using Dentista.Core.DTOs;
using Dentista.Core.Interfaces.Services;
using Dentista.Infrastructure.Commom;

namespace Dentista.Infrastructure.Repositories
{
    public class ConsultaRepository : BaseRepository, IConsultaService
    {
        public ConsultaRepository(DentistaDbContext context) : base(context)
        {
        }

        public Task<ConsultaDto> BuscarConsultas()
        {
            throw new System.NotImplementedException();
        }

        public Task<ConsultaDto> BuscarConsulta()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> MarcarConsulta()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AtualizarConsulta()
        {
            throw new System.NotImplementedException();
        }
    }
}