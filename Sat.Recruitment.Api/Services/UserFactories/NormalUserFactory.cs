using Sat.Recruitment.Api.Entities;
using System;

namespace Sat.Recruitment.Api.Services {
    public abstract class NormalUserFactory : BaseUserFactory {

        public override User CreateUser(string name, string email, string address, string phone, decimal money) {
            var usr = base.CreateUser(name, email, address, phone, money);
            usr.UserType = User.Types.NORMAL_USER;
            if (money > 100) {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = money * percentage;
                usr.Money += gif;
            }
            if (money <= 100 && money > 10) {
                var percentage = Convert.ToDecimal(0.8);
                var gif = money * percentage;
                usr.Money += gif;
            }

            return usr;
        }
    }
}
