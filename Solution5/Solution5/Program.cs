/*
5. **Написать игру «Верю. Не верю».
В файле хранятся вопрос и ответ, правда это или нет. Например: «Шариковую ручку изобрели в древнем Египте»,
«Да». Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
Список вопросов ищите во вложении или воспользуйтесь интернетом.

Селютин Александр
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution5 {
    class Question {
        private string text;
        private string answer;

        public Question(string text, string answer) {
            this.text = text;
            this.answer = answer;
        }

        public string Text => text;
        public string Answer => answer;
    }
    
    internal class Program {
        private static int questionsNumber = 5;
            
        public static void Main(string[] args) {
            var questions = ExtractQuestions();
            var randomQuestions = SampleQuestions(questions, questionsNumber);

            int rightCounter = 0;
            Console.WriteLine($"Answer the following {questionsNumber} questions.");
            foreach (var question in randomQuestions) {
                Console.WriteLine("Question:");
                Console.WriteLine(question.Text);
                Console.WriteLine("Answer:");
                var answer = Console.ReadLine();
                if (answer == question.Answer) {
                    rightCounter++;
                }
            }
            
            Console.WriteLine($"You answered on {rightCounter} questions from {questionsNumber}");
        }

        public static Question[] ExtractQuestions() {
            var questions = new List<Question>();
            StreamReader reader = new StreamReader("../../../believe_or_not.txt");
            while (!reader.EndOfStream) {
                var text = reader.ReadLine();
                var answer = reader.ReadLine();
                questions.Add(new Question(text, answer));
            }

            return questions.ToArray();
        }

        public static Question[] SampleQuestions(Question[] questions, int questionsNumber) {
            var random = new Random();
            var indices = new HashSet<int>();
            var randomQuestions = new Question[questionsNumber];
            
            while (indices.Count < questionsNumber) {
                var index = random.Next(0, questions.Length);
                indices.Add(index);
            }

            int i = 0;
            foreach (var index in indices) {
                randomQuestions[i] = questions[index];
                i++;
            }

            return randomQuestions;
        }
    }
}