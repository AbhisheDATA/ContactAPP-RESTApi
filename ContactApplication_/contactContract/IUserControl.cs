using ContactApplication_.Model;
using Microsoft.AspNetCore.Identity;

namespace ContactApplication_.contactContract
{
    public interface IUserControl
    {
        Task<IdentityResult> SignUpAsync(SignupModel signup);
        Task<string> LoginAsync(SigninModel signin);
        Task<string> SetNewPassword(SetNewPasswordModel newPassword);
        Task<string> ForgetPassword(ForgetPasswordModel forgetPassword);
    }
}
