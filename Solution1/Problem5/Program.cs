using System;
/*
а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
б) *Сделать задание, только вывод организовать в центре экрана.
в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).

Селютин Александр
*/

namespace Problem5 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter your first name");
            var firstName = Console.ReadLine();
            
            Console.WriteLine("Enter your second name");
            var secondName = Console.ReadLine();
            
            Console.WriteLine("Enter your city");
            var city = Console.ReadLine();
            
            var firstNameStr = $"Your first name: {firstName}";
            var secondNameStr = $"Your second name: {secondName}";
            var cityStr = $"Your city: {city}";
            
            Console.WriteLine("Print your info in ordinary way");
            Console.WriteLine(firstNameStr);
            Console.WriteLine(secondNameStr);
            Console.WriteLine(cityStr);
            
            Console.WriteLine("Print your info in center");
            Console.SetCursorPosition((Console.WindowWidth - firstNameStr.Length) / 2, Console.CursorTop);
            Console.WriteLine($"Your first name: {firstName}");
            Console.SetCursorPosition((Console.WindowWidth - secondNameStr.Length) / 2, Console.CursorTop);
            Console.WriteLine($"Your second name: {secondName}");
            Console.SetCursorPosition((Console.WindowWidth - cityStr.Length) / 2, Console.CursorTop);
            Console.WriteLine($"Your city: {city}");
            
            Console.WriteLine("Print your info in center with methods");
            CenterPrint(firstNameStr);
            CenterPrint(secondNameStr);
            CenterPrint(cityStr);
        }

        static void CenterPrint(string msg) {
            var left = (Console.WindowWidth - msg.Length) / 2;
            var top = Console.CursorTop;
            Print(msg, left, top);
        }

        static void Print(string msg, int left, int top) {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(msg);
        }
    }
}

