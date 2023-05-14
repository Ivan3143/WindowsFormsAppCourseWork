namespace WindowsFormsAppCourseWork
{
    partial class Database
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Database));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.collectionSolutionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gaussSeidelDataSet1 = new WindowsFormsAppCourseWork.GaussSeidelDataSet1();
            this.gaussSeidelDataSet = new WindowsFormsAppCourseWork.GaussSeidelDataSet();
            this.gaussSeidelDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.collectionSolutionsTableAdapter = new WindowsFormsAppCourseWork.GaussSeidelDataSet1TableAdapters.CollectionSolutionsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matricxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solutionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeSolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectionSolutionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussSeidelDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussSeidelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussSeidelDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.matricxDataGridViewTextBoxColumn,
            this.vectorDataGridViewTextBoxColumn,
            this.solutionDataGridViewTextBoxColumn,
            this.dateTimeSolDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.collectionSolutionsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 157);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1228, 363);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // collectionSolutionsBindingSource
            // 
            this.collectionSolutionsBindingSource.DataMember = "CollectionSolutions";
            this.collectionSolutionsBindingSource.DataSource = this.gaussSeidelDataSet1;
            // 
            // gaussSeidelDataSet1
            // 
            this.gaussSeidelDataSet1.DataSetName = "GaussSeidelDataSet1";
            this.gaussSeidelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gaussSeidelDataSet
            // 
            this.gaussSeidelDataSet.DataSetName = "GaussSeidelDataSet";
            this.gaussSeidelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gaussSeidelDataSetBindingSource
            // 
            this.gaussSeidelDataSetBindingSource.DataSource = this.gaussSeidelDataSet;
            this.gaussSeidelDataSetBindingSource.Position = 0;
            // 
            // collectionSolutionsTableAdapter
            // 
            this.collectionSolutionsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(266, 536);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(446, 536);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(628, 536);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "Печать\n";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(804, 536);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 43);
            this.button4.TabIndex = 4;
            this.button4.Text = "Очистить БД";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // matricxDataGridViewTextBoxColumn
            // 
            this.matricxDataGridViewTextBoxColumn.DataPropertyName = "Matricx";
            this.matricxDataGridViewTextBoxColumn.HeaderText = "Matricx";
            this.matricxDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.matricxDataGridViewTextBoxColumn.Name = "matricxDataGridViewTextBoxColumn";
            this.matricxDataGridViewTextBoxColumn.ReadOnly = true;
            this.matricxDataGridViewTextBoxColumn.Width = 125;
            // 
            // vectorDataGridViewTextBoxColumn
            // 
            this.vectorDataGridViewTextBoxColumn.DataPropertyName = "Vector";
            this.vectorDataGridViewTextBoxColumn.HeaderText = "Vector";
            this.vectorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.vectorDataGridViewTextBoxColumn.Name = "vectorDataGridViewTextBoxColumn";
            this.vectorDataGridViewTextBoxColumn.ReadOnly = true;
            this.vectorDataGridViewTextBoxColumn.Width = 125;
            // 
            // solutionDataGridViewTextBoxColumn
            // 
            this.solutionDataGridViewTextBoxColumn.DataPropertyName = "Solution";
            this.solutionDataGridViewTextBoxColumn.HeaderText = "Solution";
            this.solutionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.solutionDataGridViewTextBoxColumn.Name = "solutionDataGridViewTextBoxColumn";
            this.solutionDataGridViewTextBoxColumn.ReadOnly = true;
            this.solutionDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateTimeSolDataGridViewTextBoxColumn
            // 
            this.dateTimeSolDataGridViewTextBoxColumn.DataPropertyName = "DateTimeSol";
            this.dateTimeSolDataGridViewTextBoxColumn.HeaderText = "DateTimeSol";
            this.dateTimeSolDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateTimeSolDataGridViewTextBoxColumn.Name = "dateTimeSolDataGridViewTextBoxColumn";
            this.dateTimeSolDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateTimeSolDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1252, 607);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Database";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История решений СЛАУ ";
            this.Load += new System.EventHandler(this.Database_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectionSolutionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussSeidelDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussSeidelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussSeidelDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource gaussSeidelDataSetBindingSource;
        public GaussSeidelDataSet gaussSeidelDataSet;
        public GaussSeidelDataSet1 gaussSeidelDataSet1;
        private System.Windows.Forms.BindingSource collectionSolutionsBindingSource;
        public GaussSeidelDataSet1TableAdapters.CollectionSolutionsTableAdapter collectionSolutionsTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matricxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn solutionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeSolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}