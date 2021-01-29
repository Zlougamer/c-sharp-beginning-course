/*
а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
Требуется подсчитать сумму всех нечетных положительных чисел.
Сами числа и сумму вывести на экран, используя tryParse;

б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
При возникновении ошибки вывести сообщение.
Напишите соответствующую функцию;

Селютин Алесандр 
*/

using System;

namespace Problem2 {
    internal class Program {
        public static void Main(string[] args) {

            int sum = 0;
            while (true) {
                Console.WriteLine("Enter a number. Enter zero to exit loop.");
                int num;
                if (!TryGetNumber(out num)) {
                    continue;
                }

                if (num == 0) {
                    break;
                }

                if (num % 2 == 1 && num > 0) {
                    Console.WriteLine($"Number {num} is odd and positive. Add it to sum");
                    sum += num;
                }
            }
            Console.WriteLine($"Sum of positive odd numbers is {sum}");
        }

        private static bool TryGetNumber(out int num) {
            var value = Console.ReadLine();
            num = -1;
            var flag = int.TryParse(value, out num);
            if (!flag) {
                Console.WriteLine($"Value '{value}' can not be converted to int. Please try again");
                return false; 
            }
            return true;
        }
    }
}