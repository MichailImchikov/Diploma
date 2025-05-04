using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.FindParent
{
    public class Outsourcing :IFindParents
    {
        List<int[]> _population;
        List<int> _showParent1;
        public Outsourcing(List<int[]>Population) 
        {
            this._population = Population;
        }

        public (int[], int[]) GetParents(int Parameter)
        {
            _showParent1 = new List<int>();
            Random Rnd = new Random();
            var indexParent1 = Rnd.Next(0,_population.Count);
            do
            {
                var Parent1 = _population[indexParent1];
                var Parent2 = PairSearch(Parent1, Parameter);
                if (Parent2 is not null) return (Parent1, Parent2);
                indexParent1 = GetRandomParent1();
            } while (indexParent1 != -1);
            return GetParents(Parameter - 1);

        }
        public int GetRandomParent1()
        {
            Random rnd = new();
            int randomIndex = 0;
            do
            {
                randomIndex = rnd.Next(0, _population.Count);
            } while (_showParent1.Contains(randomIndex) || _showParent1.Count != _population.Count);
            if (_showParent1.Contains(randomIndex)) return -1;
            _showParent1.Add(randomIndex);
            return randomIndex;
        }
        private int[] PairSearch(int[] Parent1,int Parameter)
        {
            List<int[]> ShowParent = new();
            foreach (var element in _population)
            {
                if(CountParametr(Parent1, element) > Parameter)
                        ShowParent.Add(element);  
            }
            if (ShowParent.Count == 0) return null;
            Random rnd = new();
            return ShowParent[rnd.Next(0, ShowParent.Count)];

        }
        private int CountParametr(int[] Parent1, int[] Parent2)
        {
            int param = 0;
            for(var i=0 ; i<Parent1.Length; i++)
            {
                if (Parent1[i] != Parent2[i]) param++;
            }
            return param;
        }
    }
}
