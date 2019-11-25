using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Factory;

namespace LogicLayer
{
    public class Exercise
    {
        public void UpdateExercise(int id, string name, int weight, int repetitions, string skillevel)
        {
            ExerciseFactory.CreateExerciseDAL().UpdateExercise(id, name, weight, repetitions, skillevel);
        }
    }
}
