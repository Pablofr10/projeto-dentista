using System.Threading.Tasks;
using Dentista.Application.Extensions;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Exceptions;
using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Dentista.Application.Services
{
    public class AdministracaoService : IAdministracaoService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministracaoService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> AdicionaPermissao(PermissaoRequest request)
        {
            IdentityRole permissao = new IdentityRole
            {
                Name = request.Nome
            };

            IdentityResult result = await _roleManager.CreateAsync(permissao);

            if (!result.Succeeded)
            {
                string mensagemErro = result.Errors.MensagemErro();

                throw new AdministracaoException($"Erro ao adicionar permissão. {mensagemErro}");
            }

            return true;
        }
    }
}
