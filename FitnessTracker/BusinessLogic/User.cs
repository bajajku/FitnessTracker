//using AndroidX.Core.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    //Author: seb
    public class User
    {
        //ACCT INFO
        //Username
        private string _username;
        public string Username
        {
            get => _username;
            init //username cannot be changed. 
            {
                //check that no user with same username exists.
                _username = value;
            }
        }
        //Password
        private string _password;
        public string Password
        {
            get => _password;
            init
            {
                _password = value;
            }
        }
        //USER INFO
        //DoB
        private DateTime _dob;
        public DateTime Dob
        {
            get => _dob;
            init
            {
                TimeSpan MinAge = new TimeSpan(4745, 0, 0, 0);
                if ((DateTime.Today - value) <= MinAge) //checks to ensure user is above the age of 13
                {
                    _dob = value;
                }

            }
        }
        //Age
        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - Dob.Year;
            if (Dob.Date > today.AddYears(-age)) age--;
            return age;
        }
        //Height
        private float _height;
        public float Height
        {
            get => _height;
            set { _height = value; }
        }
        //Weight
        private float _weight;
        public float Weight
        {
            get => _weight;
            set { _weight = value; }
        }
        //BMI
        public float Bmi
        {
            get { return ((float)(Weight / Math.Pow(Height/100,2))); }
        }
        public User(string username, string password, DateTime dob, float height, float weight)
        {
            _username = username;
            _password = password;
            _dob = dob;
            _height = height;
            _weight = weight;
            //also has workoutPlan, nutritionPlan, however they are not directly connected, logically connected as they are marked with the username.
        }
        public override string ToString()
        {
            return $"{Username}, {Password}, {Dob}, {Height}, {Weight}";
        }
    }
}
