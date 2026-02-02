using WinFormsApp_Article.Algorithms;
using WinFormsApp_Article.BenchMark;
using WinFormsApp_Article.Utils;

namespace WinFormsApp_Article.Services
{
    /// <summary>
    /// Главный сервис - основной слой бизнес-логики
    /// </summary>
    public class MainService
    {
        /// <summary>
        /// Метод для получения списка всех результатов работы 
        /// методов разрешения коллизий
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method"> метод хеширования </param>
        /// <returns> список результатов </returns>
        private List<MethodResults> GetAllResults(int[] array, Func<int, int, int> method)
        {
            List<MethodResults> results = [];

            results.Add(GetChainMethodResults(array, method));
            results.Add(GetLinerProbingHenerate(array, method));
            results.Add(GetQudraticProbingResults(array, method));
            results.Add(GetDoubleHashingResults(array, method));
            return results;
        }
        
        /// <summary>
        /// Метод для получения результатов работы метода цепочек
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method"> метод хеширования </param>
        /// <returns> результаты работы </returns>
        private MethodResults GetChainMethodResults(int[] array, Func<int, int, int> method)
        {
            MethodResults chainResults = new()
            {
                AlgorithmName = "Метод цепочек"
            };
            List<int>[] moc = [];
            Action mc = () => chainResults.Сomparisons++;
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

        /// <summary>
        /// Метод для получения результатов работы метода линейного пробирования
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method"> метод хеширования </param>
        /// <returns> результаты работы </returns>
        private MethodResults GetLinerProbingHenerate(int[] array, Func<int, int, int> method)
        {
            MethodResults linnerResults = new()
            {
                AlgorithmName = "Линейное пробирование"
            };
            int[] moa = [];
            Action mc = () => linnerResults.Сomparisons++;
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

        /// <summary>
        /// Метод для получения результатов работы метода квадратичного пробирования
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method"> метод хеширования </param>
        /// <returns> результаты работы </returns>
        private MethodResults GetQudraticProbingResults(int[] array, Func<int, int, int> method)
        {
            MethodResults quadraticResults = new()
            {
                AlgorithmName = "Квадратичное пробирование"
            };
            int[] moa = [];
            Action mc = () => quadraticResults.Сomparisons++;
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

        /// <summary>
        /// Метод для получения результатов работы метода двойного хеширования
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method1"> первый метод хеширования </param>
        /// <returns> результаты хеширования </returns>
        private MethodResults GetDoubleHashingResults(int[] array,
            Func<int, int, int> method1)
        {
            MethodResults doubleHashingResults = new()
            {
                AlgorithmName = "Двойное хеширование"
            };
            int[] moa = [];
            Action mc = () => doubleHashingResults.Сomparisons++;
            doubleHashingResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
            {
                doubleHashingResults.InsertTime = MeasurementServices.MeasureTime(() =>
                {
                    moa = CollisionAlgorithms.DoubleHashingInsert(array,
                        method1, 
                        GetMethodsUtil.GetSecondMethod(method1)); // вспомогательная утилита
                                                                  // сама определит второй метод
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

        /// <summary>
        /// Метод для генерации массива чисел
        /// </summary>
        /// <param name="size"> размер массива </param>
        /// <returns> массив псевдослучайных чисел </returns>
        private int[] ArrayGenerate(int size)
        {
            Random random = new();
            int[] array = new int[size];
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(0, (int)Math.Pow(10, 7));
            return array;
        }

        /// <summary>
        /// Основной метод, через который с сервисо взаимодействуют сторонние компоненты
        /// </summary>
        /// <param name="size"> размер массива </param>
        /// <param name="method"> метод хеширования </param>
        /// <returns> список всех результатов </returns>
        public List<MethodResults> Run(int size, Func<int, int, int> method)
        {
            int[] array = ArrayGenerate(size);
            var results = GetAllResults(array, method);
            return results;
        }
    }
}