using System;
using System.Linq;
using System.Web.Mvc;
using Crypticism.Models.DatabaseModel;
using Crypticism.Models;
using Crypticism.Models.ViewModels;

namespace Crypticism.Controllers
{
    public class ReviewController : Controller
    {
        private readonly MyDbContext _db = new MyDbContext();
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddReview()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(AddReviewViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                var review = new Review
                {
                    CompanyId = _db.Company.SingleOrDefault(c => c.CompanyName == model.CompanyName).Id,
                    CreatedDate = DateTime.Now,
                    Title = model.Title,
                    Content = model.Content,
                    IsUserVerified = false
                    // TODO : handle IsUserVerified
                };
                _db.Review.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Invalid attempt.\n" + e.Message);
                return View(model);
            }
        }
    }
}