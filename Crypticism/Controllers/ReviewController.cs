using System;
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
                var review = new Review()
                {
                    Content = model.Content
                };
                _db.Reviews.Add(review);
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