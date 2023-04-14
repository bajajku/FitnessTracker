using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    public class WorkoutPlanViewModel
    {
        // model for My workouts plan page
        public string UserName { get; set; } // has username
        public List<string> Workouts{ get; set; }//has list of workout names
    }
}
