﻿using Dentista.Core.Interfaces.Services;
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
                string mensagemErro = result.Errors.MensagemErro();

                throw new AutenticacaoException($"Erro ao realizar a autenticação. {mensagemErro}");
            }

            return true;
        }
        public async Task<bool> Login(LoginRequest request)
        {
            if (request == null)
            {
                throw new AutenticacaoException("Para realizar o login é necessário informar Email e Senha");
            }

            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (!result.Succeeded)
            {

                throw new AutenticacaoException("Login inválido");
            }

            return true;
        }
    }
}
