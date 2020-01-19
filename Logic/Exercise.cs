using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Factory;

namespace LogicLayer
{
    public class Exercise
    {
        private string connectionstring;

        public Exercise(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void UpdateExercise(int id, string name, int weight, int repetitions, string skillevel)
        {
            ExerciseFactory.CreateExerciseDAL().UpdateExercise(id, name, weight, repetitions, skillevel, connectionstring);
        }

        public int GetIdFromLatestExercise()
        {
            return ExerciseFactory.CreateExerciseDAL().GetIdFromLatestExercise(connectionstring);
        }
    }
}
