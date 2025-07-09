using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                Session["Admin"] = "admin";
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            var messages = db.Contacts.ToList();
            return View(messages);
        }

        [HttpGet]
        public ActionResult EditPortfolio()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            return View();
        }

        [HttpPost]
        public ActionResult EditPortfolio(string Title, string Description, HttpPostedFileBase ImageFile)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            string imagePath = null;

            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                var fileName = System.IO.Path.GetFileName(ImageFile.FileName);
                var path = Server.MapPath("~/Content/images/" + fileName);
                ImageFile.SaveAs(path);
                imagePath = "/Content/images/" + fileName;
            }

            var portfolio = new PortfolioItem
            {
                Title = Title,
                Description = Description,
                ImagePath = imagePath
            };

            db.PortfolioItems.Add(portfolio);
            db.SaveChanges();

            ViewBag.Message = "Portfolyo başarıyla eklendi.";
            return View();
        }
        [HttpPost]
        public ActionResult ResetPortfolio()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            var allItems = db.PortfolioItems.ToList();
            db.PortfolioItems.RemoveRange(allItems);
            db.SaveChanges();

            ViewBag.Message = "Tüm portfolyo kayıtları sıfırlandı.";
            return RedirectToAction("EditPortfolio");
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return RedirectToAction("Login");
        }
    }
}
