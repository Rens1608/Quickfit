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

        public void Add(WorkoutModel workout, int userId)
        {
            WorkoutFactory.CreateWorkoutContainerDAL().Add(workout, userId);
        }

        public List<WorkoutModel> GetAll(int userId)
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().GetAll(userId);
        }

        public List<ExerciseModel> GetExercisesInWorkout(int workoutId)
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().GetAllExercises(workoutId);
        }
        public WorkoutModel FindById(int id)
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().FindById(id);
        }
    }
}
