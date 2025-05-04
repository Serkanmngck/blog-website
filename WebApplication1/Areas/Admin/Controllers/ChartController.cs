using DotNetCoreCamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Areas.Admin.Models;

namespace DotNetCoreCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 5
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 2
            });
            return Json(new { jsonlist = list });
        }
    }
}