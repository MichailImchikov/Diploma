using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0.StartPopulation
{
    public class RandomPopulations : IStartPopulations
    {
        private int _countNumber;
        public RandomPopulations(int CountNumber)
        {
            this._countNumber = CountNumber;
        }
        public List<int[]> GetBasePopulation(int countPopulation)
        {
            List<int[]> pupulation = new();
            var rnd = new Random();
            for (int i =0; i< countPopulation; i++)
            {
                int[] newPermutation = new int[_countNumber];
                List<int> remainingNumber = Enumerable.Range(1, _countNumber).ToList();
                for (int j =0; j< _countNumber; j++)
                {
                    var randomIndex = rnd.Next(0, remainingNumber.Count);
                    var randomNumber = remainingNumber[randomIndex];
                    newPermutation[j] = randomNumber;
                    remainingNumber.RemoveAt(randomIndex);
                }
                pupulation.Add(newPermutation);
            }
            return pupulation;
        }
    }
}
