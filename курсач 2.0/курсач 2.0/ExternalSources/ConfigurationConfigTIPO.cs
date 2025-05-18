using курсач_2._0.Crossingover;
using курсач_2._0.FindParent;
using курсач_2._0.Mutation;
using курсач_2._0.Select;
using курсач_2._0.StartPopulation;

namespace курсач_2._0;

public class ConfigurationConfigTIPO
{
    public static List<Configuration> GetConfigurations()
    {
        List<Configuration> configurations = new List<Configuration>();
        List<IStartPopulations> startPopulations = new List<IStartPopulations>();
        startPopulations.Add(new RandomPopulations());
        startPopulations.Add(new Dispersion());
        float ration1 = 20;
        float ration2 = 80;
        while (ration1 < 100)
        {
            var nationalInitialPopulation = new NationalInitialPopulations();
            nationalInitialPopulation.GetMember((new RandomPopulations(), ration1), (new Dispersion(), ration2));
            startPopulations.Add(nationalInitialPopulation);
            ration1 += 20;
            ration2 -= 20;
        }
        List<IFindParents> findParents = new List<IFindParents>();
        findParents.Add(new Insourcing());
        findParents.Add(new Outsourcing());
        foreach (var start in startPopulations)
        {
            foreach (var parent in findParents)
            {
                configurations.Add(GetConfiguration(start, parent));
            }
        }
        return configurations;
    }

    private static Configuration GetConfiguration(IStartPopulations startPopulations, IFindParents findParents)
    {
        var conf = new Configuration();
        conf.FindParents = findParents;
        conf.StartPopulation = startPopulations;
        conf.Mutation = new MutationInversion();
        conf.Select = new LineRang();
        conf.Crossover = new Crossbreeding();
        var excelManager = new ExcelManager(conf.NameFile);
        conf.excelManager = excelManager;
        return conf;
    }
}