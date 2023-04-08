using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    public class Workout
    {
        public Workout() { }
        string _name; // name of workout , eg: pull workout
        [JsonPropertyName("name")]
        public string Name { get { return _name;} set { _name = value; } }
        string _description;// one line description of workout , eg: Works muscles primary used for pulling that are back, biceps etc.
        [JsonPropertyName("description")]

        public string Description { get { return _description;} set { _description = value; } }

        // a field to calculate duration for workout.

        DifficultyLevel _difficultyLevel;// difficulty level for the workout.
        [JsonPropertyName("difficultyLevel")]
        public DifficultyLevel DifficultyLevel { get { return _difficultyLevel;} set { _difficultyLevel = value; } }

        int _duration;
        public int Duration { get { return _duration; } set { _duration = value; } }

        List<string> _tags;
        public List<string> Tags { get { return _tags; } set { _tags = value; } }

        List<Exercise> _exercises;
        public List<Exercise> Exercises { get { return _exercises; } set { _exercises = value; } }
    }
}
