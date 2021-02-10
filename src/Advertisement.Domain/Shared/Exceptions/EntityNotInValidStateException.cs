namespace Advertisement.Domain.Shared.Exceptions
{
    public abstract class EntityNotInValidStateException : DomainException
    {
        protected EntityNotInValidStateException(string message) : base(message)
        {
        }
    }
}