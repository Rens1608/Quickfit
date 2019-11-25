using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum Skillevel { Beginner, Intermidiate, Advanced }
    public class ExerciseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Repetitions { get; set; }
        public string Date { get; set; }
        public string Level { get; set; }
        public bool InWorkout { get; set; }
            
        public ExerciseModel()
        {

        }

        public ExerciseModel(int id, string name, int weight, int repetitions, string date, string level, bool inWorkout)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Repetitions = repetitions;
            Date = date;
            Level = level;
            InWorkout = inWorkout;
        }

        public ExerciseModel(string name, int repetitions, string level)
        {
            Name = name;
            Repetitions = repetitions;
            Level = level;
        }
    }
}
