using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IExerciseContainerDAL
    {
        List<ExerciseModel> GetAll(string sortField);
        void Add(ExerciseModel exercise, int workoutId);
        void Delete( int id);
    }
}
