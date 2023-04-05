using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    // class to store exercises
   public class Exercises
   {
        string _name;
        string _description;
        MuscleGroup _targetMuscle;
        bool _isCardio;
        float _calorieBurned;
        
        public string Name
        {
            get { return _name; }
            set 
            {   if (value == null) throw new ArgumentNullException();
                
                _name = value;
            }
        }
        public string Description { get => _description; set {} }
        public Exercises(string name, string description, MuscleGroup targetMuscle, bool isCardio, float calorieBurned)
        {
            Name = name;
            Description = description;
            _targetMuscle = targetMuscle;
            _isCardio = isCardio;
            _calorieBurned = calorieBurned;
        }

    }

}
