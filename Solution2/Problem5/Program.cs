/*
а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, 
нужно ли человеку похудеть, набрать вес или всё в норме.
б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

Селютин Александр
*/

using System;

namespace Problem5 {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Enter your weight in kilograms");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height in meters");
            double height = double.Parse(Console.ReadLine());

            var indexMassBody = CalculateIndexMassBody(weight, height);
            Console.WriteLine($"Your index mass body is {indexMassBody}");

            string state = GetYourWeightCategory(indexMassBody);
            Console.WriteLine($"Your weight category is {state}");
            string advice = HowShouldChangeWeight(indexMassBody);
            Console.WriteLine(advice);

            if (isWeightNormal(indexMassBody)) {
                Console.WriteLine("Your weight is normal");
            }
            else {
                double normalWeight = CalculateNormalWeight(indexMassBody, height);
                if (weight > normalWeight) {
                    var delta = weight - normalWeight;
                    Console.WriteLine($"Your should lose at least {delta} kg");
                } else {
                    var delta = normalWeight - weight;
                    Console.WriteLine($"Your should get at least {delta} kg");
                }
            }
        }

        public static double CalculateIndexMassBody(double weight, double height) {
            return weight / (height * height);
        }

        public static string GetYourWeightCategory(double indexMassBody) {
            string state = "";

            if (indexMassBody < 15.0) {
                state = "Very severely underweight";
            } else if (indexMassBody < 16.0 && indexMassBody >= 15.0) {
                state = "Severely underweight";
            } else if (indexMassBody < 18.5 && indexMassBody >= 16) {
                state = "Underweight";
            } else if (isWeightNormal(indexMassBody)) {
                state = "Normal (healthy weight)";
            } else if (indexMassBody < 30.0 && indexMassBody >= 25.0) {
                state = "Overweight";
            } else if (indexMassBody < 35 && indexMassBody >= 30) {
                state = "Obese Class I (Moderately obese)";
            } else if (indexMassBody < 40 && indexMassBody >= 35) {
                state = "Obese Class II (Severely obese)";
            } else if (indexMassBody >= 40) {
                state = "Obese Class III (Very severely obese)";
            } else {
                state = "Incorrect index mass body";
            }

            return state;
        }

        public static string HowShouldChangeWeight(double indexMassBody) {
            string advice = "";
            if (isWeightNormal(indexMassBody)) {
                advice = "Your weight is normal. You should not lose weight or get fat";
            } else if (indexMassBody >= 25) {
                advice = "You have some extra weight. You should lose weight";
            } else {
                advice = "You have some lack of weight. You should get fat";
            }

            return advice;
        }

        public static double CalculateNormalWeight(double indexMassBody, double height) {
            if (indexMassBody >= 25) {
                var maxIndexMassBody = 24.9;
                var maxWeight = maxIndexMassBody * height * height;
                return maxWeight;
            }

            var minIndexMassBody = 18.5;
            var minWeight = minIndexMassBody * height * height;
            return minWeight;
        }

        public static bool isWeightNormal(double indexMassBody) {
            return indexMassBody < 25 && indexMassBody >= 18.5;
        }
    }
}