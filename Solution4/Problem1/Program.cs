/*
Дан  целочисленный  массив  из 20 элементов. 
Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно.
Заполнить случайными числами.
Написать программу, позволяющую найти и вывести количество пар элементов массива,
в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
Написать программу, позволяющую найти и вывести количество пар элементов массива,
в которых хотя бы одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.

Селютин Александр
*/

using System;

namespace Program1 {
    internal class Program {
        private static int ARR_LEN = 8;
        private static int MIN_NUM = -10000;
        private static int MAX_NUM = 10000;
        private static int DIVISOR = 3;
        
        public static void Main(string[] args) {
            int[] array = InitArray();
            PrintArray(array);

            int onlyOneDivizion = CountOnlyOneDivizionFromPair(array, DIVISOR);
            Console.WriteLine($"Number of consequent pairs where only one number could be divided by {DIVISOR}");
            Console.WriteLine(onlyOneDivizion);
            
            int atLeastOneDivizion = CountAtLeastOneDivizionFromPair(array, DIVISOR);
            Console.WriteLine($"Number of consequent pairs where at least one number could be devided by {DIVISOR}");
            Console.WriteLine(atLeastOneDivizion);
        }

        public static int[] InitArray() {
            Console.WriteLine("Initialize array with random numbers.");
            Console.WriteLine($"Array len: {ARR_LEN}, min number: {MIN_NUM}, max number: {MAX_NUM}.\n");
            var array = new int[ARR_LEN];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++) {
                array[i] = rand.Next(MIN_NUM, MAX_NUM);
            }
//            int[] array = {2026, -6305, -6906, -6512, 3605, 8205, 2286, -3537};
            return array;
        }

        public static void PrintArray(int[] array) {
            Console.WriteLine("Print array");
            foreach (var el in array) {
                Console.Write($"{el} ");
            }
            Console.WriteLine("\n");
        }

        public static int CountOnlyOneDivizionFromPair(int[] array, int divisor) {
            var counter = 0;
            for (int i = 1; i < array.Length; i++) {
                var firstNum = array[i - 1];
                var secondNum = array[i];

                var isFirstNumDivisible = firstNum % divisor == 0;
                var isSecondNumDivisible = secondNum % divisor == 0;
                if (
                    (isFirstNumDivisible || isSecondNumDivisible) && 
                    !(isFirstNumDivisible && isSecondNumDivisible)
                ) {
                    counter++;
                }
            }
            return counter;
        }

        public static int CountAtLeastOneDivizionFromPair(int[] array, int divisor) {
            var counter = 0;
            for (int i = 1; i < array.Length; i++) {
                var firstNum = array[i - 1];
                var secondNum = array[i];
                
                var isFirstNumDivisible = firstNum % divisor == 0;
                var isSecondNumDivisible = secondNum % divisor == 0;
                if (isFirstNumDivisible || isSecondNumDivisible) {
                    counter++;
                }
            }

            return counter;
        }
    }
    
}