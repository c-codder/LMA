using JokeConsole.Interfaces;
using JokeConsole.Services;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddHttpClient<IJokeService, JokeService>();

var provider = services.BuildServiceProvider();

var jokeService = provider.GetRequiredService<IJokeService>();
var jokes = await jokeService.GetJokesAsync();

Console.WriteLine("Jokes:\n");
int i = 1;
foreach (var joke in jokes)
{
    Console.WriteLine($"{i}. {joke}\n");
    i++;
}
