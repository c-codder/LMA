using JokeConsole.Models;

namespace JokeConsole.Interfaces;

public interface IJokeService
{
    Task<List<Joke>> GetJokesAsync();
}
