using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNoteSOAP.Models.NoteModels
{
    public class NoteCreate
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(8000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int CategoryEntityId { get; set; }
    }
}
