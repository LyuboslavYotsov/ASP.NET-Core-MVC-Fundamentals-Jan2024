using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "Contacts");
            }

            return View();
        }
    }
}