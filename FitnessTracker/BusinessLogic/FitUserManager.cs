using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    internal class FitUserManager
    {
        private List<User> _users = new List<User>();
        public List<User> Users
        {
            get => _users;
            init => Users = _users;
        }

        public User GetByUsername(string username)
        {
            foreach (User A in Users)
            {
                if (username == A.Username)
                {
                    return A;
                }
            }

            return null; //returns null if there are no users with matching username
        }
        public void AddUser(string username, string password, DateTime dob, float height, float weight)
        {
            if (GetByUsername(username) == null)
            {
                int userId = Users.Count() + 1;
                User newUser = new User(userId, username, password, dob, height, weight);
                Users.Add(newUser);
                Login(username, password);
            }
            else throw new Exception($"User with name {username} already exists");
        }

        public User Login(string username, string password)
        {
            User loggedIn = GetByUsername(username);
            if (loggedIn == null) { return loggedIn; } //returns null if no user with matching username exists
            else if (loggedIn.Password == password) { return loggedIn; } //returns user with matching info
            else { return loggedIn; } //returning null if user with matching username has a password different than entered
        }
    }
}
