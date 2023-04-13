using FitnessTracker.BusinessLogic;

namespace FitnessTracker.Pages;

public partial class UserHomePage : ContentPage
{
	NutritionManager NutritionManager = new NutritionManager();
	public UserHomePage(User user)
	{
        //BindingContext = user;
		//When homepage runs, load the users nutritional tracker
		if (NutritionManager.GetNutritionTracker(user.Username) == null)
		{
			NutritionManager.CreateNewTracker(user.Username);
		}
		//else !! get the nutrition tracker and bind it to something
		//if nutrition tracker objects date doesnt match, current date, delete it and make a new one -- this stuff is a maybe. focus on other stuff first
        InitializeComponent();

		
	}


}