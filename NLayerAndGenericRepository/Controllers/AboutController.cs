using Microsoft.AspNetCore.Mvc;

namespace NLayerAndGenericRepository.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
