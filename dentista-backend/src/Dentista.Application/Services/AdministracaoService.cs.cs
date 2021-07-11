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

            if (!permissoes.Any()) throw new AdministracaoException("Permissões não encontrada");

            return _mapper.Map<IEnumerable<PermissaoResponse>>(permissoes);
        }

        public async Task<PermissaoResponse> BuscarPermissao(string id)
        {
            var permissao = await _roleManager.Roles.Where(x => x.Id == id).FirstOrDefaultAsync();

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

        public Task<bool> EditarPermissoesUsuarios(IEnumerable<UsuarioPermissaoRequest> request, string idPermissao)
        {
            throw new System.NotImplementedException();
        }
    }
}