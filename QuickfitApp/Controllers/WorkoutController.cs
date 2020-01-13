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
        Workout workout = new Workout();
        WorkoutContainer workoutContainer = new WorkoutContainer();
        ExerciseContainer exerciseContainer = new ExerciseContainer();
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
                return View();
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
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var workout = workoutContainer.FindById(id);
            workout.Exercises = workoutContainer.GetExercisesInWorkout(id);
            return View(workout);
        }

        public ActionResult AddExerciseToWorkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExerciseToWorkout(ExerciseModel exercise, int id)
        {
            if (ModelState.IsValid)
            {
                exerciseContainer.Add(exercise, id, Convert.ToInt32(HttpContext.Session.GetInt32("userId")));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}