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
    //Author: seb
    internal class UserJsonManager : IUserDataManager
    {
        string _filePath;
        
        public UserJsonManager(string filePath)
        {
            _filePath = filePath;
        }
        private readonly JsonSerializerOptions _writeOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented= true,
        };
        private readonly JsonSerializerOptions _readOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
        public void WriteAllUsers(List<User> userList)
        {
            using (FileStream writer = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(writer, userList);
            }
        }
        public List<User> ReadAllUsers()
        {
            List<User> users;
            using (FileStream reader = new FileStream(_filePath, FileMode.Open))
            {
                users = JsonSerializer.Deserialize<List<User>>(reader);
            }
            return users;

        }

    }
}
