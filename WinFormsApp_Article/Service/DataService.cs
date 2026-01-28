using System;
/// <summary>
/// Сервис - основной слой бизнес-логики
/// </summary>
public class DataService
{
    private List<MethodResults> getAllResults(int[] array, Func<int,int,int> method)
    {
        List<MethodResults> results = [];

        MethodResults linerProbingResults = getLinerProbingHenerate(array, method);
        results.Add(linerProbingResults);
        return results;
    }

    private MethodResults getLinerProbingHenerate(int[] array, Func<int, int, int> method)
    {
        (int[] moa, int insertTime) = CollisionAlgorithms.LinerProbingInsert(array, 
            method);
        (int sum, int founds, int searchTime) = CollisionAlgorithms.LinerProbingSearch(moa,
            method);
        return new MethodResults
        {
            AlgorithmName = "Линейное пробирование",
            InsertTime = insertTime,
            SearchTime = searchTime,
            Сomparisons = sum,
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
        var results = getAllResults(array, method);
        return results;
    }
}
