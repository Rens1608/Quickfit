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
        public string Level { get; set; }

        public List<ExerciseModel> exercises = new List<ExerciseModel>() { 
            new ExerciseModel{Id = 1, Name = "Deadlift", Weight = 130, Repetitions = 2, Level = "Intermediate"}
        };
            
        public ExerciseModel()
        {

        }

        public ExerciseModel(int id, string name, int weight, int repetitions, string level)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Repetitions = repetitions;
            Level = level;
        }

        public ExerciseModel(string name, int weight, int repetitions, string level)
        {
            Name = name;
            Weight = weight;
            Repetitions = repetitions;
            Level = level;
        }
    }
}
