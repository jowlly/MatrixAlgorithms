using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private MyMatrix classicResult;
        public MyMatrix ClassicResult { get => classicResult; set => classicResult = value; }

        private MyMatrix shtrassenResult;
        public MyMatrix ShtrassenResult { get => shtrassenResult; set => shtrassenResult = value; }

        private MyMatrix vinogradResult;
        public MyMatrix VinogradResult { get => vinogradResult; set => vinogradResult = value; }

        private MyMatrix fourrussiansResult;
        public MyMatrix FourRussiansResult { get => fourrussiansResult; set => fourrussiansResult = value; }

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
        /// <summary>
        /// Проверка на то, является ли заданное число степенью двойки
        /// </summary>
        /// <param name="n">заданное число</param>
        /// <returns>true - если да, false - если нет</returns>
        private bool IsPowOfTwo(int n)
        {
            double log = Math.Log(n, 2);
            return (log - Math.Truncate(log) == 0);
        }

        #endregion

        #region timers

        public double ClassicTimer(MyMatrix first, MyMatrix second)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ClassicResult = ClassicMultiplication(first, second);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalSeconds;
        }

        public double ShtrassenTimer(MyMatrix first, MyMatrix second)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ShtrassenResult = ShtrassenMultiplication(first, second);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalSeconds;
        }

        public double VinogradTimer(MyMatrix first, MyMatrix second)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            VinogradResult = VinogradMultiplication(first, second);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalSeconds;
        }

        public double FourRussiansTimer(MyMatrix first, MyMatrix second)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            FourRussiansResult = FourRussiansMultiplication(first, second);

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalSeconds;
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
                n /= 2;

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
                MyMatrix d3 = ShtrassenMultiplication(a11, Subscrtract(b12, b22));
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
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>матрицу, полученную в результате перемножения первой и второй матриц</returns>
        public MyMatrix VinogradMultiplication(MyMatrix first, MyMatrix second)
        {
            int del = first.ColumnsCount / 2;
            MyMatrix ans = new MyMatrix(first.RowsCount, second.ColumnsCount);

            float[] rows = RowsChange(first, first.RowsCount, del);
            float[] columns = ColumnsChange(second, second.ColumnsCount, del);

            //𝐶𝑖,𝑗 = A𝑖(1×n) ∗ B𝑗(n×1) = (𝑎1 + 𝑏2) ∗ (𝑎2 + 𝑏1) + (𝑎3 + 𝑏4) ∗ (𝑎4 + 𝑏3) + A𝑖(n×4) + B𝑗(n×1)
            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int j = 0; j < second.ColumnsCount; j++)
                {
                    //поэлементно вносим в матрицу значения с вынесенным за пределы функций отрицанием
                    ans.Matrix[i, j] = -rows[i] - columns[j];

                    for (int k = 0; k < del; k++)
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

        /// <summary>
        /// Функция умножения матриц методом четырёх русских
        /// </summary>
        /// <param name="first">первая матрица</param>
        /// <param name="second">вторая матрица</param>
        /// <returns>матрицу, полученную в результате перемножения первой и второй матриц</returns>
        public MyMatrix FourRussiansMultiplication(MyMatrix first, MyMatrix second)
        {
            int k = (int)Math.Log(first.ColumnsCount, 2);
            
            while (first.ColumnsCount % k != 0) //если не получается разделить на целые части
            {
                first = first.AddColumn();
                second = second.AddRow();
            }

            MyMatrix bin = new MyMatrix((int)Math.Pow(2, k), (int)Math.Pow(2, k));
            bin = NewMatrixBin(bin, k);

            MyMatrix a = NewMatrixRows(first, k);
            MyMatrix b = NewMatrixColumns(second, k);
            MyMatrix c = new MyMatrix(first.RowsCount, second.ColumnsCount);

            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int m = 0; m < second.ColumnsCount; m++)
                {
                    for (int n = 0; n < second.ColumnsCount / k; n++)
                    {
                        c.Matrix[i, m] += bin.Matrix[(int)a.Matrix[i, n], (int)b.Matrix[n, m]];
                    }
                    c.Matrix[i,m] = c.Matrix[i,m] % 2;
                }
            }
            return c;
        }

        /// <summary>
        /// функция, запускающая все алгоритмы с дополнительными дообразовниями, если требуется и замером времени
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="res1"></param>
        /// <param name="res2"></param>
        /// <param name="res3"></param>
        /// <param name="res4"></param>
        public void Multiplication(MyMatrix first, MyMatrix second, 
            out MyMatrix res1, out MyMatrix res2, out MyMatrix res3, out MyMatrix res4,
            out double restime1, out double restime2, out double restime3, out double restime4)
        {
            MyMatrix ans1 = new MyMatrix();
            MyMatrix ans2 = new MyMatrix();
            MyMatrix ans3 = new MyMatrix();
            MyMatrix ans4 = new MyMatrix();

            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();
            Stopwatch stopwatch4 = new Stopwatch();

            double time1 = new double();
            double time2 = new double();
            double time3 = new double();
            double time4 = new double();

            if (CheckMultiplicationExist(first, second)) //любая матрица на любую матрицу, если умножение возможно
            {
                stopwatch1.Start();

                ans1 = ClassicMultiplication(first, second);

                stopwatch1.Stop();
                //time1 = stopwatch1.Elapsed.TotalMilliseconds;
                time1 = stopwatch1.Elapsed.TotalSeconds;

                stopwatch3.Start();

                ans3 = VinogradMultiplication(first, second);

                stopwatch3.Stop();
                //time3 = stopwatch3.Elapsed.TotalMilliseconds;
                time3 = stopwatch3.Elapsed.TotalSeconds;

                stopwatch4.Start();

                ans4 = FourRussiansMultiplication(first.ToOneZero(), second.ToOneZero());

                stopwatch4.Stop();
                //time4 = stopwatch4.Elapsed.TotalMilliseconds;
                time4 = stopwatch4.Elapsed.TotalSeconds;

                if (first.IsSquare && second.IsSquare) //обе матрицы квадратные
                {
                    if (CheckSameExist(first, second) && IsPowOfTwo(first.ColumnsCount)) //у матриц общий одинаковый порядок, который является степенью двойки
                    {
                        
                        stopwatch2.Start();

                        ans2 = ShtrassenMultiplication(first, second);

                        stopwatch2.Stop();
                        //time2 = stopwatch2.Elapsed.TotalMilliseconds;
                        time2 = stopwatch2.Elapsed.TotalSeconds;
                    }

                    else
                    {
                        MyMatrix newfirst = ToBalance(first, second, true)[0];
                        MyMatrix newsecond = ToBalance(first, second, true)[1];

                        stopwatch2.Start();

                        ans2 = ShtrassenMultiplication(newfirst, newsecond);

                        stopwatch2.Stop();

                        //time2 = stopwatch2.Elapsed.TotalMilliseconds;
                        time2 = stopwatch2.Elapsed.TotalSeconds;
                    }
                }
                else
                {

                    first.ToSquare();
                    second.ToSquare();
                    if (CheckSameExist(first, second) && IsPowOfTwo(first.ColumnsCount))
                    {
                        stopwatch2.Start();

                        ans2 = ShtrassenMultiplication(first, second);

                        stopwatch2.Stop();
                        //time2 = stopwatch2.Elapsed.TotalMilliseconds;
                        time2 = stopwatch2.Elapsed.TotalSeconds;
                    }
                    else
                    {
                        MyMatrix newfirst2 = ToBalance(first, second, true)[0];
                        MyMatrix newsecond2 = ToBalance(first, second, true)[1];

                        stopwatch2.Start();

                        ans2 = ShtrassenMultiplication(newfirst2, newsecond2);

                        stopwatch2.Stop();

                        //time2 = stopwatch2.Elapsed.TotalMilliseconds;
                        time2 = stopwatch2.Elapsed.TotalSeconds;
                    }
                }
            }
            else
            {
                ans1 = new MyMatrix();
                ans2 = new MyMatrix();
                ans3 = new MyMatrix();
                ans4 = new MyMatrix();
            }

            res1 = ans1;
            res2 = ans2;
            res3 = ans3;
            res4 = ans4;

            restime1 = time1;
            restime2 = time2;
            restime3 = time3;
            restime4 = time4;
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
        public float[] RowsChange(MyMatrix matrix, int cRows, int del)
        {             
            float[] ans = new float[cRows];
            for (int i = 0; i < cRows; i++)
            {
                for (int j = 0; j < del; j++)
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
        public float[] ColumnsChange(MyMatrix matrix, int cColumns, int del)
        {
            float[] ans = new float[cColumns];
            for (int i = 0; i < cColumns; i++)
            {
                for (int j = 0; j < del; j++)        
                {
                    ans[i] += matrix.Matrix[2 * j, i] * matrix.Matrix[2 * j + 1, i];
                }
            }
            return ans;
        }
        #endregion

        #region for FourRussians
        /// <summary>
        /// Функция создания новой матрицы путем деления каждой её строки на блоки размера k
        /// </summary>
        /// <param name="row">матрица для преобразований</param>
        /// <param name="k"></param>
        /// <returns></returns>
        public MyMatrix NewMatrixRows(MyMatrix row, int k)
        {
            MyMatrix ans = new MyMatrix(row.RowsCount, row.ColumnsCount / k);

            for (int i = 0; i < row.RowsCount; i++)
            {
                int index = 0;
                for (int m = 0; m < row.ColumnsCount; m += k)
                {
                    for (int n = 0; n < k; n++)
                    {
                        if (row.Matrix[i, m + n] == 1)
                            ans.Matrix[i, index] += (int)Math.Pow(2, k - 1 - n);
                        //00 = 0, 01 = 1, 10 = 2, 11 = 3 и тд.
                    }
                    index++;
                }
            }
            return ans;
        }

        /// <summary>
        /// Функция создания новой матрицы путем деления каждого её столбца на блоки размера k
        /// </summary>
        /// <param name="col">матрица для преобразований</param>
        /// <param name="k"></param>
        /// <returns></returns>
        private MyMatrix NewMatrixColumns(MyMatrix col, int k)
        {
            MyMatrix ans = new MyMatrix(col.RowsCount / k, col.ColumnsCount);
            for (int m = 0; m < col.ColumnsCount; m++)
            {
                int index = 0;
                for (int i = 0; i < col.RowsCount; i += k)
                {
                    for (int n = 0; n < k; n++)
                    {
                        if (col.Matrix[i + n, m] == 1)
                            ans.Matrix[index, m] += (int)Math.Pow(2, k - 1 - n);
                        //00 = 0, 01 = 1, 10 = 2, 11 = 3 и тд.
                    }
                    index++;
                }
            }
            return ans;
        }
        /// <summary>
        /// Преподсчёт скалярных произведений
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        int OneOrZero(int number1, int number2, int k)

        {
            int count = 0;
            //побитовая конъюнкция чисел
            int number = number1 & number2;
            //количество единиц в бинарной записи
            for (int i = 0; i < k; i++)
            {
                count += (number >> i) & 1;
            }
            return count % 2;
        }
        /// <summary>
        /// Вспомогательная матрица для предподсчёта скалярных произведений
        /// </summary>
        /// <param name="resmatrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private MyMatrix NewMatrixBin(MyMatrix resmatrix, int k)
        {
            int size = (int)Math.Pow(2, k);
            //заполняем таблицу произведений всех возможных бинарных кусочков длины k
            for (int i = 0; i < size; i++)
            {
                for (int m = 0; m < size; m++)
                {
                    resmatrix.Matrix[i, m] = OneOrZero(i, m, k);
                }
            }
            return resmatrix;
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
            int i = 2;
            while (order > i)
            {
               i *= 2;
            }

           return i;

        }
        #endregion

    }
}

