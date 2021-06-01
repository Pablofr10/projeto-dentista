namespace Dentista.Core.Entities
{
    public class ConsultaEspecialidade
    {
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }
        public int ConsultaId { get; set; }
        public virtual Consulta Consulta { get; set; }
    }
}