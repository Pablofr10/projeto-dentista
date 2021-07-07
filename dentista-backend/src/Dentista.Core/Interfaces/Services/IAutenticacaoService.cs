using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;

namespace Dentista.Core.Interfaces.Services
{
    public interface IAutenticacaoService
    {
        Task<bool> Registro(RegistroRequest request);
        Task<LoginResponse> Login(LoginRequest request);
    }
}
