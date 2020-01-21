using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using Models;

namespace LogicLayer
{
    public class WorkoutContainer
    {
        private string connectionstring;

        public WorkoutContainer(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void Delete(int id)
        {
            WorkoutFactory.CreateWorkoutContainerDAL().Delete(id, connectionstring);
        }

        public void Add(WorkoutModel workout, int userId)
        {
            WorkoutFactory.CreateWorkoutContainerDAL().Add(workout, userId, connectionstring);
        }

        public List<WorkoutModel> GetAll(int userId)
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().GetAll(userId, connectionstring);
        }

        public List<ExerciseModel> GetExercisesInWorkout(int workoutId)
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().GetAllExercises(workoutId, connectionstring);
        }
        public WorkoutModel FindById(int id)
        {
            return WorkoutFactory.CreateWorkoutContainerDAL().FindById(id, connectionstring);
        }

        public void AddExerciseToWorkout(int userId, ExerciseModel exercise, int workoutId)
        {
            WorkoutFactory.CreateWorkoutContainerDAL().AddExerciseToWorkout(userId, exercise,workoutId,connectionstring);
        }
    }
}
