// Задайте двумерный массив из целых чисел.
// Количество строк и столбцов задается с клавиатуры. Отсортировать элементы по возрастанию слева направо и сверху вниз.

// С четырьмя циклами вложенными друг в друга получается значительно компактней, зато развивает пространственное мышление :)
int[] TransformToOneDimensionalArray(int[,] array)
{
    int oneDimentionalArraySize = array.GetLength(0) * array.GetLength(1);
    int[] oneDimentionalArray = new int[oneDimentionalArraySize];
    int i = 0;
    int j = 0;
    int k = 0;
    while (i < oneDimentionalArraySize)
    {
        if (i == j * array.GetLength(0) + array.GetLength(1))
        {
            j++;
            k = 0;
        }
        oneDimentionalArray[i] = array[j, k];
        k++;
        i++;
    }
    return oneDimentionalArray;
}

void PrintOneDimensionalAsTwoDimensional(int[] array, int rows, int cols)
{
    Console.WriteLine();
    int j = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (i == j * rows + cols)
        {
            Console.WriteLine();
            j++;
        }
        Console.Write($"{array[i],3}\t");
    }

}

int[] SortArray(int[] array)
{
    int[] sortArray = new int[array.Length];
    for (int i = 0; i < array.Length; i++)
        sortArray[i] = array[i];
    for (int i = 0; i < sortArray.Length; i++)
        for (int j = i; j < sortArray.Length; j++)
            if (sortArray[i] > sortArray[j])
                (sortArray[i], sortArray[j]) = (sortArray[j], sortArray[i]);
    return sortArray;
}

void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = new Random().Next(-20, 21);
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j],3}\t");
        Console.WriteLine();

    }
}


Console.WriteLine("Ведите количество строк двумерного массива");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ведите количество столбцов двумерного массива");
int cols = Convert.ToInt32(Console.ReadLine());
int[,] array = new int[rows, cols];
FillArray(array);
PrintArray(array);
int[] oneDimensionalArray = TransformToOneDimensionalArray(array);
oneDimensionalArray = SortArray(oneDimensionalArray);
PrintOneDimensionalAsTwoDimensional(oneDimensionalArray, rows, cols);