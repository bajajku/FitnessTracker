using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
//using Android.Service.Notification;
using FitnessTracker.BusinessLogic;
//using Newtonsoft.Json;

namespace FitnessTracker.DataAccess
{
    internal class UserJsonManager:IUserDataManager
    {
        string _filePath;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented= true,
        };
        public void WriteAllUsers(List<User> userList)
        {
            string userJson = JsonSerializer.Serialize(userList, _options);
            File.WriteAllText(_filePath, userJson);    
        }
        public List<User> ReadAllUsers()
        {
            string userJson = File.ReadAllText(_filePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(userJson);
            return users;

        }

    }
}
