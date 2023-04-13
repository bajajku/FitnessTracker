using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    public class WorkoutPlanViewModel
    {
        public string UserName { get; set; }
        public List<string> Workouts{ get; set; }
    }
}
