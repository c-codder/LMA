using System.Net.Http.Json;
using JokeConsole.Interfaces;
using JokeConsole.Models;

namespace JokeConsole.Services;

public class JokeService : IJokeService
{
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&amount=3";

    public JokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Joke>> GetJokesAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<JokeApiResponse>(ApiUrl);
        var jokes = new List<Joke>();

        if (response?.Jokes != null)
        {
            foreach (var jokeData in response.Jokes)
            {
                Joke joke;
                if (jokeData.Type == "single")
                {
                    joke = new OneLinerJoke { Content = jokeData.Joke ?? string.Empty };
                }
                else
                {
                    joke = new TwoLinerJoke
                    {
                        Setup = jokeData.Setup ?? string.Empty,
                        Delivery = jokeData.Delivery ?? string.Empty
                    };
                }
                jokes.Add(joke);
            }
        }

        return jokes;
    }
}

public class JokeApiResponse
{
    public List<JokeData>? Jokes { get; set; }
}

public class JokeData
{
    public string Type { get; set; } = string.Empty;
    public string? Joke { get; set; }
    public string? Setup { get; set; }
    public string? Delivery { get; set; }
}
