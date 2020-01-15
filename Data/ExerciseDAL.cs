using System;
using System.Collections.Generic;
using ILayer;
using Models;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ExerciseDAL : IExerciseContainerDAL, IExerciseDAL
    {
        public void Add(ExerciseModel exercise, int workoutId, int userId, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string query = @"insert into [Exercises] (Name,Weight,Repetitions,Skillevel, InWorkout) values (@Name, @Weight, @Repetitions, @Skillevel, @InWorkout)";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.Parameters.Add("@Name");
                qry.Parameters["@Name"].Value = exercise.Name;
                qry.Parameters.Add("@Weight");
                qry.Parameters["@Weight"].Value = exercise.Weight;
                qry.Parameters.Add("@Repetitions");
                qry.Parameters["@Repetitions"].Value = exercise.Repetitions;
                qry.Parameters.Add("@Skillevel");
                qry.Parameters["@Skillevel"].Value = exercise.Level;
                qry.Parameters.Add("@InWorkout");
                qry.Parameters["@InWorkout"].Value = exercise.InWorkout;
                qry.ExecuteNonQuery();

                string userExerciseQuery = @"insert into [User_Exercise] (UserId, ExerciseId) values (@userId,'" + GetIdFromLastExercise(connectionstring) +"')";
                SqlCommand userExerciseQry = new SqlCommand(userExerciseQuery, connection);
                userExerciseQry.Parameters.Add("@userId");
                userExerciseQry.Parameters["@userId"].Value = userId;
                userExerciseQry.ExecuteNonQuery();

                if (workoutId != 0)
                {
                    string exerciseWorkoutQuery = @"insert into [Exercise_Workout](ExerciseId, WorkoutId) values ('"+ GetIdFromLastExercise(connectionstring) +"' , @workoutId)";
                    SqlCommand exerciseWorkoutQry = new SqlCommand(exerciseWorkoutQuery, connection);
                    exerciseWorkoutQry.Parameters.Add("@workoutId");
                    exerciseWorkoutQry.Parameters["@workoutId"].Value = workoutId;
                    exerciseWorkoutQry.ExecuteNonQuery();
                }
            }
        }

        public List<ExerciseModel> GetAll(string sortField, int userId, string connectionstring)
        {
            List<ExerciseModel> tempExercises = new List<ExerciseModel>();
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "SELECT * FROM Exercises Inner join User_Exercise on [Exercises].ExerciseId = [User_Exercise].ExerciseId where UserId = @userId AND InWorkout = 0 ORDER BY CASE WHEN @sortField = 'Name' Then Name WHEN @sortField = 'Weight' Then Weight WHEN @sortField = 'Repetitions' Then Repetitions WHEN @sortField = 'Date' Then Date END DESC",
                    Connection = connection
                };
                dataCommand.Parameters.Add("@userId", System.Data.SqlDbType.Int);
                dataCommand.Parameters["@userId"].Value = userId;
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

        public void Delete(int id, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string query = @"Delete from [Exercises] where ExerciseId = @Id";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                qry.Parameters["@Id"].Value = id;
                qry.ExecuteNonQuery();
            }
        }

        public void UpdateExercise(int id, string name, int weight, int repetitions, string skillevel, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var query = @"update Exercises set Name = @Name, Weight = @Weight, Repetitions = @Repetitions, Skillevel = @Skillevel where ExerciseId = @Id";
                using (SqlCommand qry = new SqlCommand(query, connection))
                {
                    qry.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    qry.Parameters["@Id"].Value = id;
                    qry.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Name"].Value = name;
                    qry.Parameters.Add("@Weight", System.Data.SqlDbType.Int);
                    qry.Parameters["@Weight"].Value = weight;
                    qry.Parameters.Add("@Repetitions", System.Data.SqlDbType.Int);
                    qry.Parameters["@Repetitions"].Value = repetitions;
                    qry.Parameters.Add("@Skillevel", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Skillevel"].Value = skillevel;
                    qry.ExecuteNonQuery();
                }
            }

        }

        public int GetIdFromLastExercise(string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
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

        public ExerciseModel FindById(int id, string connectionstring)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();
                    SqlCommand dataCommand = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM [dbo].[Exercises] WHERE [ExerciseId] = @Id",
                        Connection = connection
                    };
                    dataCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    dataCommand.Parameters["@Id"].Value = id;
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
