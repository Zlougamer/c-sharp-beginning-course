using System;
/*
Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); 
где m — масса тела в килограммах, h — рост в метрах.

Селютин Александр
*/

namespace Problem2 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter you height in meters");
            var height = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter you weight in kilogram");
            var weight = float.Parse(Console.ReadLine());

            var bodyMassIndex = weight * 1.0 / (height * height);
            
            Console.WriteLine($"Your Body Mass Index is {bodyMassIndex}");
        }
    }
}

