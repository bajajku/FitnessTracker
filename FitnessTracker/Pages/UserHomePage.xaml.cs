using FitnessTracker.BusinessLogic;

namespace FitnessTracker.Pages;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(User user)
	{
		InitializeComponent();
		HomePageViewModel hpvm = new HomePageViewModel();
		hpvm.User = user;
		BindingContext = hpvm;
	}
}