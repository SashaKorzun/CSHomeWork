// Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
(int, int) GetArraySize()
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
        //else if (enteredSymbol == String.Empty)

    } while (true);

    return (rowSize, colSize);
}
void Print2DArray(int[,] ArrayToPrint)
{
    Console.Write("[X]\t");
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
            Console.ResetColor();
        }
        Console.WriteLine();
    }
}
void Fill2DArray(int[,] ArrayToFill, int deviation = 10)
{
    for (int i = 0; i < ArrayToFill.GetLength(0); i++)
    {
        for (int j = 0; j < ArrayToFill.GetLength(1); j++)
        {
            ArrayToFill[i, j] = new Random().Next(-deviation, deviation + 1);
        }
    }
}

double GetAverageArrayColumn(int[,] ArrayToSeek, int ColumnToCalculate)
{
    double average = 0;
    for (int i = 0; i < ArrayToSeek.GetLength(0); i++)
    {
        average = average + ArrayToSeek[i, ColumnToCalculate];
    }
    average = average / ArrayToSeek.GetLength(0);
    return average;
}

int rowAmount = 0;
int columnAmount = 0;

(rowAmount, columnAmount) = GetArraySize();
int[,] Array = new int[rowAmount, columnAmount];
Fill2DArray(Array);
Print2DArray(Array);
Console.WriteLine();

Console.Write("\t");
for (int j = 0; j < Array.GetLength(1); j++)
{
    Console.Write($"{Math.Round(GetAverageArrayColumn(Array, j), 2)}\t");
}
Console.WriteLine(" <-- Средние значения по столбцам");
