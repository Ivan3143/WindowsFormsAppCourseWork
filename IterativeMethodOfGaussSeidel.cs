using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsAppCourseWork
{
    public class IterativeMethodOfGaussSeidel : Form1
    {

        public static double[] GaussSeidel(int[,] matrix, int[] vector, int maxIterations, double epsilon, double[] x)
        {
            int iteration = 0;
            double[] Xprevious = new double[x.Length];
            double[,] doubleMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double[] doubleVector = Array.ConvertAll(vector, q => (double)q);
            double delta = 0.0000000000;
            int decimalPlaces = 0;

            while (epsilon % 1 != 0)
            {
                epsilon *= 10;
                decimalPlaces++;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    doubleMatrix[i, j] = (double)matrix[i, j];
                }
            }
            //Итерация
            while (iteration < maxIterations)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    Xprevious[i] = x[i];
                }
                for (int i = 0; i < vector.Length; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < vector.Length; j++)
                    {
                        if (j != i)
                            sum += doubleMatrix[i, j] * x[j];
                    }
                    x[i] = (doubleVector[i] - sum) / doubleMatrix[i, i];
                }
                for (int i = 0; i < vector.Length; i++)
                {
                    delta += Math.Abs(x[i] - Xprevious[i]);
                }
                if (delta < epsilon)
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        if (x[i] - Math.Round(x[i]) == 0.99999 && x[i] - Math.Round(x[i]) == 0)
                        {
                            for (int k = 0; k < vector.Length; i++)
                            {
                                x[k] = Math.Round(x[k], decimalPlaces);
                            }
                            iteration = maxIterations;
                        }
                    }
                }
                iteration++;
            }
            return x;
        }

        public static bool DiagonallyDominant(int[,] matrix)
        {
            bool diagonal = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(matrix[i, j]);
                    }
                }
                if (Math.Abs(matrix[i, i]) >= sum)
                {
                    diagonal = true;
                }
                else
                {
                    diagonal = false;
                    break;
                }
            }
            return diagonal;
        }

        public static int Iteration(int[,] matrix, int[] vector, int maxIterations, double epsilon, double[] x)
        {
            int iteration = 0;
            double[] Xprevious = new double[x.Length];
            double[,] doubleMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            double[] doubleVector = Array.ConvertAll(vector, q => (double)q);
            double delta = 0.0000000000;
            int ert = 0;
            int decimalPlaces = 0;

            while (epsilon % 1 != 0)
            {
                epsilon *= 10;
                decimalPlaces++;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    doubleMatrix[i, j] = (double)matrix[i, j];
                }
            }
            //Итерация
            while (iteration < maxIterations)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    Xprevious[i] = x[i];
                }
                for (int i = 0; i < vector.Length; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < vector.Length; j++)
                    {
                        if (j != i)
                            sum += doubleMatrix[i, j] * x[j];
                    }
                    x[i] = (doubleVector[i] - sum) / doubleMatrix[i, i];
                }
                for (int i = 0; i < vector.Length; i++)
                {
                    delta += Math.Abs(x[i] - Xprevious[i]);
                }
                ert++;
                iteration++;
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] - Math.Round(x[i]) == 0.99999 || x[i] - Math.Round(x[i]) == 0.00000)
                    {
                        if (delta < epsilon)
                        {
                            for (int k = 0; k < x.Length; i++)
                            {
                                x[k] = Math.Round(x[k], decimalPlaces);
                            }
                            iteration = maxIterations;
                        }
                    }
                }
            }
            return ert;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // IterativeMethodOfGaussSeidel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1033, 519);
            this.Name = "IterativeMethodOfGaussSeidel";
            this.Load += new System.EventHandler(this.IterativeMethodOfGaussSeidel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void IterativeMethodOfGaussSeidel_Load(object sender, EventArgs e)
        {

        }
    }
}