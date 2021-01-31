/*
а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив заданной размерности и 
заполняющий массив числами от начального значения с заданным шагом. 
Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, 
меняющий знаки у всех элементов массива, метод Multi, 
умножающий каждый элемент массива на определенное число, свойство MaxCount, 
возвращающее количество максимальных элементов. 
В Main продемонстрировать работу класса.

б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)

Селютин Александр
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Problem3 {
    class CustomArray {
        private int[] array;

        public CustomArray(int size, int startingVal, int step) {
            array = new int[size];
            for (int i = 0; i < size; i++) {
                array[i] = startingVal + i * step;
            }
        }

        public CustomArray(string filename) {
            if (!File.Exists(filename)) {
                Console.WriteLine($"File {filename} does not exist!!");
                array = new int[0];
                return;
            }
            StreamReader reader = new StreamReader(filename);
            int length = int.Parse(reader.ReadLine());
            array = new int[length];
            for (int i = 0; i < length; i++) {
                array[i] = int.Parse(reader.ReadLine());
            }
            reader.Close();
        }

        public void WriteArrayToFile(string filename) {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(array.Length);
            for (int i = 0; i < array.Length; i++) {
                writer.WriteLine(array[i]);
            }
            writer.Close();
        }

        public void ReadArrayFromFile(string filename) {
            if (!File.Exists(filename)) {
                Console.WriteLine($"File {filename} does not exist!!");
                return;
            }
            StreamReader reader = new StreamReader(filename);
            int length = int.Parse(reader.ReadLine());
            array = new int[length];
            for (int i = 0; i < length; i++) {
                array[i] = int.Parse(reader.ReadLine());
            }
            reader.Close();
        }

        public int Sum {
            get {
                int sum = 0;
                foreach (var el in array) {
                    sum += el;
                }

                return sum;
            }
        }

        public void Inverse() {
            for (int i = 0; i < array.Length; i++) {
                array[i] *= -1;
            }
        }

        public void Mult(int number) {
            for (int i = 0; i < array.Length; i++) {
                array[i] *= number;
            }
        }

        public int MaxCount {
            get {
                if (array.Length == 0) {
                    return 0;
                }

                int max = array[0];
                foreach (var el in array) {
                    if (max < el) {
                        max = el;
                    }
                }

                int maxCount = 0;
                foreach (var el in array) {
                    if (el == max) {
                        maxCount++;
                    }
                }

                return maxCount;
            }
        }

        public int this[int i] {
            get { return array[i]; }
            set { array[i] = value; }
        }

        public int Length {
            get { return array.Length; }
        }

        public Dictionary<int, int> CountElementsFrequency() {
            Dictionary<int, int> freqDict = new Dictionary<int, int>();

            foreach (var el in array) {
                freqDict[el] = 0;
            }

            foreach (var el in array) {
                freqDict[el]++;
            }

            return freqDict;
        }
    }

    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Demonstrate work with array!");
            CustomArray arr = new CustomArray(10, 4, 7);
            
            Console.WriteLine("Print initial array");
            PrintArray(arr);
            
            Console.WriteLine("Print Sum");
            Console.WriteLine(arr.Sum);
            
            Console.WriteLine("Print Inversed array");
            arr.Inverse();
            PrintArray(arr);
            
            Console.WriteLine("Print Multiplied by 4 array");
            arr.Mult(4);
            PrintArray(arr);

            Console.WriteLine("Print Max count for array"); ;
            Console.WriteLine(arr.MaxCount);
            
            Console.WriteLine();

            string filename = "../../../array_file.txt";
            Console.WriteLine($"Read array from filename '{filename}'");
            CustomArray newArray = new CustomArray(filename);
            PrintArray(newArray);
            
            Console.WriteLine("Print Multiplied by -3 array");
            newArray.Mult(-3);
            PrintArray(newArray);

            string writeFile = "../../../other_array_file.txt";
            Console.WriteLine($"Write new array to file {writeFile}\n");
            newArray.WriteArrayToFile(writeFile);

            Console.WriteLine($"Read data from file {writeFile} to initial array");
            arr.ReadArrayFromFile(writeFile);
            PrintArray(arr);

            Console.WriteLine($"Get frequency dict for array");
            var freqDict = arr.CountElementsFrequency();
            PrintDict(freqDict);
        }

        public static void PrintArray(CustomArray array) {
            Console.WriteLine("Print array");
            for (int i = 0; i < array.Length; i++) {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine("\n");
        }

        public static void PrintDict(Dictionary<int, int> dict) {
            foreach (var entry in dict) {
                Console.Write($"({entry.Key}: {entry.Value}) ");
            }
            Console.WriteLine();
        }
    }
}