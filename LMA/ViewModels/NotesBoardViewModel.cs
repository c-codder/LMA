using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LMA.Interfaces;
using LMA.Models;

namespace LMA.ViewModels;

public class NotesBoardViewModel : BaseViewModel
{
    private readonly INotesService _notesService;
    private ObservableCollection<Note> _notes = new();

    public NotesBoardViewModel(INotesService notesService)
    {
        _notesService = notesService;
        LoadNotesCommand = new Command(async () => await LoadNotesAsync());
        AddNoteCommand = new Command(async () => await AddNoteAsync());
    }

    public ObservableCollection<Note> Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public Command LoadNotesCommand { get; }
    public Command AddNoteCommand { get; }

    private async Task LoadNotesAsync()
    {
        var notes = await _notesService.GetNotesAsync();
        Notes.Clear();
        foreach (var note in notes)
            Notes.Add(note);
    }

    private async Task AddNoteAsync()
    {
        var newNote = new Note { Title = "New Note", Content = "" };
        var added = await _notesService.AddNoteAsync(newNote);
        Notes.Add(added);
    }
}
