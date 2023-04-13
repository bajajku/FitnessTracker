using FitnessTracker.BusinessLogic;
using FitnessTracker.DataAccess;

namespace FitnessTracker.Pages;

public partial class UserHomePage : ContentPage
{
	NutritionManager _nutritionManager = new NutritionManager();
	INutritionDataManager _nutritionDataManager = new NutritionJsonManager(Path.Combine(FileSystem.Current.AppDataDirectory,"nutrition.json"));
	NutritionTracker _nutritionTracker;
	public UserHomePage(User user)
	{
        //BindingContext = user;
        InitializeComponent();
		try
		{
			_nutritionManager.ReadAllNutritionTrackers(_nutritionDataManager); //tries to load from file
		}
		catch (FileNotFoundException)
		{
			_nutritionManager.SaveAllNutritionTrackers(_nutritionDataManager); //if no file found, creates new one. 
		}
		
		_nutritionTracker = _nutritionManager.GetNutritionTracker(user.Username); //When homepage runs, load the users nutritional tracker
        if (_nutritionManager.GetNutritionTracker(user.Username) == null)//if the nutrition tracker doesnt exist, create the nutrition tracker and bind it to something
        {
			_nutritionTracker = _nutritionManager.CreateNewTracker(user.Username);
        }
		_nutritionTracker.DateRefresh();//if nutrition tracker objects date doesnt match, current date, reset the values to 0 (everything except the username) and update to current date
										//Set the labels with the users personal information
		TitleLabel.Text = $"Welcome {user.Username}.";
		HeightLabel.Text = $"Height: {user.Height}";
		WeightLabel.Text = $"Weight: {user.Weight}";
        DobLabel.Text = $"Date of Birth: {user.Dob}";
		BmiLabel.Text = $"BMI: {user.Bmi}";

		BindingContext= _nutritionTracker;

    }

    private void SubmitNewNutritionEntry(object sender, EventArgs e)
    {
		int calories = int.Parse(CalorieEntry.Text);
        int fat = int.Parse(FatEntry.Text);
		int carbs = int.Parse(CarbsEntry.Text);
		int protein = int.Parse(ProteinEntry.Text);
		int sodium = int.Parse(SodiumEntry.Text);
		_nutritionTracker.UpdateNutrition(calories, fat,carbs, protein, sodium);
		_nutritionManager.SaveAllNutritionTrackers(_nutritionDataManager);
    }
    private async void ViewWorkoutClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AddWorkoutPlan()); //
    }
}