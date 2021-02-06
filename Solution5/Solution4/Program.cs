/*
4. Задача ЕГЭ.

*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

Селютин Александр
*/

using System;
using System.Collections.Generic;

namespace Solution4 {
    class PupilMark {
        private string surname;
        private double avgMark;

        public PupilMark(string surname, double avgMark) {
            this.surname = surname;
            this.avgMark = avgMark;
        }

        public string Surname => surname;
        public double AvgMark => avgMark;
    }
    
    class MarkComparer : IComparer<PupilMark> {
        public int Compare(PupilMark first, PupilMark second) {
            if (first.AvgMark > second.AvgMark) {
                return 1;
            } else if (first.AvgMark < second.AvgMark) {
                return -1;
            }
            return 0;
        }
    }
    
    internal class Program {
        private static int peopleCounter = 3;
        
        public static void Main(string[] args) {
            Console.WriteLine("Enter lenght of array");
            var length = int.Parse(Console.ReadLine());
            var pupilMarks = new PupilMark[length];

            Console.WriteLine("Enter pupil name and marks");
            for (int i = 0; i < length; i++) {
                var line = Console.ReadLine();
                var lineParts = line.Split();
                var surname = lineParts[0];
                var avgMark = calculateAvgMark(lineParts[2], lineParts[3], lineParts[4]);
                
                pupilMarks[i] = new PupilMark(surname, avgMark);
            }

            Array.Sort(pupilMarks, new MarkComparer());

            if (pupilMarks.Length < peopleCounter) {
                foreach (var pupilMark in pupilMarks) {
                    Console.WriteLine(pupilMark.Surname + " " + pupilMark.AvgMark);
                }
                return;
            }

            Console.WriteLine("Print pupils with worst marks");
            var lastMark = pupilMarks[peopleCounter - 1].AvgMark;
            foreach (var pupilMark in pupilMarks) {
                if (lastMark < pupilMark.AvgMark) {
                    break;
                }
                Console.WriteLine(pupilMark.Surname + " " + pupilMark.AvgMark);
            }
        }

        private static double calculateAvgMark(string firstMark, string secondMark, string thirdMark) {
            return (double.Parse(firstMark) + double.Parse(secondMark) + double.Parse(thirdMark)) / 3;
        }
    }
}