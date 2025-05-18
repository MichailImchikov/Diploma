using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.StartPopulation
{
    public interface IStartPopulations
    {
        public List<int[]> GetBasePopulation(int size, int countPopulation);
        public string GetName();
    }
}
