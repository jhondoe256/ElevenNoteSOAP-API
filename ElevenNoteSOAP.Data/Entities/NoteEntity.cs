using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNoteSOAP.Data.Entities
{
    public class NoteEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        
        
        [MaxLength(8000)]
        public string Content { get; set; } = string.Empty;
        
        public int CategoryEntityId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
    }
}
