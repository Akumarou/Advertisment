using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Advertisement.Application.Services.Ad.Contracts;
using Advertisement.Application.Services.Ad.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.PublicApi.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetPaged.Response), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllRequest request,
            [FromServices] IAdService adService,
            CancellationToken cancellationToken)
        {
            return Ok(await adService.GetPaged(new GetPaged.Request
            {
                Limit = request.Limit,
                Offset = request.Offset
            }, cancellationToken));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Get.Response), (int) HttpStatusCode.OK )]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(
            [FromRoute] int id,
            [FromServices] IAdService service,
            CancellationToken cancellationToken
        )
        {
            return Ok(await service.Get(new Get.Request
            {
                Id = id
            }, cancellationToken));
        }

        public sealed class GetAllRequest
        {
            /// <summary>
            /// Количество возвращаемых объявлений
            /// </summary>
            public int Limit { get; set; } = 10;
            
            /// <summary>
            /// Смещение начиная с котрого возвращаются объявления
            /// </summary>
            public int Offset { get; set; } = 0;
        }
    }
}