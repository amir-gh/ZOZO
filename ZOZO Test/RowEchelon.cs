using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOZO_Test
{
    class RowEchelon
    {
        /// <summary>
        /// This is Task 1 where transforms an mxn matrix into row echelon form.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public double[,] ConvertToRowEchelonForm(double[,] A)
        {
            int h = 0;
            int k = 0;
            int m = A.GetLength(0); // for better readability I store it in a variable, otherwise the variables m and n are not needed.
            int n = A.GetLength(1);
            while (h < m && k < n)
            {
                int i_max = argmax(h, k, A);
                if (A[i_max, k] == 0)
                    k++;
                else
                {
                    SwapRows(h, i_max, ref A);
                    for (int i = h + 1; i < m; i++)
                    {
                        double f = A[i, k] / A[h, k];
                        A[i, k] = 0;
                        for (int j = k + 1; j < n; j++)
                            A[i, j] = A[i, j] - A[h, j] * f;
                    }
                    h++;
                    k++;
                }
            }

            return A;
        }

        private void SwapRows(int h, int i_max, ref double[,] A)
        {
            double tempValue;
            for (int i = 0; i < A.GetLength(1); i++)
            {
                tempValue = A[h, i];
                A[h, i] = A[i_max, i];
                A[i_max, i] = tempValue;
            }
        }

        private int argmax(int h, int k, double[,] A)
        {
            double max = A[h, k];
            int i_max = h;
            for (int i = h; i < A.GetLength(0); i++)
            {
                if (Math.Abs(A[i, k]) > max)
                {
                    max = Math.Abs(A[i, k]);
                    i_max = i;
                }
            }

            return i_max;
        }
    }
}
