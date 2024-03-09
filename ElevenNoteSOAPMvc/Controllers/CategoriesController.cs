using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace ElevenNoteSOAPMvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> PostCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>CategoryCreate(CategoryCreate categoryCreate) 
        {
            if (!ModelState.IsValid) return View(categoryCreate);
            var response = await _categoryService.AddCategoryAsync(new AddCategoryRequest(new AddCategoryRequestBody(categoryCreate)));
            if (response != null)
                return RedirectToAction(nameof(Index));
            else
                return View(categoryCreate);
        }

        [HttpGet]
        public async Task<IActionResult>Details(int id) 
        {
            var response = await _categoryService.GetCategoryAsync(new GetCategoryRequest(new GetCategoryRequestBody(id)));
            if(response == null) return NotFound();
            return View(response.Body.GetCategoryResult);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _categoryService.GetCategoryAsync(new GetCategoryRequest(new GetCategoryRequestBody(id)));
            if (response == null) return NotFound();
            var info = response.Body.GetCategoryResult;
            
            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEdit(CategoryEdit categoryEdit)
        {
            if (!ModelState.IsValid) return View(categoryEdit);
            var response = await _categoryService.EditCategoryAsync(new EditCategoryRequest(new EditCategoryRequestBody(categoryEdit)));
            if (response != null)
                return RedirectToAction(nameof(Index));
            else
                return View(categoryEdit);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var response = await _categoryService.GetCategoryAsync(new GetCategoryRequest(new GetCategoryRequestBody(id.Value)));
            if (response == null) return NotFound();
            var info = response.Body.GetCategoryResult;

            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            if (id <= 0) return BadRequest("Invalid Data Entry.");
            if( await _categoryService.DeleteCategoryAsync(id))
                return RedirectToAction(nameof(Index));
            else
                return Problem("Internal Server Error",statusCode:500);
        }
    }
}
