using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAlgoritmsLibrary
{
    /// <summary>
    /// Класс, представляющий алгоритмы перемножения матриц
    /// </summary>
    public class Algorithms
    {
        #region check for operation
        /// <summary>
        /// Проверка на возможность перемножения матриц:
        /// если число столбцов в первом сомножителе равно числу строк во втором
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>true - если возможно, false - если нет</returns>
        public bool CheckMultiplicationExist(MyMatrix first, MyMatrix second)
        {
            return first.ColumnsCount == second.RowsCount;
        }

        /// <summary>
        /// Проверка на одинаковый размер матриц
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>true - если одинаковый, false - если нет</returns>
        public bool CheckSameExist(MyMatrix first, MyMatrix second)
        {
            return first.RowsCount == second.RowsCount && first.ColumnsCount == second.ColumnsCount;
        }
        #endregion

        #region algorithms multiplication

        /// <summary>
        /// Итеративный алгоритм умножения матриц. Сложность О(n^3)
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>матрицу, полученную в результате перемножения первой и второй матриц</returns>
        public MyMatrix ClassicMultiplication(MyMatrix first, MyMatrix second)
        {
            MyMatrix ans = new MyMatrix(first.RowsCount, second.ColumnsCount);

            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int j = 0; j < second.ColumnsCount; j++)
                {
                    ans.Matrix[i, j] = 0;

                    for (int k = 0; k < first.ColumnsCount; k++)
                    {
                        ans.Matrix[i, j] += first.Matrix[i, k] * second.Matrix[k, j];
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// Функция умножения матриц методом Штрассена
        /// для подготовленных матриц 
        /// </summary>
        /// <param name="a">первая матрица</param>
        /// <param name="b">вторая матрица</param>
        /// <returns>матрицу, полученную в результате перемножения первой и второй матриц</returns>
        public MyMatrix ShtrassenMultiplication(MyMatrix a, MyMatrix b)
        {
            int n = a.Order;
            if (n <= 2)
            {
                //при порядке матриц равным двум, быстрее будет выполняться классической умножение матриц
                return ClassicMultiplication(a, b);
            }
            else
            {
                //деление на два блока
                n = n / 2;

                MyMatrix a11 = new MyMatrix(n);
                MyMatrix a12 = new MyMatrix(n);
                MyMatrix a21 = new MyMatrix(n);
                MyMatrix a22 = new MyMatrix(n);


                MyMatrix b11 = new MyMatrix(n);
                MyMatrix b12 = new MyMatrix(n);
                MyMatrix b21 = new MyMatrix(n);
                MyMatrix b22 = new MyMatrix(n);

                //деление двух блоков на четверти
                SplitToQuarters(a, out a11, out a12, out a21, out a22);
                SplitToQuarters(b, out b11, out b12, out b21, out b22);

                //рассчёт по формулам
                MyMatrix d1 = ShtrassenMultiplication(Sum(a11, a22), Sum(b11, b22));
                MyMatrix d2 = ShtrassenMultiplication(Sum(a21, a22), b11);
                MyMatrix d3 = ShtrassenMultiplication(a11, Subscrtract(b11, b22));
                MyMatrix d4 = ShtrassenMultiplication(a22, Subscrtract(b21, b11));
                MyMatrix d5 = ShtrassenMultiplication(Sum(a11, a12), b22);
                MyMatrix d6 = ShtrassenMultiplication(Subscrtract(a21, a11), Sum(b11, b12));
                MyMatrix d7 = ShtrassenMultiplication(Subscrtract(a12, a22), Sum(b21, b22));

                //рассчёт по формулам
                MyMatrix c11 = Sum(Sum(d1, d4), Subscrtract(d7, d5));
                MyMatrix c12 = Sum(d3, d5);
                MyMatrix c21 = Sum(d2, d4);
                MyMatrix c22 = Sum(Subscrtract(d1, d2), Sum(d3, d6));

                return PutTogethert(c11, c12, c21, c22);
            }

        }
        /// <summary>
        /// Функция умножения матриц методом Винограда
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public MyMatrix VinogradMultiplication(MyMatrix first, MyMatrix second)
        {
            MyMatrix ans = new MyMatrix(first.RowsCount, second.ColumnsCount);
            //𝐶𝑖,𝑗 = A𝑖(1×n) ∗ B𝑗(n×1) = (𝑎1 + 𝑏2) ∗ (𝑎2 + 𝑏1) + (𝑎3 + 𝑏4) ∗ (𝑎4 + 𝑏3) + A𝑖(n×4) + B𝑗(n×1)
            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int j = 0; j < second.ColumnsCount; j++)
                {
                    //поэлементно вносим в матрицу значения с вынесенным за пределы функций отрицанием
                    ans.Matrix[i, j] = - RowsChange(first, i+1)[i] - ColumnsChange(second, j+1)[j];

                    for (int k = 0; k < first.ColumnsCount / 2; k++)
                    {
                        //поэлементно перемножаем матрицы и вносим эти значения
                        //𝐶𝑖,𝑗 = A𝑖(1×n) ∗ B𝑗(n×1) = (𝑎1 + 𝑏2) ∗ (𝑎2 + 𝑏1) + (𝑎3 + 𝑏4) ∗ (𝑎4 + 𝑏3) + ...(𝑎n-1 + 𝑏n) ∗ (𝑎n + 𝑏n-1)... + A𝑖(n×4) + B𝑗(n×1)

                        ans.Matrix[i, j] += (first.Matrix[i, 2 * k] + second.Matrix[2 * k + 1, j]) * (first.Matrix[i, 2 *
                       k + 1] + second.Matrix[2 * k, j]);
                    }
                }
            }
            //в cлучае нечётной общей размерности
            if (first.ColumnsCount % 2 != 0) 
            {
                for (int i = 0; i < first.RowsCount; i++)
                {
                    for (int j = 0; j < second.ColumnsCount; j++)
                    {
                        ans.Matrix[i, j] += first.Matrix[i, first.ColumnsCount - 1] * second.Matrix[first.ColumnsCount - 1, j];
                    }
                }
            }
            return ans;
        }


        #endregion

        #region actions with matrix

        #region basic
        /// <summary>
        /// Функция для сложения матриц
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>матрицу, полученную в результате вычитания из первой второй матрицы</returns>
        public MyMatrix Sum(MyMatrix first, MyMatrix second)
        {
            if (CheckSameExist(first, second))
            {

                MyMatrix ans = new MyMatrix(first.RowsCount, first.ColumnsCount);
                for (int i = 0; i < first.RowsCount; i++)
                {
                    for (int j = 0; j < first.ColumnsCount; j++)
                    {
                        ans.Matrix[i, j] = first.Matrix[i, j] + second.Matrix[i, j];
                    }
                }
                return ans;
            }
            else
            {
                throw new Exception("Матрицы неодинакового размера нельзя сложить");
            }
        }
        /// <summary>
        /// Функция для вычитания матриц
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>матрицу, полученную в результате сложения первой и второй матриц</returns>
        public MyMatrix Subscrtract(MyMatrix first, MyMatrix second)
        {
            if (CheckSameExist(first, second))
            {
                MyMatrix ans = new MyMatrix(first.RowsCount, first.ColumnsCount);
                for (int i = 0; i < first.RowsCount; i++)
                {
                    for (int j = 0; j < first.ColumnsCount; j++)
                    {
                        ans.Matrix[i, j] = first.Matrix[i, j] - second.Matrix[i, j];
                    }
                }
                return ans;
            }
            else
            {
                throw new Exception("Матрицы неодинакового размера нельзя сложить");
            }
        }
            #endregion

        #region matrix in parts

        /// <summary>
        /// Функция, разделяющая матрицу на четверти
        /// </summary>
        /// <param name="a">целая матрица</param>
        /// <param name="a11">первая четверть матрицы</param>
        /// <param name="a12">вторая четверть матрицы</param>
        /// <param name="a21">третья четверть матрицы</param>
        /// <param name="a22">четвертая четверть матрицы</param>
        private void SplitToQuarters(MyMatrix a, out MyMatrix a11, out MyMatrix a12, out MyMatrix a21, out MyMatrix a22)
        {
            int n = a.Order;

            a11 = a.CopyWithIndex(0, 0, n / 2, n / 2);
            a12 = a.CopyWithIndex(0, n / 2, n / 2, n);
            a21 = a.CopyWithIndex(n / 2, 0, n, n / 2);
            a22 = a.CopyWithIndex(n / 2, n / 2, n, n);

        }

        /// <summary>
        /// Функция, соединяющая четверти матрицы в единую
        /// </summary>
        /// <param name="a11">первая четверть матрицы</param>
        /// <param name="a12">вторая четверть матрицы</param>
        /// <param name="a21">третья четверть матрицы</param>
        /// <param name="a22">четвертая четверть матрицы</param>
        /// <returns>целая, собранная из четвертей, матрица</returns>
        private MyMatrix PutTogethert(MyMatrix a11, MyMatrix a12, MyMatrix a21, MyMatrix a22)
        {
            int n = a11.Order;
            MyMatrix a = new MyMatrix(n * 2, n * 2);

            a11.CopyWithIndexBack(a, 0, 0, n, n);
            a12.CopyWithIndexBack(a, 0, n, n, n * 2);
            a21.CopyWithIndexBack(a, n, 0, n * 2, n);
            a22.CopyWithIndexBack(a, n, n, n * 2, n * 2);
            return a;
        }
        #endregion

        #region for Vinograd
        /// <summary>
        /// Функция, преобразующая строку в значение по формуле: 
        /// A𝑖(1, n) = (𝑎1, 𝑎2, 𝑎3, 𝑎4,...n-1, n) = −𝑎1 ∗ 𝑎2 − 𝑎3 ∗ 𝑎4 ... − (n-1 ∗ n)
        /// </summary>
        /// <param name="matrix">матрица, из которой нужно преобразовать строку</param>
        /// <param name="cRows">индекс преобразуемой строки матрицы</param>
        /// <returns>массив, содержащий преобразованную строку</returns>
        public float[] RowsChange(MyMatrix matrix, int cRows)
        {             
            float[] ans = new float[cRows];
            for (int i = 0; i < cRows; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount/2; j++)
                {
                    ans[i] += matrix.Matrix[i, 2 * j] * matrix.Matrix[i, 2 * j + 1];
                }
            }
            return ans;
        }

        /// <summary>
        /// Функция, преобразующая столбец в значение по формуле: 
        /// B𝑖(n,1) =
        ///      (𝑏1,
        ///       𝑏2,
        ///       𝑏3,
        ///       𝑏4,
        ///       ...
        ///       n-1,
        ///       n)
        ///= −𝑏1 ∗ 𝑏2 − 𝑏3 ∗ 𝑏4 ... − (n-1 ∗ n)
        /// </summary>
        /// <param name="matrix">матрица, из которой нужно преобразовать столбец</param>
        /// <param name="cColumns">индекс преобразуемого столбца матрицы</param>
        /// <returns>массив, содержащий преобразованный столбец</returns>
        public float[] ColumnsChange(MyMatrix matrix, int cColumns)
        {
            float[] ans = new float[cColumns];
            for (int i = 0; i < cColumns; i++)
            {
                for (int j = 0; j < matrix.ColumnsCount / 2; j++)        
                {
                    ans[i] += matrix.Matrix[2 * j, i] * matrix.Matrix[2 * j + 1, i];
                }
            }
            return ans;
        }
        #endregion


        #endregion

        #region for equal matrix
        /// <summary>
        /// Функция уравнивания квадратных матриц путем приведения к единому порядку
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <param name="withpow">наличие необходимости получения порядка в виде степени двойки: 1 - есть, 0 - нет </param>
        /// <returns>массив, состоящий из двух приведенных к общему порядку матриц (первая, вторая)</returns>
        public MyMatrix[] ToBalance(MyMatrix first, MyMatrix second, bool withpow)
        {
            MyMatrix[] matrices = new MyMatrix[2];

            int order = withpow ? GetCommonOrderPowTwo(first, second) : GetCommonOrder(first, second);
            matrices[0] = first.ToSquare(order);
            matrices[1] = second.ToSquare(order);

            return matrices;
        }

        /// <summary>
        /// Функция получения общего порядка матриц
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>необходимый общий порядок двух матриц</returns>
        private int GetCommonOrder(MyMatrix first, MyMatrix second)
        {
            return Math.Max(first.ToSquare().Order, second.ToSquare().Order);
        }

        /// <summary>
        /// Функция получения наиболее приближенного значения, равному степени двойки к изначальному значению 
        /// общего порядка матриц
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>общий порядок матриц, равный степени двойки</returns>
        private int GetCommonOrderPowTwo(MyMatrix first, MyMatrix second)
        {
            int order = GetCommonOrder(first, second);
            double i = 1;
            while (order > Math.Pow(i, 2))
            {
                i++;
            }
            return (int)Math.Pow(i, 2);
        }
        #endregion

    }
}

