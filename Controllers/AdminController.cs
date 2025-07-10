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

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditPersonalInfo()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            return View(new PersonalInfoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPersonalInfo(PersonalInfoViewModel model, HttpPostedFileBase ProfileImage, HttpPostedFileBase CvFile)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            ViewBag.Message = "Bilgiler başarıyla güncellendi!";
            return View(model);
        }

        [HttpGet]
        public ActionResult EditSkills()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            var skills = db.Skills.ToList();
            ViewBag.Skills = skills;
            return View(new Skill());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkills(Skill skill)
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            if (ModelState.IsValid)
            {
                db.Skills.Add(skill);
                db.SaveChanges();
                ViewBag.Message = $"{skill.Name} (%{skill.Percentage}) başarıyla eklendi.";
            }

            ViewBag.Skills = db.Skills.ToList();
            return View(new Skill());
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
        [HttpPost]
        public ActionResult ResetSkills()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");

            var allSkills = db.Skills.ToList();
            db.Skills.RemoveRange(allSkills);
            db.SaveChanges();

            ViewBag.Message = "Tüm yetenekler başarıyla sıfırlandı.";
            return RedirectToAction("EditSkills");
        }
    }
}
