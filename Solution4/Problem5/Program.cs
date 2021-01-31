/*
*а) Реализовать класс для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами.
Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, 
возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)

*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

Дополнительные задачи
в) Обработать возможные исключительные ситуации при работе с файлами.

Селютин Александр
*/

using System;
using System.IO;

namespace Problem5 {
    public class CustomMatrix {
        private int[,] matrix;
        private static int MIN_BOUND = -10000;
        private static int MAX_BOUND = 10000;
        
        public CustomMatrix(int rows, int columns) {
            matrix = new int[rows, columns];
            var random = new Random();
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    matrix[i, j] = random.Next(MIN_BOUND, MAX_BOUND);
                }
            }
        }

        public int Sum() {
            int sum = 0;
            foreach (var el in matrix) {
                sum += el;
            }

            return sum;
        }
        
        public int RestrictedSum(int bound) {
            int sum = 0;
            foreach (var el in matrix) {
                if (bound < el) {
                    sum += el;
                }
            }

            return sum;
        }

        public int Max {
            get {
                if (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0) {
                    Console.WriteLine("Matrix is empty");
                    return 0;
                }
                int max = matrix[0, 0];
                foreach (var el in matrix) {
                    if (max < el) {
                        max = el;
                    }
                }

                return max;
            }
        }

        public int Min {
            get {
                if (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0) {
                    Console.WriteLine("Matrix is empty");
                    return 0;
                }
                int min = matrix[0, 0];
                foreach (var el in matrix) {
                    if (min > el) {
                        min = el;
                    }
                }

                return min;
            }
        }

        public void GetMaxElementIndices(ref int row, ref int column) {
            if (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0) {
                Console.WriteLine("Matrix is empty");
                row = -1;
                column = -1;
                return;
            }
            int max = matrix[0, 0];
            row = 0;
            column = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    if (max < matrix[i, j]) {
                        max = matrix[i, j];
                        row = i;
                        column = j;
                    }
                }
            }
        }

        public int RowsLen {
            get { return matrix.GetLength(0); }
        }

        public int ColumnLen {
            get { return matrix.GetLength(1); }
        }

        public int this[int i, int j] {
            get {
                if (i < matrix.GetLength(0) && j < matrix.GetLength(1)) {
                    return matrix[i, j];
                }
                Console.WriteLine($"You inserted incorrected indices: ({i}, {j})");
                return -1;
            }
        } 

        public CustomMatrix(string filename) {
            int rows = 0;
            int columns = 0;
            matrix = new int[rows, columns];
            
            if (!File.Exists(filename)) {
                Console.WriteLine($"File {filename} does not exist!!");
                return;
            }
            StreamReader reader = new StreamReader(filename);
            bool flag;
            do {
                if (reader.EndOfStream) {
                    Console.WriteLine("File does not contain full information for matrix!");
                    reader.Close();
                    return;
                }
                string entry = reader.ReadLine();
                flag = int.TryParse(entry, out rows);
                if (!flag) {
                    Console.WriteLine($"Read incorrect entry: {entry}, which does not comform to rows. Try again");
                }
            } while (!flag);
            do {
                if (reader.EndOfStream) {
                    Console.WriteLine("File does not contain full information for matrix!");
                    reader.Close();
                    return;
                }
                string entry = reader.ReadLine();
                flag = int.TryParse(entry, out columns);
                if (!flag) {
                    Console.WriteLine($"Read incorrect entry: {entry}, which does not comform to columns. Try again");
                }
            } while (!flag);
            
            matrix = new int[rows, columns];
            
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (reader.EndOfStream) {
                        Console.WriteLine("File does not contain full information for matrix!");
                        reader.Close();
                        return;
                    }

                    flag = false;
                    int value = -1;
                    while (!flag) {
                        if (reader.EndOfStream) {
                            Console.WriteLine("File does not contain full information for matrix!");
                            reader.Close();
                            return;
                        }
                        string entry = reader.ReadLine();
                        flag = int.TryParse(entry, out value);
                        if (!flag) {
                            Console.WriteLine($"Read incorrect entry: {entry}, which does not comform to value. Try again");
                        }
                    }

                    matrix[i, j] = value;
                }
            }
            reader.Close();
        }

        public void WriteMatrixToFile(string filename) {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(matrix.GetLength(0));
            writer.WriteLine(matrix.GetLength(1));
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    writer.WriteLine(matrix[i, j]);
                }
            }
            writer.Close();
        }

        public void ReadArrayFromFile(string filename) {
            int rows = 0;
            int columns = 0;
            matrix = new int[rows, columns];
            
            if (!File.Exists(filename)) {
                Console.WriteLine($"File {filename} does not exist!!");
                return;
            }
            StreamReader reader = new StreamReader(filename);
            bool flag;
            do {
                if (reader.EndOfStream) {
                    Console.WriteLine("File does not contain full information for matrix!");
                    reader.Close();
                    return;
                }
                string entry = reader.ReadLine();
                flag = int.TryParse(entry, out rows);
                if (!flag) {
                    Console.WriteLine($"Read incorrect entry: {entry}, which does not comform to rows. Try again");
                }
            } while (!flag);
            do {
                if (reader.EndOfStream) {
                    Console.WriteLine("File does not contain full information for matrix!");
                    reader.Close();
                    return;
                }
                string entry = reader.ReadLine();
                flag = int.TryParse(entry, out columns);
                if (!flag) {
                    Console.WriteLine($"Read incorrect entry: {entry}, which does not comform to columns. Try again");
                }
            } while (!flag);
            
            matrix = new int[rows, columns];
            
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (reader.EndOfStream) {
                        Console.WriteLine("File does not contain full information for matrix!");
                        reader.Close();
                        return;
                    }

                    flag = false;
                    int value = -1;
                    while (!flag) {
                        if (reader.EndOfStream) {
                            Console.WriteLine("File does not contain full information for matrix!");
                            reader.Close();
                            return;
                        }
                        string entry = reader.ReadLine();
                        flag = int.TryParse(entry, out value);
                        if (!flag) {
                            Console.WriteLine($"Read incorrect entry: {entry}, which does not comform to value. Try again");
                        }
                    }

                    matrix[i, j] = value;
                }
            }
            reader.Close();
        }

    }
    
    internal class Program {
        public static int ROW_SIZE = 5;
        public static int COLUMN_SIZE = 6;
        
        public static void Main(string[] args) {
            var matrix = new CustomMatrix(ROW_SIZE, COLUMN_SIZE);
            PrintMatrix(matrix);
            Console.WriteLine();

            Console.WriteLine("Print sum of all elements in matrix");
            Console.WriteLine(matrix.Sum());
            Console.WriteLine();
            
            Console.WriteLine("Print sum of all elements in matrix, which greater than 25");
            Console.WriteLine(matrix.RestrictedSum(25));
            Console.WriteLine();
            
            Console.WriteLine("Print max element in matrix");
            Console.WriteLine(matrix.Max);
            Console.WriteLine();
            
            Console.WriteLine("Print min element in matrix");
            Console.WriteLine(matrix.Min);
            Console.WriteLine();

            int i = -1;
            int j = -1;
            Console.WriteLine("Print indices of max element in matrix");
            matrix.GetMaxElementIndices(ref i, ref j);
            Console.WriteLine($"row: {i}, column: {j}");
            Console.WriteLine();
            
            Console.WriteLine();

            string filename = "../../../matrix_file.txt";
            Console.WriteLine($"Read matrix from file: '{filename}'");
            var otherMatrix = new CustomMatrix(filename);
            PrintMatrix(otherMatrix);
            Console.WriteLine();
            
            string otherFilename = "../../../other_matrix_file.txt";
            Console.WriteLine($"Write initial matrix to file: '{otherFilename}'");
            matrix.WriteMatrixToFile(otherFilename);
            Console.WriteLine();

            Console.WriteLine($"Read initial matrix from file: '{otherFilename}'");
            otherMatrix.ReadArrayFromFile(otherFilename);
            PrintMatrix(otherMatrix);
            Console.WriteLine();
            
            Console.WriteLine();

            filename = "../../../broken_matrix_data.txt";
            Console.WriteLine($"Read broken matrix from file: '{filename}'");
            var newestMatrix = new CustomMatrix(filename);
            PrintMatrix(newestMatrix);
            Console.WriteLine();

            filename = "../../../not_full_matrix_data.txt";
            Console.WriteLine($"Try to read not full matrix from file: '{filename}'");
            newestMatrix.ReadArrayFromFile(filename);
            PrintMatrix(newestMatrix);
            Console.WriteLine();
        }

        public static void PrintMatrix(CustomMatrix matrix) {
            Console.WriteLine("Print matrix");
            for (int i = 0; i < matrix.RowsLen; i++) {
                for (int j = 0; j < matrix.ColumnLen; j++) {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        } 
    }
}