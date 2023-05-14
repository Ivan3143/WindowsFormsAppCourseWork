using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCourseWork
{
    public partial class AddForm : Form
    {
        string Id = "";
        public AddForm()
        {
            InitializeComponent();
            Database database = this.Owner as Database;
            if (database != null)
            {
                int newId = findMaxId(database.gaussSeidelDataSet1.Tables[0]) + 1;
                Id= newId.ToString();
            }
        }

        public Database Database
        {
            get => default;
            set
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database database = this.Owner as Database;
            if (database != null)
            {
                //запрещаем пользователю самому добавлять строки
                database.dataGridView1.AllowUserToAddRows = false;
            }
            Close();
        }

        private static int findMaxId(DataTable table)
        {
            int maxId = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int id = table.Rows[i].Field<int>("Id");
                if (id > maxId) maxId = id;
            }
            return maxId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database database = this.Owner as Database;

            if (database != null)
             {
                database.dataGridView1.AllowUserToAddRows = true;
                DataRow dataRow = database.gaussSeidelDataSet1.Tables[0].NewRow();
                int maxId = findMaxId(database.gaussSeidelDataSet1.Tables[0]);

                dataRow[0] = maxId+1;
                dataRow[1]= textBox1.Text;
                dataRow[2]= textBox2.Text;
                dataRow[3] = textBox3.Text;
                dataRow[4] = dateTimePicker1.Text + " " + dateTimePicker2.Text; 
                dataRow[5]= textBox4.Text;

                database.gaussSeidelDataSet1.Tables[0].Rows.Add(dataRow);
                database.collectionSolutionsTableAdapter.Update(database.gaussSeidelDataSet1.CollectionSolutions);
                database.gaussSeidelDataSet1.Tables[0].AcceptChanges();
                database.dataGridView1.Refresh();
                Id = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                dateTimePicker1.Text = "";
            }
        }
        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database database = this.Owner as Database;
            if (database != null)
            {
                //запрещаем пользователю самому добавлять строки
                database.dataGridView1.AllowUserToAddRows = false;
            }
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}