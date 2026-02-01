using WinFormsApp_Article.Algorithms;
using WinFormsApp_Article.BenchMark;
using WinFormsApp_Article.Utils;

namespace WinFormsApp_Article.Services
{
    /// <summary>
    /// Сервис - основной слой бизнес-логики
    /// </summary>
    public class MainService
    {
        private List<MethodResults> GetAllResults(int[] array, Func<int, int, int> method)
        {
            List<MethodResults> results = [];

            results.Add(GetChainMethodResults(array, method));
            results.Add(GetLinerProbingHenerate(array, method));
            results.Add(GetQudraticProbingResults(array, method));
            results.Add(GetDoubleHashingResults(array, method));
            return results;
        }

        private MethodResults GetChainMethodResults(int[] array, Func<int, int, int> method)
        {
            MethodResults chainResults = new()
            {
                AlgorithmName = "Метод цепочек"
            };
            List<int>[] moc = [];
            MeasureComparisons mc = () => chainResults.Сomparisons++;
            chainResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
            {
                chainResults.InsertTime = MeasurementServices.MeasureTime(() =>
                {
                    moc = CollisionAlgorithms.ChainMethodInsert(array, method);
                });

                chainResults.SearchTime = MeasurementServices.MeasureTime(() =>
                {
                    CollisionAlgorithms.ChainMethodSearch(array, moc, method, mc);
                });
            });
            return chainResults;
        }

        private MethodResults GetLinerProbingHenerate(int[] array, Func<int, int, int> method)
        {
            MethodResults linnerResults = new()
            {
                AlgorithmName = "Линейное пробирование"
            };
            int[] moa = [];
            MeasureComparisons mc = () => linnerResults.Сomparisons++;
            linnerResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
            {
                linnerResults.InsertTime = MeasurementServices.MeasureTime(() =>
                {
                    moa = CollisionAlgorithms.LinerProbingInsert(array, method);
                });

                linnerResults.SearchTime = MeasurementServices.MeasureTime(() =>
                {
                    CollisionAlgorithms.LinerProbingSearch(
                        array, moa, method, mc);
                });
            });
            return linnerResults;
        }

        private MethodResults GetQudraticProbingResults(int[] array, Func<int, int, int> method)
        {
            MethodResults quadraticResults = new()
            {
                AlgorithmName = "Квадратичное пробирование"
            };
            int[] moa = [];
            MeasureComparisons mc = () => quadraticResults.Сomparisons++;
            quadraticResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
            {
                quadraticResults.InsertTime = MeasurementServices.MeasureTime(() =>
                {
                    moa = CollisionAlgorithms.QuadraticProbingInsert(array, method,
                        array.Length);
                });

                quadraticResults.SearchTime = MeasurementServices.MeasureTime(() =>
                {
                    CollisionAlgorithms.QuadraticProbingSearch(
                        array, moa, method, mc);
                });
            });
            return quadraticResults;
        }

        private MethodResults GetDoubleHashingResults(int[] array,
            Func<int, int, int> method1)
        {
            MethodResults doubleHashingResults = new()
            {
                AlgorithmName = "Двойное хеширование"
            };
            int[] moa = [];
            MeasureComparisons mc = () => doubleHashingResults.Сomparisons++;
            doubleHashingResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
            {
                doubleHashingResults.InsertTime = MeasurementServices.MeasureTime(() =>
                {
                    moa = CollisionAlgorithms.DoubleHashingInsert(array,
                        method1, GetMethodsUtil.GetSecondMethod(method1));
                });

                doubleHashingResults.SearchTime = MeasurementServices.MeasureTime(() =>
                {
                    CollisionAlgorithms.DoubleHashingSearch(
                        array, moa, method1, GetMethodsUtil.GetSecondMethod(method1),
                        mc);
                });
            });
            return doubleHashingResults;
        }

        private int[] ArrayGenerate(int size)
        {
            Random random = new();
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(0, (int)Math.Pow(10, 7));
            return array;
        }

        public List<MethodResults> Run(int size, Func<int, int, int> method)
        {
            int[] array = ArrayGenerate(size);
            var results = GetAllResults(array, method);
            return results;
        }
    }
}