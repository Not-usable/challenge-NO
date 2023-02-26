using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Services.UserFactories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Api.Services {
    public class UserService : IUserService {

        private readonly Dictionary<string, IUserFactory> _factories;
        private readonly UserRepository _repository;

        public UserService(NormalUserFactory normal, PremiumUserFactory premium, SuperUserUserFactory super, UserRepository repo) {
            _factories = new Dictionary<string, IUserFactory>();
            _factories.Add(User.Types.NORMAL_USER, normal);
            _factories.Add(User.Types.PREMIUM_USER, premium);
            _factories.Add(User.Types.SUPER_USER_USER, super);
            _repository = repo;
        }

        public User CreateUser(string name, string email, string address, string phone, string userType, decimal money) {
            var factory = _factories.GetValueOrDefault(userType) ?? throw new ArgumentException("invalid user type");
            return factory.CreateUser(name, email, address, phone, money);
        }

        public bool Exists(string name, string email, string address, string phone) =>
            _repository.GetAllUsers().Any(u => u.Email == email || u.Phone == phone || (u.Name == name && u.Address == address));

    }
}
