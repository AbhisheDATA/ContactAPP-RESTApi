using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactApplication_.contactContract;
using ContactApplication_.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ContactApplication_.Repository
{
    public class UserRepository : IUserControl
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> SignUpAsync(SignupModel signup)
        {
            var user = new ApplicationUser()
            {
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                Email = signup.Email,
                UserName = signup.Email,

            };

            return await _userManager.CreateAsync(user, signup.Password);
        }
        public async Task<string> LoginAsync(SigninModel signin)
        {
            var result = await _signInManager.PasswordSignInAsync(signin.Email, signin.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,signin.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                          Guid.NewGuid().ToString())
            };
            var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:VallidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<string> ForgetPassword(ForgetPasswordModel forgetPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(forgetPassword.Email);
                if (user == null)
                {
                    return null;
                }
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                return token;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> SetNewPassword(SetNewPasswordModel newPassword)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(newPassword.Email);
                if (user == null)
                {
                    return "User not Found!!";
                }
                if (string.Compare(newPassword.newPassword, newPassword.conformPassword) != 0)
                {
                    return  "new password and conform password should be matched";
                }
                await _userManager.ResetPasswordAsync(user, newPassword.Token, newPassword.newPassword);

                return "Password Reset";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}