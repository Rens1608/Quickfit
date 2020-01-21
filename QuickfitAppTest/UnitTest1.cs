using NUnit.Framework;
using QuickfitApp;
using System;
using Models;
using LogicLayer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QuickfitAppTest
{
    [TestFixture]
    public class Tests
    {
        private string connectionstring;
        private ExerciseContainer exerciseContainer;
        private Exercise exercise;
        private UserContainer userContainer;
        private User user;
        private Workout workout;
        private WorkoutContainer workoutContainer;

        [SetUp]
        public void Setup()
        {
            connectionstring = AppSettingsJson.GetTestConnectionstring();
            exercise = new Exercise(connectionstring);
            exerciseContainer = new ExerciseContainer(connectionstring);
            userContainer = new UserContainer(connectionstring);
            user = new User(connectionstring);
            workout = new Workout(connectionstring);
            workoutContainer = new WorkoutContainer(connectionstring);
        }

        [Test]
        public void Add_User()
        {
            UserModel user = new UserModel("Bram", null, 20, 78, 190, "Male");
            user.Password = "Bram123";
            int totalAmountOfUsers = userContainer.GetAll().Count;
            userContainer.Add(user);
            int newTotalAmountOfUsers = userContainer.GetAll().Count;
            Assert.Greater(newTotalAmountOfUsers, totalAmountOfUsers);
        }

        [Test]
        public void Update_User()
        {
            UserModel userModel = userContainer.FindById(1);
            user.UpdateUser(1,"Rens", 19, 65, 185, "male");
            UserModel newUserModel = userContainer.FindById(1);
            user.UpdateUser(1,"Rens", 18, 65, 185, "male");
            Assert.AreNotEqual(userModel.Age, newUserModel.Age);

        }
        [Test]
        public void Delete_Exercise()
        {
            int amountOfExercises = exerciseContainer.GetAll(1).Count;
            exerciseContainer.Delete(exercise.GetIdFromLatestExercise());
            int newAmountOfExercises = exerciseContainer.GetAll(1).Count;
            exerciseContainer.Add(new ExerciseModel("Bench", 65, 10, null, "Beginner", false), 1);
            Assert.Less(newAmountOfExercises, amountOfExercises);
        }

        [Test]
        public void Add_Exercise_To_Workout()
        {
            int totalAmountOfExercises = workoutContainer.GetExercisesInWorkout(1).Count;
            workoutContainer.AddExerciseToWorkout(1, new ExerciseModel("Bench", 65, 10, null, "Beginner", true), 1);
            int newTotalAmountOfExercises = workoutContainer.GetExercisesInWorkout(1).Count;
            exerciseContainer.Delete(exercise.GetIdFromLatestExercise());
            Assert.Greater(newTotalAmountOfExercises, totalAmountOfExercises);
        }
    }
}