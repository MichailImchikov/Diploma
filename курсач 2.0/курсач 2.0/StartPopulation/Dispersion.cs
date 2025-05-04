using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.StartPopulation
{
    class Dispersion : IStartPopulation
    {
        List<int[]> permutations = new();
        public int CountNumber = 0;
        public Dispersion(int CountNumber)
        {
            this.CountNumber = CountNumber;
        }

        public List<int[]> GetBasePopulation(int countPopulation)
        {
            while (permutations.Count < countPopulation)
            {
                int[] newPermutation = new int[CountNumber];
                for (int i = 0; i < CountNumber; i++)
                {
                    var Value_Repetitions = GetMinNumberByIndex(i);
                    for (int j = 0; j < i; j++)
                    {
                        Value_Repetitions.Remove(newPermutation[j]);
                    }
                    var key = GetRandomKey(Value_Repetitions);
                    newPermutation[i] = key;
                }
                permutations.Add(newPermutation);
            }
            return permutations;

        }
        private int GetRandomKey(Dictionary<int, int> dict)
        {
            double totalWeight = dict.Values.Sum(value => 1.0 / value);
            double randomValue = new Random().NextDouble() * totalWeight;
            double cumulativeWeight = 0;
            foreach (var kvp in dict)
            {
                cumulativeWeight += 1.0 / kvp.Value;
                if (cumulativeWeight >= randomValue)
                {
                    return kvp.Key;
                }
            }
            return dict.Keys.First();
        }
        private Dictionary<int, int> GetMinNumberByIndex(int index)
        {
            Dictionary<int, int> Value_Repetitions = new();
            foreach (var permutation in permutations)
            {
                if (Value_Repetitions.ContainsKey(permutation[index])) Value_Repetitions[permutation[index]]++;
                else Value_Repetitions.Add(permutation[index], 1);
            }
            for (int i = 0; i < CountNumber; i++)
            {
                if (!Value_Repetitions.ContainsKey(i))
                    Value_Repetitions.Add(i, 0);
            }
            return Value_Repetitions;
        }
    }
}
