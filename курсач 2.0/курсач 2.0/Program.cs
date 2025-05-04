using System.Diagnostics;
using курсач_2._0.Crossingover;
using курсач_2._0.FindParent;
using курсач_2._0.Mutation;
using курсач_2._0.Select;
using курсач_2._0.StartPopulation;

namespace курсач_2._0
{
    internal class Program
    {
        static int Factorial(int n)
        {
            if(n == 1) return 1;
            return n* Factorial(n-1);
        }
          
        static void Main(string[] args)
        {
            int SizeMatrix = 30;
            int CountPopulation = SizeMatrix * 10;
            int CountStep = SizeMatrix * 10;
            int CrossParam = (int)(SizeMatrix / 4);
            int Probability = 5;
            KZN_Data data1 = new(SizeMatrix.ToString());
            var randomPopultion = new RandomPopulation(SizeMatrix);
            var populationParent = randomPopultion.GetBasePopulation(CountPopulation);
            int Iteration = 0;
            var Cross = new Crossbreeding();
            List<int[]> newPopulation = new();
            Random rnd = new Random();
            var Mutation = new MutationInversion();
            var LineRang = new LineRang();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (Iteration <CountStep)
            {
                newPopulation.Clear();
                for(int i=0;i< CountPopulation;i++)
                {
                    var OutBriding = new Outsourcing(populationParent);
                    var Para = OutBriding.GetParents(CrossParam);
                    var newChild = Cross.GetChild(Para.Item1, Para.Item2);
                    newPopulation.Add(newChild);
                }
                for (var i = 0; i < newPopulation.Count; i++)
                {
                    var value = rnd.Next(0, 100);
                    if (value > Probability) continue;
                    newPopulation.Add(Mutation.Mutation(newPopulation[i]));
                }
                var newParent = LineRang.GetNewPopulation(populationParent, newPopulation, data1);
                populationParent = newParent;
                Iteration++;
            }
            stopwatch.Stop();
            Console.WriteLine(string.Join(", ", populationParent[0]));
            Console.WriteLine(data1.GetCriteria(populationParent[0]));
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }
    }
}
