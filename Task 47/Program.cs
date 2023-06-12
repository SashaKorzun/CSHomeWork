// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
internal class Program
{
    public static (int, int) GetArraySize()
    {
        int rowSize = 0;
        int colSize = 0;
        string enteredSymbol = string.Empty;
        do
        {
            Console.Clear();
            Console.Write("Создать случайный 2D массив? Нажмите y/n: ");
            enteredSymbol = Console.ReadLine();
            if (enteredSymbol == "y")
            {
                rowSize = new Random().Next(2, 11);
                colSize = new Random().Next(2, 11);
                Console.WriteLine("Значение m: {0}", rowSize);
                Console.WriteLine("Значение n: {0}", colSize);
                Console.WriteLine();
                break;
            }
            else if (enteredSymbol == "n")
            {
                Console.Write("Введите значение m:");
                rowSize = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите значение n:");
                colSize = Convert.ToInt32(Console.ReadLine());
                break;
            }
        } while (true);

        return (rowSize, colSize);
    }
    static void Print2DArray(double[,] ArrayToPrint)
    {
        Console.Write("[ ]\t");
        for (int i = 0; i < ArrayToPrint.GetLength(1); i++)
        {
            Console.Write($"[{i}]\t", i);
        }
        Console.WriteLine();
        for (int i = 0; i < ArrayToPrint.GetLength(0); i++)
        {
            Console.Write($"[{i}]\t", i);
            for (int j = 0; j < ArrayToPrint.GetLength(1); j++)
            {
                if (ArrayToPrint[i, j] < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                Console.Write(ArrayToPrint[i, j] + "\t");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }
    }
    static void FillArray(double[,] ArrayToFill, int deviation = 10)
    {
        var multiply = new Random();
        for (int i = 0; i < ArrayToFill.GetLength(0); i++)
        {
            for (int j = 0; j < ArrayToFill.GetLength(1); j++)
            {
                ArrayToFill[i, j] = new Random().NextDouble() * multiply.Next(-deviation, deviation + 1);
                ArrayToFill[i, j] = Math.Round(ArrayToFill[i, j], 2);
            }
        }
    }
    private static void Main()
    {
        int rowArraySize = 0;
        int colArraySize = 0;
        (rowArraySize, colArraySize) = GetArraySize();
        double[,] Array2D = new double[rowArraySize, colArraySize];
        FillArray(Array2D);
        Print2DArray(Array2D);

    }
}
