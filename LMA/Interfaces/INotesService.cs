using System.Collections.Generic;
using System.Threading.Tasks;
using LMA.Models;

namespace LMA.Interfaces
{
    public interface INotesService
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<Note> AddNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(int id);
    }
}
