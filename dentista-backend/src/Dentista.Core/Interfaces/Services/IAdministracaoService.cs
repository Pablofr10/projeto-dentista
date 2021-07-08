using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;

namespace Dentista.Core.Interfaces.Services
{
    public interface IAdministracaoService
    {
        Task<bool> AdicionaPermissao(PermissaoRequest request);
    }
}
