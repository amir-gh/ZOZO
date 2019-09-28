using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOZO_Test
{
    class GaussianElimination
    {

        /// <summary>
        /// Task 2 - This function gets the input matrix and the b matrix and solves the system of linear equation.
        /// </summary>
        /// <param name="inputMatrix"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double[] PerformGaussianElimination(double[,] inputMatrix, double[] b)
        {
            if (inputMatrix.GetLength(0) != inputMatrix.GetLength(1))
            {
                Console.WriteLine("Please enter a sqaure matrix");
                return null;
            }
            else
            {
                double[,] A = MakeAugmentedMatrix(inputMatrix, b);
                RowEchelon rowEchelon = new RowEchelon();
                var rowEchelonForm = rowEchelon.ConvertToRowEchelonForm(A);

                // Back Substitution
                double[] x = PerformBackSubstitution(rowEchelonForm);

                return x;
            }
        }

        private double[] PerformBackSubstitution(double[,] rowEchelonForm)
        {
            int m = rowEchelonForm.GetLength(0);

            double[] x = new double[m]; // the size of x should be the same as the number of equations (i.e. the number of rows in A)
            for (int i = m - 1; i >= 0; i--) // in reverse order
            {
                double sum = 0;
                for (int j = i + 1; j < m - 1; j++)
                    sum += rowEchelonForm[i, j] * x[j];

                if (rowEchelonForm[i, i] == 0)
                    x[i] = 0;
                else
                    x[i] = 1.0 / rowEchelonForm[i, i] * (rowEchelonForm[i, m] - sum);
            }

            return x;
        }

        private double[,] MakeAugmentedMatrix(double[,] inputMatrix, double[] b)
        {
            double[,] A = new double[inputMatrix.GetLength(0), inputMatrix.GetLength(1) + 1];

            for (int i = 0; i < inputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inputMatrix.GetLength(1); j++)
                    A[i, j] = inputMatrix[i, j];
                A[i, inputMatrix.GetLength(1)] = b[i];
            }

            return A;
        }
    }
}
