using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum Category { Bodybuilding, Powerlifting, Weightloss, Calisthenics}
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Skillevel Skillevel { get; set; }
        public int Time { get; set; }
        public int CaloriesBurned { get; set; }
        public Category category { get; set; }

        public Workout(int id, string name, Skillevel skillevel, int time, int caloriesBurned, Category category)
        {
            Id = id;
            Name = name;
            Skillevel = skillevel;
            Time = time;
            CaloriesBurned = caloriesBurned;
            this.category = category;
        }

        public Workout(string name, Skillevel skillevel, int time, int caloriesBurned, Category category)
        {
            Name = name;
            Skillevel = skillevel;
            Time = time;
            CaloriesBurned = caloriesBurned;
            this.category = category;
        }

        public Workout()
        {

        }
    }
}
