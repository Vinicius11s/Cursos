using System;

namespace SistemaBancario
{
    /// <summary>
    /// Exceção a ser lançada quando a idade de um possível novo cliente não for aceita.
    /// </summary>
    public class IdadeNaoPermitidaException : Exception
    {
        public const string MSG_IDADE_INVALIDA = "A idade do cliente precisa estar entre 18 e 65 anos.";

        public IdadeNaoPermitidaException(string message) : base(message)
        {
        }

        public IdadeNaoPermitidaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
