using System;
using System.Collections.Generic;

namespace Dentista.Core.Entities
{
    public class Paciente : Base
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int CEP { get; set; }
        public string Sexo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public List<Consulta> Consultas { get; set; }
        public DateTime DataExclusao { get; set; }
        
    }
}
