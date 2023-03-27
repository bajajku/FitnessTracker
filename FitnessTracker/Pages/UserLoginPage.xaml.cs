using Android.OS;
using Microsoft.Maui.Graphics.Text;
using FitnessTracker.BusinessLogic;
using Android.Hardware.Lights;

namespace FitnessTracker.Pages;

public partial class UserLoginPage : ContentPage
{
    FitUserManager _fitUserManager = new FitUserManager();
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
        if (NewAccount.IsChecked) { PhysDataEntry.IsVisible = true; } //shows the user data entry section, allowing the user to enter their info 
        else if (!NewAccount.IsChecked) { PhysDataEntry.IsVisible = false; } //hides the user data entry section
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        if (NewAccount.IsChecked) { NewUserFromEntry(); }
        //move to main user page.
    }

    public void NewUserFromEntry()
    {
        if ((UsernameEntry.Text).Length > 0) //makes sure there is actual entry for username
        {
            string username = UsernameEntry.Text; // is ensured to be unique by the AddUser method.
            if ((PasswordEntry.Text).Length > 0) // makes sure there is a entered password.
            {
                string password = PasswordEntry.Text;
                DateTime dob = DoBPicker.Date;
                if (float.Parse(HeightEntry.Text) > 0) //makes sure height is above 0
                {
                    float height = float.Parse(HeightEntry.Text);
                    if (float.Parse(WeightEntry.Text) > 0) //makes sure weight is above 0
                    {
                        float weight = float.Parse(WeightEntry.Text);
                        _fitUserManager.AddUser(username, password, dob, height, weight); //adds the user.
                        //TODO: this line will navigate to the User Page from this page.
                    }

                }
            }

        }
        //NEEDS PROPER EXCEPTION HANDLING .. i think...
    }

    public void LoginFromEntry()
    {
        if ((UsernameEntry.Text).Length > 0) //makes sure there is actual entry for username
        {
            string username = UsernameEntry.Text; // is ensured to be unique by the AddUser method.
            if ((PasswordEntry.Text).Length > 0) // makes sure there is a entered password.
            {
                string password = PasswordEntry.Text;
                _fitUserManager.Login(username, password); //returns User. TODO: this line will navigate to the User Page from this page.
            }
        }
    }
}