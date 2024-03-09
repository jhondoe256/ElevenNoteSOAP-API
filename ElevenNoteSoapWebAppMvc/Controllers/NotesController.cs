using Microsoft.AspNetCore.Mvc;

namespace ElevenNoteSoapWebAppMvc.Controllers
{
    public class NotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
