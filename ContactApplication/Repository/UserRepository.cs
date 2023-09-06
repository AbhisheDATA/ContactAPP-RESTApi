using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactApplication.ContractApp;
using ContactApplication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ContactApplication.Repository
{
    public class UserRepository:IUserControl
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<IdentityResult> SignUpAsync(Signup signup)
        {
            var user = new ApplicationUser()
            {
                FirstName = signup.FirstName,
                LastName = signup.LastName,
                Email = signup.Email,
                UserName=signup.Email,

            };

            return await _userManager.CreateAsync(user,signup.Password);
        }
        public async Task<string> LoginAsync(Signin signin)
        {
            var result = await _signInManager.PasswordSignInAsync(signin.Email, signin.Password,false,false);
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
           return  new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
