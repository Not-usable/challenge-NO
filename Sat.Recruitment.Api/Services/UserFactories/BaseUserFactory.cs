using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Services.UserFactories;
using System;

namespace Sat.Recruitment.Api.Services {
    public abstract class BaseUserFactory : IUserFactory {

        public virtual User CreateUser(string name, string email, string address, string phone, decimal money) {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
            var normalizedEmail = string.Join("@", new string[] { aux[0], aux[1] });

            return new User {
                Name = name,
                Email = normalizedEmail,
                Address = address,
                Phone = phone,
                Money = money
            };
        }
    }
}
