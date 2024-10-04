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
    public class UserController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();
        
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult SignUp()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var user = _db.User.SingleOrDefault(u => u.Username == model.Username);
            if (user != null && user.PasswordHash == BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(model.Password))))
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "Home");
            }
            
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(UserViewModel model)
        {

            if (!ModelState.IsValid) return View(model);

            if (_db.User.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("", "this username has already been existed");
                return RedirectToAction("Signup", "User");
            }
            var user = new User()
            {
                Username = model.Username,
                PasswordHash = BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(model.Password))),
            };
            _db.User.Add(user);
            _db.SaveChanges();
            FormsAuthentication.SetAuthCookie(user.Username, false);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}