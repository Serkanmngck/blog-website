using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            String mail;
            mail = "serkan@gmail.com";
            var values = messageManager.GetInBoxListByWriter(mail);
            return View(values);
        }
    }
    
}
