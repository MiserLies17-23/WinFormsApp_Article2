using WinFormsApp_Article.Algorithms;

namespace WinFormsApp_Article.Utils
{
    public static class GetMethodsUtil
    {
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