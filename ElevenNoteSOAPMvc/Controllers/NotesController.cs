using Microsoft.AspNetCore.Mvc;
using NotesReference;

namespace ElevenNoteSOAPMvc.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var notes = await _noteService.GetNotesAsync();
            return View(notes);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _noteService.GetNoteAsync(new GetNoteRequest(new GetNoteRequestBody(id)));
            if (response == null) return NotFound();
            return View(response.Body.GetNoteResult);
        }

        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>PostNote(NoteCreate noteCreate) 
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var response = await _noteService.AddNoteAsync(new AddNoteRequest(new AddNoteRequestBody(noteCreate)));
            if (response != null)
                return RedirectToAction(nameof(Index));
            else
                return View(noteCreate);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _noteService.GetNoteAsync(new GetNoteRequest(new GetNoteRequestBody(id)));
            if (response == null) return NotFound();
            
            var data = response.Body.GetNoteResult;

            var noteEdit = new NoteEdit
            {
                Id = data.Id,
                CategoryEntityId = data.Category.Id,
                Content = data.Content,
                Title = data.Title
            };

            return View(noteEdit);
        }

        [HttpPost]
        public async Task<IActionResult>NoteEdit(NoteEdit noteEdit)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var response = await _noteService.EditNoteAsync(new EditNoteRequest(new EditNoteRequestBody(noteEdit)));
            if (response != null)
                return RedirectToAction(nameof(Index));
            else
                return View(noteEdit);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var response = await _noteService.GetNoteAsync(new GetNoteRequest(new GetNoteRequestBody(id!.Value)));
            if (response == null) return NotFound();
            return View(response.Body.GetNoteResult);
        }

        [HttpPost]
        public async Task<IActionResult> NoteDelete(int id)
        {
            if (id<=0) { return BadRequest("Invalid Data Entry."); }
             
            if (await _noteService.DeleteNoteAsync(id))
                return RedirectToAction(nameof(Index));
            else
                return Problem("Internal Server Error",statusCode:500);
        }
    }
}
