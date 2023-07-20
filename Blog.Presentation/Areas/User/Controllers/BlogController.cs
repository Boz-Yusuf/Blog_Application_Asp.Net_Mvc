using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.User.Controllers
{
    [Area("User")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
