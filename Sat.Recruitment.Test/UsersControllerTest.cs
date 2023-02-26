using Moq;
using Sat.Recruitment.Api.Controllers.Users;
using Sat.Recruitment.Api.Services;
using Xunit;

namespace Sat.Recruitment.Test {
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTest {
        [Fact]
        public void Should_work() {
            var mock = GetUserManagerMock(false);
            var userController = new UsersController(mock.Object);

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Should_fail_when_user_have_duplicated_email() {
            var mock = GetUserManagerMock(true);
            var userController = new UsersController(mock.Object);

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void Should_fail_when_user_have_invalid_money() {
            var mock = GetUserManagerMock(false);
            var userController = new UsersController(mock.Object);

            var result = userController.CreateUser("Pepe", "Pepe@gmail.com", "Av. Juan G", "+534645213542", "Normal", "1aa24").Result;

            Assert.False(result.IsSuccess);
            Assert.Equal("The money is not a valid number", result.Errors);
        }

        private Mock<IUserService> GetUserManagerMock(bool exists) {
            var userManager = new Mock<IUserService>();
            userManager.Setup(m => m.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>()))
                .Returns(new Api.Entities.User());
            userManager.Setup(m => m.Exists(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(exists);
            return userManager;
        }
    }
}
