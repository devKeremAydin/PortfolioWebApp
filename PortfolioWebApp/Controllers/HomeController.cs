using System.Web.Mvc;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
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
                ViewBag.Message = "Mesajınız başarıyla gönderildi!";
            }

            return View("Index");
        }
    }
}
