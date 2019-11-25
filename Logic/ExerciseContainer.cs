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

        public void Add(ExerciseModel exercise, int workoutId)
        {
            ExerciseFactory.CreateExerciseContainerDAL().Add(exercise, workoutId);
        }

        public List<ExerciseModel> GetAll()
        {
            return ExerciseFactory.CreateExerciseContainerDAL().GetAll();
        }
    }
}
