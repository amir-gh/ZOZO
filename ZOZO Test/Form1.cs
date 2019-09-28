using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZOZO_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double[,] A = new double[,] { { 3, 9, 3 }, { 3, 3, -3 }, { 9, 33, 15 } };
            double[] b = new double[] { 27, 3, 105 };

            GaussianElimination gaussianElimination = new GaussianElimination();
            double[] x = gaussianElimination.PerformGaussianElimination(A, b);


            // validate
            double[] result = new double[x.Length];
            bool equal = true;
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    result[i] += A[i, j] * x[j];

                if (result[i] != b[i])
                    equal = false;
            }
        }
    }
}
