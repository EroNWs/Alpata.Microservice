using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Alpata.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
		public string Surname { get; set; }
		public string Phone { get; set; }
        public string ProfilePicturePath { get; set; }

    }
}
