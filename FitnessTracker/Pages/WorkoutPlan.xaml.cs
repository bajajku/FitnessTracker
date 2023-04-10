namespace FitnessTracker.Pages;
using BusinessLogic;
using FitnessTracker.Repository;

public partial class WorkoutPlan : ContentPage
{
	JsonReader jsonReader = new JsonReader();
	List<Workout> workouts;
    Workout _selectedWorkout;
    List<string> tags = new List<string>();

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
        tags.Add("All");
        tags.AddRange(string.Join(",", workouts.Select(x=> string.Join(",",x.Tags)).ToList()).Split(",").ToList().Distinct().ToList());
        Filter.ItemsSource = tags;
        Filter.SelectedIndex= 0;
        BindingContext= this;
	}

    private void Filter_SelectedIndexChanged(object sender, EventArgs e)
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
}