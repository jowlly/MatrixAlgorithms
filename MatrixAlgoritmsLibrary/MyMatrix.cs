using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAlgoritmsLibrary
{
    /// <summary>
    /// Класс, представляющий матрицу
    /// </summary>
    public class MyMatrix //<T>
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
        /// Возвращает порядок квадратной матрицы
        /// </summary>
        public int Order { get
            {
                if (IsSquare) return RowsCount;
                return -1;
            } }

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

        #region methods
        /// <summary>
        /// Метод для представления неквадратной матрицы в виде квадратной (добавлением пустых элементов)
        /// </summary>
        /// <returns></returns>
        public MyMatrix ToSquare()
        {
            int order = Math.Max(ColumnsCount, RowsCount);
            MyMatrix ans = new MyMatrix(order);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    ans.Matrix[i, j] = Matrix[i, j];
                }
            }
            return ans;
        }

        public MyMatrix ToSquare(int order)
        {
            MyMatrix ans = new MyMatrix(order);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    ans.Matrix[i, j] = Matrix[i, j];
                }
            }
            return ans;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MyMatrix ToOneZero()
        {
            int order = Math.Max(ColumnsCount, RowsCount);
            MyMatrix ans = new MyMatrix(order);
            
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (Matrix[i, j] != 0 )
                    {
                        ans.Matrix[i, j] = 1;
                    }
                    else
                    {
                        ans.Matrix[i, j] = 0;
                    }
                }
            }
            return ans;
        }

        public MyMatrix AddRow()
        {
            MyMatrix ans = new MyMatrix(RowsCount + 1, ColumnsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    ans.Matrix[i, j] = Matrix[i, j];
                }
            }
            return ans;
        }

        public MyMatrix AddColumn()
        {
            MyMatrix ans = new MyMatrix(RowsCount, ColumnsCount + 1);

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    ans.Matrix[i, j] = Matrix[i, j];
                }
            }
            return ans;
        }
        /// <summary>
        /// Метод копирования части матрицы, заданной по индексам строк и столбцов
        /// из большего блока в меньший 
        /// </summary>
        /// <param name="startrows">индекс строки большего блока, с котрого нужно начать копирование
        /// из большего блока в меньший</param>
        /// <param name="startcolumns">индекс столбца большего блока, с котрого нужно начать копирование
        /// из большего блока в меньший</param>
        /// <param name="endrows">индекс строки большего блока, которым нужно закончить копирование
        /// из большего блока в меньший</param>
        /// <param name="endcolumns">индекс столбца большего блока, которым нужно закончить копирование
        /// из большего блока в меньший</param>
        /// <returns>меньший блок, скопированный с части большего блока</returns>
        public MyMatrix CopyWithIndex(int startrows, int startcolumns, int endrows, int endcolumns)
        {
            MyMatrix ans = new MyMatrix(endrows - startrows, endcolumns - startcolumns);
            for (int i = startrows, ansi = 0; i < endrows; i++, ansi++)
            {
                for (int j = startcolumns, ansj = 0; j < endcolumns; j++, ansj++)
                {
                    ans.Matrix[ansi, ansj] = Matrix[i, j];
                }
            }
            return ans;
        }

        /// <summary>
        /// Метод копирования части матрицы, заданной по индексам строк и столбцов
        /// из меньшего блока в больший        
        /// </summary>        
        /// <param name="ans">больший блок, в который будет скопирован меньшй блок</param>
        /// <param name="startrows">индекс строки большего блока, с котрого нужно начать копирование
        /// из меньшего блока в больший</param>   
        /// <param name="startcolumns">индекс столбца большего блока, с котрого нужно начать копирование
        /// из меньшего блока в больший</param>  
        /// <param name="endrows">индекс строки большего блока, которым нужно закончить копирование
        /// из меньшего блока в больший</param>  
        /// <param name="endcolumns">индекс столбца большего блока, которым нужно закончить копирование
        /// из меньшего блока в больший</param>  
        /// <returns>больший блок со скопированным в нем малым блоком</returns>
        public MyMatrix CopyWithIndexBack(MyMatrix ans, int startrows, int startcolumns, int endrows, int endcolumns)
        {
            for (int i = startrows, ansi = 0; i < endrows; i++, ansi++)
            {
                for (int j = startcolumns, ansj = 0; j < endcolumns; j++, ansj++)
                {
                    ans.Matrix[i, j] = Matrix[ansi, ansj];
                }
            }
            return ans;
        }

        /// <summary>
        /// Метод копирования матрицы целиком
        /// </summary>
        /// <param name="forcopy">матрица для копирования</param>
        /// <returns>копированную матрицу</returns>
        public MyMatrix Copy()
        {
            return new MyMatrix(Matrix);
        }


        /// <summary>
        /// Функция создания рандомной квадратной матрицы
        /// </summary>
        /// <param name="order">порядок квадратной матрицы</param>
        /// <returns>созданную матрицу</returns>
        public MyMatrix CreateRandomSquareMatrix(int order)
        {
            Random random = new Random();
            MyMatrix ans = new MyMatrix(order);

            for (int i = 0; i < ans.RowsCount; i++)
            {
                for (int j = 0; j < ans.ColumnsCount; j++)
                {
                    ans.Matrix[i, j] = random.Next(0, 100);
                }
            }
            return ans;
        }

        /// <summary>
        /// Переопределенный метод ToString для возвращения строки, представляющей матрицу
        /// </summary>
        /// <returns>строки, представляющяя матрицу</returns>
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
        #endregion

    }
}
