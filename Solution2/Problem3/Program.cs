/*
С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.

Селютин Александр
*/

using System;

namespace Problem3 {
    internal class Program {
        public static void Main(string[] args) {
            int sumOddNumbers = 0;

            while (true) {
                Console.WriteLine("Enter number. Enter 0 to stop program");
                var number = int.Parse(Console.ReadLine());
                if (isZero(number)) {
                    break;
                }
                if (isEven(number)) {
                    continue;
                }
                if (isNegative(number)) {
                    continue;
                }
                
                sumOddNumbers += number;
            }
            
            Console.WriteLine($"Sum of odd numbers is {sumOddNumbers}");
        }

        public static bool isZero(int number) {
            return number == 0;
        }

        public static bool isEven(int number) {
            return number % 2 == 0;
        }
        public static bool isNegative(int number) {
            return number < 0;
        }
    }
}