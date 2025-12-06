namespace AOC_2025;

public interface IParsedInput;

public abstract class Days
{
    protected HttpClient Client { get; set; }
    
}

public interface ISolvable
{
    
    public int SolvePart1(List<IParsedInput> input);
    public int SolvePart2(List<IParsedInput> input);

}