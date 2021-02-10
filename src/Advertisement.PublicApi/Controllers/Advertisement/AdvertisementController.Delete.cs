using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advertisement.Application.Services.Ad.Contracts;
using Advertisement.Application.Services.Ad.Interfaces;
using Advertisement.PublicApi.Controllers.User;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.PublicApi.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int id,
            [FromServices] IAdService service,
            CancellationToken cancellationToken
            )
        {
            await service.Delete(new Delete.Request
            {
                Id = id
            }, cancellationToken);
            return NoContent();
        }
    }
}