using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ILayer;
using Models;


namespace DataLayer
{
    public class ExerciseDAL : IExerciseContainerDAL, IExerciseDAL
    {
        public void Add(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public List<Exercise> GetAll()
        {
            List<Exercise> tempExercises = new List<Exercise>();
            using (SqlConnection connection = new SqlConnection(Connection.GetConnectionstring()))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "SELECT * FROM [dbo].[Exercises]",
                    Connection = connection
                };
                using (SqlDataReader userReader = dataCommand.ExecuteReader())
                {
                    userReader.Read();
                    Exercise tempExercise = new Exercise(Convert.ToInt32(userReader["ExerciseId"]), userReader["Name"].ToString(), Convert.ToInt32(userReader["Weight"]), Convert.ToInt32(userReader["Repetition"]), userReader["Skillevel"].ToString());
                    tempExercises.Add(tempExercise);
                    userReader.Close();
                    return tempExercises;
                }
            }
        }

        public void Remove(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public void UpdateLevel()
        {
            throw new NotImplementedException();
        }

        public void UpdateName()
        {
            throw new NotImplementedException();
        }

        public void UpdateRepetitions()
        {
            throw new NotImplementedException();
        }

        public void UpdateWeight()
        {
            throw new NotImplementedException();
        }
    }
}
