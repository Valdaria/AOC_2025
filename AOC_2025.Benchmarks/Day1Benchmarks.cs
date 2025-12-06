using AOC_2025;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;

namespace AOC_2025.Benchmarks;

//
// | Method     | Mean      | Error    | StdDev   | Allocated |
// |----------- |----------:|---------:|---------:|----------:|
// | SolvePart1 |  50.62 us | 0.507 us | 0.450 us |         - |
// | SolvePart2 | 528.33 us | 3.587 us | 3.355 us |         - |

[MemoryDiagnoser]
[InProcess]
[InvocationCount(1000)]
public class Day1Benchmarks
{
    private Day1 _day1 = null!;
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
        _day1 = new Day1(mockFactory);
        // _testInput = _day1.TestInputPart1().Cast<IParsedInput>().ToList();
        _parsedInput = _day1.ParseInput().Result.Cast<IParsedInput>().ToList();

    }

    [Benchmark]
    public int SolvePart1()
    {
        return _day1.SolvePart1(_parsedInput);
    }

    [Benchmark]
    public int SolvePart2()
    {
        return _day1.SolvePart2(_parsedInput);
    }
}
