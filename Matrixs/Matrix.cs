using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrixs
{
    class Matrix
    {
        private double[,] _data;
        private int _rowCount;
        private int _columnCount;
        readonly Random rnd = new Random();

        public Matrix() { }
        public Matrix(int row, int column)
        {
            _rowCount = row;
            _columnCount = column;
            _data = new double[_rowCount, _columnCount];
        }

        public void Read()
        {
            Console.WriteLine("Введите количество строк и количество столбцов матрицы через пробел:");
            int[] matrixSize = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            _rowCount = matrixSize[0];
            _columnCount = matrixSize[1];
            _data = new double[_rowCount, _columnCount];
            for (int row = 0; row < _rowCount; row++)
            {
                Console.WriteLine($"Введите значения {row + 1} строки через пробел:");
                double[] value = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
                for (int column = 0; column < value.Length; column++)
                    _data[row, column] = value[column];
            }
        }

        public void ReadRandom(int rows, int columns)
        {
            _rowCount = rows;
            _columnCount = columns;
            _data = new double[_rowCount, _columnCount];
            for (int row = 0; row < _rowCount; row++)
            {
                double[] value = new double[_columnCount];
                for (int i = 0; i < _columnCount; i++)
                {
                    value[i] = rnd.Next(0, 10);
                }
                for (int column = 0; column < value.Length; column++)
                    _data[row, column] = value[column];
            }
        }

        public void Write()
        {
            Console.WriteLine("Вывод матрицы:");
            for (int row = 0; row < _rowCount; row++)
            {
                for (int column = 0; column < _columnCount; column++)
                {
                    Console.Write(column + 1 == _columnCount ? $"{_data[row, column]}" : $"{_data[row, column]} ");
                }
                Console.WriteLine();
            }
        }

        public static void GetSize(Matrix x)
        {
            Console.WriteLine($"Строк = {x._rowCount}, Столбцов = {x._columnCount}");
        }

        public static Matrix operator +(Matrix x, Matrix y)
        {
            var NewMatrix = new Matrix(x._rowCount, x._columnCount);
            for (int row = 0; row < x._data.GetLength(0); row++)
            {
                for (int column = 0; column < x._data.GetLength(1); column++)
                {
                    NewMatrix._data[row, column] = x._data[row, column] + y._data[row, column];
                }
            }
            return NewMatrix;
        }

        public static Matrix operator -(Matrix x, Matrix y)
        {
            Matrix NewMatrix = new Matrix(x._rowCount, x._columnCount);
            for (int row = 0; row < x._data.GetLength(0); row++)
            {
                for (int column = 0; column < x._data.GetLength(1); column++)
                {
                    NewMatrix._data[row, column] = x._data[row, column] - y._data[row, column];
                }
            }
            return NewMatrix;
        }
        public static Matrix operator *(Matrix x, double multiplier)
        {
            Matrix NewMatrix = new Matrix(x._rowCount, x._columnCount);
            for (int row = 0; row < x._rowCount; row++)
            {
                for (int column = 0; column < x._columnCount; column++)
                {
                    NewMatrix._data[row, column] = x._data[row, column] * multiplier;
                }
            }
            return NewMatrix;
        }

        public static Matrix operator *(Matrix x, Matrix y)
        {
            if (x._rowCount != y._columnCount)
            {
                throw new ArgumentException("Умножение этих матриц не возможно!");
            }
            Matrix NewMatrix = new Matrix(x._rowCount, y._columnCount);
            for (int i = 0; i < NewMatrix._rowCount; i++)
            {
                for (int j = 0; j < NewMatrix._columnCount; j++)
                {
                    for (int k = 0; k < x._columnCount; k++)
                    {
                        NewMatrix._data[i, j] += x._data[i, k] * y._data[k, j];
                    }
                }
            }
            return NewMatrix;
        }

        public static Matrix Transposition(Matrix x)
        {
            Matrix NewMatrix = new Matrix(x._columnCount, x._rowCount);
            for (int i = 0; i < x._rowCount; i++)
            {
                for (int j = 0; j < x._columnCount; j++)
                {
                    NewMatrix._data[j, i] = x._data[i, j];
                }
            }
            return NewMatrix;
        }
    }
}

