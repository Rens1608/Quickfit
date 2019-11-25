using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;

namespace QuickfitApp.Controllers
{
    public class WorkoutController : Controller
    {
        WorkoutContainer workoutContainer = new WorkoutContainer();
        ExerciseContainer exerciseContainer = new ExerciseContainer();
        public IActionResult Index()
        {
            List<WorkoutModel> workoutlist = workoutContainer.GetAll();
            return View(workoutlist);
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
                workoutContainer.Add(workout);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var workout = workoutContainer.GetAll().Where(w => w.Id == id).FirstOrDefault();
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
                exerciseContainer.Add(exercise, id);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}