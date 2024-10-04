using System.Web.Mvc;
using Crypticism.Models.DatabaseModel;

namespace Crypticism.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();
        
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}