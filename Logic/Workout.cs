using System;
using System.Collections.Generic;
using System.Text;
using Factory;

namespace LogicLayer
{
    public class Workout
    {
        public void UpdateWorkout(int id, string name, string skillevel, int time, string category)
        {
            WorkoutFactory.CreateWorkoutDAL().UpdateWorkout(id, name, skillevel, time, category);
        }
    }
}
