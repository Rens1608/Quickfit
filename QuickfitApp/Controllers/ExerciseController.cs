﻿using System;
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
        ExerciseContainer exerciseContainer = new ExerciseContainer(AppSettingsJson.GetConnectionstring());
        Exercise exercise = new Exercise(AppSettingsJson.GetConnectionstring());
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index","Home");
            }
            List<ExerciseModel> exercises = exerciseContainer.GetAll(Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
            return View(exercises);
        }

        [HttpPost]
        public ActionResult Index(string sortField)
        {
            try
            {
                sortField = Request.Form["orderString"];
                List<ExerciseModel> exercises = exerciseContainer.GetAll(Convert.ToInt32(HttpContext.Session.GetInt32("UserId")), sortField);
                return View(exercises);
            }
            catch
            {
                return RedirectToAction("Index","Account");
            }
        }

        public ActionResult Edit(int id)
        {
                var exercise = exerciseContainer.GetAll(Convert.ToInt32(HttpContext.Session.GetInt32("UserId"))).Where(e => e.Id == id).FirstOrDefault();
                return View(exercise);
        }

        [HttpPost]
        public ActionResult Edit(ExerciseModel exerciseModel)
        {
            try
            {
                exercise.UpdateExercise(exerciseModel.Id, exerciseModel.Name, exerciseModel.Weight, exerciseModel.Repetitions, exerciseModel.Level);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Level", "Something was not filled in correctly, try again!");
                return View(exerciseModel);
            }
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
                exerciseContainer.Add(exercise, workoutId, Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            ExerciseModel exerciseModel = exerciseContainer.GetAll(Convert.ToInt32(HttpContext.Session.GetInt32("UserId"))).Where(e => e.Id == id).FirstOrDefault();
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