using System;

namespace Symas.Core.Service
{
    public enum ServiceResultError
    {
        NotFound = 1000,
        UndefinedError = 1001
    }

    public class ServiceResultException : ApplicationException
    {
        public Enum ExceptionCode { get; }

        public ServiceResultException(Enum code, Exception error) : base(string.Empty, error)
        {
            ExceptionCode = code;
        }
    }
}
