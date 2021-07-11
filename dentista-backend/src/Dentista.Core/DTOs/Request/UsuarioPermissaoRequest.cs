namespace Dentista.Core.DTOs.Request
{
    public class UsuarioPermissaoRequest
    {
        public string IdUsuario { get; set; }
        public string UserName { get; set; }
        public bool IsSelecionado { get; set; }
    }
}
