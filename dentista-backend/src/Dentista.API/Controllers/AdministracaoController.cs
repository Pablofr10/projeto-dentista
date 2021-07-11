using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dentista.Core.DTOs.Request;
using Dentista.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dentista.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministracaoController : ControllerBase
    {
        private readonly IAdministracaoService _service;

        public AdministracaoController(IAdministracaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPermissoes()
        {
            var permissoes = await _service.BuscarPermissoes();

            return permissoes.Any()
                ? Ok(permissoes)
                : BadRequest("Erro ao buscar permissões");
        }

        [HttpGet("{idPermissao}")]
        public async Task<IActionResult> BuscarPermissao(string idPermissao)
        {
            var permissoes = await _service.BuscarPermissao(idPermissao);

            return permissoes != null
                ? Ok(permissoes)
                : BadRequest("Erro ao buscar permissão");
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPermissao(PermissaoRequest request)
        {
            var permissaoCadastrada = await _service.AdicionaPermissao(request);

            return permissaoCadastrada
                ? Ok("Permissão cadastrada com sucesso!")
                : BadRequest("Erro ao cadastrar permissão");
        }

        [HttpPut]
        public async Task<IActionResult> EditarPermissao(EditarPermissaoRequest request)
        {
            var permissaoEditada = await _service.EditarPermisao(request);

            return permissaoEditada
                ? Ok("Permissão editada com sucesso!")
                : BadRequest("Erro ao editar permissão");
        }

        [HttpPost("permissoes-usuarios/{idPermissao}")]
        public async Task<IActionResult> DeletarPermissaoUsuario(List<UsuarioPermissaoRequest> request, string idPermissao)
        {
            var permissoesEditadas = await _service.EditarPermissoesUsuarios(request, idPermissao);

            return permissoesEditadas
                ? Ok("Permissão editada com sucesso!")
                : BadRequest("Erro ao editar permissão");
        }
    }
}