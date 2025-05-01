using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 2;
            var values = messageManager.GetInBoxListByWriter(id);
            return View(values);
        }
    }
    
}
