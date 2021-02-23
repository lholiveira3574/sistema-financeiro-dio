using System;

namespace sistema_financeiro_dio.Entidades.Exceptions
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message): base(message)
        {   
        }
    }
}