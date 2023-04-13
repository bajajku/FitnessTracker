using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    public class NutritionTracker
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            init { _userName = value; }
        }

        private int _calories;
        public int Calories
        {
            get { return _calories; }
            set { if (value >= 0) _calories = value; }
        }
        private int _fat;
        public int Fat
        {
            get { return _fat; }
            set { if (value >= 0) _fat = value; }
        }
        private int _carbs;
        public int Carbs
        {
            get { return _carbs; }
            set { if (value >= 0) _carbs = value; }
        }
        private int _protien;
        public int Protien
        {
            get { return _protien; }
            set { if (value >= 0) _protien = value; }
        }
        private int _sodium;
        public int Sodium
        {
            get { return _sodium; }
            set { if (value >= 0) _sodium = value; }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public void UpdateNutrition(int fat, int carbs, int protien, int sodium)
        {
            _fat += fat;
            _carbs += carbs;
            _protien += protien;
            _sodium += sodium;
        }
        public NutritionTracker(string userName)
        {
            _userName= userName;
            _fat = 0;
            _carbs = 0;
            _protien = 0;
            _sodium = 0;
            _date= DateTime.Now;
        }
    }
}
