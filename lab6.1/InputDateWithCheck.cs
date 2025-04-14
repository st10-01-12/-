namespace lab6._1
{
    internal class InputDateWithCheck
    {
        //Проверка правильности ввода, в том числе принадлежности к указанному диапазону.
        static public int InputIntegerWithValidation
            (string linerequest, int left, int right)                                                                                   
        {
            bool correct;
            int input;
            do
            {
                Console.WriteLine(linerequest);
                correct = int.TryParse(Console.ReadLine(),
                    out input);
                if (correct)
                    if (input < left || input > right)
                        correct = false;
                if (!correct)
                {
                    ConsoleColor tmp = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВведенные " +
                        $"данные имеют неверный формат" +
                        $" или не принадлежат диапазону" +
                        $" [{left}; {right}]");
                    Console.WriteLine("Повторите ввод\n");
                    Console.ForegroundColor = tmp;
                }
            } while (!correct);
            return input;
        }
    }
}
