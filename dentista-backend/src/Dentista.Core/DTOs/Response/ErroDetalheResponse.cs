using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Dentista.Core.DTOs.Response
{
    public class ErroDetalheResponse
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
