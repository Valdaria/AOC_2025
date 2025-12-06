using AOC_2025;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;

namespace AOC_2025.Benchmarks;

[MemoryDiagnoser]
[InProcess]
[InvocationCount(100)]
public class Day2Benchmarks
{
    private Day2 _day2 = null!;
    private List<IParsedInput> _parsedInput = null!;

    [GlobalSetup]
    public void Setup()
    {

        
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var cookie = configuration.GetSection("AocSettings:Cookie").Value
                     ?? throw new InvalidOperationException("AOC Cookie not found in configuration");

        // Create a mock HttpClientFactory for benchmarking
        var mockFactory = new MockHttpClientFactory(cookie);
        _day2 = new Day2(mockFactory);
        // _testInput = _day1.TestInputPart1().Cast<IParsedInput>().ToList();
        _parsedInput = _day2.ParseInput().Result.Cast<IParsedInput>().ToList();

    }

    [Benchmark]
    public long SolvePart1()
    {
        return _day2.SolvePart1(_parsedInput);
    }

    // [Benchmark]
    // public long SolvePart2()
    // {
    //     return _day1.SolvePart2(_parsedInput);
    // }
}
