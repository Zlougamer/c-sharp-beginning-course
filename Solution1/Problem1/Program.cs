using System;
/*
Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). 
В результате вся информация выводится в одну строчку:
а) используя  склеивание;
б) используя форматированный вывод;
в) используя вывод со знаком $

Селютин Александр
*/

namespace Problem1 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter your first name");
            var firstName = Console.ReadLine();
            
            Console.WriteLine("Enter your second name");
            var secondName = Console.ReadLine();
            
            Console.WriteLine("Enter your age");
            var age = Console.ReadLine();
            
            Console.WriteLine("Enter your height");
            var height = Console.ReadLine();
            
            Console.WriteLine("Enter your weight");
            var weight = Console.ReadLine();
            
            Console.WriteLine("Your info:");
            var gluingInfo = firstName + " " + 
                                secondName + " " + 
                                age + " " + 
                                height + " " + 
                                weight + " ";
            Console.WriteLine(gluingInfo);
            Console.WriteLine("{0} {1} {2} {3} {4}", firstName, secondName, age, height, weight);
            Console.WriteLine($"{firstName} {secondName} {age} {height} {weight}");
        }
    }
}
