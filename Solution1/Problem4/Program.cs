using System;
/*
Написать программу обмена значениями двух переменных:
а) с использованием третьей переменной;
б) *без использования третьей переменной.

Селютин Александр
*/

namespace Problem4 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter first number");
            var firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            var secondNumber = int.Parse(Console.ReadLine());

            var intermediateVar = firstNumber;
            firstNumber = secondNumber;
            secondNumber = intermediateVar;
            
            Console.WriteLine("After exchange, with extra var");
            Console.WriteLine($"First number: {firstNumber}, second number: {secondNumber}");
            
            firstNumber = firstNumber + secondNumber;
            secondNumber = firstNumber - secondNumber;
            firstNumber = firstNumber - secondNumber;
            
            Console.WriteLine("After exchange, without extra var");
            Console.WriteLine($"First number: {firstNumber}, second number: {secondNumber}");
        }
    }
}

