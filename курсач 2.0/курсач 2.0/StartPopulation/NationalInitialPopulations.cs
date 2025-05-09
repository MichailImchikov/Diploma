namespace курсач_2._0.StartPopulation;

public class NationalInitialPopulations : IStartPopulations
{
    private List<(IStartPopulations metod, float ratio)> _members;
    private int _countPopulation;
    public NationalInitialPopulations(List<(IStartPopulations, float)> members, int countPopulation)
    {
        _members = members;
        _countPopulation = countPopulation;
    }
    

    public List<int[]> GetBasePopulation(int countPopulation)
    {
        var populations = new List<int[]>();
        foreach (var member in  _members)
        {
            var memberPopulation = member.metod.GetBasePopulation((int)(member.ratio * _countPopulation));
            populations.AddRange(memberPopulation);
        }
        return populations;
    }
}