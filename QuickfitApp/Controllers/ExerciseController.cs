using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;

namespace QuickfitApp.Controllers
{
    public class ExerciseController : Controller
    {
        readonly ExerciseContainer exerciseContainer = new ExerciseContainer();
        // GET: Exercise

        public ActionResult Index()
        {
            var exerciseList = exerciseContainer.GetAll();
            return View(exerciseList);
        }

        public ActionResult Edit(int id)
        {
            var exercise = exerciseContainer.GetAll();
            return View(exercise);
        }

        [HttpPost]
        public ActionResult Edit(ExerciseModel exercise)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ExerciseModel exercise)
        {
            if (ModelState.IsValid)
            {
                exerciseContainer.Add(exercise);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}