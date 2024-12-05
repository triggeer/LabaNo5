using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaNo5
{
    internal class Proverka
    {
        public static int IntNum(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message); // Запрашиваем ввод в каждой итерации
                string input = Console.ReadLine();

                // Пытаемся преобразовать строку в целое число
                if (int.TryParse(input, out value))
                {
                    return value; // Возвращаем значение, если преобразование прошло успешно
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное целое число.");
                }
            }
        }
    }
}
