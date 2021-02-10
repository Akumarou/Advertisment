using System;

namespace Advertisement.Domain.Shared.Exceptions
{
    public abstract class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }        
    }
}