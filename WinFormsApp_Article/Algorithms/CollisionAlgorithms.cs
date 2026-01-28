using System;
public static class CollisionAlgorithms
{
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

    public static (int, int, int) LinerProbingSearch(int[] moa, 
        Func<int, int, int> method)
    {
        int sum = 0, founds = 0, endTime;

        int startTime = Environment.TickCount;
        foreach (int num in moa)
        {
            int hash = method(num, moa.Length);

            for (int i = 0; i < moa.Length; i++)
            {
                sum++;
                if (num == moa[hash % moa.Length])
                {
                    founds++;
                    break;
                }
                hash++;
            }
            sum++;
        }
        endTime = Environment.TickCount - startTime;
            
        return (sum, founds, endTime);
    }

    public static int[] QuadraticProbing(int[] array,
        Func<int, int, int> method)
    {
        int[] moa = new int[array.Length];
        Array.Fill(moa, -1);
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
        return [];
    }

    public static int[] DoubleHashing(int[] array,
        Func<int, int, int> method1,
        Func<int, int, int> method2)
    {
        return [];
    }
}
