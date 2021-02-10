using Advertisement.Domain.Shared.Exceptions;

namespace Advertisement.Application.Services.User.Contracts.Exceptions
{
    public sealed class NoRightsException : Domain.Shared.Exceptions.NoRightsException
    {
        public NoRightsException(string message) : base(message)
        {
        }
    }
}