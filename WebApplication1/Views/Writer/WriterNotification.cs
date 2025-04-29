using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Views.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
