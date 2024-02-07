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
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using Microsoft.Extensions.Logging;

namespace Alpata.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserController> _logger;

        public UserController(UserManager<ApplicationUser> userManager, ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromForm] SingupDto signUpDto, [FromForm] IFormFile file)
        {
            _logger.LogInformation("SignUp called with userName: {UserName}, email: {Email}", signUpDto?.UserName, signUpDto?.Email);
            if (file == null)
            {
                _logger.LogWarning("File is null");
                return BadRequest("File is required.");
            }

            if (signUpDto == null)
            {
                _logger.LogWarning("SignUpDto is null");
                return BadRequest("SignUpDto is required.");
            }

            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profilePics");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var profilePicPath = $"/profilePics/{fileName}";


            var user = new ApplicationUser
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email,
                PhoneNumber = signUpDto.Phone,
                ProfilePicturePath = profilePicPath, 
            };

            var result = await _userManager.CreateAsync(user, signUpDto.Password);

            if (!result.Succeeded)
            {
                System.IO.File.Delete(filePath);
                var errors = result.Errors.Select(e => e.Description);
                _logger.LogError("User creation failed: {Errors}", string.Join(", ", errors));
                return BadRequest(Response<NoContent>.Fail(errors.ToList(), 400));
            }

            _logger.LogInformation("User {UserName} created successfully", user.UserName);
            return Ok(new { UserId = user.Id });
        }


        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim is null) return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user is null) return BadRequest();

            return Ok(new { user.Id, user.UserName, user.Surname, user.Email, user.Phone, user.ProfilePicturePath });

        }


    }

}
