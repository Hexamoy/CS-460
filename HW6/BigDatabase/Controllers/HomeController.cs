﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using BigDatabase.Controllers;
using BigDatabase.Models;
using BigDatabase.Models.ViewModels;
using System.Web.Security;
using System.Security.Cryptography.X509Certificates;

namespace BigDatabase.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            string client = Request.QueryString["client"];
            if(client != null && client != "")
            {
                List<PersonVM> SearchResult = db.People.Where(person => person.FullName.Contains(client)).Where(p => p.PersonID 
                            != 1).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

                if (SearchResult.FirstOrDefault() == null)
                {
                    ViewBag.Toggle = 2;
                    return View(SearchResult);
                }
                else
                {
                    ViewBag.Toggle = 1;
                    return View(SearchResult);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(string result)
        {
            if(result == null || result == "")
            {
                return (RedirectToAction("About"));
            }

            Debug.WriteLine(result);
            List<PersonVM> DetailPerson = db.People.Where(person => person.FullName == result).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

            return View(DetailPerson);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}