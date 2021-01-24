/*
a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.

Селютин Александр
*/

using System;

namespace Program7 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Get first number");
            int firstNumber = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Get second number");
            int secondNumber = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Print numbers from {firstNumber} to {secondNumber}");
            PrintNumbers(firstNumber, secondNumber);

            Console.WriteLine($"Print sum of numbers from {firstNumber} to {secondNumber}");
            var sum = GetSumNumbers(firstNumber, secondNumber);
            Console.WriteLine(sum);
        }

        public static void PrintNumbers(int firstNumber, int secondNumber) {
            if (firstNumber > secondNumber) {
                Console.WriteLine();
                return;
            }
            Console.Write(firstNumber + " ");
            PrintNumbers(firstNumber + 1, secondNumber);
        }

        public static int GetSumNumbers(int firstNumber, int secondNumber) {
            if (firstNumber > secondNumber) {
                return 0;
            }
            return firstNumber + GetSumNumbers(firstNumber + 1, secondNumber);
        }
    }
}