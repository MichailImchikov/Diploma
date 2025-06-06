﻿namespace курсач_2._0.StartPopulation
{
    class Dispersion : IStartPopulations
    {
        private readonly List<int[]> _permutations = new();
        private int _countNumber = 0;
        public List<int[]> GetBasePopulation(int size,int countPopulation)
        {
            _countNumber = size;
            while (_permutations.Count < countPopulation)
            {
                int[] newPermutation = new int[size];
                for (int i = 0; i < size; i++)
                {
                    var valueRepetitions = GetMinNumberByIndex(i);
                    for (int j = 0; j < i; j++)
                    {
                        valueRepetitions.Remove(newPermutation[j]);
                    }
                    var key = GetRandomKey(valueRepetitions);
                    newPermutation[i] = key;
                }
                _permutations.Add(newPermutation);
            }
            return _permutations;
        }

        public string GetName()
        {
            return "Dispersion";
        }

        private int GetRandomKey(Dictionary<int, int> dict)
        {
            double totalWeight = dict.Values.Sum(value => 1.0 / (value + 1)); // +1 чтобы избежать деления на 0
            double randomValue = new Random().NextDouble() * totalWeight;
            double cumulativeWeight = 0;
            foreach (var kvp in dict)
            {
                cumulativeWeight += 1.0 / (kvp.Value + 1);
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
            foreach (var permutation in _permutations)
            {
                if (index < permutation.Length)
                {
                    int val = permutation[index];
                    if (Value_Repetitions.ContainsKey(val))
                        Value_Repetitions[val]++;
                    else
                        Value_Repetitions[val] = 1;
                }
            }

            // Теперь от 1 до CountNumber
            for (int i = 1; i <= _countNumber; i++)
            {
                if (!Value_Repetitions.ContainsKey(i))
                    Value_Repetitions.Add(i, 0);
            }
            return Value_Repetitions;
        }
    }
}