using Sat.Recruitment.Api.Entities;
using System.Collections.Generic;
using System.IO;

namespace Sat.Recruitment.Api.Repositories {
    public class UserRepository {

        public List<User> GetAllUsers() {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            List<User> users = new List<User>();

            while (reader.Peek() >= 0) {
                var fields = reader.ReadLineAsync().Result.Split(',');
                var user = new User {
                    Name = fields[0],
                    Email = fields[1],
                    Phone = fields[2],
                    Address = fields[3],
                    UserType = fields[4],
                    Money = decimal.Parse(fields[5]),
                };
                users.Add(user);
            }
            reader.Close();

            return users;
        }
    }
}
