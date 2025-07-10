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
            var portfolios = db.PortfolioItems.ToList();
            ViewBag.PortfolioItems = portfolios;

            // TempData ile mesaj geldiyse view'a aktar
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
