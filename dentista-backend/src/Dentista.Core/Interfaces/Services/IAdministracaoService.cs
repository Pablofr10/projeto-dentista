using System.Collections.Generic;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;

namespace Dentista.Core.Interfaces.Services
{
    public interface IAdministracaoService
    {
        Task<IEnumerable<PermissaoResponse>> BuscarPermissoes();
        Task<bool> AdicionaPermissao(PermissaoRequest request);
    }
}
