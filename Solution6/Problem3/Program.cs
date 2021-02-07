/*
3. Переделать программу «Пример использования коллекций» для решения следующих задач:

а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;
д) разработать единый метод подсчета количества студентов по различным параметрам
выбора с помощью делегата и методов предикатов.

Селютин Александр
*/

using System;
using System.Collections.Generic;
using System.IO;
class Student {
    public string lastName;
    public string firstName;
    public string university;
    public string faculty;
    public int course;
    public string department;
    public int group;
    public string city;
    public int age;

    public Student(
            string firstName,
            string lastName,
            string university,
            string faculty,
            string department,
            int course,
            int age,
            int group,
            string city
    ) {
        this.lastName = lastName;
        this.firstName = firstName;
        this.university = university;
        this.faculty = faculty;
        this.department = department;
        this.course = course;
        this.age = age;
        this.group = group;
        this.city = city;
    }
}

class Program {
    public delegate Object GetKey(Student student);
    public delegate bool Predicate(Dictionary<object, int> freqDict, object key);

    static int MyDelegat(Student st1, Student st2) {
        return String.Compare(st1.firstName, st2.firstName);
    }

    static int AgeComparator(Student st1, Student st2) {
        if (st1.age < st2.age) {
            return -1;
        } else if (st1.age > st2.age) {
            return 1;
        }

        return 0;
    }

    static int CourseAgeComparator(Student st1, Student st2) {
        if (st1.course < st2.course) {
            return -1;
        } else if (st1.course > st2.course) {
            return 1;
        }
        
        // case of st1.course == st2.course

        if (st1.age < st2.age) {
            return -1;
        } else if (st1.age > st2.age) {
            return 1;
        }
        
        return 0;
    }

    private static int fiftCourse = 5;
    private static int sixthCourse = 6;

    private static int lowerStudentYear = 18;
    private static int higherStudentYear = 20;
    
    static void Main(string[] args) {
        int numOfBachelors = 0;
        int numOfMasters = 0;
        int numOfFifthCourse = 0;
        int numOfSixthCourse = 0;
        List<Student> list = new List<Student>();
        DateTime dt = DateTime.Now;
        StreamReader reader = new StreamReader("../../../students_database.csv");
        while (!reader.EndOfStream) {
            try {
                string[] s = reader.ReadLine().Split(';');
                var firstName = s[0];
                var lastName = s[1];
                var university = s[2];
                var faculty = s[3];
                var department = s[4];
                var course = int.Parse(s[5]);
                var age = int.Parse(s[6]);
                var group = int.Parse(s[7]);
                var city = s[8];
                
                list.Add(
                    new Student(
                        firstName,
                        lastName,
                        university,
                        faculty,
                        department,
                        course,
                        age,
                        group,
                        city
                    )
                );
                if (course < fiftCourse) {
                    numOfBachelors++;
                } else {
                    numOfMasters++;
                }

                if (course == fiftCourse) {
                    numOfFifthCourse++;
                }
                if (course == sixthCourse) {
                    numOfSixthCourse++;
                }
                
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error! Press ESC to quit from programm");
                if (Console.ReadKey().Key == ConsoleKey.Escape) {
                    return;
                }
            }
        }
        reader.Close();

        var freqDict = CountStudentsByCourses(list);
        
        list.Sort(new Comparison<Student>(MyDelegat));
        Console.WriteLine("All students number:" + list.Count);
        Console.WriteLine("Number of masters: {0}", numOfMasters);
        Console.WriteLine("Number of bachelors: {0}", numOfBachelors);
        Console.WriteLine();

        Console.WriteLine("Number of fifth year students: {0}", numOfFifthCourse);
        Console.WriteLine("Number of sixth year students: {0}", numOfSixthCourse);
        Console.WriteLine();
        
        Console.WriteLine(
            $"Print count number for students between {lowerStudentYear} and {higherStudentYear} by course"
        );
        foreach (var entry in freqDict) {
            Console.WriteLine($"course = {entry.Key}: count of students = {entry.Value}");
        }
        Console.WriteLine();

        list.Sort(AgeComparator);
        Console.WriteLine("List of students sorted by age");
        foreach (var entry in list) {
            Console.WriteLine(entry.firstName + " " + entry.age);
        }
        Console.WriteLine();

        list.Sort(CourseAgeComparator);
        Console.WriteLine("List of students sorted by course and age");
        foreach (var entry in list) {
            Console.WriteLine(entry.firstName + " " + entry.course + " " + entry.age);
        }
        Console.WriteLine();

        Console.WriteLine("Use unique counter");
        Console.WriteLine("Count by university");
        var universityCounter = UniqueCounter(list, GetUniversity, UniversityPredicate);
        foreach (var entry in universityCounter) {
            Console.WriteLine($"university = {entry.Key}: count of students = {entry.Value}");
        }
        Console.WriteLine();

        Console.WriteLine(DateTime.Now - dt);
    }

    public static Dictionary<int, int> CountStudentsByCourses(List<Student> list) {
        var freqDict = new Dictionary<int, int>();
        foreach (var entry in list) {
            var age = entry.age;

            if (age < lowerStudentYear || age > higherStudentYear) {
                continue;
            }
            var course = entry.course;
            if (!freqDict.ContainsKey(course)) {
                freqDict[course] = 0;
            }

            freqDict[course]++;
        }

        return freqDict;
    }

    public static string GetUniversity(Student student) {
        return student.university;
    }
    public static bool UniversityPredicate(Dictionary<object, int> freqDict, object key) {
        return freqDict.ContainsKey(key);
    }
    public static Dictionary<Object, int> UniqueCounter(List<Student> list, GetKey getKey, Predicate predicate) {
        var freqDict = new Dictionary<object, int>();
        foreach (var entry in list) {
            var key = getKey(entry);

            if (!predicate(freqDict, key)) {
                freqDict[key] = 0;
            }

            freqDict[key]++;
        }

        return freqDict;
    }
}
