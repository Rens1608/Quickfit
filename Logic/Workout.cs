using System;
using System.Collections.Generic;
using System.Text;
using Factory;

namespace LogicLayer
{
    public class Workout
    {
        private string connectionstring;

        public Workout(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void UpdateWorkout(int id, string name, string skillevel, int time, string category)
        {
            WorkoutFactory.CreateWorkoutDAL().UpdateWorkout(id, name, skillevel, time, category, connectionstring);
        }
    }
}
