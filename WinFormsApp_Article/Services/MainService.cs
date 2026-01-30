using System;
using System.Reflection;

/// <summary>
/// Сервис - основной слой бизнес-логики
/// </summary>
public class MainService
{
    private List<MethodResults> GetAllResults(int[] array, Func<int,int,int> method)
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
        chainResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
        {
            chainResults.InsertTime = MeasurementServices.MeasureTime(() =>
            {
                moc = CollisionAlgorithms.ChainMethodInsert(array, method);
            });

            chainResults.SearchTime = MeasurementServices.MeasureTime(() =>
            {
                chainResults.Сomparisons = CollisionAlgorithms.ChainMethodSearch(
                    array, moc, method);
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
        linnerResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
        {
            linnerResults.InsertTime = MeasurementServices.MeasureTime(() =>
            {
                moa = CollisionAlgorithms.LinerProbingInsert(array, method);
            });

            linnerResults.SearchTime = MeasurementServices.MeasureTime(() =>
            {
                linnerResults.Сomparisons = CollisionAlgorithms.LinerProbingSearch(
                    array, moa, method);
            });
        });
        return linnerResults;
    }

    //Требуется исправить 
    private MethodResults GetQudraticProbingResults(int[] array, Func<int, int, int> method)
    {
        MethodResults QuadraticResults = new()
        {
            AlgorithmName = "Квадратичное пробирование"
        };
        int[] moa = [];
        QuadraticResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
        {
            QuadraticResults.InsertTime = MeasurementServices.MeasureTime(() =>
            {
                moa = CollisionAlgorithms.QuadraticProbingInsert(array, method,
                    array.Length);
            });

            QuadraticResults.SearchTime = MeasurementServices.MeasureTime(() =>
            {
                QuadraticResults.Сomparisons = CollisionAlgorithms.QuadraticProbingSearch(
                    array, moa, method);
            });
        });
        return QuadraticResults;
    }

    private MethodResults GetDoubleHashingResults(int[] array, 
        Func<int, int, int> method1)
    {
        MethodResults doubleHashingResults = new()
        {
            AlgorithmName = "Двойное хеширование"
        };
        int[] moa = [];
        doubleHashingResults.TotalMemory = MeasurementServices.MeasureMemory(() =>
        {
            doubleHashingResults.InsertTime = MeasurementServices.MeasureTime(() =>
            {
                moa = CollisionAlgorithms.DoubleHashingInsert(array, 
                    method1, GetMethodsUtil.GetSecondMethod(method1));
            });

            doubleHashingResults.SearchTime = MeasurementServices.MeasureTime(() =>
            {
                doubleHashingResults.Сomparisons = CollisionAlgorithms.DoubleHashingSearch(
                    array, moa, method1, GetMethodsUtil.GetSecondMethod(method1));
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

    public List<MethodResults> Run(int size, Func<int,int,int> method)
    {
        int[] array = ArrayGenerate(size);
        var results = GetAllResults(array, method);
        return results;
    }
}
