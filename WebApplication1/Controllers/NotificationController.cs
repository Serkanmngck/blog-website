using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
