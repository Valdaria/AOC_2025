namespace AOC_2025;

public class Day2 : Days, ISolvable
{

    public record struct Range(long Start, long End) : IParsedInput;
    
    public Day2(IHttpClientFactory httpClientFactory)
    {
        Client = httpClientFactory.CreateClient("AOC"); 
    }
    
    public async Task<List<Range>> ParseInput()
    {
        var input = await Client.GetStringAsync("2/input");
        return input
            .Trim()
            .Split(",")
            .Select(line => line.Split("-"))
            .Select(line => new Range(long.Parse(line[0]), long.Parse(line[1])))
            .ToList();

    }

    public List<Range> TestInputPart1()
    {
        return
        [
            new Range(11, 22),
            new Range(95, 115),
            new Range(998, 1012),
            new Range(1188511880, 1188511890),
            new Range(222220, 222224),
            new Range(1698522, 1698528),
            new Range(446443, 446449),
            new Range(38593856, 38593862),
            new Range(565653, 565659),
            new Range(824824821, 824824827),
            new Range(2121212118, 2121212124),
        ];
    }

    public long TestPart1()
    {
        var input = TestInputPart1();
        return SolvePart1(input.Cast<IParsedInput>().ToList());
    }

    public async Task<long> Part1()
    {
        var input = await ParseInput();
        return SolvePart1(input.Cast<IParsedInput>().ToList());
    }
    
    public long SolvePart1(List<IParsedInput> genericInput)
    {
        // si le nombre a un nombre de caractères impair > skip
        // on coupe la poire en deux, si gauche = droite => OK

        var result = 0L;
        var input = genericInput.Cast<Range>();

        foreach (var range in input)
        {
            var current = range.Start;
            while (current <= range.End)
            {
                var currentString = current.ToString();

                if (currentString.Length % 2 == 1)
                {
                    current++;
                    continue;
                }
                var splittedLeft = currentString[..(currentString.Length / 2)];
                var splittedRight = currentString[((currentString.Length / 2))..];
                if(splittedLeft.Equals(splittedRight)) 
                    result += current;
                current++;
            } 
            
        }
        
        
        return result;

    }

    public long SolvePart2(List<IParsedInput> input)
    {
        throw new NotImplementedException();
    }
}