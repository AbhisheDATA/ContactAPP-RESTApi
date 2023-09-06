using ContactApplication.ContractApp;
using ContactApplication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly IUserControl userControl;

        public UsersController(IUserControl userControl)
        {
            this.userControl = userControl;
        }

        [HttpPost,Route("Signup")]
        public async Task<IActionResult> SignUp([FromBody]Signup signup)
        {
            try
            {
                var result = await userControl.SignUpAsync(signup);
                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
              
                
                    return Unauthorized();
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] Signin signin)
        {
            try
            {
                var result = await userControl.LoginAsync(signin);
                if (string.IsNullOrEmpty(result))
                {
                    return Unauthorized();
                }


                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
