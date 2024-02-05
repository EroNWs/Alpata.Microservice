using Alpata.IdentityServer.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Alpata.IdentityServer.Shared
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }


    }
}
