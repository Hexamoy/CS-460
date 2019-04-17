﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;

namespace Powerlevel.Controllers
{

    public class UserWorkoutsController : Controller
    {
        private toasterContext db = new toasterContext();

        //user leveling algorithm logic function
        public void CheckUserLevel()
        {
            //get user current level
            int userCurrentLevel = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Level).FirstOrDefault();

            //get user current exp
            int userCurrentExp = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();

            //get the list of required exp for certain lv
            var expReqList = db.LevelExps.Select(x => x.Exp).ToList();


            //formula for calculating user lv
            //if their exp is more than the current exp bracket of the level
            for (int counter = userCurrentLevel; counter < expReqList.Count(); counter++)
            {
                if (userCurrentExp >= expReqList[userCurrentLevel])
                {
                    userCurrentLevel += 1; //increase their level by 1
                }
            }

            //access user level info in the database
            var userData = db.Users.First(x => x.UserName == User.Identity.Name);
            userData.Level = userCurrentLevel;
            db.SaveChanges();
        }

        //Function for accessing database to update user exp
        public void AddExp(int expAmount)
        {

            //get the user current exp and add to it.
            int getCurrentExp = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();
            getCurrentExp += expAmount;

            //find the user column in the database and modified the existing value
            var userData = db.Users.First(x => x.UserName == User.Identity.Name);
            userData.Experience = getCurrentExp;
            db.SaveChanges();

            //calcalate the user level by their exp
            CheckUserLevel();
        }


        // GET: UserWorkouts
        public ActionResult Index()
        {
            var UserWorkouts = db.UserWorkouts.Include(u => u.User).Include(u => u.WorkoutExercise);
            return View(UserWorkouts.ToList());
        }

        // GET: UserWorkouts
        public ActionResult History()
        {
            var UserWorkouts = db.UserWorkouts.Include(u => u.User).Include(u => u.WorkoutExercise).OrderByDescending(u => u.CompletedTime);
            return View(UserWorkouts.ToList());
        }

