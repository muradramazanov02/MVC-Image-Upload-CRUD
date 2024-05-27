using Microsoft.AspNetCore.Mvc;

namespace NLayerAndGenericRepository.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
