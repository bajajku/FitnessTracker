using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    internal class NutritionTracker
    {
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
        

    }
}