        // GET: UserWorkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            if (UserWorkout == null)
            {
                return HttpNotFound();
            }
            return View(UserWorkout);
        }

        // GET: UserWorkouts/Create
        [HttpGet]
        public ActionResult Create()
        {
            // Sets the User that is creating a workout to the currently logged in User automatically
            var CurrentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;

            
            ViewBag.AvailableWorkouts = new SelectList(db.Workouts, "WorkoutId", "Name");

            /* These variables preset the selection of workouts to start so that the user starts at the beginning of a workout, not
             * somewhere in the middle.
             * The "Where" Statements in these two variables don't actually do anything, I just left them in there
             * in an effort to review and understand LINQ better later on
            */
            /*var WorkoutHellhole = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.Hellhole = WorkoutHellhole.LinkId;

            var WorkoutBurningBack = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.BurningBack = WorkoutBurningBack.LinkId + 3; /* Adding "+ 3" to the LinkId was the best method I could find
            in having the second "Burning Back" workout option start properly when selected by the user, can code this prettier later on */
            //var BurningBackTest = db.WorkoutExercises.Where(x => x.Workout.)

            /*var WorkoutFullBodyGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.FullBodyGym = WorkoutFullBodyGym.LinkId + 6;

            var WorkoutRestDay = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.RestDay = WorkoutRestDay.LinkId + 15;

            var WorkoutUpperBodyGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.UpperBodyGym = WorkoutUpperBodyGym.LinkId + 16;

            var WorkoutLowerBodyGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.LowerBodyGym = WorkoutLowerBodyGym.LinkId + 27;

            var WorkoutPushGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.PushGym = WorkoutPushGym.LinkId + 32;

            var WorkoutPullGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.PullGym = WorkoutPullGym.LinkId + 38;

            var WorkoutLegsGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.LegsGym = WorkoutLegsGym.LinkId + 44;

            var WorkoutChestTricepsCalvesGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.ChestTricepsCalvesGym = WorkoutChestTricepsCalvesGym.LinkId + 50;

            var WorkoutLegsAbsGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.LegsAbsGym = WorkoutLegsAbsGym.LinkId + 58;

            var WorkoutShouldersCalvesGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.ShouldersCalvesGym = WorkoutShouldersCalvesGym.LinkId + 65;

            var WorkoutBackBicepsAbsGym = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.BackBicepsAbsGym = WorkoutBackBicepsAbsGym.LinkId + 69;

            var WorkoutBodyOnlyChestArms = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.BodyOnlyChestArms = WorkoutBodyOnlyChestArms.LinkId + 76;

            var WorkoutBodyOnlyCore = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.BodyOnlyCore = WorkoutBodyOnlyCore.LinkId + 82;

            var WorkoutBodyOnlyLegs = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.BodyOnlyLegs = WorkoutBodyOnlyLegs.LinkId + 89;*/

            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workout Workout)
        {//gets the current userid to be added to the userworkout table
            var currentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();

            if (ModelState.IsValid)
            {//uses the returned workout to start to create a new active entry in the userworkout table
                UserWorkout ActiveUserWorkout = new UserWorkout { UserId = userId, UserActiveWorkout = Workout.WorkoutId, WorkoutCompleted = false,
                    ActiveWorkoutStage = 0};
                db.UserWorkouts.Add(ActiveUserWorkout);
                db.SaveChanges();
                //gets the UCWId for the routing id to track in progress workouts
                var testucwid = db.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.UCWId).ToList();
                int ucwid = testucwid.First();
                
                return RedirectToAction("Progress", routeValues: new { id = ucwid });
            }

            /*ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", UserWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(db.WorkoutExercises, "LinkId", "LinkId", UserWorkout.UserActiveWorkout);*/
            return View(Workout);
        }

        public ActionResult Progress(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //gets the activeWorkout record for the user
            var UserWorkout = db.UserWorkouts.Find(id);
            //gets the active workout
            Workout InProgressWorkout = db.Workouts.Find(UserWorkout.UserActiveWorkout);
            //gets the stage of the active workout
            int CurrentWorkoutStage = UserWorkout.ActiveWorkoutStage;
            //gets the total number of exercises in the workout to determine the final stage of the workout.
            int maxStage = InProgressWorkout.WorkoutExercises.Where(x => x.WorkoutId == UserWorkout.UserActiveWorkout).Count();

            if(CurrentWorkoutStage == 0)
            {//gets the current exercise in the workout by querying the workout/exercise transaction table. This returns the first exercise in the workout
                Exercise CurrentExercise = (Exercise)db.WorkoutExercises.Where(x => x.WorkoutId == InProgressWorkout.WorkoutId && x.OrderNumber == 1).Select(x => x.Exercise);
                //changes the stage of the workout to the next exercise
                UserWorkout.ActiveWorkoutStage = UserWorkout.ActiveWorkoutStage + 1;
                //saves the changes in the db
                db.Entry(UserWorkout).State = EntityState.Modified;
                db.SaveChanges();
                //returns the current exercise
                return View(CurrentExercise);
            }
            else if(CurrentWorkoutStage == maxStage)
            {
                //go to completed screen and distribute awards. Probably call the completed actionmethod here so it links in with Chi's exp code    
            }
            return View();
        }

        // GET: UserWorkouts/Abandon/5
        public ActionResult Abandon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            if (UserWorkout == null)
            {
                return HttpNotFound();
            }
            return View(UserWorkout);
        }

        // POST: UserWorkouts/Abandon/5
        [HttpPost, ActionName("Abandon")]
        [ValidateAntiForgeryToken]
        public ActionResult AbandonConfirmed(int id)
        {
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            db.UserWorkouts.Remove(UserWorkout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: UserWorkouts/Complete/5
        public ActionResult Complete(int? id)
        {
            ViewBag.workoutId = 0;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            if (UserWorkout == null)
            {
                return HttpNotFound();
            }
            return View(UserWorkout);
        }

        // POST: UserWorkouts/Complete/5
        [HttpPost, ActionName("Complete")]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteConfirmed(int id)
        {
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);

            //Marks the current workout as "Completed", moving it from the User's Active Workout tab to the Workout History tab
            var completedWorkout = new UserWorkout { UserId = UserWorkout.UserId, UserActiveWorkout = UserWorkout.UserActiveWorkout, WorkoutCompleted = true };
            db.UserWorkouts.Add(completedWorkout);

            //"Removes" the old table, as the new one is essentially a duplicate with a WorkoutCompleted value of True, instead of False
            db.UserWorkouts.Remove(UserWorkout);
            db.SaveChanges();

            //increase user exp by 50 on workout completion, right now exp reward is fixed at 50 per workout, might change it later
            AddExp(50);
            return RedirectToAction("Index");
        }

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
