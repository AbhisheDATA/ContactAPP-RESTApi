using System.ComponentModel.DataAnnotations;
namespace ContactApplication.Model
{
    public class Signin
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    
    }
}
