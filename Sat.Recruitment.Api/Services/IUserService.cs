using Sat.Recruitment.Api.Entities;
using System.Collections.Generic;

namespace Sat.Recruitment.Api.Services {
    public interface IUserService {
        User CreateUser(string name, string email, string address, string phone, string userType, decimal money);
        public bool Exists(string name, string email, string address, string phone);
    }
}
