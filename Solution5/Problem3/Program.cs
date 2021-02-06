/*
3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
Регистр можно не учитывать:

а) с использованием методов C#;
б) *разработав собственный алгоритм.
Например:
badc являются перестановкой abcd.

Селютин Александр
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter first string");
            var firstString = Console.ReadLine();
            Console.WriteLine("Enter second string");
            var secondString = Console.ReadLine();
            
            Console.WriteLine("Is the first string is permutation of second string");
            Console.WriteLine("Check it with C# functions");
            Console.WriteLine(IsPermutationCSharp(firstString, secondString));

            Console.WriteLine("Check it with own algorithm");
            Console.WriteLine(IsPermutationOwnAlgo(firstString, secondString));

        }

        public static bool IsPermutationCSharp(string firstString, string secondString) {
            var firstArr = SortLowerString(firstString);
            var secondArr = SortLowerString(secondString);

            if (firstArr.Length != secondArr.Length) {
                return false;
            }
            
            for (int i = 0; i < firstArr.Length; i++) {
                if (firstArr[i] != secondArr[i]) {
                    return false;
                }
            }
            return true;
        }

        public static char[] SortLowerString(string input) {
            char[] characters = input.ToLower().ToArray();
            Array.Sort(characters);
            return characters;
        }

        public static bool IsPermutationOwnAlgo(string firstString, string secondString) {
            var firstLowerStr = firstString.ToLower();
            var secondLowerStr = secondString.ToLower();

            var freqDict = new Dictionary<char, int>();
            foreach (var symbol in firstLowerStr) {
                if (!freqDict.ContainsKey(symbol)) {
                    freqDict[symbol] = 0;
                }

                freqDict[symbol] += 1;
            }
            foreach (var symbol in secondLowerStr) {
                if (!freqDict.ContainsKey(symbol)) {
                    return false;
                }

                if (freqDict[symbol] == 0) {
                    return false;
                }

                freqDict[symbol] -= 1;
            }

            foreach (var value in freqDict.Values) {
                if (value != 0) {
                    return false;
                }
            }
            
            return true;
        }
    }
}