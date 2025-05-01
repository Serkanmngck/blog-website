using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager=new Message2Manager(new EfMessage2Repository());
        public IActionResult InBox()
        {
            int id = 2;
            var values= message2Manager.GetInBoxListByWriter(id);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.TGetById(id);


            return View(value);
        }
    }
}
