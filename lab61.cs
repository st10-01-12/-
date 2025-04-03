using System;

public class Poles
{
    public int pole1;
    public int pole2;
    public int pole3;

    // Конструктор по умолчанию
    public Poles() { }

    // Конструктор копирования
    public Poles(Poles other)
    {
        this.pole1 = other.pole1;
        this.pole2 = other.pole2;
        this.pole3 = other.pole3;
    }

    public int maxdigit()
    {
        int lastDigit1 = Math.Abs(pole1 % 10);
        int lastDigit2 = Math.Abs(pole2 % 10);
        int lastDigit3 = Math.Abs(pole3 % 10);

        int maxDigit = Math.Max(lastDigit1, Math.Max(lastDigit2, lastDigit3));
        return maxDigit;
    }

    // Перегрузка метода ToString()
    public override string ToString()
    {
        return $"Poles(pole1: {pole1}, pole2: {pole2}, pole3: {pole3})";
    }
}

// Дочерний класс
public class ColourPoles : Poles
{
    public string color1;
    public string color2;
    public string color3;

    // Конструктор по умолчанию
    public ColourPoles() : base()
    {
        color1 = "White";
        color2 = "White";
        color3 = "White";
    }

    // Конструктор копирования
    public ColourPoles(ColourPoles other) : base(other)
    {
        this.color1 = other.color1;
        this.color2 = other.color2;
        this.color3 = other.color3;
    }

    // Метод для изменения цветов
    public void ChangeColors(string newColor1, string newColor2, string newColor3)
    {
        color1 = newColor1;
        color2 = newColor2;
        color3 = newColor3;
    }

    // Метод для проверки, все ли цвета одинаковы
    public bool ColorsSame()
    {
        return color1 == color2 && color2 == color3;
    }

    // Перегрузка метода ToString()
    public override string ToString()
    {
        return $"ColoredPoles(color1: {color1}, color2: {color2}, color3: {color3})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Poles polepole = new Poles();

        Console.Write("Введите значение для pole1: ");
        while (!int.TryParse(Console.ReadLine(), out polepole.pole1))
        {
            Console.Write("Некорректный ввод. Введите целое число для pole1: ");
        }

        Console.Write("Введите значение для pole2: ");
        while (!int.TryParse(Console.ReadLine(), out polepole.pole2))
        {
            Console.Write("Некорректный ввод. Введите целое число для pole2: ");
        }

        Console.Write("Введите значение для pole3: ");
        while (!int.TryParse(Console.ReadLine(), out polepole.pole3))
        {
            Console.Write("Некорректный ввод. Введите целое число для pole3: ");
        }

        Poles polepole2 = new Poles(polepole);

        Console.WriteLine("Значения для первого объекта: " + polepole.ToString());
        Console.WriteLine("Скопированные значения для второго объекта: " + polepole2.ToString());

        int max = polepole.maxdigit();
        Console.WriteLine($"Максимальная цифра: {max}");

        ColourPoles testPoles = new ColourPoles();

        Console.Write("Введите значение для color1: ");
        testPoles.color1 = Console.ReadLine();

        Console.Write("Введите значение для color2: ");
        testPoles.color2 = Console.ReadLine();

        Console.Write("Введите значение для color3: ");
        testPoles.color3 = Console.ReadLine();

        Console.WriteLine("Исходные цвета: " + testPoles.ToString());
        Console.WriteLine("Все цвета одинаковы? " + testPoles.ColorsSame());

        testPoles.ChangeColors("red", "red", "red");
        Console.WriteLine("Измененные цвета: " + testPoles.ToString());
        Console.WriteLine("Все цвета одинаковы? " + testPoles.ColorsSame());
    }
}
