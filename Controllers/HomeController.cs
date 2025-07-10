using PortfolioWebApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace PortfolioWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            // Portfolyo verilerini al
            var portfolios = db.PortfolioItems.ToList();
            ViewBag.PortfolioItems = portfolios;

            // Yetenek verilerini al
            var skills = db.Skills.ToList();
            ViewBag.Skills = skills;

            // Kişisel bilgi verisini al
            var personalInfo = db.PersonalInfos.FirstOrDefault();
            ViewBag.PersonalInfo = personalInfo;

            // TempData ile gelen mesajı aktar
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"];

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();

                // Redirect sonrası mesaj göstermek için TempData kullan
                TempData["Message"] = "Mesajınız başarıyla gönderildi!";
            }

            return RedirectToAction("Index");
        }
    }
}
