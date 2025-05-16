using System;
using System.IO;
using lab7;
internal class Program
{
    private static void Main(string[] args)
    {
        string filePath = "C:\\Users\\sofam\\OneDrive\\Desktop\\numbers.txt";
        string fileforcopy = "C:\\Users\\sofam\\OneDrive\\Desktop\\copytext.txt";
        int count;
        int number;
        int length;
        int divisible;
        int lengthofwords;
        int price;

        count = InputDateWithCheck.InputIntegerWithValidation("Введите количество чисел в файле: ");
        while (count < 0)
        {
            Console.WriteLine("Ошибка: количество чисел не может быть отрицательным. Повторите ввод.");
            count = InputDateWithCheck.InputIntegerWithValidation("Введите количество чисел в файле: ");
        }

        Console.WriteLine("\nЗадание #1");

        WorkWithFiles.FillFileWithRandomNumbers(filePath, count, 0, 100);
        number = InputDateWithCheck.InputIntegerWithValidation("Введите число для нахождения его в файле: ");
        if(WorkWithFiles.SearchNumberInFile(filePath, number))
        {
            Console.WriteLine($"Число {number} содержится в файле {filePath}");
        }
        else
        {
            Console.WriteLine($"Число {number} не содержится в файле {filePath}");
        }

        Console.WriteLine("\nЗадание #2");

        length = InputDateWithCheck.InputIntegerWithValidation("Введите количество чисел в строке: ");
        WorkWithFiles.FillFileWithSeveralRandomNumbers(filePath, count, 0, 100, length);
        divisible = InputDateWithCheck.InputIntegerWithValidation("Введите число для проверки на кратность: ");
        while (divisible == 0)
        {
            Console.WriteLine("Ошибка: делитель не может быть равен нулю.");
            divisible = InputDateWithCheck.InputIntegerWithValidation("Введите число для проверки на кратность: ");
        }
        WorkWithFiles.SumOfMultiplesInFile(filePath, divisible);

        Console.WriteLine("\nЗадание #3");

        lengthofwords = InputDateWithCheck.InputIntegerWithValidation("Введите количество слов в строке: ");
        WorkWithFiles.FillFileWithRandomText(filePath, count, lengthofwords);
        WorkWithFiles.CopyLinesWithoutDigits(filePath, fileforcopy);

        Console.WriteLine("\nЗадание #4");

        WorkWithFiles.FillBinaryFileWithRandomNumbers(filePath, count, 0, 100);
        WorkWithFiles.CopyFileWithUniqueNumbers(filePath, fileforcopy);

        Console.WriteLine("\nЗадание #5");

        WorkWithFiles.FillFileWithRandomToys(filePath, count);
        price = InputDateWithCheck.InputIntegerWithValidation("Введите максимально допустимую цену: ");
        while (price < 0)
        {
            Console.WriteLine("Ошибка: цена не может быть отрицательной");
            price = InputDateWithCheck.InputIntegerWithValidation("Введите максимально допустимую цену: ");
        }
        WorkWithFiles.PrintToysByPriceAndAge(filePath, price, 5);

        Console.WriteLine("\nЗадание #6");

        List<int> numbers = new List<int>();
        WorkWithFiles.FillListWithRandomNumbers(numbers, count);
        number = InputDateWithCheck.InputIntegerWithValidation("Введите число для удаления его из списка: ");
        WorkWithFiles.RemoveAllOccurrences(numbers, number);

        Console.WriteLine("\nЗадание #7");

        WorkWithFiles.FillListWithRandomNumbers(numbers, count);
        number = InputDateWithCheck.InputIntegerWithValidation("Введите число для переставления между ним других чисел в списке: ");
        WorkWithFiles.ReverseBetweenFirstAndLast(numbers, number);
    }
}
