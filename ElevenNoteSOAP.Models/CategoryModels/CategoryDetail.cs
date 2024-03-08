using ElevenNoteSOAP.Data.Entities;
using ElevenNoteSOAP.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNoteSOAP.Models.CategoryModels
{
    public class CategoryDetail
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<NoteListItem> Notes { get; set; } = new List<NoteListItem>();
    }
}
