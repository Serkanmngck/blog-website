using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager=new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllNotification()
        {
            var values = notificationManager.GetList();
            return View(values);
        }
    }


}
