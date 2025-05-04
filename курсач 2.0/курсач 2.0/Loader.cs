using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсач_2._0
{
    class Loader
    {
        //public void SaveToFile(string filename)
        //{
        //    try
        //    {
        //        using (StreamWriter writer = new StreamWriter(filename))
        //        {
        //            Сохраняем матрицу F
        //            writer.WriteLine(F.GetLength(0));
        //            for (int i = 0; i < F.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < F.GetLength(0); j++)
        //                {
        //                    writer.Write(F[i, j] + " ");
        //                }
        //                writer.WriteLine();
        //            }
        //            writer.WriteLine();

        //            Сохраняем матрицу D
        //            writer.WriteLine("D:");
        //            for (int i = 0; i < F.GetLength(0); i++)
        //            {
        //                for (int j = 0; j < F.GetLength(0); j++)
        //                {
        //                    writer.Write(D[i, j] + " ");
        //                }
        //                writer.WriteLine();
        //            }
        //        }
        //        Console.WriteLine($"Матрицы сохранены в файл: {filename}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
        //    }
        //}

        public static (int[,]? F, int[,]? D) LoadFromFile(string filename, out int Size)
        {
            int[,] F;
            int[,] D;
            try
            {
                using (StreamReader reader = new StreamReader("task" + filename + ".txt"))
                {
                    // Загружаем матрицу F
                    string line = reader.ReadLine();
                    if (line.Contains("  ")) line = line.Replace("  ", " ");
                    Size = Convert.ToInt32(line);
                    F = new int[Size, Size];
                    D = new int[Size, Size];
                    for (int i = 0; i < Size; i++)
                    {
                        line = reader.ReadLine();
                        if (line.Contains("  "))
                            for (int j = 0; j < 5; j++)
                                line = line.Replace("  ", " ");
                        string[] values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < Size; j++)
                        {
                            F[i, j] = int.Parse(values[j]);
                        }
                    }
                    reader.ReadLine(); // Пропускаем пустую строку

                    for (int i = 0; i < Size; i++)
                    {
                        line = reader.ReadLine();
                        if (line.Contains("  "))
                            for (int j = 0; j < 5; j++)
                                line = line.Replace("  ", " ");
                        string[] values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < Size; j++)
                        {
                            D[i, j] = int.Parse(values[j]);
                        }
                    }
                    return (F, D);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
            }
            Size = 0;
            return (null, null);
        }
    }
}


