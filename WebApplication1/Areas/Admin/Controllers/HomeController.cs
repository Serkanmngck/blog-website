using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
           
            return View();
        }
    }
}
