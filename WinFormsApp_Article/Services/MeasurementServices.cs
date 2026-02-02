using System.Diagnostics;
using WinFormsApp_Article.Algorithms;

namespace WinFormsApp_Article.Services
{
    public static class MeasurementServices
    {
        public static float MeasureMemory(Action action)
        {
            // Сборка мусора, стандартный алгоритм
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memoryBefore = GC.GetTotalMemory(true);
            action();
            long memoryAfter = GC.GetTotalMemory(true);

            return (float)(memoryAfter - memoryBefore) / 1024; // Возвращаем результат в килобайтах
        }

        public static long MeasureTime(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.ElapsedTicks; // Результат в тиках
                                           // Для секунд нужно поделить на Stopwatch.Frequency
        }

        //public static void MeasureComparisons(int comparisons)
        //{
        //    comparisons++;  
        //}

        //public static Action CreateComparisonCounter(ref int counter)
        //{
        //    // Замыкание на переданную по ссылке переменную
        //    return () => counter++;
        //}
    }
}