using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;

namespace Dentista.Core.Interfaces.Services
{
    public interface IAutenticacaoService
    {
        Task<bool> Registro(RegistroRequest request);
        Task<bool> Login(LoginRequest request);
    }
}
