using FitnessTracker.BusinessLogic;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess
{
    public class WorkoutJsonReader
    {
        string _filePath;

        public WorkoutJsonReader(string filePath)
        {
            _filePath = filePath;
        }
        public  List<Workout> Workouts { get { return ReadFromWorkoutJson(); } }
        public List<Workout> ReadFromWorkoutJson()
        {
            var workouts = new List<Workout>();
            string json = File.ReadAllText(_filePath);

            // Deserialize the JSON to a dynamic object
            // dynamic dataList = JsonSerializer.Deserialize<dynamic>(json);

            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            // Get the array of data elements from the root element
            JsonElement dataElement = root.GetProperty("Workout");
            JsonElement.ArrayEnumerator dataArray = dataElement.EnumerateArray();


            // Map the Difficulty Level to a Difficulty Level enum
            foreach (var data in dataArray)
            {
                workouts.Add(new Workout()
                {
                    Name = data.GetProperty("name").GetString(),
                    Description = data.GetProperty("description").GetString(),
                    DifficultyLevel = (DifficultyLevel)Enum.Parse(typeof(DifficultyLevel), data.GetProperty("difficultyLevel").GetString(), ignoreCase: true),
                    //Duration = int.Parse(data.GetProperty("duration").GetString()),
                    Tags = JsonSerializer.Deserialize<List<string>>(data.GetProperty("tags").GetRawText()),
                    Exercises = JsonSerializer.Deserialize<List<Exercise>>(data.GetProperty("exercises").GetRawText())
                });
            }
            return workouts;

        }

    }
}
