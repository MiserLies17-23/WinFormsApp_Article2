using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_Article.Algorithms
{
    /// <summary>
    /// Статический класс, предоставляющий хеш-функции
    /// </summary>
    public static class HashAlgorithms
    {
        /// <summary>
        /// АЛГОРИТМ ХЕШИРОВАНИЯ МЕТОДОМ УМНОЖЕНИЯ
        /// </summary>
        /// <param name="data"> массив ключей </param>
        /// <param name="range"> длина массива </param>
        /// <returns> массив частот </returns>
        public static int[] MultipleMethod(int[] data, int range)
        {
            int[] outputArray = new int[range]; // выходной массив частот
            double permanent = (Math.Sqrt(5) - 1) / 2; // оптимальная константа для умножения

            for (int i = 0; i < data.Length; i++)
            {
                double fractional = (data[i] * permanent) % 1; // вычисление дробной части
                int hash = (int)Math.Floor(range * fractional); // расчет хэша
                outputArray[hash]++; // подсчет количества встречающихся частот
            }
            return outputArray;
        }

        /// <summary>
        /// АЛГОРИТМ ХЕШИРОВАНИЯ МЕТОДОМ ДЕЛЕНИЯ
        /// </summary>
        /// <param name="data"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int[] DivisionMethod(int[] data, int range)
        {
            int[] outputArray = new int[range];

            for (int i = 0; i < data.Length; i++)
            {
                int hash = data[i] % range;
                outputArray[hash]++;
            }
            return outputArray;
        }

        /// <summary>
        /// АЛГОРИТМ ХЕШИРОВАНИЯ МЕТОДОМ СВЕРТЫВАНИЯ
        /// </summary>
        /// <param name="data"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int[] FoldingMethod(int[] data, int range)
        {
            int partSize = 3; // количество цифр в одной части
            int[] outputArray = new int[range];

            for (int i = 0; i < data.Length; i++)
            {
                int sum = 0; // сумма
                int temp = data[i]; // текущий ключ
                while (temp > 0)
                {
                    int part = temp % (int)Math.Pow(10, partSize); // выделение части
                    sum += part;
                    temp /= (int)Math.Pow(10, partSize);
                }
                int hash = sum % range;
                outputArray[hash]++;
            }
            return outputArray;
        }

        /// <summary>
        /// АЛГОРИТМ ХЕШИРОВАНИЯ МЕТОДОМ СЕРЕДИНЫ КВАДРАТА
        /// </summary>
        /// <param name="data"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int[] MidSquareMethod(int[] data, int range)
        {
            int[] outputArray = new int[range];
            int digits = 3; // количество средних цифр из квадрата числа

            for (int i = 0; i < data.Length; i++)
            {
                long squared = (long)data[i] * data[i]; // квадрат ключа
                string s = squared.ToString(); // перевод в строку

                // вычисление середины строки
                int start = Math.Max(0, (s.Length - digits) / 2);
                string middle = s.Substring(start, Math.Min(digits, s.Length - start));
                int middleValue = int.Parse(middle);

                int hash = middleValue % range;
                outputArray[hash]++;
            }
            return outputArray;
        }
    }
}
