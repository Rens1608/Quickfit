using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IWorkoutContainerDAL
    {
        List<WorkoutModel> GetAll(int userId);
        List<ExerciseModel> GetAllExercises(int workoutId);
        void Add(WorkoutModel workoutModel, int userId);
        void Delete(int id);
    }
}
