using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IExerciseContainerDAL
    {
        List<ExerciseModel> GetAll(string sortField, int userId, string connectionstring);
        void Add(ExerciseModel exercise, int workoutId, int userId, string connectionstring);
        void Delete( int id, string connectionstring);
        ExerciseModel FindById(int id, string connectionstring);
    }
}
