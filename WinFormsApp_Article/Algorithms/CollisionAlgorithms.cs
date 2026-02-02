namespace WinFormsApp_Article.Algorithms
{
    /// <summary>
    /// Статический класс, представляющий методы разрешения коллизий
    /// </summary>
    public static class CollisionAlgorithms
    {
        /// <summary>
        /// Метод, реализующий вставку элементов для метода цепочек
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method"> метод хеширования </param>
        /// <returns> массив списков (цепочки) </returns>
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

        /// <summary>
        /// Метод, реализующий поиск для метода цепочек
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="moc"> массив списков </param>
        /// <param name="method"> метод хеширования </param>
        /// <param name="mc"> делегат для подсчёта количества сравнений </param>
        public static void ChainMethodSearch(int[] array,
            List<int>[] moc, Func<int, int, int> method,
            Action mc)
        {
            foreach (int num in array)
            {
                int hash = method(num, array.Length);
                for (int i = 0; i < moc[hash].Count; i++)
                {
                    mc();
                    if (num == moc[hash][i])
                        break;
                }
                mc();
            }
        }

        /// <summary>
        /// Метод, реализующий вставку элементов для метода линейного пробирования
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method"> метод хеширования </param>
        /// <returns> массив хешей </returns>
        /// <exception cref="Exception"> ошибка переполнения массива </exception>
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

        /// <summary>
        /// Метод, реализующий поиск для метода линейного пробирования
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="moa"> массив хешей </param>
        /// <param name="method"> метод хеширования </param>
        /// <param name="mc"> делегат для подсчёта количества сравнений </param>
        public static void LinerProbingSearch(int[] array, int[] moa,
            Func<int, int, int> method, Action mc)
        {
            foreach (int num in array)
            {
                int hash = method(num, moa.Length);

                for (int i = 0; i < moa.Length; i++)
                {
                    mc(); 
                    if (num == moa[hash % moa.Length])
                        break;
                    hash++;
                }
                mc();
            }
        }

        /// <summary>
        /// Метод, реализующий вставку элементов для метода квадратичного пробирования
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method"> мтеод хеширования </param>
        /// <param name="size"> размер исходного массива </param>
        /// <returns> массив хешей </returns>
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

        /// <summary>
        /// Метод, реализующий поиск для метода квадратичного пробирования
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="moa"> массив хешей </param>
        /// <param name="method"> метод хеширования </param>
        /// <param name="mc"> делегат для подсчёта количества сравнений </param>
        public static void QuadraticProbingSearch(int[] array, int[] moa,
            Func<int, int, int> method, Action mc)
        {
            foreach (int num in array)
            {
                int hash = method(num, array.Length);
                int item = 0, index = hash;
                while (item < moa.Length)
                {
                    index = (hash + item * item) % moa.Length;
                    mc(); 
                    if (num == moa[index])
                        break;
                    item++;
                }
                mc();
            }
        }

        /// <summary>
        /// Метод, реализующий вставку элементов для метода двойного хеширования 
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="method1"> первый метод хеширования </param>
        /// <param name="method2"> второй метод хеширования </param>
        /// <returns> массив хешей </returns>
        /// <exception cref="Exception"> ошибка переполнения массива </exception>
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

        /// <summary>
        /// Метод, реализующий поиск для метода двойного хеширования 
        /// </summary>
        /// <param name="array"> исходный массив чисел </param>
        /// <param name="moa"> массив хешей </param>
        /// <param name="method1"> первый метод хеширования </param>
        /// <param name="method2"> второй метод хеширования </param>
        /// <param name="mc"> делегат для подсчёта количества сравнений </param>
        public static void DoubleHashingSearch(int[] array, int[] moa,
            Func<int, int, int> method1, Func<int, int, int> method2,
            Action mc)
        {
            foreach (int num in array)
            {
                int hash = method1(method2(num, array.Length), array.Length);

                for (int i = 0; i < moa.Length; i++)
                {
                    mc(); 
                    if (num == moa[hash % moa.Length])
                        break;
                    hash++;
                }
                mc();
            }
        }
    }
}