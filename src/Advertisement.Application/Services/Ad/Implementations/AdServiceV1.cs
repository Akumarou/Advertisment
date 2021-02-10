using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advertisement.Application.Services.Ad.Contracts;
using Advertisement.Application.Services.Ad.Contracts.Exceptions;
using Advertisement.Application.Services.Ad.Interfaces;
using Advertisement.Application.Services.User.Interfaces;

namespace Advertisement.Application.Services.Ad.Implementations
{
    public sealed class AdServiceV1 : IAdService
    {
        private readonly IRepository<Domain.Ad, int> _repository;
        private readonly IUserService _userService;
            
        public AdServiceV1(IRepository<Domain.Ad, int> repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public async Task<Create.Response> Create(Create.Request request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrent(cancellationToken);

            if (user == null)
            {
                throw new NoUserForAdCreationException($"Попытка создания объявления [{request.Name}] без пользователя.");
            }

            var ad = new Domain.Ad
            {
                Name = request.Name,
                Price = request.Price,
                OwnerId = user.Id,
                Status = Domain.Ad.Statuses.Created,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.Save(ad, cancellationToken);
            return new Create.Response
            {
                Id = ad.Id
            };
        }

        public async Task<Get.Response> Get(Get.Request request, CancellationToken cancellationToken)
        {
            var ad = await _repository.FindById(request.Id, cancellationToken);
            if (ad == null)
            {
                throw new NoAdFoundException(request.Id);
            }
            
            return new Get.Response
            {
                Name = ad.Name,
                Status = ad.Status.ToString(),
                Price = ad.Price,
                Owner = new Get.Response.OwnerResponse
                {
                    Id = ad.Owner.Id,
                    Name = ad.Owner.Name
                }
            };
        }

        public async Task Delete(Delete.Request request, CancellationToken cancellationToken)
        {
            var ad = await _repository.FindById(request.Id, cancellationToken);
            if (ad == null)
            {
                throw new NoAdFoundException(request.Id);
            }

            if (ad.Status != Domain.Ad.Statuses.Created)
            {
                throw new AdShouldBeInCreatedStateForClosingException(ad.Id);
            }

            ad.Status = Domain.Ad.Statuses.Closed;
            ad.UpdatedAt = DateTime.UtcNow;

            await _repository.Save(ad, cancellationToken);
        }

        public async Task<GetPaged.Response> GetPaged(GetPaged.Request request, CancellationToken cancellationToken)
        {
            var total = await _repository.Count(cancellationToken);
            if (total == 0)
            {
                return new GetPaged.Response
                {
                    Total = 0,
                    Offset = request.Offset,
                    Limit = request.Limit
                };
            }

            var ads =await _repository.GetPaged(request.Offset, request.Limit, cancellationToken);

            return new GetPaged.Response
            {
                Items = ads.Select(a => new GetPaged.Response.Item
                {
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    Status = a.Status.ToString()
                }),
                Total = total,
                Offset = request.Offset,
                Limit = request.Limit
            };
        }
    }
}