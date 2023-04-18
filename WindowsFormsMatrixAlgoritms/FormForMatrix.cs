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

        private void button1_Click(object sender, EventArgs e)
        {
            int orderF = int.Parse(textBoxFirstMatrix.Text);
            int orderS = int.Parse(textBoxSecondMatrix.Text);
            MyMatrix first = new MyMatrix();
            MyMatrix second = new MyMatrix();

            MyMatrix res1 = new MyMatrix();
            MyMatrix res2 = new MyMatrix();
            MyMatrix res3 = new MyMatrix();
            MyMatrix res4 = new MyMatrix();

            double t1 = new double();
            double t2 = new double();
            double t3 = new double();
            double t4 = new double();

            first = first.CreateRandomSquareMatrix(orderF);
            second = second.CreateRandomSquareMatrix(orderS);

            Algorithms algorithms = new Algorithms();
            algorithms.Multiplication(first, second, out res1, out res2, out res3, out res4, out t1, out t2, out t3, out t4);

            textBox1.Text = t1.ToString();
            textBox2.Text = t2.ToString();
            textBox3.Text = t3.ToString();
            textBox4.Text = t4.ToString();
        }
    }
}
