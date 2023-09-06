using ContactApplication_.contactContract;
using ContactApplication_.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApplication_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersServiceController : ControllerBase
    {
        private readonly IUserControl userControl;

        public UsersServiceController(IUserControl userControl)
        {
            this.userControl = userControl;
        }

        [HttpPost, Route("Signup")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel signup)
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody] SigninModel signin)
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
        [HttpPost, Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword( ForgetPasswordModel forgetPassword)
        {
            try
            {
              var result= await  userControl.ForgetPassword(forgetPassword);
                if (result == null)
                {
                    return StatusCode(400, result);
                }
                return StatusCode(200,result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost, Route("ResetNewPassword")]
        public async Task<string> ResetPassword(SetNewPasswordModel setPassword)
        {
            try
            {
                var result = await userControl.SetNewPassword(setPassword);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}