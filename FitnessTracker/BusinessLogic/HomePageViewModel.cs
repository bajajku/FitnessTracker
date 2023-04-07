using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    public class HomePageViewModel
    {
        public User User { get; set; }
        public string QuoteOfTheDay
        {
            get
            {
                switch (DateTime.UtcNow.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return "Quote for Sunday";
                    case DayOfWeek.Monday:
                        return "Quote for Monday";
                    case DayOfWeek.Tuesday:
                        return "Quote for Sunday";
                    case DayOfWeek.Wednesday:
                        return "Quote for Wednesday";
                    case DayOfWeek.Thursday:
                        return "Quote for Thursday";
                    case DayOfWeek.Friday:
                        return "Quote for Friday";
                    case DayOfWeek.Saturday:
                        return "Quote for Saturday";
                    default:
                        return "Random Quote!";
                }
            }
        }
    }
}
