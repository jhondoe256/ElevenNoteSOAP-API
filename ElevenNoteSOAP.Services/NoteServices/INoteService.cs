using ElevenNoteSOAP.Models.CategoryModels;
using ElevenNoteSOAP.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNoteSOAP.Services.NoteServices
{
    [ServiceContract]
    public interface INoteService
    {
        [OperationContract]
        Task<bool> AddNote(NoteCreate note);

        [OperationContract]
        Task<bool> EditNote(NoteEdit note);

        [OperationContract]
        Task<bool> DeleteNote(int noteId);

        [OperationContract]
        Task<List<NoteListItem>> GetNotes();

        [OperationContract]
        Task<NoteDetail> GetNote(int id);
    }
}
