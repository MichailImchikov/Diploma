using курсач_2._0.Crossingover;
using курсач_2._0.FindParent;
using курсач_2._0.Mutation;
using курсач_2._0.Select;
using курсач_2._0.StartPopulation;

namespace курсач_2._0;

public struct Configuration
{
    public string NameFile;
    public string DescriptionFile => StartPopulation + " " + FindParents + " "+ Crossover + " " + Mutation + " " + Select;
    public ICrossingover Crossover;
    public IFindParents FindParents;
    public IMutation Mutation;
    public IStartPopulations StartPopulation;
    public ISelect Select;
    public ExcelManager excelManager;
}