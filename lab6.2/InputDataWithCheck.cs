namespace lab6._2
{
    internal class InputDataWithCheck
    {
        public static double InputDoubleWithValidation(string number)
        {
            bool correct;
            double input;
            do
            {
                Console.WriteLine(number);
                correct = double.TryParse(Console.ReadLine(), out input);
                if (!correct)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nВведенные данные имеют неверный формат. Повторите ввод.\n");
                    Console.ForegroundColor = tmp;
                }
            } while (!correct);
            return input;
        }
    }
}
