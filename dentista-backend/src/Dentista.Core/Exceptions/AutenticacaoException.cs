using System;

namespace Dentista.Core.Exceptions
{
    [Serializable]
    public class AutenticacaoException : Exception
    {
        public AutenticacaoException()
        {}

        public AutenticacaoException(string mensagem) : base(mensagem)
        {}
    }
}
