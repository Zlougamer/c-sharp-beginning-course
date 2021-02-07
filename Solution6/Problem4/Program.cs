/*
**Считайте файл различными способами.
Смотрите “Пример записи файла различными способами”.
Создайте методы, которые возвращают массив byte (FileStream, BufferedStream),
строку для StreamReader и массив int для BinaryReader.

Селютин Александр
*/

using System;
using System.IO;
using System.Diagnostics;

namespace CopySamples {
    class Program {
        public static string FileStreamFilename = "../../../bigdata0.bin";
        public static string BinaryStreamFilename = "../../../bigdata1.bin";
        public static string StreamWriterFilename = "../../../bigdata2.bin";
        public static string BufferedStreamFilename = "../../../bigdata3.bin";
        
        static void Main(string[] args) {
            long kbyte = 1024;
            long mbyte = 1024 * kbyte;
            long tenNbyte = 10 * mbyte;
            long gbyte = 1024 * mbyte;
            long size = tenNbyte;
            //Write FileStream
            //Write BinaryStream
            //Write StreamReader/StreamWriter
            //Write BufferedStream

            Console.WriteLine(
                "FileStream. Milliseconds:{0}", FileStreamSample(FileStreamFilename, size)
            );
            Console.WriteLine(
                "BinaryStream. Milliseconds:{0}", BinaryStreamSample(BinaryStreamFilename, size)
            );
            Console.WriteLine(
                "StreamWriter. Milliseconds:{0}", StreamWriterSample(StreamWriterFilename, size)
            );
            Console.WriteLine(
                "BufferedStream. Milliseconds:{0}", BufferedStreamSample(BufferedStreamFilename, size)
            );
            Console.WriteLine();

            FileStreamRead(FileStreamFilename);
            BinaryStreamRead(BinaryStreamFilename);
            StreamReaderRead(StreamWriterFilename);
            BufferedStreamReader(BufferedStreamFilename);

            Console.ReadKey();
        }

        static long FileStreamSample(string filename, long size) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            for (int i = 0; i < size; i++) {
                fs.WriteByte(0);
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static byte[] FileStreamRead(string filename) {
            Console.WriteLine("FileStreamRead function started");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            var size = fs.Length / sizeof(byte);
            byte[] values = new byte[size];
            for (int i = 0; i < size; i++) {
                var val = (byte)fs.ReadByte();
                values[i] = val;
            }
            fs.Close();
            stopwatch.Stop();
            Console.WriteLine($"FileStreamRead time elapsed: {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine();

            return values;
        }

        static long BinaryStreamSample(string filename, long size) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
                bw.Write((byte)0);
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static int[] BinaryStreamRead(string filename) {
            Console.WriteLine("BinaryStreamRead function started");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            long size = fs.Length / sizeof(int);
            int[] values = new int[size];
            for (int i = 0; i < size; i++) {
                int value = bw.Read();
                values[i] = value;
            }
            fs.Close();
            stopwatch.Stop();
            Console.WriteLine($"BinaryStreamRead time elapsed: {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine();

            return values;
        }

        static long StreamWriterSample(string filename, long size) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < size; i++) {
                sw.Write(0);
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static string StreamReaderRead(string filename) {
            Console.WriteLine("StreamStreamRead function started");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string value = sr.ReadToEnd();
            fs.Close();
            sr.Close();
            stopwatch.Stop();
            Console.WriteLine($"StreamStreamRead time elapsed: {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine();

            return value;
        }

        static long BufferedStreamSample(string filename, long size) {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            int countPart = 4;
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs,bufsize);
            //bs.Write(buffer, 0, (int)size);//Error!
            for (int i = 0; i < countPart; i++) {
                bs.Write(buffer, 0, (int) bufsize);
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static byte[] BufferedStreamReader(string filename) {
            Console.WriteLine("BufferedStreamReader function started");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            long size = fs.Length / sizeof(byte);
            int countPart = 4;
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            byte[] values = new byte[size];
            
            //bs.Write(buffer, 0, (int)size);//Error!
            for (int i = 0; i < countPart; i++) {
                bs.Read(buffer, 0, (int) bufsize);
                for (int j = 0; j < bufsize; j++) {
                    values[i * bufsize + j] = buffer[j];
                }
            }
            fs.Close();
            stopwatch.Stop();
            Console.WriteLine($"BufferedStreamReader time elapsed: {stopwatch.ElapsedMilliseconds}");
            Console.WriteLine();

            return values;
        }
    }
}
