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
            MyMatrix matrix1 = new MyMatrix(3);
            MyMatrix matrix2 = new MyMatrix(3);
            MyMatrix matrix3 = new MyMatrix(1, 2);
            matrix1.FillMatrix(new float[3, 3]
            {
                { 1, 2, 3},
                { 3, 4, 3},
                { 3, 3, 3},

            });
            //    { 1, 2, 3, 4},
            //    { 3, 4, 3, 4},
            //    { 3, 3, 3, 4},
            //    { 1, 2, 1, 2 },

            matrix2.FillMatrix(new float[3, 3]
            {
                { 1, 2, 1},
                { 1, 2, 1},
                { 1, 2, 1},


            });
            //    { 1, 2, 1, 2 },
            //    { 1, 2, 1, 2 },
            //    { 1, 2, 1, 2 },
            //    { 1, 2, 1, 2 },
            matrix3.FillMatrix(new float[1, 2]
            {
                { 2, 1 },

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
            
            //Console.WriteLine(algorithms.ShtrassenMultiplication(matrix1, matrix2).ToString());
            Console.WriteLine(algorithms.VinogradMultiplication(matrix1, matrix2).ToString());
            

            Console.ReadKey();

        }

   
    }
}
