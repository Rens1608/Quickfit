using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IExerciseContainerDAL
    {
        List<ExerciseModel> GetAll(string sortField, int userId);
        void Add(ExerciseModel exercise, int workoutId, int userId);
        void Delete( int id);
        void DeleteAll();
        ExerciseModel FindById(int id);
    }
}
