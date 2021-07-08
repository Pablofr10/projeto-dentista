using System.ComponentModel.DataAnnotations;

namespace Dentista.Core.DTOs.Request
{
    public class PermissaoRequest
    {
        [Required(ErrorMessage = "É obrigatório informar o nome da permissão para realizar o cadastro.")]
        public string Nome { get; set; }
    }
}
