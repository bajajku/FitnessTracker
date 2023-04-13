using FitnessTracker.BusinessLogic;
using FitnessTracker.DataAccess;
using System.Collections.Generic;

namespace FitnessTracker.Pages;

public partial class NewPage1 : ContentPage
{
	string _userName;
	public NewPage1(string username)
	{
		InitializeComponent();
		_userName = username;
		var workoutPlan = WorkoutJsonReader.ReadWorkoutPlan().Where(x=>x.UserName == _userName).FirstOrDefault();
		List<Workout> listOfWorkouts = WorkoutJsonReader.ReadFromWorkoutJson();
		List<Workout> myPlan = new List<Workout>();

        foreach (var workout in workoutPlan.Workouts)
		{
			myPlan.Add(listOfWorkouts.Where(x => x.Name == workout).FirstOrDefault());
		}
		ListMyPlan.ItemsSource = myPlan;
	}
}