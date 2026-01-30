using System;
public static class CollisionAlgorithms
{

    public static (List<int>[], int) ChainMethodInsert(int[] array, 
        Func<int, int, int> method)
    {
        List<int>[] moc = new List<int>[array.Length];
        for (int i = 0; i < moc.Length; i++)
            moc[i] = [];
        int startTime = Environment.TickCount;
        foreach (int num in array)
        {
            int hash = method(num, array.Length);
            //if (hash > moc.Length)
            //    throw new ArgumentException($"Ошибка! Hash = {hash}");
            moc[hash].Add(num);
        }
        int endTime = Environment.TickCount - startTime;
        return (moc, endTime);
    }

    public static (int, int, int) ChainMethodSearch(int[] array,
        List<int>[] moc, Func<int, int, int> method)
    {
        int comparisons = 0, founds = 0;
        int startTime = Environment.TickCount;
        foreach (int num in array)
        {
            int hash = method(num, array.Length);
            for (int i = 0; i < moc[hash].Count; i++)
            {
                comparisons++;
                if (num == moc[hash][i])
                {
                    founds++;
                    break;
                }
            }
            comparisons++;
        }
        int endTime = Environment.TickCount - startTime;
        return (comparisons, founds, endTime);
    }
    public static (int[], int) LinerProbingInsert(int[] array, Func<int, int, int> method)
    {
        int[] moa = new int[array.Length];
        Array.Fill(moa, -1);
        int startTime = Environment.TickCount;
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
        int endTime = Environment.TickCount - startTime;
        return (moa, endTime);
    }

    public static (int, int, int) LinerProbingSearch(int[] array, int[] moa, 
        Func<int, int, int> method)
    {
        int comparisons = 0, founds = 0, endTime;

        int startTime = Environment.TickCount;
        foreach (int num in array)
        {
            int hash = method(num, array.Length);

            for (int i = 0; i < moa.Length; i++)
            {
                comparisons++;
                if (num == moa[hash % moa.Length])
                {
                    founds++;
                    break;
                }
                hash++;
            }
            comparisons++;
        }
        endTime = Environment.TickCount - startTime;
            
        return (comparisons, founds, endTime);
    }

    // Исправить!
    public static (int[], int) QuadraticProbingInsert(int[] array,
        Func<int, int, int> method)
    {
        int[] moa = new int[array.Length];
        Array.Fill(moa, -1);
        int startTime = Environment.TickCount;
        foreach (int num in array)
        {
            int hash = method((int)num, array.Length);
            int item = 0;
            int c = 1;
            while (moa[hash % moa.Length] != -1 && item < moa.Length)
            {
                hash += c * c;
                c++;
                item++;
            }
            if (item == moa.Length)
                throw new Exception("Массив заполнен!");
            moa[hash % moa.Length] = num;
        }
        int endTime = Environment.TickCount - startTime;
        return (moa, endTime);
    }

    public static (int, int, int) QuadraticProbingSearch(int[] array, int[] moa, 
        Func<int, int, int> method)
    {
        int comparisons = 0, founds = 0, endTime;

        int startTime = Environment.TickCount;
        foreach (int num in array)
        {
            int hash = method(num, array.Length);

            if (num == moa[0])
            {
                comparisons++;
                founds++;
            }
            for (int i = 1; i < moa.Length; i*=i)
            {
                comparisons++;
                if (num == moa[hash % moa.Length])
                {
                    founds++;
                    break;
                }
                hash++;
            }
            comparisons++;
        }
        endTime = Environment.TickCount - startTime;
        return (comparisons, founds, endTime);
    }

    public static (int[], int) DoubleHashingInsert(int[] array,
        Func<int, int, int> method1, Func<int, int, int> method2)
    {
        int[] moa = new int[array.Length];
        Array.Fill(moa, -1);
        int startTime = Environment.TickCount;
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
        int endTime = Environment.TickCount - startTime;
        return (moa, endTime);
    }

    public static (int, int, int) DoubleHashingSearch(int[] array, int[] moa,
        Func<int, int, int> method1, Func<int, int, int> method2)
    {
        int comparisons = 0, founds = 0, endTime;

        int startTime = Environment.TickCount;
        foreach (int num in array)
        {
            int hash = method1(method2(num, array.Length), array.Length);

            for (int i = 0; i < moa.Length; i++)
            {
                comparisons++;
                if (num == moa[hash % moa.Length])
                {
                    founds++;
                    break;
                }
                hash++;
            }
            comparisons++;
        }
        endTime = Environment.TickCount - startTime;
        return (comparisons, founds, endTime);
    }
}
