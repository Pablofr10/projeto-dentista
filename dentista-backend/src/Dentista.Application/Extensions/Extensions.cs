using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Dentista.Application.Extensions
{
    public static class Extensions
    {
        public static string FormatadorPalavras(this string str)
        {
            return str.ToLower().Trim();
        }

        public static string MensagemErro(this IEnumerable<IdentityError> errosIdentity)
        {

            List<string> erros = new List<string>();
            foreach (var erro in errosIdentity)
            {
                erros.Add(erro.Description);
            }

            string mensagemErro = string.Join(",", erros);

            return mensagemErro;
        }
    }
}