using System;
/// <summary>
/// Сервис - основной слой бизнес-логики
/// </summary>
public class DataService
{
    private List<MethodResults> GetAllResults(int[] array, Func<int,int,int> method)
    {
        List<MethodResults> results = [];

        results.Add(GetChainMethodResults(array, method));
        results.Add(GetLinerProbingHenerate(array, method));
        results.Add(GetQudraticProbingResults(array, method));
        return results;
    }

    private MethodResults GetChainMethodResults(int[] array, Func<int, int, int> method)
    {
        var result = CollisionAlgorithms.ChainMethodInsert(array, method);
        List<int>[] moc = result.Item1;
        int insertTime = result.Item2;
        (int comparisons, int founds, int searchTime) = CollisionAlgorithms.ChainMethodSearch(
            array, moc, method);
        return new MethodResults
        {
            AlgorithmName = "Метод цепочек",
            InsertTime = insertTime,
            SearchTime = searchTime,
            Сomparisons = comparisons,
        };
    }

    private MethodResults GetQudraticProbingResults(int[] array, Func<int, int, int> method)
    {
        (int[] moa, int insertTime) = CollisionAlgorithms.QuadraticProbingInsert(array,
            method);
        (int comparisons, int founds, int searchTime) = CollisionAlgorithms.QuadraticProbingSearch(
            array, moa, method);
        return new MethodResults
        {
            AlgorithmName = "Квадратичное пробирование",
            InsertTime = insertTime,
            SearchTime = searchTime,
            Сomparisons = comparisons,
        };
    }
    private MethodResults GetLinerProbingHenerate(int[] array, Func<int, int, int> method)
    {
        (int[] moa, int insertTime) = CollisionAlgorithms.LinerProbingInsert(array, 
            method);
        (int comparisons, int founds, int searchTime) = CollisionAlgorithms.LinerProbingSearch(
            array, moa, method);
        return new MethodResults
        {
            AlgorithmName = "Линейное пробирование",
            InsertTime = insertTime,
            SearchTime = searchTime,
            Сomparisons = comparisons,
        };
    }

    private int[] ArrayGenerate(int size)
    {
        Random random = new();
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++) 
            array[i] = random.Next();
        return array;
    }

    public List<MethodResults> Run(int size, Func<int,int,int> method)
    {
        int[] array = ArrayGenerate(size);
        var results = GetAllResults(array, method);
        return results;
    }
}
