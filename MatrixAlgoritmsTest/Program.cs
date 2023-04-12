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
            MyMatrix matrix1 = new MyMatrix(2);
            MyMatrix matrix2 = new MyMatrix(1,2);
            matrix1.FillMatrix(new float[2, 2] 
            { 
                { 1, 2 } , 
                { 3 ,4 } 
            });

            matrix2.FillMatrix(new float[1, 2] 
            { 
                { 1, 2 },

            });

            //if (Algorithms.CheckMultiplicationExict(matrix1, matrix2))
            //{
            //    Console.WriteLine(Algorithms.NaiveMultiplication(matrix1, matrix2).ToString());
            //}
            //else Console.WriteLine("Умножение невозможно");

            Console.WriteLine(matrix2.ToSquare(2).ToString());
            Algorithms.ToBalance(matrix1, matrix2);
            Console.WriteLine (matrix2.ToString());

            Console.ReadKey();

        }

   
    }
}
