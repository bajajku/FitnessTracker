//using Android.OS;
using Microsoft.Maui.Graphics.Text;
using FitnessTracker.BusinessLogic;
//using Java.Lang;
//using Android.Hardware.Lights;

namespace FitnessTracker.Pages;

public partial class UserLoginPage : ContentPage
{
    FitUserManager _fitUserManager = new FitUserManager();

    //IUserDataManager _userDataManager = new UserJsonManager(Path.Combine(FileSystem.Current.AppDataDirectory, "users.json"));
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
        if (NewAccount.IsChecked) NewUserFromEntry();
        LoginFromEntry(); //always tries to login, if newaccount is checked, it will create a user FIRST

    }

    public void NewUserFromEntry()
    {
        //error handling ver:
        try
        {
            if (string.IsNullOrEmpty(UsernameEntry.Text) == true) throw new Exception("Username Cannot be Empty");
            string username = UsernameEntry.Text;
            if (string.IsNullOrEmpty(PasswordEntry.Text) == true) throw new Exception("Password Cannot be Empty");
            string password = PasswordEntry.Text;
            DateTime dob = DoBPicker.Date;
            if (string.IsNullOrEmpty(HeightEntry.Text) == true || float.Parse(HeightEntry.Text) <= 0) throw new Exception("Height must be greater than 0");
            float height = float.Parse(HeightEntry.Text);
            if (string.IsNullOrEmpty(WeightEntry.Text) == true || float.Parse(WeightEntry.Text) <= 0) throw new Exception("Weight must be greater than 0");
            float weight = float.Parse(WeightEntry.Text);
            _fitUserManager.AddUser(username, password, dob, height, weight);
  //          _fitUserManager.SaveData(_userDataManager);
        }
        catch (Exception N)
        {
            HandleInputError(N.Message);
        }

    }

    public void HandleInputError(string message)
    {
        DisplayAlert("Couldn't Continue", message, "Ok.");
    }

    public async void LoginFromEntry()
    {
        try
        {
            if (string.IsNullOrEmpty(UsernameEntry.Text) == true) throw new Exception("Username Cannot be Empty");
            string username = UsernameEntry.Text;
            if (string.IsNullOrEmpty(PasswordEntry.Text) == true) throw new Exception("Password Cannot be Empty");
            string password = PasswordEntry.Text;

            if (_fitUserManager.Login(username, password) == null)
            {
                PasswordEntry.Text= string.Empty;
                throw new Exception("Username or Password is incorrect");
            }
            else
            {
                //navigate to homepage
               
                User loggedInUser = _fitUserManager.Login(username, password);
                if (loggedInUser == null)
                {
                    PasswordEntry.Text = string.Empty;
                    throw new Exception("Username or Password is incorrect");
                }
                UserHomePage _userHomePage = new UserHomePage(loggedInUser);//parameter should be the fuckin uh, the user manager i think? cause the index of the user is the key for everything else.
                _userHomePage.BindingContext = loggedInUser; //binding context of user page is the goddamn user!!! as GOD intended!!
                await Navigation.PushAsync(_userHomePage);
            }
            
        }
        catch(Exception N)
        {
            HandleInputError(N.Message);
        }

    }


}