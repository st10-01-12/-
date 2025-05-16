
namespace lab7
{
    internal class InputDateWithCheck
    {
        static public int InputIntegerWithValidation(string
            linerequest)
        {
            bool correct;
            int input;
            do
            {
                Console.WriteLine(linerequest);
                correct = int.TryParse(Console.ReadLine(),
                    out input);
                if (!correct)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВведенные " +
                        $"данные имеют неверный формат");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }
            } while (!correct);
            return input;
        }
    }
}
