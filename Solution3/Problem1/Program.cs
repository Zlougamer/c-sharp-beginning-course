/*
а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
в) Добавить диалог с использованием switch демонстрирующий работу класса.

Селютин Александр
*/

using System;

namespace Solution3 {

    struct ComplexStruct {
        public double re;
        public double im;

        public ComplexStruct(double re, double im) {
            this.re = re;
            this.im = im;
        }

        public override string ToString() {
            return $"{this.re} + {this.im}i";
        }

        public ComplexStruct Plus(ComplexStruct arg) {
            ComplexStruct result;
            result.re = this.re + arg.re;
            result.im = this.im + arg.im;
            return result;
        }

        public ComplexStruct Minus(ComplexStruct arg) {
            ComplexStruct result;
            result.re = this.re - arg.re;
            result.im = this.im - arg.im;
            return result;
        }

        public ComplexStruct Mult(ComplexStruct arg) {
            ComplexStruct result;
            result.re = this.re * arg.re - this.im * arg.im;
            result.im = this.re * arg.im + this.im * arg.re;
            return result;
        }
    }
    
    class ComplexClass {
        private double re;
        private double im;

        public ComplexClass(double re, double im) {
            this.re = re;
            this.im = im;
        }

        public ComplexClass() {
            this.re = 0;
            this.im = 0;
        }

        public override string ToString() {
            return $"{this.re} + {this.im}i";
        }

        public double Im {
            get => im;
        }

        public double Re {
            get => re;
        }

        public ComplexClass Plus(ComplexClass arg) {
            var reVal = this.re + arg.Re;
            var imVal = this.im + arg.Im;
            return new ComplexClass(reVal, imVal);
        }

        public ComplexClass Minus(ComplexClass arg) {
            var reVal = this.re - arg.Re;
            var imVal = this.im - arg.Im;
            return new ComplexClass(reVal, imVal);
        }

        public ComplexClass Mult(ComplexClass arg) {
            var reVal = this.re * arg.Re - this.im * arg.Im;
            var imVal = this.re * arg.Im + this.im * arg.Re;
            return new ComplexClass(reVal, imVal);
        }
    }
    
    
    internal class Program {
        public static void Main(string[] args) {
            ShowWorkForComplexStruct();
            ShowWorkForComplexClass();
            DemonstrateComplexClass();
        }

        public static void ShowWorkForComplexStruct() {
            Console.WriteLine("Show work of ComplexStruct");
            ComplexStruct firstStruct;
            firstStruct.re = 14;
            firstStruct.im = 23;
            ComplexStruct secondStruct = new ComplexStruct(34, 57);
            ComplexStruct result;
            
            Console.WriteLine($"First example of ComplexStruct: {firstStruct}");
            Console.WriteLine($"Second example of ComplexStruct: {secondStruct}");

            result = firstStruct.Plus(secondStruct);
            Console.WriteLine($"Sum of first and second examples: {result}");

            result = firstStruct.Minus(secondStruct);
            Console.WriteLine($"Sub of first and second examples: {result}");

            result = firstStruct.Mult(secondStruct);
            Console.WriteLine($"Mult of first and second examples: {result}");
            
            Console.WriteLine();
        }

        public static void ShowWorkForComplexClass() {
            Console.WriteLine("Show work of ComplexClass");
            ComplexClass firstClass = new ComplexClass(14, 23);
            ComplexClass secondClass = new ComplexClass(34, 57);
            ComplexClass result;
            
            Console.WriteLine($"First example of ComplexClass: {firstClass}");
            Console.WriteLine($"Second example of ComplexClass: {secondClass}");

            result = firstClass.Plus(secondClass);
            Console.WriteLine($"Sum of first and second examples: {result}");

            result = firstClass.Minus(secondClass);
            Console.WriteLine($"Sub of first and second examples: {result}");

            result = firstClass.Mult(secondClass);
            Console.WriteLine($"Mult of first and second examples: {result}");
            
            Console.WriteLine();
        }

        public static void DemonstrateComplexClass() {
            ComplexClass firstClass = new ComplexClass();
            ComplexClass secondClass = new ComplexClass();
            double real;
            double image;
            
            while (true) {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"First complex number: {firstClass}");
                Console.WriteLine($"Second complex number: {secondClass}");
                Console.WriteLine("Insert number to produce some action");
                Console.WriteLine("1) Set first number");
                Console.WriteLine("2) Set second number");
                Console.WriteLine("3) Get sum of first and second numbers");
                Console.WriteLine("4) Get subtract of first and second numbers");
                Console.WriteLine("5) Get multiplication of first and second numbers");
                Console.WriteLine("6) Exit");
                Console.WriteLine();

                var key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (key) {
                    case '1':
                        Console.WriteLine("Insert real part");
                        real = double.Parse(Console.ReadLine());
                        Console.WriteLine("Insert image part");
                        image = double.Parse(Console.ReadLine());
                        firstClass = new ComplexClass(real, image);
                        break;
                    case '2':
                        Console.WriteLine("Insert real part");
                        real = double.Parse(Console.ReadLine());
                        Console.WriteLine("Insert image part");
                        image = double.Parse(Console.ReadLine());
                        secondClass = new ComplexClass(real, image);
                        break;
                    case '3':
                        Console.WriteLine($"Sum of {firstClass} and {secondClass} is");
                        Console.WriteLine(firstClass.Plus(secondClass));
                        break;
                    case '4':
                        Console.WriteLine($"Sub of {firstClass} and {secondClass} is");
                        Console.WriteLine(firstClass.Minus(secondClass));
                        break;
                    case '5':
                        Console.WriteLine($"Mult of {firstClass} and {secondClass} is");
                        Console.WriteLine(firstClass.Mult(secondClass));
                        break;
                    case '6':
                        Console.WriteLine("Exit program");
                        return;
                    default:
                        Console.WriteLine("You inserted wrong value");
                        Console.WriteLine("Please try again");
                        break;
                }
            }
        }
    }
}