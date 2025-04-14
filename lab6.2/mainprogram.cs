using System;
using lab6._2;
class Program
{
    static void Main(string[] args)
    {
        double start;
        double end;
        double number;
        bool result;

        start = InputDataWithCheck.InputDoubleWithValidation
            ("Введите начало отрезка: ");
        end = InputDataWithCheck.InputDoubleWithValidation
            ("Введите конец отрезка: ");
        number = InputDataWithCheck.InputDoubleWithValidation
            ("Введите число для проверки: ");

        LineSegment segment = new LineSegment(start, end);
        result = segment.IntoSegment(number);

        Console.WriteLine(segment.ToString());
        Console.WriteLine($"Число {number} {(result ? "попадает" : "не попадает")} в отрезок.");
    }
}
