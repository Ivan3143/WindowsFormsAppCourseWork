using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsAppCourseWork.Form1;


namespace WindowsFormsAppCourseWork
{
    public partial class Database : Form
    {
        public Database()
        {
            InitializeComponent();
        }

        public void Database_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "gaussSeidelDataSet1.CollectionSolutions". При необходимости она может быть перемещена или удалена.
            this.collectionSolutionsTableAdapter.Fill(this.gaussSeidelDataSet1.CollectionSolutions);
            dataGridView1.AllowUserToAddRows = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Owner = this;
            addForm.Show();
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = 0;
            indexDel indexdel = new indexDel();
                indexdel.ShowDialog();
                if (indexdel.DialogResult == DialogResult.OK)
                {
                index = Convert.ToInt32(indexdel.numericUpDown1.Value); 
                }
            int dataGridView_index = 0;
            bool check = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["idDataGridViewTextBoxColumn"].Value != null && row.Cells["idDataGridViewTextBoxColumn"].Value.ToString() == index.ToString())
                {
                    DialogResult dr = MessageBox.Show("Удалить решение?", "Удаление", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                    if (dr != DialogResult.Cancel)
                    {

                        int DelInd = gaussSeidelDataSet1.Tables[0].Rows[dataGridView_index].Field<int>("Id");
                        dataGridView1.Rows.RemoveAt(dataGridView_index);
                        dataGridView1.Refresh();
                        using (ApplicationContext db = new ApplicationContext())
                        {
                            CollectionSolutions сollectionsolutions = db.CollectionSolutions.Find(DelInd);
                            db.CollectionSolutions.Remove(сollectionsolutions);
                            db.SaveChanges();
                        }
                        check = true;
                    }
                    break;
                }
                else
                {
                    dataGridView_index++;
                }
            }
            if (check==false) 
            {
                MessageBox.Show("Ой, такого индекса нет. Проверьте правильность введёного индекса и попробкуйте снова.", "Информация", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            DataGridViewPrinter dataGridViewPrinter = new DataGridViewPrinter(dataGridView1, e.Graphics, e.MarginBounds, e.PageBounds, e.PageSettings);
            bool morePages = dataGridViewPrinter.DrawDataGridView();
            if (morePages)
            {
                e.HasMorePages = true;
            }
        }

        public class DataGridViewPrinter
        {
            private DataGridView dataGridView;
            private Graphics graphics;
            private Rectangle marginBounds;
            private Rectangle pageBounds;
            private PageSettings pageSettings;
            private int rowIndex;
            private bool firstPage;
            private bool lastPage;

            public DataGridViewPrinter(DataGridView dataGridView, Graphics graphics, Rectangle marginBounds, Rectangle pageBounds, PageSettings pageSettings)
            {
                this.dataGridView = dataGridView;
                this.graphics = graphics;
                this.marginBounds = marginBounds;
                this.pageBounds = pageBounds;
                this.pageSettings = pageSettings;
                this.rowIndex = 0;
                this.firstPage = true;
                this.lastPage = false;
            }

            public bool DrawDataGridView()
            {
                float x = marginBounds.Left;
                float y = marginBounds.Top;
                float cellHeight = dataGridView.Rows[0].Height;
                float headerHeight = dataGridView.ColumnHeadersHeight + cellHeight;
                int rowsPerPage = (int)((marginBounds.Height - headerHeight) / cellHeight);
                if (firstPage)
                {
                    rowIndex = 0;
                    graphics.DrawString(dataGridView.Name, dataGridView.Font, Brushes.Black, x, y);
                    y += headerHeight;
                }
                while (rowIndex < dataGridView.Rows.Count)
                {
                    DataGridViewRow row = dataGridView.Rows[rowIndex];
                    if (y + cellHeight > marginBounds.Bottom)
                    {
                        lastPage = false;
                        return true;
                    }
                    if (row.Index == dataGridView.Rows.Count - 1)
                    {
                        lastPage = true;
                    }
                    if (row.Visible)
                    {
                        float rowHeight = row.Height;
                        float cellWidth = (float)dataGridView.Columns[0].Width;
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            DataGridViewColumn column = dataGridView.Columns[i];
                            if (column.Visible)
                            {
                                object value = row.Cells[i].FormattedValue;
                                RectangleF cellBounds = new RectangleF(x, y, cellWidth, rowHeight);
                                graphics.DrawString(value.ToString(), dataGridView.Font, Brushes.Black, cellBounds);
                                x += cellWidth;
                            }
                        }
                        x = marginBounds.Left;
                        y += rowHeight;
                    }
                    rowIndex++;
                }
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            int propusk = 0;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите очистить базу данных?", 
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int DelInd = gaussSeidelDataSet1.Tables[0].Rows[0].Field<int>("Id");
                while (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows.RemoveAt(0);
                    dataGridView1.Refresh();
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        try
                        {
                            CollectionSolutions сollectionsolutions = db.CollectionSolutions.Find(DelInd);
                            db.CollectionSolutions.Remove(сollectionsolutions);
                            db.SaveChanges();
                        }
                        catch
                        {
                            propusk++;
                        }
                    }
                    DelInd++;
                }
                MessageBox.Show("База данных успешно очищена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public AddForm AddForm
        {
            get => default;
            set
            {
            }
        }

        public indexDel indexDel
        {
            get => default;
            set
            {
            }
        }

        public Form1 Form1
        {
            get => default;
            set
            {
            }
        }
    }
}
