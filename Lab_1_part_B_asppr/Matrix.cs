using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_part_B_asppr
{
    internal class Matrix
    {
        private readonly double[,] _data;

        public int Rows { get; }
        public int Columns { get; }
        public int Rank { get; set; }

        public string[] RowHeaders { get; set; }
        public string[] ColumnHeaders { get; set; }
        public double GetMaxZ { get => this[this.Rows - 1, this.Columns - 1]; }

        public Matrix(double[,] matrix)
        {
            _data = matrix;
            Rows = matrix.GetLength(0);
            Columns = matrix.GetLength(1);
        }

        public double this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }

        public Matrix Clone()
        {
            int rows = Rows;
            int cols = Columns;
            double[,] newData = new double[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    newData[i, j] = this[i, j];

            Matrix newMatrix = new Matrix(newData);

            newMatrix.Rank = this.Rank;

            if (this.RowHeaders != null)
            {
                newMatrix.RowHeaders = (string[])this.RowHeaders.Clone();
            }

            if (this.ColumnHeaders != null)
            {
                newMatrix.ColumnHeaders = (string[])this.ColumnHeaders.Clone();
            }

            return newMatrix;
        }

        public void InitializeHeaders()
        {
            RowHeaders = new string[Rows];
            ColumnHeaders = new string[Columns];

            for (int i = 0; i < Rows - 1; i++)
            {
                RowHeaders[i] = "y" + (i + 1);
            }
            RowHeaders[Rows - 1] = "Z";

            for (int j = 0; j < Columns - 1; j++)
            {
                ColumnHeaders[j] = "x" + (j + 1);
            }
            ColumnHeaders[Columns - 1] = "1";
        }
    }
}