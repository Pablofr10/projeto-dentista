using Dentista.Core.Interfaces.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;

namespace Dentista.Application.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AutenticacaoService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Registro(RegistroRequest request)
        {
            var usuarioGravar = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,

            };

            var result = await _userManager.CreateAsync(usuarioGravar, request.Password);

            return result.Succeeded;
        }
    }
}
