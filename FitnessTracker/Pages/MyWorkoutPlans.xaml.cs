
using FitnessTracker.BusinessLogic;
using FitnessTracker.DataAccess;
using FitnessTracker.DataAccess;

namespace FitnessTracker.Pages;

public partial class MyWorkoutPlans : ContentPage
{
	string _userName;
    IWorkoutManager workoutPlanManager = new WorkoutPlanJsonReader(Path.Combine(FileSystem.Current.AppDataDirectory, "WorkoutPlans.json"));
    WorkoutJsonReader workoutManager = new WorkoutJsonReader(Path.Combine(FileSystem.Current.AppDataDirectory, "Workout.json"));
	Workout _selectedWorkout;
    public Workout SelectedWorkout // property to return selected room from list view
    {
        get => _selectedWorkout;
        set
        {
            if (_selectedWorkout == value) return;
            _selectedWorkout = value;
            OnPropertyChanged(); //notifies binding targets about the change in the property 
        }
    }

    public MyWorkoutPlans(string username)
	{
		InitializeComponent();
		_userName = username;
		var workoutPlan = workoutPlanManager.ReadWorkoutPlan().Where(x=>x.UserName == _userName).FirstOrDefault();
		List<Workout> listOfWorkouts = workoutManager.ReadFromWorkoutJson();
		List<Workout> myPlan = new List<Workout>();

		try
		{
			if (workoutPlan == null)
			{
				throw new Exception("No Workout Plans Found in Your Plans");
			}
			else
			{

				foreach (var workout in workoutPlan.Workouts)
				{
					myPlan.Add(listOfWorkouts.Where(x => x.Name == workout).FirstOrDefault());
				}
				ListWorkoutPlans.ItemsSource = myPlan;
			}
		}catch(Exception c)
		{
			DisplayAlert("Alert", c.Message, "Ok");
		}
	}
    public async void BackToHomeClicked(object sender, EventArgs e)// takes user back to home page
    {
        await Navigation.PopAsync();

    }
}