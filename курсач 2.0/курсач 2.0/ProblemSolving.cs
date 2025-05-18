using System.Diagnostics;
using курсач_2._0.Crossingover;
using курсач_2._0.FindParent;
using курсач_2._0.Mutation;
using курсач_2._0.Select;
using курсач_2._0.StartPopulation;

namespace курсач_2._0;

public class ProblemSolving
{
    private Configuration _configuration;
    public ProblemSolving(Configuration cfg)
    {
     _configuration = cfg;   
    }
    public void Run(int size, int row, string pref = "")
    {
        int countPopulation = size / 2;
        int countStep = size * 100 ;
        int crossParam = (int)(size / 4);
        int probability = 5;
        int сounter = 0;
        int iteracion = 0;
        float bestCriteria = float.MaxValue;
        
        List<int[]> childs = new();
        Random rnd = new Random();
        Stopwatch stopwatch = new Stopwatch();
        KZN_Data data = new(size.ToString()+pref);
        
        var parents = _configuration.StartPopulation.GetBasePopulation(size, countPopulation);
        stopwatch.Start();
        do
        {
            childs.Clear();
            for (int i = 0; i < countPopulation; i++)
            {
                var para = _configuration.FindParents.GetParents(crossParam,parents);
                var newChild = _configuration.Crossover.GetChild(para.Item1, para.Item2);
                childs.Add(newChild);
            }
            for (var i = 0; i < childs.Count; i++)
            {
                var value = rnd.Next(0, 100);
                if (value > probability) continue;
                childs.Add(_configuration.Mutation.Mutation(childs[i]));
            }
            parents = _configuration.Select.GetNewPopulation(parents, childs, data);
            iteracion++;
            int currentBestCriteria = data.GetCriteria(parents[0]);
            if (bestCriteria > currentBestCriteria)
            {
                сounter = 0;
                bestCriteria = currentBestCriteria;
            }
            else сounter++;
        } while (сounter < countStep);
        stopwatch.Stop();
        _configuration.excelManager.WriteCell(row, 4, data.GetCriteria(parents[0]));
        _configuration.excelManager.WriteCell(row, 5, stopwatch.Elapsed.TotalSeconds);
        _configuration.excelManager.WriteCell(row, 6, iteracion);
    }
}