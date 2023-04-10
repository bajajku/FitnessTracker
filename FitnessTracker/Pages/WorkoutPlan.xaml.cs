namespace FitnessTracker.Pages;
using BusinessLogic;
using FitnessTracker.Repository;

public partial class WorkoutPlan : ContentPage
{
	JsonReader jsonReader = new JsonReader();
	List<Workout> workouts;
    Workout _selectedWorkout;
    List<string> tags;

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

    public WorkoutPlan()
	{
		InitializeComponent();
		workouts = jsonReader.Workouts;
		ListWorkoutPlans.ItemsSource = workouts;
        tags = string.Join(",", workouts.Select(x=> x.Tags).ToList()).Split(",").ToList().Distinct().ToList();
        Filter.ItemsSource = tags;
        BindingContext= this;
	}
}