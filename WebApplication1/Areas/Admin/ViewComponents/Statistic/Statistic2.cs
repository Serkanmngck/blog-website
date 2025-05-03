using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.ViewComponents.Statistic
{
    [Area("Admin")]
    public class Statistic2 : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Blogs.OrderByDescending(x=>x.BlogId).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            //ViewBag.v3 = context.Comments.Count();
            return View();
        }
    }
}
