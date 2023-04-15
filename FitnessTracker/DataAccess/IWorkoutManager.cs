using FitnessTracker.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess
{
    public interface IWorkoutManager // interface for impemeneting workoutplanjsonrader
    {

        public List<WorkoutPlanViewModel> ReadWorkoutPlan();

        public void WriteWorkoutPlan(string workoutName, string userName);
        public void RemoveWorkoutPlan(string workoutName, string userName);

    }
}
