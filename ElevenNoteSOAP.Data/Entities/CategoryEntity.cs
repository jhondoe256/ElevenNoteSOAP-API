using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNoteSOAP.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        public List<NoteEntity> Notes { get; set; } = new List<NoteEntity>();
    }
}
