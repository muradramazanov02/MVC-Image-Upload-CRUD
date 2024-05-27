using Microsoft.AspNetCore.Mvc;
using Pronia.Business.Services.Abstracts;

namespace NLayerAndGenericRepository.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ShopController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var datas = _categoryService.GetAllCategories();
            return View(datas);
        }
        public IActionResult SingleProductVariable()
        {
            return View();
        }
    }
}
