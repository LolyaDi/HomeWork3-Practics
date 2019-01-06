using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    class Program
    {
        const int INITIAL_VALUE = 0;
        const int TICKETS_PART_SIZE = 3;
        const int CAPITAL_LETTER_A = 65;
        const int CAPITAL_LETTER_Z = 90;
        const int DIFFERENCE_CAPITAL_AND_SMALL = 32;

        static void Main(string[] args)
        {
            // 1-задание
            ConsoleKeyInfo consoleKey;

            Console.WriteLine("Вычисление кол-ва введенных Вами пробелов:" +
                "\n(Фиксируется пока не будет введена точка)");

            int countOfSpacebars = INITIAL_VALUE;

            Console.Write("\nВведите любые символы: ");
            while (true)
            {
                consoleKey = Console.ReadKey();

                if (consoleKey.KeyChar == '.')
                {
                    break;
                }
                if (consoleKey.Key == ConsoleKey.Spacebar)
                {
                    countOfSpacebars++;
                }
            }

            Console.WriteLine($"\n\nОтвет:\nКол-во введенных пробелов = {countOfSpacebars}");

            // 2-задание
            string userStringValue;

            Console.WriteLine("\nПроверка на то, является ли Ваш билет счастливым:" +
                "\n(Если сумма первых трёх цифр равна сумме последних трёх, то этот билет считается счастливым)");

            Console.WriteLine("\nВведите номер Вашего трамвайного билета:\n(Пример:567-456)");
            userStringValue = Console.ReadLine();

            string[] partsOfStringTicket = userStringValue.Split('-');

            char[] firstPartOfString = partsOfStringTicket[0].ToCharArray();
            char[] secondPartOfString = partsOfStringTicket[1].ToCharArray();

            int[] firstNumbersOfTicket = new int[TICKETS_PART_SIZE];
            int[] lastNumbersOfTicket = new int[TICKETS_PART_SIZE];

            for (int i = 0; i < TICKETS_PART_SIZE; i++)
            {
                firstNumbersOfTicket[i] = (int)char.GetNumericValue(firstPartOfString[i]);
                lastNumbersOfTicket[i] = (int)char.GetNumericValue(secondPartOfString[i]);
            }

            int sumFirstNumbersOfTicket = firstNumbersOfTicket[0] + firstNumbersOfTicket[1] + firstNumbersOfTicket[2];
            int sumLastNumbersOfTicket = lastNumbersOfTicket[0] + lastNumbersOfTicket[1] + lastNumbersOfTicket[2];

            if (sumFirstNumbersOfTicket == sumLastNumbersOfTicket)
            {
                Console.WriteLine("\nПоздравляю, у Вас счастливый билет!");
            }
            else
            {
                Console.WriteLine("\nК сожалению, Ваш билет не является счастливым");
            }

            // 3-задание
            Console.WriteLine("\nКонвертация символов в строке из нижнего регистра в верхний и наоборот:");

            Console.Write("Введите любую строку: ");
            userStringValue = Console.ReadLine();

            char[] userCharValue = userStringValue.ToCharArray();

            for(int i = 0; i < userCharValue.Length; i++)
            {
                if(userCharValue[i] >= CAPITAL_LETTER_A && userCharValue[i] <= CAPITAL_LETTER_Z)
                {
                    userCharValue[i] += (char)DIFFERENCE_CAPITAL_AND_SMALL;
                }
                else if(userCharValue[i] >= CAPITAL_LETTER_A + DIFFERENCE_CAPITAL_AND_SMALL && userCharValue[i] <= CAPITAL_LETTER_Z + DIFFERENCE_CAPITAL_AND_SMALL)
                {
                    userCharValue[i] -= (char)DIFFERENCE_CAPITAL_AND_SMALL;
                }
            }

            Console.WriteLine("\nВывод измененной строки:");
            foreach(char letter in userCharValue)
            {
                Console.Write($"{letter}");
            }

            // 4-задание
            Console.Write("\n\nВведите первое число: ");
            userStringValue = Console.ReadLine();

            int startRangeNumber = Convert.ToInt32(userStringValue);

            Console.Write("Введите второе число, которое должно быть больше первого: ");
            userStringValue = Console.ReadLine();

            int endRangeNumber = Convert.ToInt32(userStringValue);

            Console.WriteLine($"\nВывод чисел, в введенном ранее диапозоне(от {startRangeNumber} до {endRangeNumber}):");
            for(int i = startRangeNumber; i <= endRangeNumber; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }

            // 5-задание
            Console.WriteLine("\nЧтение введенных чисел справа налево:");

            Console.Write("Введите любое число, которое больше нуля: ");
            userStringValue = Console.ReadLine();

            string reverseUserString = new string(userStringValue.ToCharArray().Reverse().ToArray());

            Console.WriteLine($"\nЧисло в перевернутом виде:\n{userStringValue} => {reverseUserString}");

            Console.ReadKey();
        }
    }
}
