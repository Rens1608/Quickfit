using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickfitApp.Models;
using Logic;

namespace QuickfitApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly User user = new User(1, "Rens", 18, 65, 185, "male");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["UserName"] = "Name: " + user.Name;
            ViewData["UserAge"] = "Age: " + user.Age;
            ViewData["UserHeight"] = "Height: " + user.Height;
            ViewData["UserWeight"] = "Weight: " + user.Weight;
            ViewData["UserGender"] = "Gender: " + user.Gender;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
