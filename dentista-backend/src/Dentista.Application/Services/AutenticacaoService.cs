using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Exceptions;
using System.Collections.Generic;
using Dentista.Application.Extensions;

namespace Dentista.API.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutenticacaoService(UserManager<IdentityUser> userManager, 
                    SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Registro(RegistroRequest request)
        {
            var usuarioGravar = new IdentityUser
            {
                UserName = request.Email,
                Email = request.Email,

            };

            var result = await _userManager.CreateAsync(usuarioGravar, request.Password);

            if (!result.Succeeded)
            {
                var mensagemErro = result.Errors.MensagemErro();

                throw new AutenticacaoException($"Erro ao realizar a autenticação. {mensagemErro}");
            }

            return result.Succeeded;
        }
    }
}
