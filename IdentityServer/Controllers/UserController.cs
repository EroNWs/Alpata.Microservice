using Alpata.IdentityServer.Dtos;
using Alpata.IdentityServer.Models;
using Alpata.IdentityServer.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;
using System.IdentityModel.Tokens.Jwt;

namespace Alpata.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SingupDto signupDto)
        {
            var user = new ApplicationUser
            {
                Name = signupDto.Name,
                Surname = signupDto.Surname,
                Email = signupDto.Email,
                Phone = signupDto.Phone,
                ProfilePicture = signupDto.ProfilePicture,
             

            };
            var result = await _userManager.CreateAsync(user, signupDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }

            return NoContent();
        }



        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim is null) return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user is null) return BadRequest();

            return Ok(new { user.Id, user.Name, user.Surname, user.Email, user.Phone, user.ProfilePicture });

        }


    }

}
