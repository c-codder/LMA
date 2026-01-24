namespace JokeConsole.Models;

public class OneLinerJoke : Joke
{
    public override string ToString() => Content;
}
