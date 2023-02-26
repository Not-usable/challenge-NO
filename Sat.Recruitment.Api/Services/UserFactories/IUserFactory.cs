using Sat.Recruitment.Api.Entities;

namespace Sat.Recruitment.Api.Services.UserFactories {
    public interface IUserFactory {
        User CreateUser(string name, string email, string address, string phone, decimal money);
    }
}
