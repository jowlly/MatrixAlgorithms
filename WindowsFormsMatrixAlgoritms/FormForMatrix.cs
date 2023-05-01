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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsMatrixAlgoritms
{
    public partial class FormForMatrix : Form
    {
        const int step = 2;

        int maxMatrixOrder;

        private List<MyMatrix> matrixList;
        public List<MyMatrix> MatrixList { get=> matrixList; set=> matrixList=value; }
        public int MaxMatrixOrder { get => maxMatrixOrder; set => maxMatrixOrder = value; }

        public FormForMatrix()
        {
           
            InitializeComponent();

        }

        private void ToChart()
        {
            MatrixList = InitializeMatrixList(MaxMatrixOrder, step);
            int startOffset = 0;
            int endOffset = 4;
            foreach (MyMatrix matrix in MatrixList)
            {
                Algorithms algorithms = new Algorithms();

                chartMatrix.Series[0].Points.Add(new DataPoint(matrix.Order, algorithms.ClassicTimer(matrix, matrix)));
                chartMatrix.Series[1].Points.Add(new DataPoint(matrix.Order, algorithms.ShtrassenTimer(matrix, matrix)));
                chartMatrix.Series[2].Points.Add(new DataPoint(matrix.Order, algorithms.VinogradTimer(matrix, matrix)));
                chartMatrix.Series[3].Points.Add(new DataPoint(matrix.Order, algorithms.FourRussiansTimer(matrix, matrix)));

                //chartMatrix.ChartAreas[0].AxisX.CustomLabels.Add(new CustomLabel(startOffset, endOffset, Convert.ToString(matrix.Order), 0, LabelMarkStyle.None));
                //startOffset+=5;
                //endOffset+=5;
            }
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

            for (int i = start; i <= maxMatrixOrder; i*=step)
            {
                matrixList.Add(ans.CreateRandomSquareMatrix(i));

            }
            return matrixList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearChart();

            MaxMatrixOrder = int.Parse(textBoxFirstMatrix.Text);
            int orderF = int.Parse(textBoxFirstMatrix.Text);
            int orderS = int.Parse(textBoxSecondMatrix.Text);

            ToChart();

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

        private void ClearChart()
        {
            chartMatrix.Series[0].Points.Clear();
            chartMatrix.Series[1].Points.Clear();
            chartMatrix.Series[2].Points.Clear();
            chartMatrix.Series[3].Points.Clear();
        }
    }
}
