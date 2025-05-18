namespace курсач_2._0.StartPopulation;

public class NationalInitialPopulations : IStartPopulations
{
    private List<(IStartPopulations metod, float ratio)> _members;
    public NationalInitialPopulations(List<(IStartPopulations, float)> members, int countPopulation)
    {
        _members = members;
    }
    public List<int[]> GetBasePopulation(int size, int countPopulation)
    {
        var populations = new List<int[]>();
        foreach (var member in  _members)
        {
            var memberPopulation = member.metod.GetBasePopulation( size, (int)(member.ratio * size));
            populations.AddRange(memberPopulation);
        }
        return populations;
    }
}