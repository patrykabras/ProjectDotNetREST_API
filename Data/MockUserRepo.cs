using System.Collections.Generic;
using CryptaEcillas.Models;

namespace CryptaEcillas.Data
{
    public class MockUserRepo : IUserRepo
    {
        public User GetUserById(int id)
        {
            return new User{
                Id = 0,
                Username = "Admin",
                Password = "admin",
                Email = "admin@admin.pl"
            };
        }

        public IEnumerable<User> GetUsers()
        {
            var users = new List<User>
            {
                new User{
                Id = 0,
                Username = "Admin",
                Password = "admin",
                Email = "admin@admin.pl"
                },
                new User{
                Id = 1,
                Username = "Patryk",
                Password = "pat",
                Email = "patryk@patryk.pl"
                }
            };
            return users;
        }
    }

}
        