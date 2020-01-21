using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IWorkoutContainerDAL
    {
        List<WorkoutModel> GetAll(int userId, string connectionstring);
        List<ExerciseModel> GetAllExercises(int workoutId, string connectionstring);
        void Add(WorkoutModel workoutModel, int userId, string connectionstring);
        void Delete(int id, string connectionstring);
        WorkoutModel FindById(int id, string connectionstring);
        void AddExerciseToWorkout(int userId, ExerciseModel exercise, int workoutId ,string connection);
    }
}
