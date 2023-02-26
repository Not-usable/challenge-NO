using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Services.UserFactories;
using System;

namespace Sat.Recruitment.Api.Services {
    public abstract class PremiumUserFactory : BaseUserFactory {

        public override User CreateUser(string name, string email, string address, string phone, decimal money) {
            var usr = base.CreateUser(name, email, address, phone, money);
            usr.UserType = User.Types.PREMIUM_USER;
            if (money > 100) {
                var gif = money * 2;
                usr.Money += gif;
            }

            return usr;
        }
    }
}
