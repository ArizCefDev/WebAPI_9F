using Microsoft.AspNetCore.Mvc;

namespace WebAPI_9F.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
