using ClosedXML.Excel;
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
            List<int> taskList = new() { 12, 14, 15, 16, 16, 17, 18, 20, 21,22, 24, 25, 27, 28, 30, 32, 64, 60, 70, 80 };
            for(int taskIndex = 0; taskIndex < taskList.Count; taskIndex++)
            {
                if (taskIndex == 3) Start(taskList[taskIndex],taskIndex+2, "a");
                else if (taskIndex == 4) Start(taskList[taskIndex], taskIndex + 2, "b");
                else  Start(taskList[taskIndex], taskIndex + 2);
                Console.WriteLine(taskList[taskIndex].ToString());
            }
        }
        static public void Write(int row, float value, double time)
        {
            // Путь к существующему файлу
            string filePath = @"C:\Users\Cokle\Desktop\Diploma/Сравнение.xlsx";

            // Открываем книгу
            var workbook = new XLWorkbook(filePath);

            // Получаем первый лист (по имени или по индексу)
            var worksheet = workbook.Worksheet("Лист1");  // или workbook.Worksheets.First()
            worksheet.Cell(row, 4).Value = value;
            worksheet.Cell(row, 5).Value = time;

            // Сохраняем изменения обратно в тот же файл
            workbook.Save();

            Console.WriteLine("Данные успешно добавлены.");
        }
        static public void Start(int size, int row, string pref = "")
        {
            int SizeMatrix = size;
            int CountPopulation = SizeMatrix * 10;
            int CountStep = SizeMatrix * 10;
            int CrossParam = (int)(SizeMatrix / 4);
            int Probability = 5;
            KZN_Data data1 = new(SizeMatrix.ToString()+pref);


            var dispersion = new Dispersion(SizeMatrix);
            var randomPopulation = new RandomPopulations(SizeMatrix);
            var listMembers = new List<(IStartPopulations, float)>()
                { (dispersion, 0.5f), (randomPopulation, 0.5f) };
            var startPopulation = new NationalInitialPopulations(listMembers,CountPopulation);// select logik for start population
            
            
            var populationParent = startPopulation.GetBasePopulation(CountPopulation);
            int Iteration = 0;
            var Cross = new Crossbreeding();
            List<int[]> newPopulation = new();
            Random rnd = new Random();
            var Mutation = new MutationInversion();
            var LineRang = new LineRang();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (Iteration < CountStep)
            {
                newPopulation.Clear();
                for (int i = 0; i < CountPopulation; i++)
                {
                    var OutBriding = new Insourcing(populationParent);
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
            Write(row, data1.GetCriteria(populationParent[0]), stopwatch.Elapsed.TotalSeconds);
            Console.WriteLine(string.Join(", ", populationParent[0]));
            Console.WriteLine(data1.GetCriteria(populationParent[0]));
            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
        }
    }
}
