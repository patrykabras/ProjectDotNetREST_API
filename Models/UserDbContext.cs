using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CryptaEcillas.Models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            // LoadDefaultUsers();
            // this.SaveChanges();
        }

        public List<User> getUsers () => Users.ToList();

        public void addUser (User user) {
            Users.Add(user);
            this.SaveChanges();
            return;
        }
        public User getUserById(int id)
        {
            return getUsers().Find(u => u.Id == id);
        }

        private void LoadDefaultUsers()
        {
            Users.Add(new User 
            { 
                Id = 0,
                Username = "admin",
                Password = "admin",
                Email = "admin@admin.com"
            });
            Users.Add(new User 
            { 
                Id = 1,
                Username = "pat",
                Password = "pat",
                Email = "pat@pat.com"
            });
        }
    }
}