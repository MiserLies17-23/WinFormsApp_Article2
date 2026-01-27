using System;
using System.CodeDom;
using System.Drawing;


namespace WinFormsApp_Article.Algorithms
{
    public static class CollisionAlgorithms
    {
        public static int[] LinerProbingInsert(int[] array, Func<int, int, int> method,
            int div)
        {
            int[] moa = new int[array.Length];
            Array.Fill(moa, -1);
            foreach (int num in array)
            {
                int hash = method((int)num, div);
                int item = 0;
                while (moa[hash % moa.Length] != -1 && item < moa.Length)
                {
                    hash++;
                    item++;
                }
                if (item == moa.Length)
                    throw new Exception("Массив зареполнен!");
                moa[hash % moa.Length] = num;
            }
            return moa;
        }

        public static (int, int, int) LinerProbingSearch(int[] moa, Func<int, int, int> method)
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
    }
}
