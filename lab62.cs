using System;

public class LineSegment
{
    public double start;
    public double end;

    // Конструктор для инициализации начала и конца отрезка
    public LineSegment(double x, double y)
    {
        start = Math.Min(x, y);
        end = Math.Max(x, y);
    }

    // Метод для проверки, попадает ли число в отрезок
    public bool Popadaet(double number)
    {
        return number >= start && number <= end;
    }

    // Перегрузка метода ToString для представления отрезка
    public override string ToString()
    {
        return $"LineSegment(start: {start}, end: {end})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        double x, y;

        // Ввод начала отрезка с проверкой корректности
        Console.Write("Введите начало отрезка: ");
        while (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, начало отрезка ");
        }

        // Ввод конца отрезка с проверкой корректности
        Console.Write("Введите конец отрезка: ");
        while (!double.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите конец отрезка: ");
        }

        LineSegment segment = new LineSegment(x, y);

        Console.WriteLine(segment.ToString());

        // Проверяем, попадает ли число в отрезок
        double number;
        Console.Write("Введите число для проверки: ");
        while (!double.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
        }

        bool result = segment.Popadaet(number);
        Console.WriteLine($"Число {number} {(result ? "попадает" : "не попадает")} в отрезок.");
    }
}
