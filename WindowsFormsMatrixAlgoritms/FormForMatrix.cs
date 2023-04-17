using MatrixAlgoritmsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMatrixAlgoritms
{
    public partial class FormForMatrix : Form
    {
        const int step = 10;
        const int maxMatrixOrder = 300;

        private List<MyMatrix> matrixList;
        public List<MyMatrix> MatrixList { get=> matrixList; set=> matrixList=value; }
        public FormForMatrix()
        {
            #region Initialization
            InitializeComponent();

            MatrixList = InitializeMatrixList(maxMatrixOrder,step);

            foreach(MyMatrix matrix in MatrixList)
            {
                Algorithms algorithms = new Algorithms();

                chartMatrix.Series[0].Points.Add(algorithms.ClassicTimer(matrix,matrix), matrix.Order);
                //chartMatrix.Series[1].Points.Add(matrix.Order, algorithms.ShtrassenTimer(matrix, matrix));
                //chartMatrix.Series[2].Points.Add(matrix.Order, algorithms.VinogradTimer(matrix, matrix));
                //chartMatrix.Series[3].Points.Add(matrix.Order, algorithms.FourRussiansTimer(matrix, matrix));

            }

            #endregion
        }

        /// <summary>
        /// Функция создания списка случайных матриц возрастающего порядка 
        /// </summary>
        /// <param name="maxMatrixOrder">максимальный порядок созданных матриц</param>
        /// <param name="step">шаг, на который увеличивается порядок матриц</param>
        /// <returns>список всех созданных матриц</returns>
        private List<MyMatrix> InitializeMatrixList(int maxMatrixOrder, int step)
        {
            List<MyMatrix> matrixList = new List<MyMatrix>();
            int start = step;

            MyMatrix ans = new MyMatrix();

            for (int i = start; i < maxMatrixOrder; i*=step)
            {
                matrixList.Add(ans.CreateRandomSquareMatrix(i));
            }
            return matrixList;
        }


    }
}
