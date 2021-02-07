/*
1. Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

Селютин Александр
*/

using System;

namespace Problem1 {
    public delegate double Func(double a, double x);
    
    internal class Program {
        public static void Table(Func func, double x, double a, double b) {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b) {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, func(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double FirstFunc(double a, double x) {
            return a * Math.Pow(x, 2);
        }

        public static double SecondFunc(double a, double x) {
            return a * Math.Sin(x);
        }
        
        public static void Main(string[] args) {
            var x = -5;
            var a = 3;
            var b = 7;
            Console.WriteLine("Table for function a*x^2");
            Console.WriteLine($"x = {x}, a = {a}, b = {b}");
            Table(FirstFunc, x, a, b);
            Console.WriteLine("Table for function a*sin(x)");
            Console.WriteLine($"x = {x}, a = {a}, b = {b}");
            Table(SecondFunc, x, a, b);
        }
    }
}