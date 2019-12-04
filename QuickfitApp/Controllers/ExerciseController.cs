using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DataLayer;
using LogicLayer;
using System.Web;


namespace QuickfitApp.Controllers
{
    public class ExerciseController : Controller
    {
        ExerciseContainer exerciseContainer = new ExerciseContainer();
        Exercise exercise = new Exercise();
        public ActionResult Index()
        {
                List<ExerciseModel> exercises = exerciseContainer.GetAll();
                return View(exercises);
        }

        [HttpPost]
        public ActionResult Index(string sortField)
        {
            sortField = Request.Form["orderString"];
            List<ExerciseModel> exercises = exerciseContainer.GetAll(sortField);
            return View(exercises);
        }

        public ActionResult Edit(int id)
        {
            var exercise = exerciseContainer.GetAll().Where(e => e.Id == id).FirstOrDefault();
            return View(exercise);
        }

        [HttpPost]
        public ActionResult Edit(ExerciseModel exerciseModel)
        {
            exercise.UpdateExercise(exerciseModel.Id, exerciseModel.Name, exerciseModel.Weight, exerciseModel.Repetitions, exerciseModel.Level);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExerciseModel exercise, int workoutId = 0)
        {

            if (ModelState.IsValid)
            {
                exerciseContainer.Add(exercise, workoutId);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            ExerciseModel exerciseModel = exerciseContainer.GetAll().Where(e => e.Id == id).FirstOrDefault();
            return View(exerciseModel);
        }

        [HttpPost]
        public ActionResult Delete(ExerciseModel exerciseModel)
        {
            try
            {
                exerciseContainer.Delete(exerciseModel.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(exerciseModel);
            }
        }
    }
}