using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Alpata.IdentityServer.Models
{
   
    public class ApplicationUser : IdentityUser
    {
		public string Surname { get; set; }
		public string Phone { get; set; }
        public string ProfilePicturePath { get; set; }

    }
}
