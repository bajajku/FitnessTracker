using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.BusinessLogic;

namespace FitnessTracker.DataAccess
{
    //Author: Seb
    public interface INutritionDataManager
    {
        public void WriteAllNutritionTrackers(List<NutritionTracker> nutritionList);

        public List<NutritionTracker> ReadAllNutritionTrackers();


    }
}
