using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1= blogManager.GetList().Count;
            ViewBag.v2 = context.Contacts.Count();
            ViewBag.v3 = context.Comments.Count();
            return View();
        }
    }
}

