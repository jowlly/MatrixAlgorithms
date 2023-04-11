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
            MyMatrix matrix = new MyMatrix(2);

            matrix.FillMatrix(new float[2, 2] 
            { 
                { 1, 2 } , 
                { 3 ,4 } 
            });

            Console.WriteLine(matrix.ToString());
            Console.ReadKey();

        }

    }
}
