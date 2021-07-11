using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Application.Extensions;
using Dentista.Core.DTOs;
using Dentista.Core.DTOs.Request;
using Dentista.Core.DTOs.Response;
using Dentista.Core.Exceptions;
using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dentista.Application.Services
{
    public class AdministracaoService : IAdministracaoService
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministracaoService(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissaoResponse>> BuscarPermissoes()
        {
            var permissoes = await _roleManager.Roles.ToListAsync();

            if (!permissoes.Any()) throw new AdministracaoException("Permissões não encontrada");

            return _mapper.Map<IEnumerable<PermissaoResponse>>(permissoes);
        }

        public async Task<PermissaoResponse> BuscarPermissao(string id)
        {
            var permissao = await _roleManager.FindByIdAsync(id);

            if (permissao == null) throw new AdministracaoException("Permissão não encontrada");

            return _mapper.Map<PermissaoResponse>(permissao);
        }

        public async Task<bool> AdicionaPermissao(PermissaoRequest request)
        {
            var permissao = new IdentityRole
            {
                Name = request.Nome
            };

            var result = await _roleManager.CreateAsync(permissao);

            if (!result.Succeeded)
            {
                var mensagemErro = result.Errors.MensagemErro();

                throw new AdministracaoException($"Erro ao adicionar permissão. {mensagemErro}");
            }

            return true;
        }

        public async Task<bool> EditarPermisao(EditarPermissaoRequest request)
        {
            var permissao = await _roleManager.FindByIdAsync(request.Id);

            if (permissao == null) throw new AdministracaoException("Permissão não encontrada");

            permissao.Name = request.Nome;
            var result = await _roleManager.UpdateAsync(permissao);

            if (!result.Succeeded)
            {
                var mensagemErro = result.Errors.MensagemErro();

                throw new AdministracaoException($"Erro ao editar permissão. {mensagemErro}");
            }

            return true;
        }

        public async Task<bool> EditarPermissoesUsuarios(List<UsuarioPermissaoRequest> request, string idPermissao)
        {
            var permissao = await _roleManager.FindByIdAsync(idPermissao);

            if (permissao == null) throw new AdministracaoException("Permissão não encontrada");

            for (var i = 0; i < request.Count(); i++)
            {
                var usuario = await _userManager.FindByIdAsync(request[i].IdUsuario);

                IdentityResult result = null;

                if (request[i].IsSelecionado && !await _userManager.IsInRoleAsync(usuario, permissao.Name))
                    result = await _userManager.AddToRoleAsync(usuario, permissao.Name);
                else if (!request[i].IsSelecionado && await _userManager.IsInRoleAsync(usuario, permissao.Name))
                    result = await _userManager.RemoveFromRoleAsync(usuario, permissao.Name);
                else
                    continue;

                if (!result.Succeeded)
                {
                    var mensagemErro = result.Errors.MensagemErro();

                    throw new AdministracaoException($"Erro ao editar permissões dos usuários. {mensagemErro}");
                }
            }

            return true;
        }

        public async Task<IEnumerable<UsuarioResponse>> ListaPermissoesUsuarios()
        {
            var permissoesUsuarios = _userManager.Users;

            var usuarioRetorno = _mapper.Map<IEnumerable<UsuarioResponse>>(permissoesUsuarios);
            return usuarioRetorno;
        }
    }
}