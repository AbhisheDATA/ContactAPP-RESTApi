using Microsoft.AspNetCore.Identity;

namespace ContactApplication.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }    
    }
}
