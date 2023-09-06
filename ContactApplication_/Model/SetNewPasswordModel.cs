using System.ComponentModel.DataAnnotations;

namespace ContactApplication_.Model
{
    public class SetNewPasswordModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "new password is required")]
        public string? newPassword { get; set; }
        [Required(ErrorMessage = "conform password is required")]
        public string? conformPassword { get; set; }
        public string? Token { get; set; }
    }
}
