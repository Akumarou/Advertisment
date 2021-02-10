using Advertisement.Domain.Shared.Exceptions;

namespace Advertisement.Application.Services.Ad.Contracts.Exceptions
{
    public sealed class NoUserForAdCreationException : NoRightsException
    {
        public NoUserForAdCreationException(string message) : base(message)
        {
        }
    }
}