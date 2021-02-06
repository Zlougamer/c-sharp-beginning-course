/*
2. Разработать класс Message, содержащий следующие статические методы для обработки

текста:
а) Вывести только те слова сообщения, которые содержат не более n букв.
б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
в) Найти самое длинное слово сообщения.
г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
Продемонстрируйте работу программы на текстовом файле с вашей программой.
д) ***Создать метод, который производит частотный анализ текста. В качестве параметра в него передается массив 
слов и текст, в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
Здесь требуется использовать класс Dictionary.

Селютин Александр
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2 {
    
    class Message {

        private static char[] SEPARATOR = {' '};
        public static void ShowWordsNotMoreNumberLetters(int maxLen, string text) {
            Console.WriteLine($"Show words from message, which contains have not more than {maxLen} symbols");
            string[] words = text.Split(SEPARATOR);
            foreach (var word in words) {
                if (word.Length <= maxLen) {
                    Console.WriteLine(word);
                }
            }
        }
        
        public static string RemoveWordsByLastSymbol(char symbol, string text) {
            Console.WriteLine($"Remove words from message, which ends with '{symbol}' symbol");
            string[] words = text.Split(SEPARATOR);
            StringBuilder filteredText = new StringBuilder();
            foreach (var word in words) {
                if (word[word.Length - 1] != symbol) {
                    if (filteredText.Length == 0) {
                        filteredText.Append(word);
                    } else {
                        filteredText.Append(" " + word);
                    }
                }
            }

            return filteredText.ToString();
        }
        
        public static Dictionary<string, int> MakeFrequencyAnalysis(string[] words, string text) {
            Console.WriteLine("Create frequency analysis array.");
            var freqDict = new Dictionary<string, int>();

            foreach (var word in words) {
                freqDict[word] = 0;
            }

            var textWords = text.Split(SEPARATOR);
            foreach (var word in textWords) {
                if (freqDict.ContainsKey(word)) {
                    freqDict[word] += 1;
                }
            }

            return freqDict;
        }
        
        public static string FindLongestWord(string text) {
            Console.WriteLine("Find first the longest word in the text");
            string[] words = text.Split(SEPARATOR);
            if (words.Length == 0) {
                return "";
            }
            int maxLen = words[0].Length;
            foreach (var word in words) {
                if (word.Length > maxLen) {
                    maxLen = word.Length;
                }
            }

            foreach (var word in words) {
                if (word.Length == maxLen) {
                    return word;
                }
            }
            return "";
        }
        
        public static string ConcatLongestWords(string text) {
            Console.WriteLine("Concat longest words in the text");
            string[] words = text.Split(SEPARATOR);
            if (words.Length == 0) {
                return "";
            }
            int maxLen = words[0].Length;
            foreach (var word in words) {
                if (word.Length > maxLen) {
                    maxLen = word.Length;
                }
            }

            StringBuilder builder = new StringBuilder();
            foreach (var word in words) {
                if (word.Length == maxLen) {
                    if (builder.Length == 0) {
                        builder.Append(word);
                    } else {
                        builder.Append(" " + word);
                    }
                }
            }
            return builder.ToString();
        }
        
    }
    
    internal class Program {
        public static string SomeText = "some simple sampl training miracle interesting wonderful wet text";
        public static string SeveralLongestText = "some simplee sample miracle aaaasss text";
        public static string NewestText = "some some wet aaaasss text wet wet text some";

        public static void Main(string[] args) {
            Message.ShowWordsNotMoreNumberLetters(3, SomeText);
            Message.ShowWordsNotMoreNumberLetters(5, SomeText);
            Message.ShowWordsNotMoreNumberLetters(7, SomeText);
            Console.WriteLine();

            Console.WriteLine(Message.RemoveWordsByLastSymbol('e', SomeText));
            Console.WriteLine(Message.RemoveWordsByLastSymbol('l', SomeText));
            Console.WriteLine(Message.RemoveWordsByLastSymbol('t', SomeText));
            Console.WriteLine();
            
            Console.WriteLine(Message.FindLongestWord(SomeText));
            Console.WriteLine();

            Console.WriteLine(Message.ConcatLongestWords(SomeText));
            Console.WriteLine(Message.ConcatLongestWords(SeveralLongestText));

            var wordArr = new string[]{"some", "wet", "text", "arara"};
            var firstDict = Message.MakeFrequencyAnalysis(wordArr, SomeText);
            Console.WriteLine("Text");
            Console.WriteLine(SomeText);
            Console.WriteLine("Frequency array:");
            foreach (var kvp in firstDict) {
                Console.WriteLine("word = {0}, count = {1}", kvp.Key, kvp.Value);
            }
            var secondDict = Message.MakeFrequencyAnalysis(wordArr, NewestText);
            Console.WriteLine("Text");
            Console.WriteLine(NewestText);
            Console.WriteLine("Frequency array:");
            foreach (var kvp in secondDict) {
                Console.WriteLine("word = {0}, count = {1}", kvp.Key, kvp.Value);
            }
        }
    }
}