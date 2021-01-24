/*
*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
«Хорошим» называется число, которое делится на сумму своих цифр.
Реализовать подсчёт времени выполнения программы, используя структуру DateTime.

Селютин Александр
*/

using System;

namespace Program6 {
    internal class Program {
        private static ulong MaxNumber = 1000000000;
//        private static ulong MaxNumber = 100;
        private static ulong MinNumber = 1;
        
        public static void Main(string[] args) {
            int goodNumbersCounter = 0;
            
            Console.WriteLine(
                $"Start to count good numbers from {MinNumber} to {MaxNumber}"
            );
            var startTime = DateTime.Now;

            for (ulong i = MinNumber; i < MaxNumber; i++) {
                if (isGoodNumber(i)) {
                    goodNumbersCounter++;
                }
            }

            var finishTime = DateTime.Now;
            Console.WriteLine(
                $"Number of \"good\" numbers from {MinNumber} to {MaxNumber} is {goodNumbersCounter}"
            );
            var delta = finishTime - startTime;
            Console.WriteLine($"Elapsed time is {delta}");
        }

        public static bool isGoodNumber(ulong number) {
            var sumDigits = calculateDigitsSum(number);
            return number % sumDigits == 0;
        }

        public static ulong calculateDigitsSum(ulong number) {
            ulong digitsSum = 0;

            while (true) {
                var digit = number % 10;
                number /= 10;
                digitsSum += digit;
                if (number == 0) {
                    break;
                }
            }

            return digitsSum;
        }
    }
}