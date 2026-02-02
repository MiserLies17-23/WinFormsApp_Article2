using WinFormsApp_Article.Algorithms;

namespace WinFormsApp_Article.Utils
{
    /// <summary>
    /// Утилитный статический класс
    /// предназначен для получения нужных методов хеширования
    /// </summary>
    public static class GetMethodsUtil
    {
        /// <summary>
        /// Метод для получения метода хеширования по названию
        /// </summary>
        /// <param name="methodName"> название метода хеширования </param>
        /// <returns> метод хеширования, соответствующий названию </returns>
        /// <exception cref="ArgumentException"> ошибка неверного названия метода </exception>
        public static Func<int, int, int> GetCurrentMethod(string methodName)
        {
            return methodName switch
            {
                "Метод деления" =>
                    HashAlgorithms.DivisionMethod,
                "Метод середины квадрата" =>
                    HashAlgorithms.MidsquareMethod,
                "Метод умножения" =>
                    HashAlgorithms.MultiplicationMethod,
                "Метод свёртывания" =>
                    HashAlgorithms.FoldingMethod,
                _ => throw new ArgumentException("Метод не распознан!"),
            };
        }

        /// <summary>
        /// Метод для получения второго метода хеширования по первому
        /// возвращает метод в соответсвии с последовательностью в выпадающем списке формы
        /// </summary>
        /// <param name="method1"> первый метод хеширования </param>
        /// <returns> второй метод хеширования </returns>
        /// <exception cref="ArgumentException"> ошибка распознавания метода хеширования </exception>
        public static Func<int, int, int> GetSecondMethod(Func<int, int, int> method1)
        {
            string methodName = method1.Method.Name;

            return methodName switch
            {
                nameof(HashAlgorithms.DivisionMethod) => HashAlgorithms.MidsquareMethod,
                nameof(HashAlgorithms.MidsquareMethod) => HashAlgorithms.FoldingMethod,
                nameof(HashAlgorithms.FoldingMethod) => HashAlgorithms.MultiplicationMethod,
                nameof(HashAlgorithms.MultiplicationMethod) => HashAlgorithms.DivisionMethod,
                _ => throw new ArgumentException("Неизвестный метод хеширования")
            };
        }
    }
}