using System.Web.Mvc;
using PortfolioWebApp.Models;
using PortfolioWebApp.Data;

namespace PortfolioWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                ViewBag.Message = "Mesajınız başarıyla gönderildi!";
            }

            return View();
        }
    }
}
