﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crypticism.Models.DatabaseModel;
using Crypticism.Models;

namespace Crypticism.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();

        public ActionResult Index()
        {
            return View();
        }

    }
}