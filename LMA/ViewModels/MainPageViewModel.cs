using System.Threading.Tasks;
using LMA.Interfaces;
using LMA.Models;
using LMA.Data;

namespace LMA.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private readonly INotesService _notesService;
    private string _markdown = string.Empty;

    // Parameterless constructor for XAML/design-time
    public MainPageViewModel() : this(new NotesDatabase())
    {
    }

    public MainPageViewModel(INotesService notesService)
    {
        _notesService = notesService;
        SaveCommand = new Command(async () => await SaveAsync());
    }

    public string Markdown
    {
        get => _markdown;
        set => SetProperty(ref _markdown, value);
    }

    public Command SaveCommand { get; }

    private async Task SaveAsync()
    {
        var note = new Note { Title = "Saved Note", Content = Markdown };
        await _notesService.AddNoteAsync(note);
    }
}
