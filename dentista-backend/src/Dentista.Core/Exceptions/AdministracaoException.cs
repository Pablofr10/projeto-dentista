using System;

namespace Dentista.Core.Exceptions
{
    [Serializable]
    public class AdministracaoException : Exception
    {
        public AdministracaoException()
        {}

        public AdministracaoException(string mensagem) : base(mensagem)
        {}
    }
}
