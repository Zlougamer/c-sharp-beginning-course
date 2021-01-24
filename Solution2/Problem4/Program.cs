/*
Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.

Селютин Александр
*/

using System;

namespace Problem4 {
    internal class Program {
        private static string Login = "root";
        private static string Password = "GeekBrains";
        private static int MaxAttempts = 3;
        
        public static void Main(string[] args) {
            int attempts = 0;

            do {
                Console.WriteLine();
                Console.WriteLine("Enter your login");
                string login = Console.ReadLine();
                
                Console.WriteLine("Enter your password");
                string password = Console.ReadLine();

                if (isAuthorizationPassed(login, password)) {
                    Console.WriteLine("Your login and passward are correct!");
                    break;
                }
                
                attempts++;
                Console.WriteLine("You entered incorrect login and/or password.");
                Console.WriteLine($"You have {MaxAttempts - attempts} attempts");
            } while (attempts < MaxAttempts);

            if (attempts == MaxAttempts) {
                Console.WriteLine();
                Console.WriteLine("You exhausted number of attempts");
            }
        }

        public static bool isAuthorizationPassed(string login, string password) {
            return login == Login && password == Password;
        }
    }
}