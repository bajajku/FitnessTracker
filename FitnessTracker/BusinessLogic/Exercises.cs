﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessTracker.BusinessLogic
{
    // class to store exercises
   public class Exercise
   {
        //field variables for exercises
        string _name;
        string _primaryMuscle;
        string _secondaryMuscle;
        int _sets;
        int _reps;
        string _image;
        [JsonPropertyOrder(1)]
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _name; }
            set 
            {   if (value == null) throw new ArgumentNullException();
                
                _name = value;
            }
        }

        [JsonPropertyName("primaryMuscle")]
        [JsonPropertyOrder(4)]

        public string PrimaryMuscle { get=> _primaryMuscle; set { _primaryMuscle = value; } }

        [JsonPropertyName("secondaryMuscle")]
        [JsonPropertyOrder(5)]
        public string SecondaryMuscle { get => _secondaryMuscle; set { _secondaryMuscle = value; } }

        [JsonPropertyName("sets")]
        [JsonPropertyOrder(2)]
        public int Sets { get => _sets; set { _sets = value; } }

        [JsonPropertyName("reps")]
        [JsonPropertyOrder(3)]
        public int Reps { get => _reps; set { _reps = value; } }

        [JsonPropertyName("image")]
        [JsonPropertyOrder(6)]
        public string Image { get=> _image; set { _image = value; } }

        public Exercise(string name, int sets, int reps, string primaryMuscle, string secondaryMuscle,string image) // constructor for exercises
        {
            Name = name;
            PrimaryMuscle = primaryMuscle;
            SecondaryMuscle= secondaryMuscle;
            Sets= sets;
            Reps = reps;
            Image = image;
        }

    }

}
