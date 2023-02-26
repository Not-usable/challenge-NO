using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Controllers.Users.Response;
using Sat.Recruitment.Api.Services;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers.Users {

    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase {

        private readonly IUserService _userService;

        public UsersController(IUserService userManager) {
            _userService = userManager;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<ResultResponse> CreateUser(string name, string email, string address, string phone, string userType, string money) {
            var errors = ValidateErrors(name, email, address, phone, userType, money);

            if (!string.IsNullOrEmpty(errors))
                return new ResultResponse() {
                    IsSuccess = false,
                    Errors = errors
                };

            if (_userService.Exists(name, email, address, phone)) {
                Debug.WriteLine("The user is duplicated");
                return new ResultResponse() {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }

            var _newUser = _userService.CreateUser(name, email, address, phone, userType, decimal.Parse(money));
            Debug.WriteLine("User Created");

            return new ResultResponse() {
                IsSuccess = true,
                Errors = "User Created"
            };
        }

        //Validate errors
        private string ValidateErrors(string name, string email, string address, string phone, string userType, string money) {
            var errors = new StringBuilder();
            if (name == null) errors.Append("The name is required ");
            if (email == null) errors.Append("The email is required ");
            if (address == null) errors.Append("The address is required ");
            if (phone == null) errors.Append("The phone is required ");
            if (userType != "Normal" && userType != "SuperUser" && userType != "Premium") errors.Append("The userType should bew one of [Normal, SuperUser, Premium] ");
            if (!decimal.TryParse(money, out _)) errors.Append("The money is not a valid number ");
            if (errors.Length > 0) errors.Remove(errors.Length - 1, 1);
            return errors.ToString();
        }
    }
}
