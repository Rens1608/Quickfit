using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using Models;

namespace LogicLayer
{
    public class WorkoutContainer
    {
        public void Delete(int id)
        {
            WorkoutFactory.CreateWorkoutContainerDAL().Delete(id);
        }

        public void Add(WorkoutModel workout)
        {
            WorkoutFactory.CreateWorkoutContainerDAL().Add(workout);
        }

        public List<WorkoutModel> GetAll()
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().GetAll();
        }

        public List<ExerciseModel> GetExercisesInWorkout(int workoutId)
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().GetAllExercises(workoutId);
        }
    }
}
