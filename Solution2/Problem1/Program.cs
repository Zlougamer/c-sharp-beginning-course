/*
Написать метод, возвращающий минимальное из трёх чисел.

Селютин Александр
*/

using System;
using System.Security.Policy;

namespace Problem1 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter first number");
            var first = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter second number");
            var second = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter third number");
            var third = int.Parse(Console.ReadLine());
            
            Console.Write("Minimal number is ");
            Console.WriteLine(GetMin(first, second, third));
        }

        public static int GetMin(int first, int second, int third) {
            var min = first;
            if(min > second) {
                min = second;
            }
            if(min > third) {
                min = third;
            }
            return min;
        }
    }
}