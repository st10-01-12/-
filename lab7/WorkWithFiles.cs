using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace lab7
{
    public class WorkWithFiles
    {
        public WorkWithFiles()
        {
        }

        public WorkWithFiles(string name, int price, int minAge, int maxAge)
        {
            Name = name;
            Price = price;
            MinAge = minAge;
            MaxAge = maxAge;
        }
        public string Name
        {
            get;
            set;
        }
        public int Price
        {
            get;
            set;
        }
        public int MinAge
        {
            get;
            set;
        }
        public int MaxAge
        {
            get;
            set;
        }
        public static void FillFileWithRandomNumbers(string filename, int count, int minRange, int maxRange)
        {
            if (count < 0)
            {
                Console.WriteLine("Ошибка: количество чисел не может быть отрицательным.");
                return;
            }

            if (minRange > maxRange)
            {
                Console.WriteLine("Ошибка: минимальное значение диапазона больше максимального.");
                return;
            }

            try
            {
                Random random = new Random();
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    for (int i = 0; i < count; i++)
                    {
                        writer.WriteLine(random.Next(minRange, maxRange + 1));
                    }
                }
                Console.WriteLine($"Файл '{filename}' заполнен {count} случайными числами от {minRange} до {maxRange}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }

        public static bool SearchNumberInFile(string filename, int numbercompare)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string numberinfile;
                    int number;
                    while ((numberinfile = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(numberinfile, out number))
                        {
                            if (number == numbercompare)
                                return true;
                        }
                        else
                        {
                            Console.WriteLine($"В файле обнаружена строка с неверным форматом числа: '{numberinfile}'");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return false;
            }
            return false;
        }

        public static void FillFileWithSeveralRandomNumbers(string filename, int count, int minRange, int maxRange, int numbersinLine)
        {
            if (count < 0)
            {
                Console.WriteLine("Ошибка: количество чисел не может быть отрицательным.");
                return;
            }

            if (minRange > maxRange)
            {
                Console.WriteLine("Ошибка: минимальное значение диапазона больше максимального.");
                return;
            }

            if (numbersinLine <= 0)
            {
                Console.WriteLine("Ошибка: количество чисел в строке должно быть не положительным.");
                return;
            }

            try
            {
                Random random = new Random();
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    int numbersWritten = 0;
                    while (numbersWritten < count)
                    {
                        int numbersInThisLine = Math.Min(numbersinLine, count - numbersWritten);
                        int[] numbers = new int[numbersInThisLine];

                        for (int i = 0; i < numbersInThisLine; i++)
                        {
                            numbers[i] = random.Next(minRange, maxRange + 1);
                        }
                        writer.WriteLine(string.Join(" ", numbers));
                        numbersWritten += numbersInThisLine;
                    }
                }
                Console.WriteLine($"Файл '{filename}' заполнен {count} случайными числами от {minRange} до {maxRange} по {numbersinLine} чисел в строке.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }

        public static void SumOfMultiplesInFile(string filename, int divisible)
        {
            if (divisible == 0)
            {
                Console.WriteLine("Ошибка: делитель не может быть равен нулю.");
                return;
            }

            int sum = 0;
            int number;

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string numberinfile;
                    while ((numberinfile = reader.ReadLine()) != null)
                    {
                        foreach (string part in numberinfile.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            if (int.TryParse(part, out number))
                            {
                                if (number % divisible == 0)
                                    sum += number;
                            }
                            else
                            {
                                Console.WriteLine($"Предупреждение: обнаружена некорректная запись '{part}', пропускается.");
                            }
                        }
                    }
                }
                Console.WriteLine($"Сумма элементов, кратных {divisible}, равна: {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }

        public static void FillFileWithRandomText(string filename, int count, int wordsinLine)
        {
            if (count < 0)
            {
                Console.WriteLine("Ошибка: количество слов не может быть отрицательным.");
                return;
            }

            if (wordsinLine <= 0)
            {
                Console.WriteLine("Ошибка: количество слов в строке должно быть положительным.");
                return;
            }

            string[] wordsfortext = new[]
            {
                "в", "этом", "году", "я", "пробежал",
                "10", "километров", "за", "45", "минут"
            };

            try
            {
                Random random = new Random();

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    int wordsWritten = 0;
                    while (wordsWritten < count)
                    {
                        int wordsInThisLine = Math.Min(wordsinLine, count - wordsWritten);
                        StringBuilder line = new StringBuilder();

                        for (int i = 0; i < wordsInThisLine; i++)
                        {
                            string word = wordsfortext[random.Next(wordsfortext.Length)];
                            line.Append(word);
                            if (i < wordsInThisLine - 1)
                                line.Append(' ');
                        }

                        writer.WriteLine(line.ToString());
                        wordsWritten += wordsInThisLine;
                    }
                }

                Console.WriteLine($"Файл '{filename}' заполнен {count} случайными словами по {wordsinLine} слов в строке.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }

        public static void CopyLinesWithoutDigits(string filename, string fileforcopy)
        {
            if (string.Equals(Path.GetFullPath(filename), Path.GetFullPath(fileforcopy), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ошибка: исходный и целевой файлы не должны совпадать.");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filename))
                using (StreamWriter writer = new StreamWriter(fileforcopy))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!Regex.IsMatch(line, @"\d"))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                Console.WriteLine($"Строки без цифр из файла '{filename}' скопированы в файл '{fileforcopy}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файлов: {ex.Message}");
            }
        }

        public static void FillBinaryFileWithRandomNumbers(string filename, int count, int minValue, int maxValue)
        {
            if (count < 0)
            {
                Console.WriteLine("Ошибка: количество чисел не может быть отрицательным.");
                return;
            }

            if (minValue > maxValue)
            {
                Console.WriteLine("Ошибка: минимальное значение диапазона больше максимального.");
                return;
            }

            try
            {
                Random random = new Random();

                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    for (int i = 0; i < count; i++)
                    {
                        int number = random.Next(minValue, maxValue + 1);
                        writer.Write(number);
                    }
                }

                Console.WriteLine($"Бинарный файл '{filename}' заполнен {count} случайными числами от {minValue} до {maxValue}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в бинарный файл: {ex.Message}");
            }
        }

        public static void CopyFileWithUniqueNumbers(string filename, string copyfile)
        {
            if (string.Equals(Path.GetFullPath(filename), Path.GetFullPath(copyfile), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Ошибка: исходный и целевой файлы не должны совпадать.");
                return;
            }

            try
            {
                int[] numbers;
                long count;

                using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    count = reader.BaseStream.Length / sizeof(int);

                    if (count == 0)
                    {
                        Console.WriteLine("Исходный файл пустой, нечего копировать.");
                        return;
                    }
                    numbers = new int[count];
                    for (int i = 0; i < count; i++)
                    {
                        numbers[i] = reader.ReadInt32();
                    }
                }
                Array.Sort(numbers);

                using (BinaryWriter writer = new BinaryWriter(File.Open(copyfile, FileMode.Create)))
                {
                    writer.Write(numbers[0]);
                    for (int i = 1; i < numbers.Length; i++)
                    {
                        if (numbers[i] != numbers[i - 1])
                        {
                            writer.Write(numbers[i]);
                        }
                    }
                }

                Console.WriteLine($"Уникальные числа из '{filename}' записаны в '{copyfile}' с помощью сортировки.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файлов: {ex.Message}");
            }
        }

        private bool IsSuitableForAge(int age)
        {
            return age >= MinAge && age <= MaxAge;
        }

        public static void FillFileWithRandomToys(string filename, int count)
        {
            if (count < 0)
            {
                Console.WriteLine("Ошибка: количество игрушек не может быть отрицательным.");
                return;
            }

            try
            {
                Random random = new Random();

                string[] examplesofnames = { "Конструктор", "Кукла", "Машинка", "Пазл", "Мяч", "Робот", "Набор для рисования" };

                WorkWithFiles[] toys = new WorkWithFiles[count];

                for (int i = 0; i < count; i++)
                {
                    string name = examplesofnames[random.Next(examplesofnames.Length)];
                    int price = random.Next(0, 2000);
                    int minAge = random.Next(0, 6);
                    int maxAge = random.Next(minAge, 16);

                    toys[i] = new WorkWithFiles(name, price, minAge, maxAge);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(WorkWithFiles[]));
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    serializer.Serialize(fs, toys);
                }

                Console.WriteLine($"Файл '{filename}' заполнен {count} случайными игрушками.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
        }

        public static void PrintToysByPriceAndAge(string filename, int maxPrice, int age)
        {
            if (maxPrice < 0)
            {
                Console.WriteLine("Ошибка: максимальная цена не может быть отрицательной.");
                return;
            }

            if (age < 0)
            {
                Console.WriteLine("Ошибка: возраст не может быть отрицательным.");
                return;
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WorkWithFiles[]));

                WorkWithFiles[] toys;
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    toys = (WorkWithFiles[])serializer.Deserialize(fs);
                }

                Console.WriteLine($"Игрушки для детей {age} лет с ценой не выше {maxPrice} руб.:");

                bool found = false;
                for (int i = 0; i < toys.Length; i++)
                {
                    var toy = toys[i];
                    if (toy.Price <= maxPrice && toy.IsSuitableForAge(age))
                    {
                        Console.WriteLine($"{i}) {toy.Name} (Цена: {toy.Price} руб., Возраст: {toy.MinAge}-{toy.MaxAge} лет)");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Подходящих игрушек не найдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении или десериализации файла: {ex.Message}");
            }
        }


        public static void FillListWithRandomNumbers(List<int> list, int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int number = random.Next(0, 20);
                list.Add(number);
            }
            Console.WriteLine("Сгенерированные числа в списке:");
            Console.WriteLine(string.Join(", ", list));
        }
        public static void RemoveAllOccurrences(List<int> list, int valueToRemove)
        {
            list.RemoveAll(item => item == valueToRemove);
            Console.WriteLine("Список после удаления: " + string.Join(", ", list));
        }

        public static void ReverseBetweenFirstAndLast(List<int> list, int element)
        {
            int firstIndex = list.IndexOf(element);
            int lastIndex = list.LastIndexOf(element);

            if (firstIndex != -1 && lastIndex != -1 && lastIndex > firstIndex + 1)
            {
                int start = firstIndex + 1;
                int count = lastIndex - firstIndex - 1;

                List<int> sublist = list.GetRange(start, count);
                sublist.Reverse();

                for (int i = 0; i < count; i++)
                {
                    list[start + i] = sublist[i];
                }
            }
            else
            {
                Console.WriteLine("Элемент встречается менее двух раз или нет элементов для реверса между вхождениями.");
            }

            Console.WriteLine("Список после переворачивания: " + string.Join(", ", list));

        }
    }
}
