using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Services.UserFactories;
using System;

namespace Sat.Recruitment.Api.Services {
    public abstract class SuperUserUserFactory : BaseUserFactory {

        public override User CreateUser(string name, string email, string address, string phone, decimal money) {
            var usr = base.CreateUser(name, email, address, phone, money);
            usr.UserType = User.Types.SUPER_USER_USER;
            if (money > 100) {
                var percentage = Convert.ToDecimal(0.20);
                var gif = money * percentage;
                usr.Money += gif;
            }

            return usr;
        }
    }
}
