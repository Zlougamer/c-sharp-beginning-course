/*
Написать метод подсчета количества цифр числа.

Селютин Александр
*/

using System;

namespace Problem2 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter number");
            var number = ulong.Parse(Console.ReadLine());

            var digitsNumber = GetDigitsNumber(number);
            Console.Write($"Number {number} consists of digits {digitsNumber}");
        }

        public static int GetDigitsNumber(ulong number) {
            var digitsNumber = 0;

            while (true) {
                number /= 10;
                digitsNumber++;
                if (number == 0) {
                    break;
                }
            }
            return digitsNumber;
        }
    }
}
