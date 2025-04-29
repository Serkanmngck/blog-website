using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var CommentValues = new List<UserComment>
            {
                new UserComment
                {
                    id = 1,
                    username="serkan"
                },
                new UserComment
                {
                    id = 2,
                    username="sserkan"
                },
                new UserComment
                {
                    id = 3,
                    username="ssserkan"
                }

            };
            return View();
        }
    }
}
