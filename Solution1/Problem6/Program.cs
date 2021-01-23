using System;
/*
*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).

Селютин Александр
*/

namespace Problem6 {
    internal class Program {
        public static void Main(string[] args) {
            var msg = "Some message";
            var sec = 3;
            
            Console.WriteLine("Play with Pause method!");
            Pause();
            Pause(msg);
            Pause(sec);
            Pause(msg, sec);
            Pause(sec, msg);
            
            Console.WriteLine("Play with Print method!");
            var anotherMessage = "Some another message!!!";
            var left = 24;
            var top = Console.CursorTop;
            var foregroundcolor = ConsoleColor.Green;
            Print(anotherMessage, left, top);
            Print(anotherMessage, foregroundcolor);
            Print(anotherMessage);
            Print(anotherMessage, left, top, foregroundcolor);
        }

        public static void Pause(string msg) {
            Console.WriteLine(msg);
            Console.ReadKey();
        }
        
        public static void Pause() {
            Console.WriteLine("Pause until press button");
            Console.ReadKey();
        }
        
        public static void Pause(int sec) {
            Console.WriteLine($"Pause for {sec} seconds...");
            System.Threading.Thread.Sleep(sec * 1000);
        }
        
        public static void Pause(string msg, int sec) {
            Console.WriteLine(msg);
            System.Threading.Thread.Sleep(sec * 1000);
        }
        
        public static void Pause(int sec, string msg) {
            Pause(msg, sec);
        }
        
        static void Print(string msg, int left, int top) {
            var foregroundcolor = ConsoleColor.DarkCyan;
            Print(msg, left, top, foregroundcolor);
        }

        static void Print(string msg, ConsoleColor foregroundcolor) {
            var left = (Console.WindowWidth - msg.Length) / 2;
            var top = Console.CursorTop;
            Print(msg, left, top, foregroundcolor);
        }

        public static void Print(string msg) {
            var left = (Console.WindowWidth - msg.Length) / 2;
            var top = Console.CursorTop;
            var foregroundcolor = ConsoleColor.DarkCyan;
            Print(msg, left, top, foregroundcolor);
        }
        static void Print(string msg, int left, int top, ConsoleColor foregroundcolor) {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg);
        }
    }
}