using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using Crypticism.Models.DatabaseModel;
using Crypticism.Models;
using Crypticism.Models.ViewModels;

namespace Crypticism.Controllers
{
    public class CompanyController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();
        
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
