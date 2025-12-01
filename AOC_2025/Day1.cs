namespace AOC_2025;

public class Day1 : Days
{
    public enum Direction { Left, Right }

    public record struct ParsedInput(Direction Direction, int Distance);

    public Day1(IHttpClientFactory httpClientFactory)
    {
        Client = httpClientFactory.CreateClient("AOC"); 
    }
    
    
    private double Mod(float a, float b)
    {
        var n = a%b;
        return n <0 ? n+b : n;
    }

    
    public async Task<List<ParsedInput>> ParseInput()
    {
        var input = await Client.GetStringAsync("1/input");
        return input
            .Trim()
            .Split("\n")
            .Select(line => new ParsedInput(line[0] == 'L' ? Direction.Left : Direction.Right, int.Parse(line[1..])))
            .ToList();
       
    }

    public List<ParsedInput> TestInputPart1()
    {
        return
        [
            new(Direction.Left, 68),
            new(Direction.Left, 30),
            new(Direction.Right, 48),
            new(Direction.Left, 5),
            new(Direction.Right, 60),
            new(Direction.Left, 55),
            new(Direction.Left, 1),
            new(Direction.Left, 99),
            new(Direction.Right, 14),
            new(Direction.Left, 82)
        ];
    }
    
    public int TestPart1()
    {
        
        var input = TestInputPart1();
        var result = SolvePart1(input);
        return result;
    }
    
    public async Task<int> Part1()
    {
        var input = await ParseInput();
        var result = SolvePart1(input);
        return result;
    }

    public int SolvePart1(List<ParsedInput> input)
    {
        var result = 0;
        var dialPosition = 50;
        foreach (var line in input)
        {
            dialPosition = line.Direction switch
            {
                Direction.Left => (int)Mod(dialPosition - line.Distance, 100),
                Direction.Right => (int)Mod(dialPosition + line.Distance, 100)
            };
            if(dialPosition == 0) result++;
        }

        return result;
    }


    
}