using System.ComponentModel.DataAnnotations;
namespace ContactApplication_.Model
{
    public class SignupModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConformPassword")]
        public string Password { get; set; }
        [Required]
        public string ConformPassword { get; set; }
    }
}
