// See https://aka.ms/new-console-template for more information

using AOC_2025;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const string AOC_COOKIE = "53616c7465645f5fecdfb1f23a04fe84c36864aefe4e06f1d426639b68e7ba37788475d1e2b7072f78661663ed429d610258717149fbfc0fd2dd7b7d8dd61534";

// Create host with dependency injection
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient("AOC", client =>
        {
            client.BaseAddress = new Uri("https://adventofcode.com/2025/day/");
            client.DefaultRequestHeaders.Add("Cookie", $"session={AOC_COOKIE}");
        });
        
        // Register your other services here
        services.AddScoped<Day1>();
    })
    .Build();

// Get HttpClient from DI container
// var httpClientFactory = host.Services.GetRequiredService<IHttpClientFactory>();
// var httpClient = httpClientFactory.CreateClient("AOC");

// Your application logic here

var day1 = host.Services.GetRequiredService<Day1>();
var test1_1 = day1.TestPart1();
Console.WriteLine($"Day 1 part 1 test: expected 3, got: {test1_1}");
var solved1_1 = await day1.Part1();
Console.WriteLine($"Day 1 part 1 solved: {solved1_1}");