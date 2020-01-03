using System;
using System.Collections.Generic;
using ILayer;
using Models;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ExerciseDAL : IExerciseContainerDAL, IExerciseDAL
    {
        public void Add(ExerciseModel exercise, int workoutId, int userId)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"insert into [Exercises] (Name,Weight,Repetitions,Skillevel, InWorkout) values ('" + exercise.Name + "','" +
                exercise.Weight + "','" + exercise.Repetitions + "','" + exercise.Level + "','" + exercise.InWorkout + "')";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();

                string userExerciseQuery = @"insert into [User_Exercise] (UserId, ExerciseId) values ('"+ userId +"','" + GetIdFromLastExercise() +"')";
                SqlCommand userExerciseQry = new SqlCommand(userExerciseQuery, connection);
                userExerciseQry.ExecuteNonQuery();

                if (workoutId != 0)
                {
                    string exerciseWorkoutQuery = @"insert into [Exercise_Workout](ExerciseId, WorkoutId) values ('"+ GetIdFromLastExercise() +"' , '" + workoutId + "')";
                    SqlCommand exerciseWorkoutQry = new SqlCommand(exerciseWorkoutQuery, connection);
                    exerciseWorkoutQry.ExecuteNonQuery();
                }
            }
        }

        public List<ExerciseModel> GetAll(string sortField, int userId)
        {
            List<ExerciseModel> tempExercises = new List<ExerciseModel>();
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "SELECT * FROM Exercises Inner join User_Exercise on [Exercises].ExerciseId = [User_Exercise].ExerciseId where UserId = '" + userId +"' AND InWorkout = 0 ORDER BY CASE WHEN @sortField = 'Name' Then Name WHEN @sortField = 'Weight' Then Weight WHEN @sortField = 'Repetitions' Then Repetitions WHEN @sortField = 'Date' Then Date END DESC",
                    Connection = connection
                };
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@sortfield";
                sqlParameter.Value = sortField;
                dataCommand.Parameters.Add(sqlParameter);
                using (SqlDataReader exerciseReader = dataCommand.ExecuteReader())
                {
                    while (exerciseReader.Read())
                    {
                        ExerciseModel tempExercise = new ExerciseModel(Convert.ToInt32(exerciseReader["ExerciseId"]), exerciseReader["Name"].ToString(), Convert.ToInt32(exerciseReader["Weight"]), Convert.ToInt32(exerciseReader["Repetitions"]), ((DateTime)exerciseReader["Date"]).ToString("d/M/yyyy HH:mm:ss"), exerciseReader["Skillevel"].ToString(), (bool)exerciseReader["InWorkout"]);
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

        public void DeleteAll()
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"Delete from [Exercises] where inWorkout = 0";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();
            }
        }

        public ExerciseModel GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                try
                {
                    connection.Open();
                    SqlCommand dataCommand = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM [dbo].[Exercises] WHERE [ExerciseId] = '" + id + "'",
                        Connection = connection
                    };
                    using (SqlDataReader exerciseReader = dataCommand.ExecuteReader())
                    {
                        exerciseReader.Read();
                        return new ExerciseModel(Convert.ToInt32(exerciseReader["ExerciseId"]), exerciseReader["Name"].ToString(), Convert.ToInt32(exerciseReader["Weight"]), Convert.ToInt32(exerciseReader["Repetitions"]), exerciseReader["Date"].ToString(), exerciseReader["Skilllevel"].ToString(), Convert.ToBoolean(exerciseReader["InWorkout"]));
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
