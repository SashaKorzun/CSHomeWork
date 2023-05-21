// Задача 10: Напишите программу, которая принимает на вход трёхзначное число 
//и на выходе показывает вторую цифру этого числа

Console.WriteLine("Введите трехзначное число");
int x = Convert.ToInt32(Console.ReadLine());
if (x<1000 && x>99)
{
    int two = x / 10;
    int result = two % 10;
    Console.Write(result);
}
else
Console.WriteLine("Ввели не трехзначное число");
