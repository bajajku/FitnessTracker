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
        DifficultyLevel _difficultyLevel;
        MuscleGroup _targetMuscle;
        
        public string Name
        {
            get { return _name; }
            set 
            {   if (value == null) throw new ArgumentNullException();
                
                _name = value;
            }
        }
        public string Description { get => _description; set {} }
        public Exercises(string name, string description, DifficultyLevel difficultyLevel, MuscleGroup targetMuscle)
        {
            _name = name;
            _description = description;
            _difficultyLevel = difficultyLevel;
            _targetMuscle= targetMuscle;
        }

   }
    public class Cardio : Exercises
    {
        int _duration;
        float _calorieBurned;


        public Cardio(float calorieBurned,string name, string description, DifficultyLevel difficultyLevel, MuscleGroup targetMuscle): base(name,description,difficultyLevel,targetMuscle)
        {
            
            _calorieBurned = calorieBurned;
        }
    }

}
