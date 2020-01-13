using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Factory;

namespace LogicLayer
{
    public class ExerciseContainer
    {
        public void Delete(int id)
        {
            ExerciseFactory.CreateExerciseContainerDAL().Delete(id);
        }

        public void Add(ExerciseModel exercise, int workoutId, int userId)
        {
            ExerciseFactory.CreateExerciseContainerDAL().Add(exercise, workoutId, userId);
        }

        public List<ExerciseModel> GetAll(int userId, string sortfield = "Date")
        {
            return ExerciseFactory.CreateExerciseContainerDAL().GetAll(sortfield, userId);
        }

        public void DeleteAll()
        {
            ExerciseFactory.CreateExerciseContainerDAL().DeleteAll();
        }

        public ExerciseModel FindById(int id)
        {
            return ExerciseFactory.CreateExerciseContainerDAL().FindById(id); 
        }
    }
}
