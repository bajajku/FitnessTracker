﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.DataAccess;

namespace FitnessTracker.BusinessLogic
{
    //Author: Seb
    public class NutritionManager
    {
        private List<NutritionTracker>_nutritionTrackers= new List<NutritionTracker>();
        public List<NutritionTracker> NutritionTrackers
        {
            get => _nutritionTrackers;
            set => _nutritionTrackers = value;
        }

        public NutritionTracker GetNutritionTracker(string username) //
        {
            foreach(NutritionTracker n in NutritionTrackers)
            {
                if(n.UserName== username) return n;
            }

            return null;
        }

        public void CreateNewTracker(string username)
        {
            NutritionTracker newTracker = new NutritionTracker(username);
            NutritionTrackers.Add(newTracker);
        }

        public void SaveData(INutritionDataManager dataManager)
        {
            dataManager.WriteAllNutritionTrackers(NutritionTrackers);
        }

        public void WriteData(INutritionDataManager dataManager)
        {
            NutritionTrackers = dataManager.ReadAllNutritionTrackers();
        }
    }
}
