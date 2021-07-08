using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dentista.Application.Extensions;
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

        public AdministracaoService(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissaoResponse>> BuscarPermissoes()
        {
            var permissoes = await _roleManager.Roles.ToListAsync();

            return permissoes.Any() ? _mapper.Map<IEnumerable<PermissaoResponse>>(permissoes) : null;
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
    }
}