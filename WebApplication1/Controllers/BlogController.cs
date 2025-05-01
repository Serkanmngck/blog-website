using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategorys();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(userIdClaim, out int writerId))
            {
                var values = bm.GetListWithCategoryByWirterBM(writerId);
                return View(values);
            }

            return RedirectToAction("Index", "Login"); 
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv=categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = userId;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogalue = bm.TGetById(id);

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;

            return View(blogalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            // Eski blogu veritabanından tekrar çekiyoruz
            var existingBlog = bm.TGetById(p.BlogId);

            // Eski oluşturulma tarihini koruyoruz
            p.BlogCreateDate = existingBlog.BlogCreateDate;

            // Diğer zorunlu alanlar
            p.WriterID = 1;
            p.BlogStatus = true;

            // Güncelleme işlemi
            bm.TUpdate(p);

            return RedirectToAction("BlogListByWriter");
        }



    }
}
