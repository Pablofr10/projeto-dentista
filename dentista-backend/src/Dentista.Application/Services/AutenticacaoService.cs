using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Exceptions;
using System.Collections.Generic;

namespace Dentista.Application.Services
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
                List<string> erros = new List<string>();
                foreach (var erro in result.Errors)
                {
                    erros.Add(erro.Description);
                }

                string mensagemErro = string.Join(",", erros);

                throw new AutenticacaoException($"Erro ao realizar a autenticação. {mensagemErro}");
            }

            return result.Succeeded;
        }
    }
}
