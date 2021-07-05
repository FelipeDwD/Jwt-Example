using System.Collections.Generic;
using System.Linq;
using Jwt_Example.Models;

namespace Jwt_Example.Repository
{
    public static class UserRepository
    {
        public static User GetUser(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User {Id = 1, Username = "Bob", Password = "bob10", Role = "manager"});
            users.Add(new User {Id = 2, Username = "John", Password = "jj10", Role = "employee"});

            var user = users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).FirstOrDefault();

            return user;
        }
    }
}