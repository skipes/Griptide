﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace griptide.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Unknown()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

    }
}
