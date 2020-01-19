﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public enum Category { Bodybuilding, Powerlifting, Weightloss, Calisthenics}
    public class WorkoutModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Skillevel { get; set; }
        [Required]
        public int Time { get; set; }
        public int CaloriesBurned { get; set; }
        [Required]
        public string Category { get; set; }
        public List<ExerciseModel> Exercises { get; set; }
        public int AmountOfExercises { get; set; }

        public WorkoutModel(int id, string name, string skillevel, int time, int caloriesBurned, string category, int amountOfExercises)
        {
            Id = id;
            Name = name;
            Skillevel = skillevel;
            Time = time;
            CaloriesBurned = caloriesBurned;
            Category = category;
            AmountOfExercises = amountOfExercises;
        }

        public WorkoutModel(string name, string skillevel, int time, int caloriesBurned, string category, List<ExerciseModel> exercises)
        {
            Name = name;
            Skillevel = skillevel;
            Time = time;
            CaloriesBurned = caloriesBurned;
            Category = category;
            Exercises = exercises;
        }

        public WorkoutModel()
        {

        }
    }
}
