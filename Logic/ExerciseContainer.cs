using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Factory;

namespace LogicLayer
{
    public class ExerciseContainer
    {
        private string connectionstring;

        public ExerciseContainer(string connectionstring)
        {
            this.connectionstring = connectionstring;
        }

        public void Delete(int id)
        {
            ExerciseFactory.CreateExerciseContainerDAL().Delete(id, connectionstring);
        }

        public void Add(ExerciseModel exercise, int userId)
        {
            ExerciseFactory.CreateExerciseContainerDAL().Add(exercise, userId, connectionstring);
        }

        public List<ExerciseModel> GetAll(int userId, string sortfield = "Date")
        {
            return ExerciseFactory.CreateExerciseContainerDAL().GetAll(sortfield, userId, connectionstring);
        }

        public ExerciseModel FindById(int id)
        {
            return ExerciseFactory.CreateExerciseContainerDAL().FindById(id, connectionstring); 
        }
    }
}
