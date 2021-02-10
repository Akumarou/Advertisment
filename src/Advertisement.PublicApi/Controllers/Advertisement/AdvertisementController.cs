using System.Collections.Generic;
using Advertisement.PublicApi.Controllers.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.PublicApi.Controllers.Advertisement
{
    [Route("api/v1/advertisements")]
    [ApiController]
    [Authorize]
    public partial class AdvertisementController : ControllerBase
    {
    }
}