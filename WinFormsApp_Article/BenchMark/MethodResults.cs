namespace WinFormsApp_Article.BenchMark
{
    /// <summary>
    /// BanchMark-компонент для подсчёт результатов 
    /// </summary>
    public class MethodResults
    {
        /// <summary>
        /// Название алгоритма (гарантируется не null)
        /// </summary>
        public string? AlgorithmName { get; set; }

        /// <summary>
        /// Время вставки
        /// </summary>
        public long InsertTime { get; set; }

        /// <summary>
        /// Время поиска
        /// </summary>
        public long SearchTime { get; set; }

        /// <summary>
        /// Количество сравнений
        /// </summary>
        public int Сomparisons { get; set; }

        /// <summary>
        /// Общий объём затраченной памяти на вставку и поиск
        /// </summary>
        public float TotalMemory { get; set; }

    }
}