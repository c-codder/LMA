namespace JokeConsole.Models;

public abstract class Joke
{
    public string Content { get; set; } = string.Empty;
    public abstract override string ToString();
}
