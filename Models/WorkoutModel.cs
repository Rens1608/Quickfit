using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum Category { Bodybuilding, Powerlifting, Weightloss, Calisthenics}
    public class WorkoutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skillevel { get; set; }
        public int Time { get; set; }
        public int CaloriesBurned { get; set; }
        public string Category { get; set; }
        public List<ExerciseModel> Exercises { get; set; }

        public WorkoutModel(int id, string name, string skillevel, int time, int caloriesBurned, string category)
        {
            Id = id;
            Name = name;
            Skillevel = skillevel;
            Time = time;
            CaloriesBurned = caloriesBurned;
            Category = category;
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
