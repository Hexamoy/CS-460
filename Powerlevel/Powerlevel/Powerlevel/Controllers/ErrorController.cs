﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Powerlevel.Controllers
{
    public class ErrorController : Controller
    {
        // handles custom error redirects for specific numbered errors
        public ActionResult NotFound()
        {
            HttpContext.Response.StatusCode = 404;
            HttpContext.Response.TrySkipIisCustomErrors = true;

            return View();
        }

        public ActionResult BadRequest()
        {
            HttpContext.Response.StatusCode = 400;
            HttpContext.Response.TrySkipIisCustomErrors = true;

            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult Forbidden()
        {
            return View();
        }
    }
}