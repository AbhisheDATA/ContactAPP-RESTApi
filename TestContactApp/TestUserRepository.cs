using ContactApplication_.Controllers;
using Microsoft.AspNetCore.Identity;
using ContactApplication_.contactContract;
using Microsoft.AspNetCore.Mvc;
using ContactApplication_.Model;
using Moq;
namespace TestContactApp
{
    [TestFixture]
    public class TestUserRepository
    {
        private UsersServiceController userServiceController;
        private Mock<IUserControl> mockUserControl;
        private ForgetPasswordModel forgetPassword;
        [SetUp]
        public void Setup()
        {
            mockUserControl = new Mock<IUserControl>();
           userServiceController = new UsersServiceController(mockUserControl.Object);
            forgetPassword= new ForgetPasswordModel();
        }
        [Test]
        public async Task Test_Login_ReturnsOkResult_WhenCredentialsAreValid()
        {
            // Arrange
            var signInModel = new SigninModel
            {
                Email = "abhisheklinkd5@gmail.com",
                Password = "Test@123456"
            };
            mockUserControl
                .Setup(x => x.LoginAsync(signInModel))
                .ReturnsAsync("token");

            // Act
            var result = await userServiceController.Login(signInModel);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
        [Test]
        public async Task Test_Login_ReturnsUnauthorizedResult_WhenCredentialsAreInvalid()
        {
            // Arrange
            var signInModel = new SigninModel
            {
                Email = "test@email.com",
                Password = "invalidpassword"
            };
            mockUserControl
                .Setup(x => x.LoginAsync(signInModel))
                .ReturnsAsync(string.Empty);

            // Act
            var result = await userServiceController.Login(signInModel);

            // Assert
            Assert.IsInstanceOf<UnauthorizedResult>(result);
        }
        [Test]
        public async Task Test_SignUp_ReturnsOkResult_WhenSignUpIsSuccessful()
        {
            // Arrange
            var signUpModel = new SignupModel
            {
                Email = "test@email.com",
                Password = "testpassword"
            };
            var identityResult = IdentityResult.Success;
            mockUserControl.Setup(x => x.SignUpAsync(signUpModel))
                .ReturnsAsync(identityResult);

            // Act
            var result = await userServiceController.SignUp(signUpModel);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
        


    }

}

