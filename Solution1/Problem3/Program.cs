using System;
/*
а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле 
r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).
Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.

Селютин Александр
*/

namespace Problem3 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter x1");
            var x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter y1");
            var y1 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter x2");
            var x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter y2");
            var y2 = double.Parse(Console.ReadLine());

            var distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"Distance between points (x1, y1) and (x2, y2) is {distance:f2}");

            var methodDistance = CalculateDistance(x1, y1, x2, y2);
            Console.WriteLine($"Distance between points (x1, y1) and (x2, y2) is {methodDistance:f2}");
        }
    
        static double CalculateDistance(double x1, double y1, double x2, double y2) {
            var firstPart = Math.Pow(x2 - x1, 2);
            var secondPart = Math.Pow(y2 - y1, 2);
            return Math.Sqrt(firstPart + secondPart);
        }
    }
}

