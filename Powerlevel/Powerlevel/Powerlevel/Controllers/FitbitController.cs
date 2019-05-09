﻿using Fitbit.Api.Portable;
using Fitbit.Api.Portable.OAuth2;
using Fitbit.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UnitsNet;
using UnitsNet.Units;
using Powerlevel.Models;
using Powerlevel.Infastructure;
using System.Data.Entity;
using System.Threading;

namespace Powerlevel.Controllers
{
    public class FitbitController : Controller
    {
        private toasterContext db = new toasterContext();
        private IToasterRepository repo;

        public FitbitController(IToasterRepository repository)
        {
            this.repo = repository;
        }
        //
        // GET: /Fitbit/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /FitbitAuth/
        // Setup - prepare the user redirect to Fitbit.com to prompt them to authorize this app.
        public ActionResult Authorize()
        {
            var appCredentials = new FitbitAppCredentials()
            {
                ClientId = ConfigurationManager.AppSettings["FitbitClientId"],
                ClientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"]
            };
            //make sure you've set these up in Web.Config under <appSettings>:

            Session["AppCredentials"] = appCredentials;

            //Provide the App Credentials. You get those by registering your app at dev.fitbit.com
            //Configure Fitbit authenticaiton request to perform a callback to this constructor's Callback method
            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");
            string[] scopes = new string[] { "activity", "heartrate", "location", "nutrition", "profile", "settings", "sleep", "social", "weight" };

            string authUrl = authenticator.GenerateAuthUrl(scopes, null);

            var User = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (User != null && User.FitbitLinked != true)
            {
                RecordFitbitLink(User);
            }
            

            return Redirect(authUrl);
        }

