namespace WinFormsApp_Article.Algorithms
{
    public delegate void MeasureComparisons();
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

        public static void ChainMethodSearch(int[] array,
            List<int>[] moc, Func<int, int, int> method,
            MeasureComparisons mc)
        {
            foreach (int num in array)
            {
                int hash = method(num, array.Length);
                for (int i = 0; i < moc[hash].Count; i++)
                {
                    mc(); // Заменить на делегат
                    if (num == moc[hash][i])
                        break;
                }
                mc();
            }
        }

        public static int[] LinerProbingInsert(int[] array, Func<int, int, int> method)
        {
            int[] moa = new int[array.Length];
            Array.Fill(moa, -1);

            foreach (int num in array)
            {
                int hash = method(num, array.Length);
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

        public static void LinerProbingSearch(int[] array, int[] moa,
            Func<int, int, int> method, MeasureComparisons mc)
        {
            foreach (int num in array)
            {
                int hash = method(num, moa.Length);

                for (int i = 0; i < moa.Length; i++)
                {
                    mc(); // Заменить на делегат
                    if (num == moa[hash % moa.Length])
                        break;

                    hash++;
                }
                mc();
            }
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
                    index = (hash + item + item * item) % size;
                    if (moa[index] == -1)
                    {
                        moa[index] = num;
                        break;
                    }
                    item++;
                }
                if (item == moa.Length)
                    return QuadraticProbingInsert(array, method, size * 2);
            }
            return moa;
        }

        public static void QuadraticProbingSearch(int[] array, int[] moa,
            Func<int, int, int> method, MeasureComparisons mc)
        {
            foreach (int num in array)
            {
                int hash = method(num, array.Length);
                int item = 0, index = hash;
                while (item < moa.Length)
                {
                    index = (hash + item * item) % moa.Length;
                    mc(); // Заменить на делегат
                    if (num == moa[index])
                        break;
                    item++;
                }
                mc();
            }
        }

        public static int[] DoubleHashingInsert(int[] array,
            Func<int, int, int> method1, Func<int, int, int> method2)
        {
            int[] moa = new int[array.Length];
            Array.Fill(moa, -1);
            foreach (int num in array)
            {
                int hash = method1(method2(num, array.Length), array.Length);
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

        public static void DoubleHashingSearch(int[] array, int[] moa,
            Func<int, int, int> method1, Func<int, int, int> method2,
            MeasureComparisons mc)
        {
            foreach (int num in array)
            {
                int hash = method1(method2(num, array.Length), array.Length);

                for (int i = 0; i < moa.Length; i++)
                {
                    mc(); // Заменить на делегат
                    if (num == moa[hash % moa.Length])
                        break;
                    hash++;
                }
                mc();
            }
        }
    }
}