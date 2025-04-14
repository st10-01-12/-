using System;
using lab6._1;


internal class Program
{
    private static void Main(string[] args)
    {
        int day;
        int month;
        int year;
        int maxdigit;

        day = InputDateWithCheck.InputIntegerWithValidation
            ("Введите день рождения: ", 1, 31);
        month = InputDateWithCheck.InputIntegerWithValidation
            ("Введите месяц рождения: ", 1, 12);
        year = InputDateWithCheck.InputIntegerWithValidation
            ("Введите год рождения: ", 1925, 2025);

        DateOfBirth sofa = new DateOfBirth();
        DateOfBirth martin = new DateOfBirth(day, month, year);
        DateOfBirth anya = new DateOfBirth(martin);

        maxdigit = anya.MaxDigit();

        Console.WriteLine($"Значения для первого объекта " +
            $"Sofa: {sofa.ToString()}");
        Console.WriteLine($"Значения для второго объекта " +
            $"Martin: {martin.ToString()}");
        Console.WriteLine($"Скопированные значения для " +
            $"третьего объекта  Anya: {anya.ToString()}"); 
        Console.WriteLine($"Максимальная цифра для объекта " +
            $"Anya: {maxdigit}");

        AgeOfPerson anyaage = new AgeOfPerson(anya);
        Console.WriteLine($"Возраст для объекта Anya: " +
            $"{anyaage.CalculateAge()}");
        if (anyaage.IsLeapYear())
            Console.WriteLine("Год рождения високосный");
        else
            Console.WriteLine("Год рождения не високосный");

    }
}
