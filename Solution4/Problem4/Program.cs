/*
Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
Создайте структуру Account, содержащую Login и Password.

Селютин Александр
*/

using System;
using System.IO;

namespace Problem4 {
    public struct Account {
        public string Login;
        public string Password;

        public Account(string login, string password) {
            this.Login = login;
            this.Password = password;
        }
    }

    public class AccountStorage {
        private Account[] accounts;

        public AccountStorage(string filename) {
            if (!File.Exists(filename)) {
                Console.WriteLine($"File {filename} does not exist!!");
                accounts = new Account[0];
                return;
            }
            StreamReader reader = new StreamReader(filename);
            int length = int.Parse(reader.ReadLine());
            accounts = new Account[length];
            for (int i = 0; i < length; i++) {
                var entry = reader.ReadLine();
                string[] subStrings = entry.Split(' ');
                if (subStrings.Length != 2) {
                    Console.WriteLine($"Line '{entry}' does not comform to pattern 'login password'. Skip it.");
                    continue;
                }
                var login = subStrings[0];
                var password = subStrings[1];
                accounts[i] = new Account(login, password);
            }
            reader.Close();
        }

        public bool CheckLoginNPassword(string login, string password) {
            foreach (var entry in accounts) {
                if (login == entry.Login && password == entry.Password) {
                    return true;
                }
            }
            return false;
        }
    }
    
    internal class Program {
        public static int MAX_ATTEMPTS = 3;
        
        public static void Main(string[] args) {
            AccountStorage storage = new AccountStorage("../../../account_data.txt");
            int attempt = 0;

            do {
                Console.WriteLine("Enter login");
                var login = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();
                if (storage.CheckLoginNPassword(login, password)) {
                    Console.WriteLine("Your login and password are correct!");
                    break;
                } else {
                    attempt++;
                    Console.WriteLine("You inserted incorrect login and/or password.");
                    var additionalAttempts = MAX_ATTEMPTS - attempt;
                    Console.WriteLine($"Please, try again. You have {additionalAttempts} attempts");
                }
            } while (attempt < MAX_ATTEMPTS);

            if (attempt == MAX_ATTEMPTS) {
                Console.WriteLine("You exceeded the number of attempts");
            }
        }
    }
}
