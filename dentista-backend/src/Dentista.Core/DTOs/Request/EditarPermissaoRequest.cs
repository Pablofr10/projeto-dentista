using System.ComponentModel.DataAnnotations;

namespace Dentista.Core.DTOs.Request
{
    public class EditarPermissaoRequest
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "É obrigatório informar o nome da permissão para edição.")]
        public string Nome { get; set; }
    }
}
