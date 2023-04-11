using FitnessTracker.Pages;

namespace FitnessTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new UserLoginPage());
	}
}
