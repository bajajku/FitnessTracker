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
        

		
	}


}