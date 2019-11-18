using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Factory;

namespace LogicLayer
{
    public class ExerciseContainer
    {
        public Exercise GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(ExerciseModel exercise)
        {
            ExerciseFactory.CreateExerciseContainerDAL.Add(exercise);
        }

        public IList<ExerciseModel> GetAll()
        {
            return ExerciseFactory.CreateExerciseContainerDAL.GetAll();
        }
    }
}
