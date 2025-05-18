using ClosedXML.Excel;
using System;
using System.IO;

namespace курсач_2._0
{
    public class ExcelManager
    {
        private readonly string _fileName;
        private readonly string _templatePath;
        private readonly string _outputFilePath;

        // Конструктор: принимает имя файла (например, "test.xlsx")
        public ExcelManager(string fileName)
        {
            _fileName = fileName + ".xlsx";

            // Путь к исходному файлу (шаблону)
            _templatePath = @"C:\Users\Cokle\Desktop\Diploma\Сравнение.xlsx";

            // Путь к папке Results и конечному файлу
            string resultsFolder = @"C:\Users\Cokle\Desktop\Diploma\Results";
            Directory.CreateDirectory(resultsFolder); // создаём папку, если её нет

            _outputFilePath = Path.Combine(resultsFolder, _fileName);

            // Если файла нет в папке Results — копируем из шаблона
            if (!File.Exists(_outputFilePath))
            {
                File.Copy(_templatePath, _outputFilePath);
                Console.WriteLine($"Файл {_fileName} создан как копия шаблона.");
            }
            else
            {
                Console.WriteLine($"Файл {_fileName} уже существует. Работаем с ним.");
            }
        }
        public void WriteCell(int row, int column, object value)
        {
            try
            {
                using var workbook = new XLWorkbook(_outputFilePath);
                var worksheet = workbook.Worksheet("Лист1");

                if (worksheet == null)
                    throw new Exception("Лист 'Лист1' не найден в файле.");
                if(value is int numberI) worksheet.Cell(row, column).Value = numberI;
                else if(value is float numberF) worksheet.Cell(row, column).Value = numberF;
                else if(value is double numberD) worksheet.Cell(row, column).Value = numberD;
                else if(value is string numberS) worksheet.Cell(row, column).Value = numberS;
                workbook.Save();

                Console.WriteLine($"Записано: строка {row}, столбец {column}, значение = {value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при записи в Excel: " + ex.Message);
            }
        }
    }
}