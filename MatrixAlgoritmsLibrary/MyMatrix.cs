using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAlgoritmsLibrary
{
    public class MyMatrix
    {
        #region fields
        private float[,] _matrix;
        #endregion

        #region propirties
        /// <summary>
        /// Доступ к матрице
        /// </summary>
        public float[,] Matrix { get => _matrix; set => _matrix = value; }

        /// <summary>
        /// Возвращает кол-во строк матрицы
        /// </summary>
        public int RowsCount { get => Matrix.GetLength(0); }

        /// <summary>
        /// Возвращает кол-во столбцов матрицы
        /// </summary>
        public int ColumnsCount { get => Matrix.GetLength(1); }

        /// <summary>
        /// Проверка на квадратную матрицу
        /// </summary>
        public bool IsSquare { get => RowsCount == ColumnsCount; }

        #endregion

        #region constructors

        public MyMatrix()
        {
            Matrix = new float[0, 0];
        }
        /// <summary>
        /// конструктор квадратной матрицы по заданному параметру
        /// </summary>
        /// <param name="n">порядок матрицы</param>
        public MyMatrix(int n)
        {
            Matrix = new float[n, n];
        }
        /// <summary>
        /// конструктор матрицы по заданным параметрам
        /// </summary>
        /// <param name="rows">кол-во строк</param>
        /// <param name="columns">кол-во столбцов</param>
        public MyMatrix(int rows, int columns)
        {
            Matrix = new float[rows, columns];
        }

        public MyMatrix(float[,] matrix) : this(matrix.GetLength(0), matrix.GetLength(1))
        {
            FillMatrix(matrix);
        }

        public void FillMatrix(float[,] matrix)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    Matrix[i, j] = matrix[i, j];
                }
            }
        }
        #endregion


        public override string ToString()
        {
            string ans = "";

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    ans += Matrix[i, j] + " ";
                }
                ans += "\n";
            }

            return ans;
        }
    }
}
