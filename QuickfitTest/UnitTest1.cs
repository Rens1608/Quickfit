using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickfitApp.Controllers;
using Models;
namespace QuickfitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LogIn()
        {
            HomeController homeController = new HomeController();
            dynamic result = homeController.Login(new UserModel(name: "Rens", password: "Rens2001", age: 18, weight: 65, height: 190, gender: "Male"));
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
