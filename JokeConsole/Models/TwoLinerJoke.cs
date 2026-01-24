namespace JokeConsole.Models;

public class TwoLinerJoke : Joke
{
    public string Setup { get; set; } = string.Empty;
    public string Delivery { get; set; } = string.Empty;

    public override string ToString() => $"{Setup}\n{Delivery}";
}
