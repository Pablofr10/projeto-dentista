using System.Threading.Tasks;
using Dentista.Core.DTOs.Response;

namespace Dentista.Core.Interfaces.Services
{
    public interface IEspecialidadeService
    {
        Task<EspecialidadeResponse> Get();
    }
}