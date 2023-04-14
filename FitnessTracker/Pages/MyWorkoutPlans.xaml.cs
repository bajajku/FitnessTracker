using FitnessTracker.BusinessLogic;
using FitnessTracker.DataAccess;
using System.Collections.Generic;

namespace FitnessTracker.Pages;

public partial class MyWorkoutPlans : ContentPage
{
	string _userName;
	public MyWorkoutPlans(string username)
	{
		InitializeComponent();
		_userName = username;
		var workoutPlan = WorkoutJsonReader.ReadWorkoutPlan().Where(x=>x.UserName == _userName).FirstOrDefault();
		List<Workout> listOfWorkouts = WorkoutJsonReader.ReadFromWorkoutJson();
		List<Workout> myPlan = new List<Workout>();

		try
		{
			if (workoutPlan == null)
			{
				throw new Exception("No Workout Plans Found in Your Plans");
			}
			else
			{

				foreach (var workout in workoutPlan.Workouts)
				{
					myPlan.Add(listOfWorkouts.Where(x => x.Name == workout).FirstOrDefault());
				}
				ListMyPlan.ItemsSource = myPlan;
			}
		}catch(Exception c)
		{
			DisplayAlert("Alert", c.Message, "Ok");
		}
	}
}