using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewComponents.Blog
{
    [AllowAnonymous]
    public class BlogLast3:ViewComponent
    {
     
            BlogManager bm = new BlogManager(new EfBlogRepository());
            public IViewComponentResult Invoke()
            {
                var values = bm.GetLast3Blog();
                return View(values);
            }
        
    }
}
