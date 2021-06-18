using Dentista.Core.Enums;

namespace Dentista.Core.Params
{
    public class EspecialidadeParams
    {
        public StatusEspecialidade Ativa { get; set; } = StatusEspecialidade.Todos;
        public string Nome { get; set; }
    }
}