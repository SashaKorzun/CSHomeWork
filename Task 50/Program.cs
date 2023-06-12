// Напишите программу, которая на вход принимает значение элемента в двумерном массиве, и возвращает позицию этого элемента или же указание, что такого элемента нет
internal class Program
{
    static (int, int) GetArraySize()
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
    static void Print2DArray(int[,] ArrayToPrint, int coloredElement = 0)
    {
        int rowColoredElement = (coloredElement - 1) / ArrayToPrint.GetLength(1);
        int colColoredElement = coloredElement - 1 - rowColoredElement * ArrayToPrint.GetLength(1);
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
                if (i == rowColoredElement
                    && j == colColoredElement)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
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
    static void Fill2DArray(int[,] ArrayToFill, int deviation = 10)
    {
        for (int i = 0; i < ArrayToFill.GetLength(0); i++)
        {
            for (int j = 0; j < ArrayToFill.GetLength(1); j++)
            {
                ArrayToFill[i, j] = new Random().Next(-deviation, deviation + 1);
            }
        }
    }

    static void ChooseArrayElement(int[,] ArrayToSeek)
    {
        string enteredSymbol = string.Empty;
        int elementNumber = 0;
        int row = 0, column = 0;
        do
        {
            Console.Clear();
            Print2DArray(ArrayToSeek);
            Console.WriteLine();
            Console.Write("Выберете номер элемента двухмерного массива. Нажмите 'q' для выхода: ");
            enteredSymbol = Console.ReadLine();

            if (enteredSymbol == string.Empty)
                continue;
            if (enteredSymbol == "q")
                break;

            elementNumber = Convert.ToInt32(enteredSymbol);

            if (elementNumber >= 1
                && elementNumber <= ArrayToSeek.GetLength(0) * ArrayToSeek.GetLength(1))
            {
                Console.Clear();
                row = (elementNumber - 1) / ArrayToSeek.GetLength(1);
                column = elementNumber - 1 - row * ArrayToSeek.GetLength(1);
                Print2DArray(ArrayToSeek, elementNumber);
                Console.Write("Элемент массива с номером {0} = {1}.",
                                elementNumber, ArrayToSeek[row, column]);
                Console.ReadKey();
            }
            else
            {
                Console.Write("Элемента с номером {0} не существует в этом массиве.", elementNumber);
                Console.ReadKey();
            }

        } while (true);
    }
    private static void Main()
    {
        int rowNumber = 0;
        int colNumber = 0;
        (rowNumber, colNumber) = GetArraySize();
        int[,] Array = new int[rowNumber, colNumber];
        Fill2DArray(Array, 9);
        ChooseArrayElement(Array);

    }
}


