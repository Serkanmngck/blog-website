using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.ViewComponents.Statistic
{
    [Area("Admin")]
    public class Statistic3 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();

        }
    }
}
