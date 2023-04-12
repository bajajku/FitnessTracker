using FitnessTracker.BusinessLogic;

namespace FitnessTracker.Pages;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(User user)
	{
        //BindingContext = user;
		//When homepage runs, load the users nutritional tracker
		//search nutritional tracker dictionary, dictionary key is username, value is nutritiontracker object.
		//if nutrition tracker objects date doesnt match, current date, delete it and make a new one
        InitializeComponent();
		
	}


}