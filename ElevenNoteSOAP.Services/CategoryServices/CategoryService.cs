using ElevenNoteSOAP.Data;
using ElevenNoteSOAP.Data.Entities;
using ElevenNoteSOAP.Models.CategoryModels;
using ElevenNoteSOAP.Models.NoteModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNoteSOAP.Services.CategoryServices
{

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCategory(CategoryCreate category)
        {
            var entity = new CategoryEntity
            {
                Title = category.Title,
            };

            await _context.Categories.AddAsync(entity);
            return _context.SaveChanges() == 1;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if(category == null) return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditCategory(CategoryEdit category)
        {
            var categoryInDb = await _context.Categories.FindAsync(category.Id);
            if( categoryInDb == null ) return false;
            
            categoryInDb.Title = category.Title;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryListItem>> GetCategories()
        {
            return await _context.Categories.Select(c=> new CategoryListItem
            {
                Id = c.Id,
                Title = c.Title,
            }).ToListAsync();
        }

        public async Task<CategoryDetail> GetCategory(int id)
        {
            var categoryInDb = await _context.Categories.FindAsync(id);
            if (categoryInDb == null) return new CategoryDetail();

            return new CategoryDetail
            {
                Id=categoryInDb.Id,
                Title=categoryInDb.Title,
                Notes = categoryInDb.Notes.Select(n=> new NoteListItem
                {
                    Id = n.Id,
                    Title = n.Title
                }).ToList()
            };
        }
    }
}
