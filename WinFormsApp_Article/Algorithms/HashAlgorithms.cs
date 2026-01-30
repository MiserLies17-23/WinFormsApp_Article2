using System;

/// <summary>
/// Статический класс, предоставляющий хеш-функции
/// </summary>
public static class HashAlgorithms
{
    /// <summary>
    /// Константа умножения
    /// </summary>
    private static readonly double A = (Math.Sqrt(5) - 1) / 2;
        
    /// <summary>
    /// Метод деления
    /// </summary>
    /// <param name="key"> ключ </param>
    /// <param name="div"> простой делитель, близкий к длине массива </param>
    /// <returns> значение хеша </returns>
    public static int DivisionMethod(int key, int div)
    {
        return key % div;
    }

    /// <summary>
    /// Метод середины квадрата
    /// </summary>
    /// <param name="key"> ключ </param>
    /// <param name="size"> длина массива </param>
    /// <returns> значение хеша </returns>
    public static int MidsquareMethod(int key, int size)
    {
        long squared = (long)key * key;
        if (squared < size)
            return (int)squared;

        int squredSize = (int)Math.Ceiling(Math.Log10(squared));
        squared /= (long)Math.Pow(10, (squredSize - (int)Math.Log10(size)) / 2);
        int hash = (int)squared % (int)Math.Pow(10, Math.Log10(size));
        return Math.Abs(hash)%size;
    }

    /// <summary>
    /// Метод свёртывания
    /// </summary>
    /// <param name="key"> ключ </param>
    /// <param name="size"> длина массива </param>
    /// <returns> значение хеша </returns>
    public static int FoldingMethod(int key, int size)
    {
        int sum = 0;
        while (key > 0)
        {
            sum += key % size;
            key /= size;
        }
        return sum % size;
    }

    /// <summary>
    /// Метод умножения 
    /// </summary>
    /// <param name="key"> ключ </param>
    /// <param name="size"> длина массива </param>
    /// <returns> значение хеша </returns>
    public static int MultiplicationMethod(int key, int size)
    {
        double fraction = (double)(key * A) % 1;
        return (int)(fraction * size);
    }
}

