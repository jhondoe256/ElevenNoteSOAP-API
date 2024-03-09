using ElevenNoteSoapWebAppMvc.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace ElevenNoteSoapWebAppMvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ServiceReference.ICategoryService _categoryService;

        public CategoriesController(ServiceReference.ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories =  await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Post() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Post(CategoryCreate model) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _categoryService.AddCategoryAsync(new AddCategoryRequest { Body = new AddCategoryRequestBody(model) });
            if(response is not null)
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }
    }
}
