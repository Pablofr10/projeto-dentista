namespace Dentista.Core.DTOs
{
    public class ProfissionalEspecialidadeDto : BaseDto
    {
        public int ProfissionalId { get; set; }
        public int EspecialidadeId { get; set; }
        public bool Status { get; set; }
    }
}