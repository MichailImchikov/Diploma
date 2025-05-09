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
        public static (int[,]? F, int[,]? D) SpecialLoader(string filename, out int Size)
        {
            string filePath = "task" + filename + ".txt"; // путь к вашему файлу

            // Чтение всех данных из файла в виде списка чисел
            List<int> numbers = new List<int>();
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int value))
                    {
                        numbers.Add(value);
                    }
                }
            }

            // Первое число — это N
            int N = numbers[0];
            Size = N;
            int totalExpectedNumbers = 2 * N * N;

            if (numbers.Count < totalExpectedNumbers + 1) // +1 для N
            {
                Console.WriteLine("Ошибка: недостаточно данных в файле.");
            }

            // Создаем матрицы
            int[,] F = new int[N, N];
            int[,] D = new int[N, N];

            // Заполняем матрицы
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int index = 1 + i * N + j;
                    F[i, j] = numbers[index];
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int index = 1 + N * N + i * N + j;
                    D[i, j] = numbers[index];
                }
            }
            return (F, D);
        }
        public static (int[,]? F, int[,]? D) LoadFromFile(string filename, out int Size)
        {
            int[,] F;
            int[,] D;
            if (filename.Contains("60") || filename.Contains("70") || filename.Contains("80"))
                return SpecialLoader(filename, out Size);
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


