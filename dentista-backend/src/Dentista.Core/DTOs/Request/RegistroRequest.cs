using System.ComponentModel.DataAnnotations;

namespace Dentista.Core.DTOs.Request
{
    public class RegistroRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senha e Senha de confirmação não combinam.")]
        public string ConfirmPassword { get; set; }
    }
}
