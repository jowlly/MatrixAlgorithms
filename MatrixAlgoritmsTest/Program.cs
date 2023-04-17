using MatrixAlgoritmsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAlgoritmsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix matrix1 = new MyMatrix(4);
            MyMatrix matrix2 = new MyMatrix(4);
            MyMatrix matrix3 = new MyMatrix(1, 2);
            MyMatrix matrix4 = new MyMatrix(4, 4);
            matrix1.FillMatrix(new float[4, 4]
            {
                { 1, 2, 3, 0},
                { 3, 4, 3, 0},
                { 3, 3, 3, 0},
                { 0, 0, 0, 0},

            });
            //    { 1, 2, 3, 4},
            //    { 3, 4, 3, 4},
            //    { 3, 3, 3, 4},
            //    { 1, 2, 1, 2 },
            //    { 1, 2, 3},
            //    { 3, 4, 3},
            //    { 3, 3, 3},

            matrix2.FillMatrix(new float[4, 4]
            {
                { 1, 2, 1, 0},
                { 1, 2, 1, 0},
                { 1, 2, 1, 0},
                { 0, 0, 0, 0},
            });
            //    { 1, 2, 1, 2 },
            //    { 1, 2, 1, 2 },
            //    { 1, 2, 1, 2 },
            //    { 1, 2, 1, 2 },
            matrix3.FillMatrix(new float[1, 2]
            {
                { 0, 1 },

            });

            matrix4.FillMatrix(new float[4, 4]
            {
               { 1, 1, 0, 1 },
               { 1, 0, 1, 0 },
                { 0, 0, 1, 0 },
                { 1, 0, 0, 0 },
            });
            //if (Algorithms.CheckMultiplicationExict(matrix1, matrix2))
            //{
            //    Console.WriteLine(Algorithms.NaiveMultiplication(matrix1, matrix2).ToString());
            //}
            //else Console.WriteLine("Умножение невозможно");

            //Console.WriteLine(matrix2.ToSquare(3).ToString());

            Algorithms algorithms = new Algorithms();

            //MyMatrix[] balanced = algorithms.ToBalance(matrix1, matrix2);
            //Console.WriteLine (balanced[0].ToString());
            //Console.WriteLine(balanced[1].ToString());

            //Console.WriteLine(algorithms.GetOrderPowTwo(matrix1, matrix2));

            //Console.WriteLine(algorithms.Sum(matrix1, matrix3).ToString());
            //Console.WriteLine(matrix1.CopyWithIndex(0, 0,  2, 2));

            Console.WriteLine(algorithms.ShtrassenMultiplication(matrix1, matrix2).ToString());
            //Console.WriteLine(algorithms.VinogradMultiplication(matrix1, matrix2).ToString());
            //Console.WriteLine(algorithms.FourRussiansMultiplication(matrix1, matrix2).ToString());

            //Console.WriteLine(algorithms.NewMatrixRows(matrix4,(int)Math.Log(matrix4.ColumnsCount, 2)).ToString());

            MyMatrix res1 = new MyMatrix();
            MyMatrix res2 = new MyMatrix();
            MyMatrix res3 = new MyMatrix();
            MyMatrix res4 = new MyMatrix();

            algorithms.Multiplication(matrix1, matrix2, out res1, out res2, out res3, out res4);
            Console.WriteLine( "Итеративный алгоритм: \n"+ res1.ToString() + "\n" +
                "Алгоритм Штрассена: \n" + res2.ToString() + "\n" +
                "Алгоритм Винограда: \n" + res3.ToString() + "\n" +
                "Алгоритм 4 русских: \n" + res4.ToString() + "\n"
                );

            Console.ReadKey();

        }

   
    }
}
