using FitnessTracker.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess
{//Author: Seb
    public interface IUserDataManager
    {
        //read
        public void WriteAllUsers(List<User> userList);

        //write
        public List<User> ReadAllUsers();
    }
}
