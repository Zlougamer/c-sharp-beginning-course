/*
Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
в)**Добавьте обработку ситуации отсутствия файла на диске.

Селютин Александр
*/
using System;
using System.IO;

namespace Problem2 {
    static class StaticClass {
        private static int DIVISOR = 3;

        public static int CountOnlyOneDivizionFromPair(int[] array) {
            var counter = 0;
            for (int i = 1; i < array.Length; i++) {
                var firstNum = array[i - 1];
                var secondNum = array[i];

                var isFirstNumDivisible = firstNum % DIVISOR == 0;
                var isSecondNumDivisible = secondNum % DIVISOR == 0;
                if (
                    (isFirstNumDivisible || isSecondNumDivisible) && 
                    !(isFirstNumDivisible && isSecondNumDivisible)
                ) {
                    counter++;
                }
            }
            return counter;
        }

        public static int CountAtLeastOneDivizionFromPair(int[] array) {
            var counter = 0;
            for (int i = 1; i < array.Length; i++) {
                var firstNum = array[i - 1];
                var secondNum = array[i];
                
                var isFirstNumDivisible = firstNum % DIVISOR == 0;
                var isSecondNumDivisible = secondNum % DIVISOR == 0;
                if (isFirstNumDivisible || isSecondNumDivisible) {
                    counter++;
                }
            }

            return counter;
        }

        public static int[] ReadArrayFromFile(string filename) {
            if (!File.Exists(filename)) {
                Console.WriteLine($"File '{filename}' does not exist! Please, read array from existing file!");
                return new int[0];
            }
            StreamReader reader = new StreamReader(filename);
            int length = int.Parse(reader.ReadLine());
            var array = new int[length];
            for (int i = 0; i < length; i++) {
                array[i] = int.Parse(reader.ReadLine());
            }
            reader.Close();
            return array;
        }
    }
    
    internal class Program {
        public static void Main(string[] args) {
            int[] array = StaticClass.ReadArrayFromFile("../../../array_file.txt");
            PrintArray(array);

            int onlyOneDivizion = StaticClass.CountOnlyOneDivizionFromPair(array);
            Console.WriteLine($"Number of consequent pairs where only one number could be divided");
            Console.WriteLine(onlyOneDivizion);
            
            int atLeastOneDivizion = StaticClass.CountAtLeastOneDivizionFromPair(array);
            Console.WriteLine($"Number of consequent pairs where at least one number could be divided");
            Console.WriteLine(atLeastOneDivizion);

        }
        
        public static void PrintArray(int[] array) {
            Console.WriteLine("Print array");
            foreach (var el in array) {
                Console.Write($"{el} ");
            }
            Console.WriteLine("\n");
        }
    }
}