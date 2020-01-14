using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuickfitApp.Controllers;
using Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LogicLayer;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace TestProjectQuickfit
{
    public static class MvcMockHelpers
    {

        [TestClass]
        public class UnitTest1
        {
            private HomeController homeController = new HomeController();
            private ExerciseController exerciseController = new ExerciseController();
            private ExerciseContainer exerciseContainer = new ExerciseContainer();
            [TestInitialize]
            public void Initialize()
            {
                var controller = new HomeController() { ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext() }; 
                controller.ControllerContext.HttpContext = new DefaultHttpContext();
            }

            [TestMethod]
            public void Login_IncorrectPassword()
            {
                UserModel userModel = new UserModel();
                userModel.Name = "Rens";
                userModel.Password = "Rens2003";
                var actionResult = homeController.Login(userModel) as ViewResult;
                Assert.AreEqual(actionResult.ViewName, null);
            }

            [TestMethod]
            //Mock Session
            public void Login_CorrectPassword()
            {
                UserModel userModel = new UserModel();
                userModel.Name = "Rens";
                userModel.Password = "Rens2001";
                var actionResult = homeController.Login(userModel) as ViewResult;
                Assert.AreEqual(actionResult.ViewName, "Index");
            }

            [TestMethod]
            //Mock Database
            public void GetAllExercises_Correct()
            {
                List<ExerciseModel> exercises = new List<ExerciseModel>();
                exercises = exerciseContainer.GetAll(6);
                Assert.AreEqual(2, exercises.Count);
            }

            [TestMethod]
            //Mock Database
            public void GetAllExercises_Incorrect()
            {
                List<ExerciseModel> exercises = new List<ExerciseModel>();
                exercises = exerciseContainer.GetAll(6);
                Assert.AreNotEqual(5, exercises.Count);
            }

            [TestMethod]
            public void AddExercise_Redirect_Correct()
            {
                ActionResult action = exerciseController.Create(new ExerciseModel(name:"Squat", repetitions:5, level:"Beginner"));
                Assert.IsInstanceOfType(action, typeof(ViewResult));
            }
        }
    }
}
