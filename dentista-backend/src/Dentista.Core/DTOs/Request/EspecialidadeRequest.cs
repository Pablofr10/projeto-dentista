namespace Dentista.Core.DTOs.Request
{
    public class EspecialidadeRequest : BaseDto
    {
        public string Nome { get; set; }
        public bool Ativa { get; set; }
    }
}