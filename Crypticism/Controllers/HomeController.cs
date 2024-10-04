using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Crypticism.Models.DatabaseModel;
using Crypticism.Models;

namespace Crypticism.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();

        public ActionResult Index()
        {
            return View(_db.Review.OrderByDescending(r => r.CreatedDate).ToList());
        } 
    }
}