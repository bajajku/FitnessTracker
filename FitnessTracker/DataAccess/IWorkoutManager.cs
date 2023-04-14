using FitnessTracker.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess
{
    public interface IWorkoutManager
    {
        public List<Workout> ReadFromWorkoutJson();

        public List<WorkoutPlanViewModel> ReadWorkoutPlan();

        public void WriteWorkoutPlan(string workoutName, string userName);

    }
}
