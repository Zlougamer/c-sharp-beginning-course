/*
*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
Предусмотреть методы сложения, вычитания, умножения и деления дробей.
Написать программу, демонстрирующую все разработанные элементы класса.
* Добавить свойства типа int для доступа к числителю и знаменателю;
* Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
** Добавить проверку, чтобы знаменатель не равнялся 0.
Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
*** Добавить упрощение дробей.

Селютин Александр
*/

using System;

namespace Problem3 {

    public class Fraction {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator) {
            if (denominator == 0) {
                throw new ArgumentException("Denominator should not be equal to 0");
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }
        
        public Fraction Add(Fraction arg) {
            int num = this.numerator * arg.denominator + arg.numerator * this.denominator;
            int den = this.denominator * arg.denominator;
            return new Fraction(num, den);
        }

        public Fraction Sub(Fraction arg) {
            int num = this.numerator * arg.denominator - arg.numerator * this.denominator;
            int den = this.denominator * arg.denominator;
            return new Fraction(num, den);
        }

        public Fraction Mult(Fraction arg) {
            int num = this.numerator * arg.numerator;
            int den = this.denominator * arg.denominator;
            return new Fraction(num, den);
        }

        public Fraction Div(Fraction arg) {
            int num = this.numerator * arg.denominator;
            int den = this.denominator * arg.numerator;
            return new Fraction(num, den);
        }

        public int Numerator {
            get => numerator;
            set => numerator = value;
        }
        public int Denominator {
            get => denominator;
            set {
                if (value == 0) {
                    throw new ArgumentException("Denominator should not be equal to 0");
                }
                denominator = value;
            }
        }

        public double Decimal => (double)numerator / denominator;

        public override string ToString() {
            return $"{this.numerator} / {this.denominator}";
        }

        public void Simplify() {
            int gcd = calculateGCD(Math.Abs(this.numerator), Math.Abs(this.denominator));
            this.numerator /= gcd;
            this.denominator /= gcd;

            if (this.denominator < 0) {
                this.denominator *= -1;
                this.numerator *= -1;
            }
        }

        private int calculateGCD(int firstNum, int secondNum) {
            if (firstNum == 0 || secondNum == 0) {
                return 1;
            }
            while (firstNum != secondNum) {
                if (firstNum > secondNum) {
                    firstNum -= secondNum;
                }
                else {
                    secondNum -= firstNum;
                }
            }
            return firstNum;
        }
    }
    
    internal class Program {
        public static void Main(string[] args) {
            Fraction firstFrac = new Fraction(5, 8);
            Fraction secondFrac = new Fraction(7, 19);
            
            Console.WriteLine($"First example fraction: {firstFrac}");
            Console.WriteLine($"Second example fraction: {secondFrac}");

            ShowOperations(firstFrac, secondFrac);
            ShowZeroDenominatorErrors(firstFrac);
            ShowSimplifyFrac();
        }

        public static void ShowOperations(Fraction firstFrac, Fraction secondFrac) {
            Console.WriteLine($"Add first fraction to second: {firstFrac.Add(secondFrac)}");
            Console.WriteLine($"Sub first fraction to second: {firstFrac.Sub(secondFrac)}");
            Console.WriteLine($"Mult first fraction to second: {firstFrac.Mult(secondFrac)}");
            Console.WriteLine($"Div first fraction to second: {firstFrac.Div(secondFrac)}");

            Console.WriteLine($"Decimal of first fraction: {firstFrac.Decimal}");
            Console.WriteLine($"Decimal of second fraction: {secondFrac.Decimal}");
            Console.WriteLine();
        }

        public static void ShowZeroDenominatorErrors(Fraction firstFrac) {
            Console.WriteLine("Try to create a fraction with zero-denominator");
            try {
                new Fraction(1, 0);
            }
            catch (ArgumentException e) {
                Console.WriteLine(e);
            }
            Console.WriteLine("Try to assign denominator to zero");
            try {
                firstFrac.Denominator = 0;
            }
            catch (ArgumentException e) {
                Console.WriteLine(e);
            }
            Console.WriteLine();
        }

        public static void ShowSimplifyFrac() {
            Fraction frac = new Fraction(10, 20);
            Console.WriteLine($"First example fraction before simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"First example fraction after simplification: {frac}");

            frac = new Fraction(0, 12);
            Console.WriteLine($"Second example fraction after simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"Second example fraction after simplification: {frac}");

            frac = new Fraction(199, 173);
            Console.WriteLine($"Third example fraction after simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"Third example fraction after simplification: {frac}");

            frac = new Fraction(182, 195);
            Console.WriteLine($"Fourth example fraction after simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"Fourth example fraction after simplification: {frac}");

            frac = new Fraction(360, 2940);
            Console.WriteLine($"Fifth example fraction after simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"Fifth example fraction after simplification: {frac}");

            frac = new Fraction(2000, 4400);
            Console.WriteLine($"Sixth example fraction after simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"Sixth example fraction after simplification: {frac}");

            frac = new Fraction(14, -48);
            Console.WriteLine($"Seventh example fraction after simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"Seventh example fraction after simplification: {frac}");

            frac = new Fraction(-12, -48);
            Console.WriteLine($"Tenth example fraction after simplification: {frac}");
            frac.Simplify();
            Console.WriteLine($"Tenth example fraction after simplification: {frac}");
        }
    }
}

