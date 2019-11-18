using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Factory;

namespace LogicLayer
{
    public class Exercise
    {
        public void UpdateName(int id, string name)
        {
            ExerciseFactory.CreateExerciseDAL.UpdateName(id, name);
        }
        public void UpdateWeight(int id, int weight)
        {
            ExerciseFactory.CreateExerciseDAL.UpdateWeight(id, weight);
        }
        public void UpdateRepetitions(int id, int repetitions)
        {
            ExerciseFactory.CreateExerciseDAL.UpdateRepetitions(id, repetitions);
        }
        public void UpdateLevel (int id, string level)
        {
            ExerciseFactory.CreateExerciseDAL.UpdateLevel(id, level);
        }
    }
}
