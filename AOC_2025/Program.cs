// See https://aka.ms/new-console-template for more information

using AOC_2025;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Create host with dependency injection
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var aocCookie = context.Configuration.GetSection("AocSettings:Cookie").Value
                        ?? throw new InvalidOperationException("AOC Cookie not found in configuration");

        services.AddHttpClient("AOC", client =>
        {
            client.BaseAddress = new Uri("https://adventofcode.com/2025/day/");
            client.DefaultRequestHeaders.Add("Cookie", $"session={aocCookie}");
        });

        // Register your other services here
        services.AddScoped<Day1>();
        services.AddScoped<Day2>();

    })
    .Build();

// Get HttpClient from DI container
// var httpClientFactory = host.Services.GetRequiredService<IHttpClientFactory>();
// var httpClient = httpClientFactory.CreateClient("AOC");

// Your application logic here

var day1 = host.Services.GetRequiredService<Day1>();
var test1_1 = day1.TestPart1();
Console.WriteLine($"Day 1 part 1 test: expected 3, got: {test1_1}");
// var solved1_1 = await day1.Part1();
// Console.WriteLine($"Day 1 part 1 solved: {solved1_1}");

var test1_2 = day1.TestPart2();
Console.WriteLine($"Day 1 part 2 test: expected 6, got: {test1_2}");
// var solved1_2 = await day1.Part2();
// Console.WriteLine($"Day 1 part 2 solved: {solved1_2}");


var day2 = host.Services.GetRequiredService<Day2>();
var test2_1 = day2.TestPart1();
Console.WriteLine($"Day 2 part 1 test: expected 1227775554, got: {test2_1}");
var solved2_1 = await day2.Part1();
Console.WriteLine($"Day 2 part 1 solved: {solved2_1}"); // 30599400849
