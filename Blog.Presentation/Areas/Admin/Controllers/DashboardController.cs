using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy ="Admin")]
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
