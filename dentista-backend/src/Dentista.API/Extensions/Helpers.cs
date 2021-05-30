namespace Dentista.API.Extensions
{
    public static class Helpers
    {
        public static string FormatadorPalavras(this string str)
        {
            return str.ToLower().Trim();
        }
    }
}