using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
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
        
        public ActionResult CompanySignUp()
        {
            return View();
        }
        
        public ActionResult EmployeeSignUp()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = _db.User.SingleOrDefault(u => u.Username == model.Username);
            if (user != null && user.PasswordHash == Hash(model.Password))
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
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
            if (!_db.User.Any(u => u.Username == model.Username))
            {
                var user = new User
                {
                    Username = model.Username,
                    PasswordHash = Hash(model.Password),
                    IsCompany = model.IsCompany,
                };
                _db.User.Add(user);
                _db.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                return RedirectToAction(model.IsCompany? "CompanySignUp" : "EmployeeSignUp", "User");
            }
            ModelState.AddModelError("", "this username has already been existed");
            return RedirectToAction("Signup", "User");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanySignUp(CompanyViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var company = new Company
            {
                UserId = Convert.ToInt32(User.Identity.Name),
                Email = model.Email,
                CompanyName = model.CompanyName,
            };
            _db.Company.Add(company);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeSignUp(EmployeeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var employee = new Employee
            {
                UserId = Convert.ToInt32(User.Identity.Name),
                Name = model.Name,
                Email = model.Email,
                CompanyId = _db.Company.SingleOrDefault(c => c.CompanyName == model.CompanyName).Id,
                IsVerified = model.PersonnelCode == null ? false : false,
                // TODO : handle IsUserVerified
            };
            _db.Employee.Add(employee);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoadDashboard()
        {
            var user = GetUser(Convert.ToInt32(User.Identity.Name));
            return RedirectToAction("Dashboard", user.IsCompany ? "Company" : "Employee");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        
        public User GetUser(int userId)
        {
            var user = _db.User.SingleOrDefault(u => u.Id == userId);
            return user;
        }

        public string Hash(string data)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(data)));

        }
    }
}