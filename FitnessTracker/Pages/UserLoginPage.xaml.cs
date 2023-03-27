namespace FitnessTracker.Pages;

public partial class UserLoginPage : ContentPage
{
	public UserLoginPage()
	{
		InitializeComponent();
        DateTime MaximumDoB = DateTime.Today;
        TimeSpan ThirteenYears = new TimeSpan(4745, 0, 0, 0); 
        MaximumDoB = MaximumDoB - ThirteenYears;
        DoBPicker.MaximumDate = MaximumDoB;
	}

    private void NewAccountCheckChanged(object sender, CheckedChangedEventArgs e)
    {
        if (NewAccount.IsChecked) { PhysDataEntry.IsVisible= true; }
        else if (!NewAccount.IsChecked) { PhysDataEntry.IsVisible= false; }
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        if (!NewAccount.IsChecked) { }
    }

    public void NewUserFromEntry()
    {

    }
}