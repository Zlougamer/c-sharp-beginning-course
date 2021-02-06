/*
1. Создать программу, которая будет проверять корректность ввода логина.
Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры,
при этом цифра не может быть первой:

а) без использования регулярных выражений;
б) с использованием регулярных выражений.

Селютин Александр
*/

using System;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace Problem1 {
    internal class Program {
        public static void Main(string[] args) {
            var login = GetLogin();

            bool isCorrect;
            isCorrect = IsLoginCorrect(login);
            if (isCorrect) {
                Console.WriteLine($"Login {login} is correct!");
            } else {
                Console.WriteLine($"Login {login} is not correct...");
            }

            isCorrect = IsLoginCorrectWithRegex(login);
            if (isCorrect) {
                Console.WriteLine($"Login {login} is correct!");
            } else {
                Console.WriteLine($"Login {login} is not correct...");
            }
        }

        public static string GetLogin() {
            Console.WriteLine("Enter login");
            return Console.ReadLine();
        }

        public static bool IsLoginCorrect(string login) {
            var length = login.Length;
            if (length < 2 || length > 10) {
                return false;
            }

            foreach (var symbol in login) {
                if (!(char.IsDigit(symbol) || char.IsLetter(symbol))) {
                    return false;
                }
            }

            if (char.IsDigit(login[0])) {
                return false;
            }
            return true;
        }

        public static bool IsLoginCorrectWithRegex(string login) {
            string template = "^[a-zA-Z][0-9a-zA-Z]{1,9}$";
            Regex regex = new Regex(template);
            return regex.IsMatch(login);
        }
    }
}