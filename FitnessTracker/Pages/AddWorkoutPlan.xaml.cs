namespace FitnessTracker.Pages;
using BusinessLogic;
using FitnessTracker.DataAccess;

public partial class AddWorkoutPlan : ContentPage
{
    // variables to store data
	List<Workout> workouts;
    Workout _selectedWorkout;
    List<string> tags = new List<string>();
    // creating instances with correct file path
    WorkoutJsonReader workoutManager = new WorkoutJsonReader(Path.Combine(FileSystem.Current.AppDataDirectory, "Workout.json"));
    IWorkoutManager workoutPlanManager = new WorkoutPlanJsonReader(Path.Combine(FileSystem.Current.AppDataDirectory, "WorkoutPlans.json"));

    User _user;
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

    public AddWorkoutPlan(User user) // Let User add workouts to their plans
	{
		InitializeComponent();
        _user = user;
		workouts = workoutManager.Workouts;
		ListWorkoutPlans.ItemsSource = workouts;
        tags.Add("All");
        tags.AddRange(string.Join(",", workouts.Select(x=> string.Join(",",x.Tags)).ToList()).Split(",").ToList().Distinct().ToList());
        Filter.ItemsSource = tags;
        Filter.SelectedIndex= 0;
        BindingContext= this;
	}

    private void Filter_SelectedIndexChanged(object sender, EventArgs e)// to filter workout plans via picker
    {
        var selectedItem = Filter.SelectedItem.ToString();
        if(selectedItem != "All")
        {
            ListWorkoutPlans.ItemsSource = workouts.Where(x => x.Tags.Contains(selectedItem)).ToList();
        }
        else
        {
            ListWorkoutPlans.ItemsSource = workouts;
        }
    }

    private async void AddPlanClicked(object sender, EventArgs e)// Event handler for add plan button clicked
    {
        Workout selectedWorkout = (Workout)ListWorkoutPlans.SelectedItem;
        if(selectedWorkout == null)
        {
            await DisplayAlert("Selection Error","No Workout is Selected","Ok");
        }
        else
        {
            workoutPlanManager.WriteWorkoutPlan(selectedWorkout.Name,_user.Username);
            await DisplayAlert("Success", "Workout has been successfully added", "Ok");
            //await Navigation.PushAsync(new NewPage1(selectedWorkout));
        }
    }

    public async void BackToHomeClicked(object sender, EventArgs e)// takes user back to home page
    {
        await Navigation.PopAsync();

    }
}