using System.Diagnostics;

namespace WinFormsApp_Article.Services
{
    /// <summary>
    /// Статический класс, представляющий сервис измерений
    /// </summary>
    public static class MeasurementServices
    {
        /// <summary>
        /// Метод для измерения памяти процесса
        /// </summary>
        /// <param name="action"> измеряемый процесс (действие) </param>
        /// <returns> объём использованной памяти </returns>
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

        /// <summary>
        /// Метод для измерения времени процесса
        /// </summary>
        /// <param name="action"> измеряемый процесс (действие) </param>
        /// <returns></returns>
        public static long MeasureTime(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds; // Результат в тиках
                                           // Для секунд нужно поделить на Stopwatch.Frequency
        }
    }
}