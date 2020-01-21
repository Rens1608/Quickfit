using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Http;
using LogicLayer;
namespace QuickfitApp.Controllers
{
    public class WorkoutController : Controller
    {
        Workout workout = new Workout(AppSettingsJson.GetConnectionstring());
        WorkoutContainer workoutContainer = new WorkoutContainer(AppSettingsJson.GetConnectionstring());
        ExerciseContainer exerciseContainer = new ExerciseContainer(AppSettingsJson.GetConnectionstring());
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<WorkoutModel> workoutlist = workoutContainer.GetAll(Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
            return View(workoutlist);
        }

        public ActionResult Delete(int id)
        {
            var workout = workoutContainer.FindById(id);
            return View(workout);
        }

        [HttpPost]
        public ActionResult Delete(WorkoutModel workout)
        {
            try
            {
                workoutContainer.Delete(workout.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Category", "Something went wrong, try again!");
                return View(workout);
            }
        }

        public ActionResult Edit(int id)
        {
            var workout = workoutContainer.FindById(id);
            return View(workout);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string skillevel, int time, string category)
        {
            try
            {
                workout.UpdateWorkout(id, name, skillevel, time, category);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Gender", "Something was not filled in correctly, try again!");
                return View(workoutContainer.FindById(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkoutModel workout)
        {
            if (ModelState.IsValid)
            {
                workoutContainer.Add(workout, Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Category", "Something was not filled in correctly, try again!");
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var workout = workoutContainer.FindById(id);
            TempData["WorkoutId"] = id;
            workout.Exercises = workoutContainer.GetExercisesInWorkout(id);
            return View(workout);
        }

        public ActionResult AddExerciseToWorkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExerciseToWorkout(ExerciseModel exercise)
        {
            if (ModelState.IsValid)
            {
                int userId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                exercise.InWorkout = true;
                int workoutId = Convert.ToInt32(TempData["WorkoutId"]);
                workoutContainer.AddExerciseToWorkout(userId, exercise, workoutId);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Gender", "Something was not filled in correctly, try again!");
                return View();
            }
        }

    }
}