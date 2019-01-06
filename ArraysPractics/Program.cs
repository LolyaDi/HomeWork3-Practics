using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPractics
{
    class Program
    {
        const int ARRAY_FIRST_SIZE = 5;
        const int ARRAY_SECOND_SIZE_ROW = 3;
        const int ARRAY_SECOND_SIZE_COLUMN = 4;
        const int ROUNDING_AFTER_DECIMAL_POINT = 3;
        const int INITIAL_VALUE_FOR_MULTIPLICATION = 1;
        const int INITIAL_VALUE_FOR_SUM = 0;
        const int FIRST_EVEN_NUMBER = 2;
        const int RANGE_NUMBERS_START = 7;
        const int RANGE_NUMBERS_END = 17;
        const int FIFTH_TASK_RANGE_NUMBERS_START = -100;
        const int FIFTH_TASK_RANGE_NUMBERS_END = 100;

        static void Main(string[] args)
        {
            // 1-задание
            double[] arrayFirst = new double[ARRAY_FIRST_SIZE];
            double[,] arraySecond = new double[ARRAY_SECOND_SIZE_ROW, ARRAY_SECOND_SIZE_COLUMN];

            string userStringValue;

            Console.WriteLine("Заполните любыми числами одномерный массив, состоящий из 5 элементов:");
            for (int i = 0; i < arrayFirst.Length; i++)
            {
                userStringValue = Console.ReadLine();
                arrayFirst[i] = Convert.ToDouble(userStringValue);
            }

            Random randomizing = new Random();

            Console.WriteLine("\nВывод введенного одномерного массива на экран:");
            foreach(double element in arrayFirst)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine("\n\nВывод двумерного массива,состоящего из рандомных дробных чисел, на экран:");
            for (int i = 0; i < arraySecond.GetLength(0); i++)
            {
                for (int j = 0; j < arraySecond.GetLength(1); j++)
                {
                    Console.Write($"{arraySecond[i, j] = Math.Round(randomizing.NextDouble(), ROUNDING_AFTER_DECIMAL_POINT)}\t");
                }
                Console.WriteLine();
            }

            double maxElementOfFisrtArray = arrayFirst.Max();
            double minElementOfFisrtArray = arrayFirst.Min();
            double maxElementOfSecondArray = arraySecond.Cast<double>().Max();
            double minElementOfSecondArray = arraySecond.Cast<double>().Min();

            double theMaxElement = maxElementOfFisrtArray; 
            double theMinElement = minElementOfFisrtArray;

            if(maxElementOfFisrtArray < maxElementOfSecondArray)
            {
                theMaxElement = maxElementOfSecondArray;
            }
            if(minElementOfFisrtArray > minElementOfSecondArray)
            {
                theMinElement = minElementOfSecondArray;
            }

            Console.WriteLine("\nИнформация о приведенных выше массивах:");

            Console.WriteLine($"Общий максимальный элемент: {theMaxElement}");
            Console.WriteLine($"Общий минимальный элемент: {theMinElement}");

            double sumElementsOfFirstArray = arrayFirst.Sum();
            double sumElementsOfSecondArray = arraySecond.Cast<double>().Sum();

            Console.WriteLine($"Общая сумма всех элементов массивов: {sumElementsOfFirstArray + sumElementsOfSecondArray}");

            double multiplyElementsOfFirstArray = INITIAL_VALUE_FOR_MULTIPLICATION;
            double multiplyElementsOfSecondArray = INITIAL_VALUE_FOR_MULTIPLICATION;

            double sumEvenElementsOfFirstArray = INITIAL_VALUE_FOR_SUM;
            double sumOddColumnsOfSecondArray = INITIAL_VALUE_FOR_SUM;
            double sumOddColumnsElementsOfSecondArray = INITIAL_VALUE_FOR_SUM;

            for (int i = 0; i < arrayFirst.Length; i++)
            {
                multiplyElementsOfFirstArray *= arrayFirst[i];

                if(arrayFirst[i] % FIRST_EVEN_NUMBER == 0)
                {
                    sumEvenElementsOfFirstArray += arrayFirst[i];
                }
            }
            for(int i = 0; i < arraySecond.GetLength(0); i++)
            {
                for(int j = 0; j < arraySecond.GetLength(1); j++)
                {
                    multiplyElementsOfSecondArray *= arraySecond[i, j];

                    if(j % FIRST_EVEN_NUMBER != 0)
                    {
                        if (i % FIRST_EVEN_NUMBER != 0)
                        {
                            sumOddColumnsOfSecondArray += j;
                        }

                        sumOddColumnsElementsOfSecondArray += arraySecond[i, j];
                    }
                }
            }

            Console.WriteLine($"Общее произведение всех элементов массивов: {multiplyElementsOfFirstArray * multiplyElementsOfSecondArray}");

            Console.WriteLine($"Сумма четных элементов первого одномерного массива: {sumEvenElementsOfFirstArray}");
            Console.WriteLine($"Сумма нечетных столбцов второго двумерного массива: {sumOddColumnsOfSecondArray}");
            Console.WriteLine($"Сумма элементов нечетных столбцов второго двумерного массива: {sumOddColumnsElementsOfSecondArray}");

            // 2-задание
            int secondTaskFirstArraySize, secondTaskSecondArraySize, secondTaskThirdArraySize;

            Console.Write("\nВведите размер первого массива: ");
            userStringValue = Console.ReadLine();

            secondTaskFirstArraySize = Convert.ToInt32(userStringValue);

            Console.Write("Введите размер второго массива: ");
            userStringValue = Console.ReadLine();

            secondTaskSecondArraySize = Convert.ToInt32(userStringValue);

            int[] secondTaskFirstArray = new int[secondTaskFirstArraySize];
            int[] secondTaskSecondArray = new int[secondTaskSecondArraySize];

            Console.WriteLine("\nВывод первого массива, заполненного рандомными целочисленными значениями:");
            for(int i = 0; i < secondTaskFirstArray.Length; i++)
            {
                Console.Write($"{secondTaskFirstArray[i] = randomizing.Next(RANGE_NUMBERS_START, RANGE_NUMBERS_END)} ");
            }
            Console.WriteLine("\nВывод второго массива, заполненного рандомными целочисленными значениями:");
            for (int i = 0; i < secondTaskSecondArray.Length; i++)
            {
                Console.Write($"{secondTaskSecondArray[i] = randomizing.Next(RANGE_NUMBERS_START, RANGE_NUMBERS_END)} ");
            }

            int[] noRepeatingsFirstArray = secondTaskFirstArray.Distinct().ToArray();
            int[] noRepeatingsSecondArray = secondTaskSecondArray.Distinct().ToArray();

            secondTaskThirdArraySize = 0;

            for (int i = 0; i < noRepeatingsFirstArray.Length; i++)
            {
                for(int j = 0; j < noRepeatingsSecondArray.Length; j++)
                {
                    if(noRepeatingsFirstArray[i] == noRepeatingsSecondArray[j])
                    {
                        secondTaskThirdArraySize++;
                    }
                }
            }

            int[] secondTaskThirdArray = new int[secondTaskThirdArraySize];

            for (int i = 0, indexOfThirdArray = 0; i < noRepeatingsFirstArray.Length; i++)
            {
                for (int j = 0; j < noRepeatingsSecondArray.Length; j++)
                {
                    if (noRepeatingsFirstArray[i] == noRepeatingsSecondArray[j] && indexOfThirdArray < secondTaskThirdArraySize)
                    {
                        secondTaskThirdArray[indexOfThirdArray++] = noRepeatingsFirstArray[i];
                    }
                }
            }

            Console.WriteLine("\nВывод третьего массива, заполненного общими элементами выше приведенных массивов(без повторений):");
            foreach(int element in secondTaskThirdArray)
            {
                Console.Write($"{element} ");
            }

            // 3-задание
            Console.WriteLine("\n\nПроверка на палиндромность строки:");

            Console.Write("Введите любую строку: ");
            userStringValue = Console.ReadLine();

            string reverseUserStringValue = new string(userStringValue.ToCharArray().Reverse().ToArray());

            Console.WriteLine("Ответ:");
            if(userStringValue == reverseUserStringValue)
            {
                Console.WriteLine("Это строка-палиндром");
            }
            else
            {
                Console.WriteLine("Строка не является палиндромом");
            }

            // 4-задание
            Console.WriteLine("\nПодсчет слов в введенной строке:");

            Console.Write("Введите любую строку: ");
            userStringValue = Console.ReadLine();

            string[] partsOfUserStringValue = userStringValue.Split();

            int countOfPartsOfString = partsOfUserStringValue.Length;

            for(int i = 0; i < partsOfUserStringValue.Length; i++)
            {
                if(partsOfUserStringValue[i] == "")
                {
                    countOfPartsOfString--;
                }
            }

            Console.WriteLine($"Ответ:\nКол-во слов в строке: {countOfPartsOfString}");

            // 5-задание
            Console.WriteLine("\nОпределение суммы элементов массива, находящиеся в диапозоне от минимального до максимального элемента" +
                              "\nСам массив заполнен рандомными значениями от -100 до 100");

            int[,] fifthTaskArray = new int[ARRAY_FIRST_SIZE, ARRAY_FIRST_SIZE];

            Console.WriteLine("\nВывод массива:");
            for(int i = 0; i < fifthTaskArray.GetLength(0); i++)
            {
                for(int j = 0; j < fifthTaskArray.GetLength(1); j++)
                {
                    Console.Write($"{fifthTaskArray[i, j] = randomizing.Next(FIFTH_TASK_RANGE_NUMBERS_START, FIFTH_TASK_RANGE_NUMBERS_END)}\t");
                }
                Console.WriteLine();
            }

            int[] fifthTaskTemporaryArray = new int[ARRAY_FIRST_SIZE * ARRAY_FIRST_SIZE];

            fifthTaskTemporaryArray = fifthTaskArray.Cast<int>().ToArray();

            int fifthTaskArrayMax = fifthTaskTemporaryArray.Max();
            int fifthTaskArrayMin = fifthTaskTemporaryArray.Min();

            Console.WriteLine($"\nМаксимальный элемент массива = {fifthTaskArrayMax}");
            Console.WriteLine($"Минимальный элемент массива = {fifthTaskArrayMin}");

            int indexOfMaxElement = Array.IndexOf(fifthTaskTemporaryArray, fifthTaskArrayMax);
            int indexOfMinElement = Array.IndexOf(fifthTaskTemporaryArray, fifthTaskArrayMin);

            int sumRangeElements = INITIAL_VALUE_FOR_SUM;

            int startRangeIndex = indexOfMinElement, endRangeIndex = indexOfMaxElement;

            if(indexOfMaxElement < indexOfMinElement)
            {
                startRangeIndex = indexOfMaxElement;
            }
            if(indexOfMinElement > indexOfMaxElement)
            {
                endRangeIndex = indexOfMinElement;
            }

            for(int i = startRangeIndex; i <= endRangeIndex; i++)
            {
                sumRangeElements += fifthTaskTemporaryArray[i];
            }

            Console.WriteLine($"\nОтвет:\nСумма элементов в данном диапозоне равна {sumRangeElements}");

            Console.ReadKey();
        }
    }
}
