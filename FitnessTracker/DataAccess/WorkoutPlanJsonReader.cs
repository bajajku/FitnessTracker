using FitnessTracker.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess
{
    public class WorkoutPlanJsonReader : IWorkoutManager
    {
        string _filePath;

        public WorkoutPlanJsonReader(string filePath)
        {
            _filePath = filePath;
        }
        public List<WorkoutPlanViewModel> ReadWorkoutPlan()
        {
            List<WorkoutPlanViewModel> wpvm;
            using (FileStream reader = new FileStream(_filePath, FileMode.Open))
            {
                wpvm = JsonSerializer.Deserialize<List<WorkoutPlanViewModel>>(reader);
            }
            return wpvm;
        }
        public void WriteWorkoutPlan(string workoutName, string userName)
        {

            List<WorkoutPlanViewModel> workoutPlans = ReadWorkoutPlan();

            var index = workoutPlans.FindIndex(x => x.UserName == userName);
            if (index == -1)
            {
                workoutPlans.Add(new WorkoutPlanViewModel() { UserName = userName, Workouts = new List<string> { workoutName } }

                );
            }
            else
            {
                workoutPlans[index].Workouts.Add(workoutName);
            }

            using (FileStream writer = new FileStream(_filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                JsonSerializer.Serialize(writer, workoutPlans);
            }
        }
    }
}
