using ContactApplication.Model;
using Microsoft.AspNetCore.Identity;

namespace ContactApplication.ContractApp
{
    public interface IUserControl
    {
        Task<IdentityResult> SignUpAsync(Signup signup);
        Task<string> LoginAsync(Signin signin);
    }
}
