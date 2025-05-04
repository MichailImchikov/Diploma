using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.Select
{
    public class LineRang 
    {
        public List<int[]> GetNewPopulation(List<int[]>Parents, List<int[]>Childs , KZN_Data data)
        {
            List<int[]> newPopulation = new List<int[]>();
            List<int[]> oldPopulation = new List<int[]>(Parents);
            List<float> probability = new();
            Random rnd = new();
            foreach(var child in Childs)
            {
                if(!oldPopulation.Contains(child)) oldPopulation.Add(child);
            }

            if (oldPopulation.Count <= Parents.Count) return oldPopulation;

            foreach(var element in oldPopulation)
            {
                probability.Add(1f / (float)data.GetCriteria(element));
            }
            var indexMax = probability.IndexOf(probability.Max());
            newPopulation.Add(oldPopulation[indexMax]);

            for (int i = 0; i < Parents.Count - 1; i++)
            {
                var sum = probability.Sum();
                var randomValue = rnd.NextDouble() * sum;
                int indexElemnet = -1;
                while (randomValue >= 0)
                {
                    indexElemnet++;
                    randomValue -= probability[indexElemnet];
                }
                newPopulation.Add(oldPopulation[indexElemnet]);
                oldPopulation.RemoveAt(indexElemnet);
                probability.RemoveAt(indexElemnet);
            }
            return newPopulation;
        }
    }
}
