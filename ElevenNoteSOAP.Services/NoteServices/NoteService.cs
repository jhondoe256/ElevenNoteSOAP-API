using ElevenNoteSOAP.Data;
using ElevenNoteSOAP.Data.Entities;
using ElevenNoteSOAP.Models.CategoryModels;
using ElevenNoteSOAP.Models.NoteModels;
using Microsoft.EntityFrameworkCore;

namespace ElevenNoteSOAP.Services.NoteServices
{
    public class NoteService : INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNote(NoteCreate note)
        {
            var entity = new NoteEntity
            {
                Title = note.Title,
                CategoryEntityId = note.CategoryEntityId,
                Content = note.Content,
            };
            await _context.Notes.AddAsync(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteNote(int noteId)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if(note == null) return false;
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditNote(NoteEdit note)
        {
            var noteData = await _context.Notes.FindAsync(note.Id);
            if (noteData == null) return false;
            
            noteData.Title = note.Title;
            noteData.Content = note.Content;
            noteData.CategoryEntityId = note.CategoryEntityId;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<NoteDetail> GetNote(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return new NoteDetail();

            return new NoteDetail 
            {
                Id = note.Id,
                Title = note.Title, 
                Content = note.Content ,
                Category = new CategoryListItem 
                {
                    Id =note.CategoryEntityId,
                    Title = note.Title,
                }
            };
        }

        public Task<List<NoteListItem>> GetNotes()
        {
            return _context.Notes.Select(n => new NoteListItem { 
                Id = n.Id,
                Title = n.Title,
            }).ToListAsync();
        }
    }
}
