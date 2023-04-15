
using FitnessTracker.BusinessLogic;
using FitnessTracker.DataAccess;
using System.Collections.ObjectModel;

namespace FitnessTracker.Pages;

public partial class MyWorkoutPlans : ContentPage
{
	string _userName;
    IWorkoutManager workoutPlanManager = new WorkoutPlanJsonReader(Path.Combine(FileSystem.Current.AppDataDirectory, "WorkoutPlans.json"));
    WorkoutJsonReader workoutManager = new WorkoutJsonReader(Path.Combine(FileSystem.Current.AppDataDirectory, "Workout.json"));
	Workout _selectedWorkout;
    ObservableCollection<Workout> myPlan;
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
		myPlan = new ObservableCollection<Workout>();
		BindingContext = this;
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

    private async void RemoveWorkoutClicked(object sender, EventArgs e)
    {
        Workout selectedWorkout = (Workout)ListWorkoutPlans.SelectedItem;
        if (selectedWorkout == null)
        {
            await DisplayAlert("Selection Error", "No Workout is Selected", "Ok");
        }
        else
        {
            try
            {
                myPlan.Remove(selectedWorkout);
                workoutPlanManager.RemoveWorkoutPlan(selectedWorkout.Name, _userName);
                await DisplayAlert("Success", "Workout has been successfully removed from plan", "Ok");

            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
            //await Navigation.PushAsync(new NewPage1(selectedWorkout));
        }
    }
}