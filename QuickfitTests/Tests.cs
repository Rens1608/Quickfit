using NUnit.Framework;

namespace QuickfitTests
{
    public class Tests
    {
        [Test]
        public void GetExecisesFromLoggedInUser_Succeeds()
        {
            QuickfitApp.Controllers.HomeController homeController = new QuickfitApp.Controllers.HomeController();
            QuickfitApp.Controllers.ExerciseController exerciseController = new QuickfitApp.Controllers.ExerciseController();
            Models.UserModel user = new Models.UserModel { Name = "Rens", Password = "Rens2001"};
            homeController.Login(user);
            exerciseController.Index("ExerciseId");
        }
    }
}