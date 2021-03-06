using System.Collections.Generic;

namespace Dentista.Core.DTOs.Response
{
    public class PermissaoResponse
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        private List<UsuarioResponse> Usuarios { get; set; }
    }
}
