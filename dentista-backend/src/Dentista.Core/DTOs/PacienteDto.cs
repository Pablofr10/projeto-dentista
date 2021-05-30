using System;

namespace Dentista.Core.DTOs
{
    public class PacienteDto : BaseDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int CEP { get; set; }
        public string Sexo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int ConsultasFinalizadas { get; set; }
    }
}