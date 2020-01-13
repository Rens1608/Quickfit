using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ILayer;
using Models;

namespace DataLayer
{
    public class WorkoutDAL : IWorkoutContainerDAL, IWorkoutDAL
    {
        public void Add(WorkoutModel workout, int userId)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"insert into [Workouts] (Name, Skillevel, Category, Time, CaloriesBurned) values (@Name, @Skillevel, @Time, @Caloriesburned)";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
                qry.Parameters["@Name"].Value = workout.Name;
                qry.Parameters.Add("@Skillevel", System.Data.SqlDbType.VarChar);
                qry.Parameters["@Skillevel"].Value = workout.Skillevel;
                qry.Parameters.Add("@Category", System.Data.SqlDbType.VarChar);
                qry.Parameters["@Category"].Value = workout.Category;
                qry.Parameters.Add("@Time", System.Data.SqlDbType.Int);
                qry.Parameters["@Time"].Value = workout.Time;
                qry.Parameters.Add("@Caloriesburned", System.Data.SqlDbType.Int);
                qry.Parameters["@Caloriesburned"].Value = workout.Time * 4;
                qry.ExecuteNonQuery();

                string userExerciseQuery = @"insert into [User_Workout] (UserId, WorkoutId) values ('" + userId + "','" + workout.Id + "')";
                SqlCommand userExerciseQry = new SqlCommand(userExerciseQuery, connection);
                userExerciseQry.ExecuteNonQuery();
            }
        }
        
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"Delete from [Workouts] where WorkoutId = @Id";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                qry.Parameters["@Id"].Value = id;
                qry.ExecuteNonQuery();
            }
        }

        public List<WorkoutModel> GetAll(int userId)
        {
            List<WorkoutModel> tempWorkouts = new List<WorkoutModel>();
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "SELECT * FROM [dbo].[Workouts] Inner join User_Workout on [Workouts].WorkoutId = User_Workout.WorkoutId where UserId = @Id SELECT COUNT(Exercise_Workout.ExerciseId) AS NumberOfExercises FROM Exercise_Workout LEFT JOIN Workouts ON Exercise_Workout.WorkoutId = Workouts.WorkoutId GROUP BY Workouts.name ",
                    Connection = connection
                };
                dataCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                dataCommand.Parameters["@Id"].Value = userId;
                using (SqlDataReader workoutReader = dataCommand.ExecuteReader())
                {
                    while (workoutReader.Read())
                    {
                        WorkoutModel tempWorkout = new WorkoutModel(Convert.ToInt32(workoutReader["WorkoutId"]), workoutReader["Name"].ToString(), workoutReader["Skillevel"].ToString(), Convert.ToInt32(workoutReader["Time"]), Convert.ToInt32(workoutReader["CaloriesBurned"]), workoutReader["Category"].ToString(), GetAmountOfExercises(Convert.ToInt32(workoutReader["WorkoutId"])));
                        tempWorkouts.Add(tempWorkout);
                    }
                    workoutReader.Close();
                    return tempWorkouts;
                }
            }
        }

        public void UpdateWorkout(int id, string name, string skillevel, int time, string category)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                var query = @"update Workouts set Name = @Name, Skillevel = @Skillevel, Time = @Time, Category = @Category where ExerciseId = @Id";
                using (SqlCommand qry = new SqlCommand(query, conn))
                {
                    qry.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    qry.Parameters["@Id"].Value = id;
                    qry.Parameters.Add("@Name", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Name"].Value = name;
                    qry.Parameters.Add("@Skillevel", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Skillevel"].Value = skillevel;
                    qry.Parameters.Add("@Time", System.Data.SqlDbType.Int);
                    qry.Parameters["@Time"].Value = time;
                    qry.Parameters.Add("@Category", System.Data.SqlDbType.VarChar);
                    qry.Parameters["@Category"].Value = category;
                    qry.ExecuteNonQuery();
                }
            }
        }

        public List<ExerciseModel> GetAllExercises(int workoutId)
        {
            List<ExerciseModel> tempExercises = new List<ExerciseModel>();
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "Select* FROM [Exercises] Inner join [Exercise_Workout] on [Exercises].ExerciseId = [Exercise_Workout].ExerciseId where [Exercise_Workout].WorkoutId = @Id",
                    Connection = connection
                };
                dataCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                dataCommand.Parameters["@Id"].Value = workoutId;
                using (SqlDataReader exerciseReader = dataCommand.ExecuteReader())
                {
                    while (exerciseReader.Read())
                    {
                        ExerciseModel tempExercise = new ExerciseModel(exerciseReader["Name"].ToString(), Convert.ToInt32(exerciseReader["Repetitions"]), exerciseReader["Skillevel"].ToString()); 
                        tempExercises.Add(tempExercise);
                    }
                    exerciseReader.Close();
                    return tempExercises;
                }
            }
        }
        public int GetAmountOfExercises(int id)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                conn.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "SELECT COUNT(Exercise_Workout.ExerciseId) AS NumberOfExercises FROM Exercise_Workout LEFT JOIN Workouts ON Exercise_Workout.WorkoutId = Workouts.WorkoutId where workouts.workoutId = @Id GROUP BY Workouts.name ",
                    Connection = conn
                };
                dataCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                dataCommand.Parameters["@Id"].Value = id;
                using (SqlDataReader workoutReader = dataCommand.ExecuteReader())
                {
                    workoutReader.Read();
                    return Convert.ToInt32(workoutReader["NumberOfExercises"]);
                }
            }
        }

        public WorkoutModel FindById(int id)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                try
                {
                    connection.Open();
                    SqlCommand dataCommand = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM [dbo].[Workouts] WHERE [WorkoutId] = @Id",
                        Connection = connection
                    };
                    dataCommand.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    dataCommand.Parameters["@Id"].Value = id;
                    using (SqlDataReader workoutReader = dataCommand.ExecuteReader())
                    {
                        workoutReader.Read();
                        return new WorkoutModel(Convert.ToInt32(workoutReader["WorkoutId"]), workoutReader["Name"].ToString(), workoutReader["Skillevel"].ToString(), Convert.ToInt32(workoutReader["Time"]), Convert.ToInt32(workoutReader["CaloriesBurned"]), workoutReader["Category"].ToString(), GetAmountOfExercises(Convert.ToInt32(workoutReader["WorkoutId"])));
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
