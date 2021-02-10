using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Advertisement.Application.Services.User.Contracts;
using Advertisement.Application.Services.User.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.PublicApi.Controllers.User
{
    public partial class UserController
    {

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromBody] UserRegisterRequest request,
            [FromServices] IUserService service,
            CancellationToken cancellationToken
        )
        {
            var response = await service.Register(new Register.Request
            {
                Name = request.Name,
                Password = request.Password
            }, cancellationToken);
            
            return Created($"api/v1/users/{response.UserId}", new {});
        }
        
        public sealed class UserRegisterRequest
        {
            [Required]
            [MaxLength(30, ErrorMessage = "Максимальная длина имени не должна превышать 30 символов")]
            public string Name { get; set; }
            
            [Required]
            public string Password { get; set; }
        }
    }
}