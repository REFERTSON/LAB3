using LAB.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace LAB
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // Путь к файлам
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");

            Stopwatch watch = new Stopwatch();
            int count_result = 0;

            ICounter counter = new Counter();
            IDirectoryProcessor directoryProcessor = new DirectoryProcessor();
            IFileReader fileReader = new FileReader();

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Указанная директория не существует.");
                Console.WriteLine("Пожалуйста, укажите путь к директории с .txt файлами.");
                return;
            }

            // Пункт а)
            Console.WriteLine("Пункт а): Считать файл асинхронно и посчитать пробелы.");
            foreach (string file in directoryProcessor.GetFilesPathFromDirectory(directoryPath))
            {
                watch.Start();

                string data = await fileReader.ReadFileAsync(file);
                count_result = counter.Count(data);

                watch.Stop();

                Console.WriteLine($"Файл - {Path.GetFileName(file)}: Кол-во пробелов: {count_result}. \nВремя на обработку: {watch.ElapsedMilliseconds} мс.\n");

                watch.Reset();
            }


            // Пункт б)
            Console.WriteLine("\nПункт б): Запуск асинхронного считывания для всех файлов.");
            IList<Task> readTaskList = new List<Task>();

            foreach (string file in directoryProcessor.GetFilesPathFromDirectory(directoryPath))
            {
                readTaskList.Add(fileReader.ReadFileAsync(file));
            }

            watch.Start();

            await Task.WhenAll(readTaskList);

            watch.Stop();

            Console.WriteLine($"Время на обработку: {watch.ElapsedMilliseconds} мс.\n");

            watch.Reset();


            // Пункт в)
            Console.WriteLine("\nПункт в): Считывание файла построчно и подсчет пробелов.");
            foreach (string file in directoryProcessor.GetFilesPathFromDirectory(directoryPath))
            {
                watch.Start();

                IEnumerable<string> data = await fileReader.ReadFileByLinesAsync(file);

                count_result = 0;
                foreach (var line in data)
                    count_result += counter.Count(line);

                watch.Stop();

                Console.WriteLine($"Файл - {Path.GetFileName(file)}: Кол-во пробелов: {count_result}. \nВремя на обработку: {watch.ElapsedMilliseconds} мс.\n");

                watch.Reset();
            }


            // Пункт г)
            Console.WriteLine("\nПункт г): Подсчет пробелов асинхронно.");
            foreach (string file in directoryProcessor.GetFilesPathFromDirectory(directoryPath))
            {
                watch.Start();

                string data = fileReader.ReadFile(file);
                count_result = await counter.CountAsync(data);

                watch.Stop();

                Console.WriteLine($"Файл - {Path.GetFileName(file)}: Кол-во пробелов: {count_result}. \nВремя на обработку: {watch.ElapsedMilliseconds} мс.\n");

                watch.Reset();
            }
        }
    }
}
