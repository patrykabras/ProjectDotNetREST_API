using System.Collections.Generic;
using CryptaEcillas.Models;

namespace CryptaEcillas.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
    }
}