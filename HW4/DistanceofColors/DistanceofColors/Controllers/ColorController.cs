﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistanceofColors.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}