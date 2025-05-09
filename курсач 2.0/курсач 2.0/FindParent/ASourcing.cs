using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.FindParent
{
    abstract public class ASourcing : IFindParents
    {
        protected List<int[]> _population;
        private List<int> _showParentIndex_One;
        private Random _rnd = new Random();
        public ASourcing(List<int[]> population)
        {
            _population = population;
        }

        protected abstract int CountParametr(int[] Parent1, int[] Parent2);
        public (int[], int[]) GetParents(int Parameter)
        {
            _showParentIndex_One = GetRandomSequence();
            foreach(var indexParent_One in _showParentIndex_One)
            {
                var Parent_One = _population[indexParent_One];
                var Parent_Two = PairSearch(Parent_One, Parameter);
                if(Parent_Two is not null) return (Parent_One, Parent_Two);
            }
            return GetParents(Parameter - 1);

        }
        public int GetParentOneSequence()
        {
            if (_showParentIndex_One.Count == 0) return -1;
            var indexParent = _showParentIndex_One[0];
            _showParentIndex_One.RemoveAt(0);
            return indexParent;
        }
        private int[] PairSearch(int[] Parent1, int Parameter)
        {
            int[] Parent_Two = null;
            List<int> shuffledList = GetRandomSequence();
            foreach (var element in shuffledList)
            {
                if (CountParametr(Parent1, _population[element]) < Parameter) continue;
                Parent_Two = _population[element];
                break;
            }
            return Parent_Two;

        }
        private List<int> GetRandomSequence()
        {
             return Enumerable.Range(0, _population.Count)
                                               .OrderBy(x => _rnd.Next())
                                               .ToList();
        }
    }
}
