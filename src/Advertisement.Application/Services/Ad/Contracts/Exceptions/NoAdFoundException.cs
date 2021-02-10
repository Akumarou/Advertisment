using Advertisement.Domain.Shared.Exceptions;

namespace Advertisement.Application.Services.Ad.Contracts.Exceptions
{
    public sealed class NoAdFoundException : NotFoundException
    {
        public NoAdFoundException(int adId) : base($"Объявление с таким ID [{adId}] не было найдено.")
        {
        }
    }
}