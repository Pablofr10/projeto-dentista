using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Exceptions;
using System.Collections.Generic;
using Dentista.Application.Extensions;
using Dentista.Core.DTOs.Response;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Dentista.API.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AutenticacaoService(IConfiguration configuration, UserManager<IdentityUser> userManager, 
                    SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
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
                string mensagemErro = result.Errors.MensagemErro();

                throw new AutenticacaoException($"Erro ao realizar a autenticação. {mensagemErro}");
            }

            return true;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (request == null)
            {
                throw new AutenticacaoException("Para realizar o login é necessário informar Email e Senha");
            }
            var user = await _userManager.FindByNameAsync(request.Email);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                throw new AutenticacaoException("Login inválido");
            }

            var userBanco = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == request.Email.ToUpper());

            LoginResponse retornoLogin = new LoginResponse {
                UserName = userBanco.UserName,
                Token = GenerateJwToken(userBanco).Result
            };


            return retornoLogin;
        }

        private async Task<string> GenerateJwToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }


}

