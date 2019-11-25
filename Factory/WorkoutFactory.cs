using System;
using System.Collections.Generic;
using System.Text;
using ILayer;
using DataLayer;

namespace Factory
{
    public class WorkoutFactory
    {
        public static IWorkoutDAL CreateWorkoutDAL()
        {
            IWorkoutDAL workoutDAL = new WorkoutDAL();
            return workoutDAL;
        }
        public static IWorkoutContainerDAL CreateWorkoutContainerDAL()
        {
            IWorkoutContainerDAL workoutContainerDAL = new WorkoutDAL();
            return workoutContainerDAL;
        }
    }
}
