using System.Collections.Generic;
using System.Threading.Tasks;
using LMA.Interfaces;
using LMA.Models;

namespace LMA.Data
{
    
    public class NotesDatabase : INotesService
    {
        private readonly List<Note> _notes = new();
        private int _nextId = 1;

        public NotesDatabase()
        {
        }

        public Task<IEnumerable<Note>> GetNotesAsync()
        {
            return Task.FromResult<IEnumerable<Note>>(_notes);
        }

        public Task<Note> AddNoteAsync(Note note)
        {
            note.Id = _nextId++;
            _notes.Add(note);
            return Task.FromResult(note);
        }

        public Task UpdateNoteAsync(Note note)
        {
            var idx = _notes.FindIndex(n => n.Id == note.Id);
            if (idx >= 0)
                _notes[idx] = note;
            return Task.CompletedTask;
        }

        public Task DeleteNoteAsync(int id)
        {
            _notes.RemoveAll(n => n.Id == id);
            return Task.CompletedTask;
        }
    }
}
