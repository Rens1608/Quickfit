using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ILayer;
using Models;

namespace DataLayer
{
    public class WorkoutDAL : IWorkoutContainerDAL, IWorkoutDAL
    {
        public void Add(WorkoutModel workout)
        {
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                string query = @"insert into [Workouts] (Name, Skillevel, Category, Time, CaloriesBurned) values ('" + workout.Name + "','" +
                               workout.Skillevel + "','" + workout.Category + "','" + workout.Time + "', '"+ workout.Time * 4 +"')";
                SqlCommand qry = new SqlCommand(query, connection);
                qry.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkoutModel> GetAll()
        {
            List<WorkoutModel> tempWorkouts = new List<WorkoutModel>();
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "SELECT * FROM [dbo].[Workouts]",
                    Connection = connection
                };
                using (SqlDataReader workoutReader = dataCommand.ExecuteReader())
                {
                    while (workoutReader.Read())
                    {
                        WorkoutModel tempWorkout = new WorkoutModel(Convert.ToInt32(workoutReader["WorkoutId"]), workoutReader["Name"].ToString(), workoutReader["Skillevel"].ToString(), Convert.ToInt32(workoutReader["Time"]), Convert.ToInt32(workoutReader["CaloriesBurned"]), workoutReader["Category"].ToString());
                        tempWorkouts.Add(tempWorkout);
                    }
                    workoutReader.Close();
                    return tempWorkouts;
                }
            }
        }

        public void UpdateWorkout(int id, string name, string skillevel, int time, string category)
        {
            throw new NotImplementedException();
        }

        public List<ExerciseModel> GetAllExercises(int workoutId)
        {
            List<ExerciseModel> tempExercises = new List<ExerciseModel>();
            using (SqlConnection connection = new SqlConnection(AppSettingsJson.GetConnectionstring()))
            {
                connection.Open();
                SqlCommand dataCommand = new SqlCommand()
                {
                    CommandText = "Select* FROM [Exercises] Inner join [Exercise_Workout] on [Exercises].ExerciseId = [Exercise_Workout].ExerciseId where [Exercise_Workout].WorkoutId = '"+ workoutId +"'",
                    Connection = connection
                };

                using (SqlDataReader exerciseReader = dataCommand.ExecuteReader())
                {
                    while (exerciseReader.Read())
                    {
                        ExerciseModel tempExercise = new ExerciseModel(exerciseReader["Name"].ToString(), Convert.ToInt32(exerciseReader["Repetitions"]), exerciseReader["Skillevel"].ToString());;
                        tempExercises.Add(tempExercise);
                    }
                    exerciseReader.Close();
                    return tempExercises;
                }
            }
        }
    }
}