        /// <summary>
        /// Records that fitbit account is linked in user table for user
        /// </summary>
        /// <param name="user"></param>
        void RecordFitbitLink(User user)
        {
            user.FitbitLinked = true;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Final step. Take this authorization information and use it in the app
        public async Task<ActionResult> Callback()
        {
            //User CurrentUser = db.Users.Where(x => x.UserName == Thread.CurrentPrincipal.Identity.Name).FirstOrDefault();

            FitbitAppCredentials appCredentials = (FitbitAppCredentials)Session["AppCredentials"];

            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");

            string code = Request.Params["code"];

            OAuth2AccessToken accessToken = await authenticator.ExchangeAuthCodeForAccessTokenAsync(code);

            //Store credentials in FitbitClient. The client in its default implementation manages the Refresh process
            var fitbitClient = GetFitbitClient(accessToken);

            //gets the current user profile from fitbit
            UserProfile FitBitProfile = await fitbitClient.GetUserProfileAsync();

            FitBitProfile = ConvertMeasurments(FitBitProfile);

            //sets height and weight in db based on fitbit profile           
            bool redirect = StoreCredentials(fitbitClient, FitBitProfile);
            
            if(redirect != true)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            ViewBag.AccessToken = accessToken;

            return View("~/Views/Home/GettingStarted.cshtml");

        }

        /// <summary>
        /// Gets the FitBitProfile for the current session
        /// </summary>
        /// <param name="fitbitClient"></param>
        /// <returns></returns>
        public async Task<UserProfile> GetFitBitProfile(FitbitClient fitbitClient)
        {
            UserProfile FitBitProfile = await fitbitClient.GetUserProfileAsync();
            FitBitProfile = ConvertMeasurments(FitBitProfile);
            return (FitBitProfile);
        }

        /// <summary>
        /// Stores the api access tokens in the db and returns bool based on storage success
        /// </summary>
        /// <param name="accessToken"></param>
        bool StoreCredentials(FitbitClient fitbitClient, UserProfile userProfile)
        {//stores the fitbit api tokens in the user table
            User ourUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            
            if (ourUser.Weight == null || ourUser.HeightFeet == null)
            {
                ourUser.HeightFeet = userProfile.Height;
                ourUser.Weight = userProfile.Weight;
                db.Entry(ourUser).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// In this example we show how to explicitly request a token refresh. However, FitbitClient V2 on its default implementation provide an OOB automatic token refresh.
        /// </summary>
        /// <returns>A refreshed token</returns>
        public async Task<ActionResult> RefreshToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = await fitbitClient.RefreshOAuth2TokenAsync(); //fitbitClient.RefreshOAuth2Token(); //Had to change this from original cause it wasn't showing up

            return View("Callback");
        }

        public async Task<ActionResult> TestToken()
        {
            //gets a new fitbit client instances
            var fitbitClient = GetFitbitClient();

            //gets the current user profile from fitbit
            UserProfile FitBitProfile = await fitbitClient.GetUserProfileAsync();

            FitBitProfile = ConvertMeasurments(FitBitProfile);

            return View(FitBitProfile);
        }

        /// <summary>
        /// Converts from kg to lb and cm to ft for user height and weight
        /// </summary>
        /// <param name="fitBitUser"></param>
        /// <returns></returns>
        UserProfile ConvertMeasurments(UserProfile fitBitUser)
        {//converst weight from kg to lb and rounds to 2 decimal places
            Mass Weight = Mass.FromKilograms(fitBitUser.Weight);
            fitBitUser.Weight = Math.Round(Weight.ToUnit(MassUnit.Pound).Pounds, 2);

            //converts height from cm to ft and rounds to 2 decimal places
            Length Height = Length.FromCentimeters(fitBitUser.Height);
            fitBitUser.Height = Math.Round(Height.ToUnit(LengthUnit.Foot).Feet, 2);
            
            return (fitBitUser);
        }
        /*
        public string TestTimeSeries()
        {
            FitbitClient client = GetFitbitClient();

            var results = client.GetTimeSeries(TimeSeriesResourceType.DistanceTracker, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            string sOutput = "";
            foreach (var result in results.DataList)
            {
                sOutput += result.DateTime.ToString() + " - " + result.Value.ToString();
            }

            return sOutput;

        }
        
        public ActionResult LastWeekDistance()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList results = client.GetTimeSeries(TimeSeriesResourceType.Distance, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            return View(results);
        }
        */

        public async Task<ActionResult> LastWeekSteps()
        {

            FitbitClient client = GetFitbitClient();

            var response = await client.GetTimeSeriesIntAsync(TimeSeriesResourceType.Steps, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            return View(response);

        }
        /*
        //example using the direct API call getting all the individual logs
        public ActionResult MonthFat(string id)
        {
            DateTime dateStart = Convert.ToDateTime(id);

            FitbitClient client = GetFitbitClient();

            Fat fat = client.GetFat(dateStart, DateRangePeriod.OneMonth);

            if (fat == null || fat.FatLogs == null) //succeeded but no records
            {
                fat = new Fat();
                fat.FatLogs = new List<FatLog>();
            }
            return View(fat);

        }

        //example using the time series, one per day
        public ActionResult LastYearFat()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList fatSeries = client.GetTimeSeries(TimeSeriesResourceType.Fat, DateTime.UtcNow, DateRangePeriod.OneYear);

            return View(fatSeries);

        }

        //example using the direct API call getting all the individual logs
        public ActionResult MonthWeight(string id)
        {
            DateTime dateStart = Convert.ToDateTime(id);

            FitbitClient client = GetFitbitClient();

            Weight weight = client.GetWeight(dateStart, DateRangePeriod.OneMonth);

            if (weight == null || weight.Weights == null) //succeeded but no records
            {
                weight = new Weight();
                weight.Weights = new List<WeightLog>();
            }
            return View(weight);

        }

        //example using the time series, one per day
        public ActionResult LastYearWeight()
        {
            FitbitClient client = GetFitbitClient();

            TimeSeriesDataList weightSeries = client.GetTimeSeries(TimeSeriesResourceType.Weight, DateTime.UtcNow, DateRangePeriod.OneYear);

            return View(weightSeries);

        }

        /// <summary>
        /// This requires the Fitbit staff approval of your app before it can be called
        /// </summary>
        /// <returns></returns>
        public string TestIntraDay()
        {
            FitbitClient client = new FitbitClient(ConfigurationManager.AppSettings["FitbitConsumerKey"],
                ConfigurationManager.AppSettings["FitbitConsumerSecret"],
                Session["FitbitAuthToken"].ToString(),
                Session["FitbitAuthTokenSecret"].ToString());

            IntradayData data = client.GetIntraDayTimeSeries(IntradayResourceType.Steps, new DateTime(2012, 5, 28, 11, 0, 0), new TimeSpan(1, 0, 0));

            string result = "";

            foreach (IntradayDataValues intraData in data.DataSet)
            {
                result += intraData.Time.ToShortTimeString() + " - " + intraData.Value + Environment.NewLine;
            }

            return result;

        }

         */

        /// <summary>
        /// HttpClient and hence FitbitClient are designed to be long-lived for the duration of the session. This method ensures only one client is created for the duration of the session.
        /// More info at: http://stackoverflow.com/questions/22560971/what-is-the-overhead-of-creating-a-new-httpclient-per-call-in-a-webapi-client
        /// </summary>
        /// <returns></returns>
        private FitbitClient GetFitbitClient(OAuth2AccessToken accessToken = null)
        {
            if (Session["FitbitClient"] == null)
            {
                if (accessToken != null)
                {
                    var appCredentials = (FitbitAppCredentials)Session["AppCredentials"];
                    FitbitClient client = new FitbitClient(appCredentials, accessToken);
                    Session["FitbitClient"] = client;
                    return client;
                }
                else
                {
                    throw new Exception("First time requesting a FitbitClient from the session you must pass the AccessToken.");
                }

            }
            else
            {
                return (FitbitClient)Session["FitbitClient"];
            }
        }
    }
}