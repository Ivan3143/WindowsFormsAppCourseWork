using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;


namespace WindowsFormsAppCourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Database Database
        {
            get => default;
            set
            {
            }
        }

        public bool needDB = false;
        public string output = "";
        public string input = "";
        public string strVector = "";
        public string status = "";

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int iter = 0;
            //===========Обработка данных===============

            int rowsCount = dataGridView1.Rows.Count;
                int columnsCount = dataGridView1.Columns.Count;
            if (columnsCount > 0)
            {
                int[] vector = new int[dataGridView1.Columns.Count];
                int[,] array = new int[rowsCount, columnsCount];
                int[,] matrix = new int[rowsCount, columnsCount - 1];
                int maxIterations = 0;
                double epsilon = 0;
                try
                {
                     maxIterations = Convert.ToInt32(textBox1.Text);
                     epsilon = Convert.ToDouble(textBox2.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = "не решено";
                    richTextBox1.Text += "==========================\n";
                    richTextBox1.Text += "Невозможно обработкать систему\n";
                    richTextBox1.Text += "==========================\n";
                    if (needDB == true)
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            CollectionSolutions cs = new CollectionSolutions { Matricx = $"{input}", Vector = $"{strVector}", DateTimeSol = DateTime.Now, Solution = "Условие диагонального преобладаня не выполнено.", Status = "не решено" };
                            db.CollectionSolutions.Add(cs);
                            db.SaveChanges();
                        }
                    }
                    return;
                }
                double[] decision = new double[columnsCount];
                double[] x = new double[columnsCount - 1];

                //Заполнение масссива первоначальными приближениями
                for (int i = 0; i < columnsCount - 1; i++)
                {
                    x[i] = 0.0;
                }
                try
                {
                    //Заполение массива из dataGridView1
                    for (int i = 0; i < rowsCount; i++)
                    {
                        for (int j = 0; j < columnsCount; j++)
                        {
                            array[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = "не решено";
                    richTextBox1.Text += "==========================\n";
                    richTextBox1.Text += "Невозможно обработкать систему\n";
                    richTextBox1.Text += "==========================\n";
                    if (needDB == true)
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            CollectionSolutions cs = new CollectionSolutions { Matricx = $"{input}", Vector = $"{strVector}", DateTimeSol = DateTime.Now, Solution = "Условие диагонального преобладаня не выполнено.", Status = "не решено" };
                            db.CollectionSolutions.Add(cs);
                            db.SaveChanges();
                        }
                    }
                    return;
                }

                // Оповещение пользователя о начале обработки массива
                richTextBox1.Text += "===================\n";
                richTextBox1.Text += "Обработка системы:";
                richTextBox1.Text += Environment.NewLine;

                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < columnsCount; j++)
                    {
                        if (columnsCount - 1 == j)
                        {
                            richTextBox1.Text += " = " + array[i, j].ToString() + " ";
                        }
                        else
                        {
                            richTextBox1.Text += array[i, j].ToString() + $"*x{j + 1} ";
                        }
                    }
                    richTextBox1.Text += Environment.NewLine;
                }
                richTextBox1.Text += Environment.NewLine;
                // Решение систем

                vector = MatrixTools.MatrixVector(array);
                matrix = MatrixTools.Matrix(array);
                
                richTextBox1.Text += "Уравнение имеет коэффициенты при неизвестных:";
                richTextBox1.Text += Environment.NewLine;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int a = i;
                        int b = j;
                        input += $" a{a + 1}{b + 1}= " + matrix[i, j].ToString();
                    }
                    input += "\n";
                }
                input = input.TrimEnd(',');
                richTextBox1.Text += input;
                richTextBox1.Text += Environment.NewLine;

                richTextBox1.Text += "Уравнение имеет свободные члены:";
                richTextBox1.Text += Environment.NewLine;
                for (int i = 0; i < vector.Length; i++)
                {
                    int a = i;
                    strVector += $"Свободный член {a + 1} = " + vector[i].ToString() + " \n";
                }
                richTextBox1.Text += strVector;
                richTextBox1.Text += Environment.NewLine;

                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < columnsCount; j++)
                    {
                        if (columnsCount - 1 == j)
                        {
                            richTextBox1.Text += " = " + array[i, j].ToString() + " ";
                        }
                        else
                        {
                            richTextBox1.Text += array[i, j].ToString() + $"*x{j + 1} ";
                        }
                    }
                    richTextBox1.Text += Environment.NewLine;
                }
                richTextBox1.Text += Environment.NewLine;

                if (IterativeMethodOfGaussSeidel.DiagonallyDominant(matrix) == false)
                {
                    MessageBox.Show("Условие диагонального преобладаня не выполнено. Дальнейшие вычислительные операции не возможны.",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    richTextBox1.Text += "Условие диагонального преобладаня не выполнено.";
                    if (needDB == true)
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            CollectionSolutions cs = new CollectionSolutions { Matricx = $"{input}", Vector = $"{strVector}", DateTimeSol = DateTime.Now, Solution = "Условие диагонального преобладаня не выполнено.", Status = "не решено" };
                            db.CollectionSolutions.Add(cs);
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    
                    decision = IterativeMethodOfGaussSeidel.GaussSeidel(matrix, vector, maxIterations, epsilon, x);
                    iter = IterativeMethodOfGaussSeidel.Iteration(matrix, vector, maxIterations, epsilon, x);
                    bool hasIntegerSolution = true;
                    foreach (double root in decision)
                    {
                        if (Math.Round(root) != root)
                        {
                            hasIntegerSolution = false;
                            break;
                        }
                    }

                    if (hasIntegerSolution)
                    {
                        richTextBox1.Text += "Система имеет целочисленное решение.\n";
                        status = "Диафантово уравнение";
                        for (int i = 0; i < decision.Length; i++)
                        {
                            output += $" x{i + 1}= " + Math.Round(decision[i]).ToString() + ", ";
                        }
                        output = output.TrimEnd(',', ' ');

                        richTextBox1.Text += $"Решение системы:{output}";
                        richTextBox1.Text += Environment.NewLine;
                        if (needDB == true)
                        {
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                CollectionSolutions cs = new CollectionSolutions { Matricx = $"{input}", Vector = $"{strVector}", DateTimeSol = DateTime.Now, Solution = $"{output}", Status = $"{status}" };
                                db.CollectionSolutions.Add(cs);
                                db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        richTextBox1.Text += "Система не имеет целочисленного решения.\n";

                        status = "Не являетя диофантовой системой";
                        for (int i = 0; i < decision.Length; i++)
                        {
                            output += $" x{i + 1}= " + decision[i].ToString() + ", ";
                        }
                        output = output.TrimEnd(',', ' ');

                        richTextBox1.Text += $"Решение системы:{output}";
                        richTextBox1.Text += Environment.NewLine;
                        if (needDB == true)
                        {
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                CollectionSolutions cs = new CollectionSolutions { Matricx = $"{input}", Vector = $"{strVector}", DateTimeSol = DateTime.Now, Solution = $"{output}", Status = $"{status}" };
                                db.CollectionSolutions.Add(cs);
                                db.SaveChanges();
                            }
                        }
                    }

                }
                strVector = "";
                output = "";
                input = "";
                status = "";
                stopwatch.Stop();
            }
            else
            {
                MessageBox.Show("Сиситема не найдена!",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (needDB == true)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        CollectionSolutions cs = new CollectionSolutions { Matricx = $"нет данных", Vector = $"нет данных", DateTimeSol = DateTime.Now, Solution = $"Нет системы", Status = $"не решено" };
                        db.CollectionSolutions.Add(cs);
                        db.SaveChanges();
                    }
                }
                richTextBox1.Text += "==========================\n";
                richTextBox1.Text += "Невозможно обработкать систему\n";
                richTextBox1.Text += "==========================\n";
            }
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += "Время выполнения программы: " + elapsedTime + $" за {iter} итераций" ;
            richTextBox1.Text += Environment.NewLine;


        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
                //Регулировка массива
                if (dataGridView1.Columns.Count - 1 > numericUpDown1.Value)
                {
                    dataGridView1.Columns.RemoveAt(Convert.ToInt32(numericUpDown1.Value));
                    dataGridView1.Rows.RemoveAt(Convert.ToInt32(numericUpDown1.Value));
                    if (numericUpDown1.Value == 0)
                    {
                        dataGridView1.Columns.RemoveAt(Convert.ToInt32(numericUpDown1.Value));
                    }
                }
                else
                {
                    if (numericUpDown1.Value > 1)
                    {
                        dataGridView1.Columns.RemoveAt(Convert.ToInt32(numericUpDown1.Value - 1));
                        dataGridView1.Columns.Add($"Column{numericUpDown1.Value}", $"X{numericUpDown1.Value}");
                        dataGridView1.Columns.Add($"Column{numericUpDown1.Value + 1}", $"СВОБОДНЫЙ ЧЛЕН");
                        dataGridView1.Rows.Add();
                    }
                    else
                    {
                        dataGridView1.Columns.Add($"Column{numericUpDown1.Value}", $"X{numericUpDown1.Value}");
                        dataGridView1.Columns.Add($"Column{numericUpDown1.Value + 1}", $"СВОБОДНЫЙ ЧЛЕН");
                        dataGridView1.Rows.Add();
                    }
                }
            
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            database.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                needDB = true;
            }
            else
            {
                needDB = false;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

           
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                File.AppendAllText(fileName, richTextBox1.Text+"\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Создаем объект PrintDocument
            PrintDocument printDocument = new PrintDocument();

            // Устанавливаем обработчик события PrintPage
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            PrintDialog printDialog = new PrintDialog();

            // Открываем диалог печати и, если пользователь выбрал принтер и нажал ОК, запускаем печать
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //  текст из richTextBox
            string text = richTextBox1.Text;

            //  объект Font для задания шрифта и размера текста
            Font font = new Font("Times New Roman", 14);

            //  объект Brush для задания цвета текста
            Brush brush = Brushes.Black;

            //  размеры страницы
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            //  размеры текста
            SizeF textSize = e.Graphics.MeasureString(text, font);

            // координаты верхнего левого угла текста
            float x = (pageWidth - textSize.Width) / 2;
            float y = (pageHeight - textSize.Height) / 2;

            // текст на странице
            e.Graphics.DrawString(text, font, brush, x, y);
        }
       
        private void button5_Click(object sender, EventArgs e)
        {
            

            // Открываем диалоговое окно для выбора файла Excel.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int iter = 0;
                // Создаем объект приложения Excel.
                Excel.Application excelApp = new Excel.Application();

                // Открываем файл Excel.
                Excel.Workbook workbook = excelApp.Workbooks.Open(openFileDialog.FileName);

                // Получаем первый лист в книге.
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                // Получаем диапазон ячеек с данными.
                Excel.Range range = worksheet.UsedRange;

                // Создаем массив для хранения данных.
                double [,] data = new double[range.Rows.Count, range.Columns.Count];
                try { 
                // Заполняем массив данными из ячеек.
                for (int row = 1; row <= range.Rows.Count; row++)
                {
                    for (int col = 1; col <= range.Columns.Count; col++)
                    {
                        data[row - 1, col - 1] = range.Cells[row, col].Value2;
                    }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка содержания Excel-файла: " + ex.Message+ ". Проверьте правильность вводимых данных в выбранном файле.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status = "не решено";
                    richTextBox1.Text += "==========================\n";
                    richTextBox1.Text += "Невозможно обработкать систему\n";
                    richTextBox1.Text += "==========================\n";
                    if (needDB == true)
                    {
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            CollectionSolutions cs = new CollectionSolutions { Matricx = $"некорректный ввод", Vector = $"некорректный ввод", DateTimeSol = DateTime.Now, Solution = $"Произошла ошибка содержания Excel-файла", Status = $"{status}" };
                            db.CollectionSolutions.Add(cs);
                            db.SaveChanges();
                        }
                    }
                    workbook.Close();
                    excelApp.Quit();
                    return;
                }

                // Закрываем книгу Excel и приложение Excel.
                workbook.Close();
                excelApp.Quit();

                richTextBox1.Text += "===============================\n";
                richTextBox1.Text += "Обработка системы из Excel-файла:";
                richTextBox1.Text += Environment.NewLine;

                for (int row = 0; row < data.GetLength(0); row++)
                {
                    for (int col = 0; col < data.GetLength(1); col++)
                    {
                        if (data.GetLength(1) - 1 == col)
                        {
                            richTextBox1.Text += " = " + data[row, col].ToString() + " ";
                        }
                        else
                        {
                            richTextBox1.Text += data[row, col].ToString() + $"*x{col + 1} ";
                        }
                    }
                    richTextBox1.Text += Environment.NewLine;
                }
                

                int rowsCount = data.GetLength(0);
                int columnsCount = data.GetLength(1);
                int[] vector = new int[data.GetLength(1)];
                int[,] array = new int[rowsCount, columnsCount];
                int[,] matrix = new int[rowsCount, columnsCount - 1];
                int maxIterations = 1000000;
                double epsilon = 0.0000000001;
                double[] decision = new double[columnsCount];
                double[] x = new double[columnsCount - 1];

                for (int i = 0; i < rowsCount; i++)
                {
                    for (int j = 0; j < columnsCount; j++)
                    {
                        array[i,j] = (int)Math.Round(data[i,j]);
                    }
                }
                richTextBox1.Text += "\n";
                richTextBox1.Text += "При наличии дробных чисел => идёт округление до целого";
                richTextBox1.Text += "\n\n";

                vector = MatrixTools.MatrixVector(array);
                matrix = MatrixTools.Matrix(array);
                richTextBox1.Text += "Уравнение имеет коэффициенты при неизвестных:";
                richTextBox1.Text += Environment.NewLine;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        int a = i;
                        int b = j;
                        input += $" a{a + 1}{b + 1}= " + matrix[i, j].ToString();
                    }
                    input += "\n";
                }
                input = input.TrimEnd(',');
                richTextBox1.Text += input;
                richTextBox1.Text += Environment.NewLine;

                richTextBox1.Text += "Уравнение имеет свободные члены:";
                richTextBox1.Text += Environment.NewLine;
                for (int i = 0; i < vector.Length; i++)
                {
                    int a = i;
                    strVector += $"Свободный член {a + 1} = " + vector[i].ToString() + " \n";
                }
                richTextBox1.Text += strVector;
                richTextBox1.Text += Environment.NewLine;

                

                if (IterativeMethodOfGaussSeidel.DiagonallyDominant(matrix) == false)
                {
                    MessageBox.Show("Условие диагонального преобладаня не выполнено. Дальнейшие вычислительные операции не возможны.",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decision = IterativeMethodOfGaussSeidel.GaussSeidel(matrix, vector, maxIterations, epsilon, x);
                    bool hasIntegerSolution = true;
                    foreach (double root in decision)
                    {
                        if (Math.Round(root) != root)
                        {
                            hasIntegerSolution = false;
                            break;
                        }
                    }

                    if (hasIntegerSolution)
                    {
                        richTextBox1.Text += "Система имеет целочисленное решение.\n";
                        status = "Диафантово уравнение";
                        for (int i = 0; i < decision.Length; i++)
                        {
                            output += $" x{i + 1}= " + Math.Round(decision[i]).ToString() + ", ";
                        }
                        output = output.TrimEnd(',', ' ');

                        richTextBox1.Text += $"Решение системы:{output}";
                        richTextBox1.Text += Environment.NewLine;
                        if (needDB == true)
                        {
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                CollectionSolutions cs = new CollectionSolutions { Matricx = $"{input}", Vector = $"{strVector}", DateTimeSol = DateTime.Now, Solution = $"{output}", Status = $"{status}" };
                                db.CollectionSolutions.Add(cs);
                                db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        richTextBox1.Text += "Система не имеет целочисленного решения.\n";

                        status = "Не являетя диофантовой системой";
                        for (int i = 0; i < decision.Length; i++)
                        {
                            output += $" x{i + 1}= " + decision[i].ToString() + ", ";
                        }
                        output = output.TrimEnd(',', ' ');

                        richTextBox1.Text += $"Решение системы:{output}";
                        richTextBox1.Text += Environment.NewLine;
                        if (needDB == true)
                        {
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                CollectionSolutions cs = new CollectionSolutions { Matricx = $"{input}", Vector = $"{strVector}", DateTimeSol = DateTime.Now, Solution = $"{output}", Status = $"{status}" };
                                db.CollectionSolutions.Add(cs);
                                db.SaveChanges();
                            }
                        }
                    }

                }
                richTextBox1.Text += "===============================\n";
                strVector = "";
                output = "";
                input = "";
                status = "";


            }
        }
    }

    public class CollectionSolutions
    {
        [Key]
        public int Id { get; set; }
        public string Matricx { get; set; }
        public string Vector { get; set; }
        public string Solution { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeSol { get; set; }
        public string Status { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<CollectionSolutions> CollectionSolutions { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-7BLRJLS2;Database=GaussSeidel;Trusted_Connection=True;");
        }
    }

}
