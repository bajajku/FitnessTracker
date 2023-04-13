using FitnessTracker.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess
{
    internal class NutritonJsonManager : INutritionDataManager
    {
        string _filePath;

        public NutritonJsonManager(string filePath)
        {
            _filePath = filePath;
        }

        public void WriteAllNutritionTrackers(List<NutritionTracker> nutritionList)
        {
            using (FileStream writer = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(writer, nutritionList);
            }
        }
        public List<NutritionTracker> ReadAllNutritionTrackers()
        {
            List<NutritionTracker> nutritionTrackers;
            using (FileStream reader = new FileStream(_filePath, FileMode.Open))
            {
                nutritionTrackers = JsonSerializer.Deserialize<List<NutritionTracker>>(reader);
            }
            return nutritionTrackers;

        }
    }
}
