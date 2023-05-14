using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsAppCourseWork
{
    public class MatrixTools : Form1
    {

        public static int[] MatrixVector(int[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            int[] vector = new int[n];

            for (int i = 0; i < n; i++)
            {
                vector[i] = array[i, m - 1];
            }
            return vector;
        }

        public static int[,] Matrix(int[,] array)
        {
            int[,] matrix = new int[array.GetLength(0), array.GetLength(1) - 1];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    matrix[i, j] = array[i, j];
                }
            }
            return matrix;
        }

    }
}