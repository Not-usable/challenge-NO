namespace Sat.Recruitment.Api.Entities {
    public class User {
        public static class Types {
            public static string NORMAL_USER = "Normal";
            public static string SUPER_USER_USER = "SuperUser";
            public static string PREMIUM_USER = "Premium";
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
