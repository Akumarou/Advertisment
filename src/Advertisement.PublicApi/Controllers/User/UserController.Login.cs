using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Advertisement.Application.Services.User.Contracts;
using Advertisement.Application.Services.User.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.PublicApi.Controllers.User
{
    public partial class UserController
    {
        [HttpPost("login")]
        [ProducesResponseType(typeof(Login.Response), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login(
            [FromBody] UserLoginRequest request,
            [FromServices] IUserService service,
            CancellationToken cancellationToken)
        {
            return Ok(await service.Login(new Login.Request
            {
                Name = request.UserName,
                Password = request.Password
            }, cancellationToken));
        }

        public sealed class UserLoginRequest
        {
            [Required]
            public string UserName { get; set; }
            
            [Required]
            public string Password { get; set; }
        }
    }
}