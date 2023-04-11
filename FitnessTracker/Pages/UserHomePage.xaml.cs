using FitnessTracker.BusinessLogic;

namespace FitnessTracker.Pages;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(User user)
	{
        //BindingContext = user;
        InitializeComponent();
		
	}
}