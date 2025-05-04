using BusinessLayer.Concrete;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

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
            string api = "1f24ccca50e5d6b0153e97b54fc73c43";
            string city = "Istanbul";
            string connection=" https://api.openweathermap.org/data/2.5/weather?q="+ city + "&mode=xml&appid=" +api;
            XDocument  document = XDocument.Load(connection);
            string Ktemperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;  // "288.55" string olarak döner
            float kelvin = float.Parse(Ktemperature, System.Globalization.CultureInfo.InvariantCulture);
            float celsius = kelvin - 273.15f;
            string Ctemperature = celsius.ToString("0.0", System.Globalization.CultureInfo.InvariantCulture) + "°C";
            ViewBag.v4 = Ctemperature;
            return View();
        }
    }
}

