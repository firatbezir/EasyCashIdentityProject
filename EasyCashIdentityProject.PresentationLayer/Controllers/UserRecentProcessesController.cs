using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class UserRecentProcessesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
