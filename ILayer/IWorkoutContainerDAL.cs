using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IWorkoutContainerDAL
    {
        List<WorkoutModel> GetAll();
        List<ExerciseModel> GetAllExercises(int workoutId);
        void Add(WorkoutModel workoutModel);
        void Delete(int id);
    }
}
