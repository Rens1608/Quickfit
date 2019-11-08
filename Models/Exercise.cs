using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum Skillevel { Beginner, Intermidiate, Advanced }
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Repetitions { get; set; }
        public string Level { get; set; }

        public Exercise()
        {

        }

        public Exercise(int id, string name, int weight, int repetitions, string level)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Repetitions = repetitions;
            Level = level;
        }

        public Exercise(string name, int weight, int repetitions, string level)
        {
            Name = name;
            Weight = weight;
            Repetitions = repetitions;
            Level = level;
        }
    }
}
