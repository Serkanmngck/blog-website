using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.ViewComponents.Statistic
{
    [Area("Admin")]
    public class Statistic4 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = context.Admins.Where(x => x.AdminID == 1).Select(y => y.ImageUrl).FirstOrDefault();
            return View();
        }
    }
}
