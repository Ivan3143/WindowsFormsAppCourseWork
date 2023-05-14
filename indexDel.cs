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
    public partial class indexDel : Form
    {
        public indexDel()
        {
            InitializeComponent();
            Database database = this.Owner as Database;
        }

        public Database Database
        {
            get => default;
            set
            {
            }
        }

        private void indexDel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
