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
        public void Add(ExerciseModel exercise)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"insert into [Exercises] (Name,Weight,Repetitions,Skillevel) values ('" + exercise.Name + "','" +
                               exercise.Weight + "''" + exercise.Repetitions + "''" + exercise.Level + "')";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();
            }
        }

        public List<ExerciseModel> GetAll()
        {
            List<ExerciseModel> tempExercises = new List<ExerciseModel>();
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
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
                    ExerciseModel tempExercise = new ExerciseModel(Convert.ToInt32(userReader["ExerciseId"]), userReader["Name"].ToString(), Convert.ToInt32(userReader["Weight"]), Convert.ToInt32(userReader["Repetition"]), userReader["Skillevel"].ToString());
                    tempExercises.Add(tempExercise);
                    userReader.Close();
                    return tempExercises;
                }
            }
        }

        public void Remove(ExerciseModel exercise)
        {
            throw new NotImplementedException();
        }

        public void UpdateLevel(int id, string level)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                var query = @"update Exercise set Level='" + level + "' where Id ='" + id + "'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateName(int id, string name)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                var query = @"update Exercise set Name='" + name + "' where Id ='" + id + "'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRepetitions(int id, int repetitions)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                var query = @"update Exercise set Repetitions='" + repetitions + "' where Id ='" + id + "'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateWeight(int id, int weight)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                var query = @"update Exercise set Weight='" + weight + "' where Id ='" + id + "'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
