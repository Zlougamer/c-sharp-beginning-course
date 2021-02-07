/*
2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.

а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке
 находить минимум.
б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она
возвращает минимум через параметр.

Селютин Александр
*/

using System;
using System.IO;

namespace Problem2 {
    public delegate double Func(double x);

    internal class Program {
        public static double FirstFunc(double x) {
            return x * x - 50 * x + 10;
        }

        public static double SecondFunc(double x) {
            return 13 * Math.Pow(x, 2);
        }

        public static double ThirdFunc(double x) {
            return 7 * Math.Sin(x);
        }

        public static double ForthFunc(double x) {
            return 4.5 * Math.Atan(x) + Math.Ceiling(x) + 6;
        }

        public static double FifthFunc(double x) {
            return 0.6 * Math.Atan2(Math.Exp(x), Math.Cosh(x)) + 4;
        }

        public static readonly Func[] Functions = { FirstFunc, SecondFunc, ThirdFunc, ForthFunc, FifthFunc};
        public static void SaveFunc(string fileName, Func func, double a, double b, double h) {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b) {
                bw.Write(func(x));
                x += h;
            }

            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double min) {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            var arraySize = (int) (fs.Length / sizeof(double));
            double[] values = new double[arraySize];
            double value;
            for(int i = 0; i < arraySize; i++) {
                value = bw.ReadDouble();
                values[i] = value;
                if (value < min) {
                    min = value;
                }
            }
            bw.Close();
            fs.Close();

            return values;
        }
        
        static void Main(string[] args) {
            Console.WriteLine("Choose function which you prefer to use");
            Console.WriteLine("0) x * x - 50 * x + 10");
            Console.WriteLine("1) 13 * x^2");
            Console.WriteLine("2) 7 * sin(x)");
            Console.WriteLine("3) 4.5 * Atan(x) + Ceiling(x) + 6");
            Console.WriteLine("4) 0.6 * Atan2(Exp(x), Cosh(x)) + 4");
            int funcIndex = int.Parse(Console.ReadLine());
            if (funcIndex < 0 || funcIndex > Functions.Length) {
                Console.WriteLine("Incorrect index! Please, enter the correct one!");
                return;
            }
            
            Console.WriteLine("Enter left end of segment");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter right end of segment");
            var b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter step");
            var h = double.Parse(Console.ReadLine());

            SaveFunc("../../../data.bin", Functions[funcIndex],a, b, h);
            double min;
            var values = Load("../../../data.bin", out min);
            Console.WriteLine("Function values");
            foreach (var value in values) {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Minimal value: {min}");
        }
    }
}