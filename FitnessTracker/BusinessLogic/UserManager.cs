using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    internal class UserManager
    {
        private List<User> _users;
        public List<User> Users
        {
            get => _users;
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

            return null;
        }
        public void AddUser(string username, string password, DateTime dob, float height, float weight)
        {
            if (GetByUsername(username)== null)
            {
                User newUser = new User(username, password, dob, height, weight);
                _users.Add(newUser);
            }   
        }
    }
}
