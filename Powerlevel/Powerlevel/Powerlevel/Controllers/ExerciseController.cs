﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;

namespace Powerlevel.Controllers
{
    public class ExerciseController : Controller
    {
        private toasterContext db = new toasterContext();

        /// <summary>
        /// Displays all exercises
        /// </summary>
        /// <returns></returns>
        // GET: Exercise
        public ActionResult Index()
        {
            return View(db.Exercises.ToList());
        }

        /// <summary>
        /// Displays the details of a particular exercise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Exercise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercise exercise = db.Exercises.Find(id);
            ViewBag.Images = db.ExerciseImages.Where(x => x.ExerciseId == exercise.ExerciseId).ToList();
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        /// <summary>
        /// Returns a list of Exercises within a specific workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WorkoutList(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exercises = db.WorkoutExercises.Where(x => x.WorkoutId == id).Include(x => x.Exercise).OrderBy(x => x.OrderNumber);
            if(exercises != null)
            {
                return View(exercises);
            }//returns bad status code if nothing was found in the db
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Disposes of db instance
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
