using System.Dynamic;

namespace курсач_2._0.StartPopulation;

public class NationalInitialPopulations : IStartPopulations
{
    private List<(IStartPopulations metod, float ratio)> _members = new();
    public void GetMember(params (IStartPopulations, float)[] member)
    {
        foreach (var value in member)
        {
            _members.Add((value.Item1, value.Item2));
        }
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

    public string GetName()
    {
        string name = string.Empty;
        foreach (var member in _members)
        {
            name += member.metod.GetName()+ "_"+ member.ratio +" ";
        }
        return name;
    }
}