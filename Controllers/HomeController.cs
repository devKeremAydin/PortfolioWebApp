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
            ViewBag.Portfolios = portfolios;
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
