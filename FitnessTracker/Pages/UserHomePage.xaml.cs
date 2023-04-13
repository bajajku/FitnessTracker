using FitnessTracker.BusinessLogic;
using FitnessTracker.DataAccess;

namespace FitnessTracker.Pages;

public partial class UserHomePage : ContentPage
{
	NutritionManager _nutritionManager = new NutritionManager();
	INutritionDataManager _nutritionDataManager = new NutritionJsonManager(Path.Combine(FileSystem.Current.AppDataDirectory,"nutrition.json"));
	public UserHomePage(User user)
	{
        //BindingContext = user;
        InitializeComponent();
        //When homepage runs, load the users nutritional tracker
		try
		{
			_nutritionManager.
		}
        //if the nutrition tracker doesnt exist, create the nutrition tracker and bind it to something
        if (_nutritionManager.GetNutritionTracker(user.Username) == null)
		{
			_nutritionManager.CreateNewTracker(user.Username);
		}
		
		//if nutrition tracker objects date doesnt match, current date, delete it and make a new one -- this stuff is a maybe. focus on other stuff first
        

		
	}


}