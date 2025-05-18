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
        readonly static List<int> taskList = new() { 12, 14, 15, 16, 16, 17, 18, 20, 21,22, 24, 25, 27, 28, 30, 32, 64, 60, 70, 80 };
        static void Main(string[] args)
        {
            foreach (var configuration in ConfigurationConfigTIPO.GetConfigurations())
            {
                var problemSolving = new ProblemSolving(configuration);
                for(int taskIndex = 0; taskIndex < taskList.Count; taskIndex++)
                {
                    if (taskIndex == 3) problemSolving.Run(taskList[taskIndex],taskIndex+2, "a");
                    else if (taskIndex == 4) problemSolving.Run(taskList[taskIndex], taskIndex + 2, "b");
                    else  problemSolving.Run(taskList[taskIndex], taskIndex + 2);
                    Console.WriteLine(taskList[taskIndex].ToString());
                }
                configuration.excelManager.WriteCell(22,1,configuration.DescriptionFile);
            }

        }
    }
}
