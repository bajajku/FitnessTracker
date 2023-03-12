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
        float _calorieBurned;

        public Cardio(float calorieBurned,string name, string description, DifficultyLevel difficultyLevel, MuscleGroup targetMuscle): base(name,description,difficultyLevel,targetMuscle)
        {
            _calorieBurned = calorieBurned;
        }
    }

}
