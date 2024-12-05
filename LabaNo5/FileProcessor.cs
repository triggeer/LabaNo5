using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNo5
{
    public static class FileProcessor
    {
        // Метод для получения значений m и n от пользователя и запуска фильтрации и записи в файл


        // Метод для фильтрации чисел и записи их в новый файл
        private static void FilterAndWriteToFile(string inputPath, string outputPath, int m, int n)
        {
            try
            {
                // Открываем файл для чтения
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    // Создаем файл для записи

                        string line;

                        // Читаем построчно из исходного файла
                        while ((line = sr.ReadLine()) != null)
                        {
                            // Разбиваем строку на отдельные числа
                            string[] notes = line.Split(' ');

                            foreach (string noteStr in notes)
                            {
                                
                            }

                            // Переход на новую строку после каждой строки из исходного файла
                            //sw.WriteLine();
                        }
                     // StreamWriter автоматически закрывается
                } // StreamReader автоматически закрывается

                Console.WriteLine("Данные успешно отфильтрованы и записаны в новый файл: " + outputPath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл " + inputPath + " не найден.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
