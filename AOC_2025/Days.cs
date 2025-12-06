namespace AOC_2025;

public interface IParsedInput;

public abstract class Days
{
    protected HttpClient Client { get; set; }
    
}

public interface ISolvable
{
    
    public long SolvePart1(List<IParsedInput> input);
    public long SolvePart2(List<IParsedInput> input);

}