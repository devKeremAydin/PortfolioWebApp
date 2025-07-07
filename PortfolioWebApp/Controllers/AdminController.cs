using System.Linq;
using System.Web.Mvc;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Admin giriş ekranı
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Giriş bilgisi kontrol
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

        // Mesajları gösteren sayfa
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
            return RedirectToAction("Login");
        }
    }
}
