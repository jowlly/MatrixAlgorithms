using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAlgoritmsLibrary
{
    public class Algorithms
    {
        ///// <summary>
        /////  
        ///// если число столбцов в первом сомножителе равно числу строк во втором
        ///// </summary>
        ///// <param name="first"></param>
        ///// <param name="sekond"></param>
        ///// <returns></returns>
        //public MyMatrix CheckMultiplicationExict(MyMatrix first, MyMatrix sekond)
        //{
        //    if (first.ColumnsCount == sekond.RowsCount)
        //        return new MyMatrix(first.RowsCount, sekond.ColumnsCount);
        //    else
        //        return null;
        //}

        /// <summary>
        ///  
        /// если число столбцов в первом сомножителе равно числу строк во втором
        /// </summary>
        /// <param name="first"></param>
        /// <param name="sekond"></param>
        /// <returns></returns>
        public static bool CheckMultiplicationExict(MyMatrix first, MyMatrix sekond)
        {
            if (first.ColumnsCount == sekond.RowsCount)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Итеративный алгоритм умножения матриц. Сложность (О)n3
        /// </summary>
        /// <param name="first"></param>
        /// <param name="sekond"></param>
        /// <returns></returns>
        public static MyMatrix NaiveMultiplication(MyMatrix first, MyMatrix sekond)
        {
            MyMatrix ans = new MyMatrix(first.RowsCount, sekond.ColumnsCount);

            for (int i = 0; i < first.RowsCount; i++)
            {
                for (int j = 0; j < sekond.ColumnsCount; j++)
                {
                    ans.Matrix[i, j] = 0;

                    for (int k = 0; k < first.ColumnsCount; k++)
                    {
                        ans.Matrix[i, j] += first.Matrix[i, k] * sekond.Matrix[k, j];
                    }
                }
            }
            return ans;
        }
        /// <summary>
        /// Функция  уравнивания квадратных матриц к единому порядку
        /// </summary>
        /// <param name="first"></param>
        /// <param name="sekond"></param>
        public static void ToBalance(MyMatrix first, MyMatrix sekond)
        {
            int order = Math.Max(first.ToSquare().RowsCount, sekond.ToSquare().RowsCount);
            //if (first.ToSquare().RowsCount < sekond.ToSquare().RowsCount ? first.ToSquare(order) : sekond.ToSquare(order); 
            first.ToSquare(order);
            sekond = sekond.ToSquare(order);
        }


    }
}
