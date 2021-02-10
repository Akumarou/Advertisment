using Advertisement.Domain.Shared.Exceptions;

namespace Advertisement.Application.Services.Ad.Contracts.Exceptions
{
    public sealed class AdShouldBeInCreatedStateForClosingException : EntityNotInValidStateException
    {
        public AdShouldBeInCreatedStateForClosingException(int adId) 
            : base($"Объявление с ID [{adId}] должно быть в статусе {Domain.Ad.Statuses.Created} для закрытия")
        {
        }
    }
}