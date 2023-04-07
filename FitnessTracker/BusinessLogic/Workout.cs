using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    public class Workout
    {
        public Workout() { }
        string _name; // name of workout , eg: pull workout
        public string Name { get { return _name;} }
        string _description;// one line description of workout , eg: Works muscles primary used for pulling that are back, biceps etc.
        public string Description { get { return _description;} }

        // a field to calculate duration for workout.

        DifficultyLevel _difficultyLevel;// difficulty level for the workout.
        public DifficultyLevel DifficultyLevel { get { return _difficultyLevel;} }
    }
}
