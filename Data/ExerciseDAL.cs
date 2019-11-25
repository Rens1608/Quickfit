using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ILayer;
using java.util;
using Models;


namespace DataLayer
{
    public class ExerciseDAL : IExerciseContainerDAL, IExerciseDAL
    {
        public void Add(ExerciseModel exercise, int workoutId)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"insert into [Exercises] (Name,Weight,Repetitions,Skillevel, InWorkout) values ('" + exercise.Name + "','" +
                exercise.Weight + "','" + exercise.Repetitions + "','" + exercise.Level + "','" + exercise.InWorkout + "')";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();

                if (workoutId != 0)
                {
                    string junctionQuery = @"insert into [Exercise_Workout](ExerciseId, WorkoutId) values ('"+ GetIdFromLastExercise() +"' , '" + workoutId + "')";
                    SqlCommand junctionQry = new SqlCommand(junctionQuery, connection);
                    junctionQry.ExecuteNonQuery();
                }
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
                    CommandText = "SELECT * FROM [dbo].[Exercises] WHERE [InWorkout] = 0",
                    Connection = connection
                };
                using (SqlDataReader exerciseReader = dataCommand.ExecuteReader())
                {
                    while (exerciseReader.Read())
                    {
                        ExerciseModel tempExercise = new ExerciseModel(Convert.ToInt32(exerciseReader["ExerciseId"]), exerciseReader["Name"].ToString(), Convert.ToInt32(exerciseReader["Weight"]), Convert.ToInt32(exerciseReader["Repetitions"]),((DateTime)exerciseReader["Date"]).ToString("d/M/yyyy HH:mm:ss"), exerciseReader["Skillevel"].ToString(), (bool)exerciseReader["InWorkout"]);
                        tempExercises.Add(tempExercise);
                    }
                    exerciseReader.Close();
                    return tempExercises;
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"Delete from [Exercises] where ExerciseId = '"+ id +"'";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();
            }
        }

        public void UpdateExercise(int id, string name, int weight, int repetitions, string skillevel)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                var query = @"update Exercises set Name ='" + name + "', Weight ='" + weight + "', Repetitions ='" + repetitions + "', Skillevel ='" + skillevel + "' where ExerciseId = '" + id + "'";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.ExecuteNonQuery();
                }
            }

        }

        public int GetIdFromLastExercise()
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "Select Top 1 ExerciseId From [Exercises] Order By ExerciseId Desc",
                    Connection = connection
                };
                using (SqlDataReader exerciseReader = dataCommand.ExecuteReader())
                {
                    exerciseReader.Read();
                    return Convert.ToInt32(exerciseReader["ExerciseId"]);
                }
            }
        }
    }
}
