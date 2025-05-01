using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace WebApplication1.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        private readonly IWriterService _writerService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WriterAboutOnDashboard(IWriterService writerService, IHttpContextAccessor httpContextAccessor)
        {
            _writerService = writerService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            var userMail = _httpContextAccessor.HttpContext.User.Identity.Name;
            var writer = _writerService.GetWriterByMail(userMail);
            return View(writer);
        }
    }
}
