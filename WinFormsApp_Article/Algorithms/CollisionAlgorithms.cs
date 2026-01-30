using System;
public static class CollisionAlgorithms
{

    public static List<int>[] ChainMethodInsert(int[] array, 
        Func<int, int, int> method)
    {
        List<int>[] moc = new List<int>[array.Length];
        for (int i = 0; i < moc.Length; i++)
            moc[i] = [];
        foreach (int num in array)
        {
            int hash = method(num, array.Length);
            moc[hash].Add(num);
        }
        return moc;
    }

    public static int ChainMethodSearch(int[] array,
        List<int>[] moc, Func<int, int, int> method)
    {
        int comparisons = 0;
        foreach (int num in array)
        {
            int hash = method(num, array.Length);
            for (int i = 0; i < moc[hash].Count; i++)
            {
                comparisons++; // Заменить на делегат
                if (num == moc[hash][i])
                    break;
            }
            comparisons++;
        }
        return comparisons;
    }

    public static int[] LinerProbingInsert(int[] array, Func<int, int, int> method)
    {
        int[] moa = new int[array.Length];
        Array.Fill(moa, -1);
        
        foreach (int num in array)
        {
            int hash = method((int)num, array.Length);
            int item = 0;
            while (moa[hash % moa.Length] != -1 && item < moa.Length)
            {
                hash++;
                item++;
            }
            if (item == moa.Length)
                throw new Exception("Массив заполнен!");
            moa[hash % moa.Length] = num;
        }
        return moa;
    }

    public static int LinerProbingSearch(int[] array, int[] moa, 
        Func<int, int, int> method)
    {
        int comparisons = 0;

        foreach (int num in array)
        {
            int hash = method(num, moa.Length);

            for (int i = 0; i < moa.Length; i++)
            {
                comparisons++; // Заменить на делегат
                if (num == moa[hash % moa.Length])
                    break;
                
                hash++;
            }
            comparisons++;
        }
        return comparisons;
    }
    // исправить
    public static int[] QuadraticProbingInsert(int[] array,
        Func<int, int, int> method, int size)
    {
        int[] moa = new int[size];
        Array.Fill(moa, -1);
        foreach (int num in array)
        {
            int hash = method(num, size);
            int item = 0, index = hash;
            while (item < moa.Length)
            {
                index = (hash + item + item*item)%size;
                if (moa[index] == -1)
                {
                    moa[index] = num;
                    break;
                }
                item++;
            }
            if (item == moa.Length)
                return QuadraticProbingInsert(array, method, size*2);
        }
        return moa;
    }

    public static int QuadraticProbingSearch(int[] array, int[] moa, 
        Func<int, int, int> method)
    {
        int comparisons = 0;
        foreach (int num in array)
        {
            int hash = method(num, array.Length);
            int item = 0, index = hash;
            while (item < moa.Length)
            {
                index = (hash + item * item) % moa.Length;
                comparisons++; // Заменить на делегат
                if (num == moa[index])
                    break;
                item++;
            }
            comparisons++;
        }
        return comparisons;
    }

    public static int[] DoubleHashingInsert(int[] array,
        Func<int, int, int> method1, Func<int, int, int> method2)
    {
        int[] moa = new int[array.Length];
        Array.Fill(moa, -1);
        foreach (int num in array)
        {
            int hash = method1(method2((int)num, array.Length), array.Length);
            int item = 0;
            while (moa[hash % moa.Length] != -1 && item < moa.Length)
            {
                hash++;
                item++;
            }
            if (item == moa.Length)
                throw new Exception("Массив заполнен!");
            moa[hash % moa.Length] = num;
        }
        return moa;
    }

    public static int DoubleHashingSearch(int[] array, int[] moa,
        Func<int, int, int> method1, Func<int, int, int> method2)
    {
        int comparisons = 0;
        foreach (int num in array)
        {
            int hash = method1(method2(num, array.Length), array.Length);

            for (int i = 0; i < moa.Length; i++)
            {
                comparisons++; // Заменить на делегат
                if (num == moa[hash % moa.Length])
                    break;
                hash++;
            }
            comparisons++;
        }
        return comparisons;
    }
}
