//  Напишите цикл, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B
Console.Clear();
System.Console.WriteLine();

int number = 3;
int exponent = 5;

int GetExponentiation(int number, int exponent)
{
    int count = 1;
    int result = number;
    while (count < exponent)
    {
        result = result * number;
        count++;
    }
    return result;
}

int result = GetExponentiation(number, exponent);
System.Console.WriteLine($"{number} ^ {exponent} = {result}");
System.Console.WriteLine();
