using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
