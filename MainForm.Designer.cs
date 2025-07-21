namespace ArshinSearch
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DgridOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dgridmimitnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dgridminame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drgridmitype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgridNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgridDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dgriddatefor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgridAppc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DgridDocnumLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DgridOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LersMeasurePoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainView
            // 
            this.MainView.AllowUserToAddRows = false;
            this.MainView.AllowUserToDeleteRows = false;
            this.MainView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgridOrg,
            this.Dgridmimitnumber,
            this.Dgridminame,
            this.Drgridmitype,
            this.DgridName,
            this.DgridNumber,
            this.DgridDate,
            this.Dgriddatefor,
            this.DgridAppc,
            this.DgridDocnumLink,
            this.DgridOwner,
            this.LersMeasurePoint});
            this.MainView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MainView.Location = new System.Drawing.Point(12, 66);
            this.MainView.Name = "MainView";
            this.MainView.ReadOnly = true;
            this.MainView.RowHeadersWidth = 4;
            this.MainView.Size = new System.Drawing.Size(765, 322);
            this.MainView.TabIndex = 0;
            this.MainView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainView_CellContentClick);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(579, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "Найти владельцев СИ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ЦСМ"});
            this.comboBox1.Location = new System.Drawing.Point(373, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(499, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 48);
            this.button2.TabIndex = 3;
            this.button2.Text = "Поиск";
            this.toolTip1.SetToolTip(this.button2, resources.GetString("button2.ToolTip"));
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "ВЗЛЕТ",
            "ВКТ",
            "ТЭМ",
            "ПРЭМ"});
            this.comboBox2.Location = new System.Drawing.Point(115, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(120, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Тип СИ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Заводской номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Поверитель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(683, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Найдено записей: ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(708, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "20293-10"});
            this.comboBox3.Location = new System.Drawing.Point(373, 12);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(120, 21);
            this.comboBox3.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Рег номер типа СИ";
            // 
            // DgridOrg
            // 
            this.DgridOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridOrg.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgridOrg.FillWeight = 50F;
            this.DgridOrg.HeaderText = "Поверитель";
            this.DgridOrg.MinimumWidth = 80;
            this.DgridOrg.Name = "DgridOrg";
            this.DgridOrg.ReadOnly = true;
            this.DgridOrg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Dgridmimitnumber
            // 
            this.Dgridmimitnumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgridmimitnumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgridmimitnumber.FillWeight = 50F;
            this.Dgridmimitnumber.HeaderText = "Регномер типа СИ";
            this.Dgridmimitnumber.MinimumWidth = 80;
            this.Dgridmimitnumber.Name = "Dgridmimitnumber";
            this.Dgridmimitnumber.ReadOnly = true;
            // 
            // Dgridminame
            // 
            this.Dgridminame.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgridminame.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgridminame.HeaderText = "Наименование СИ";
            this.Dgridminame.MinimumWidth = 130;
            this.Dgridminame.Name = "Dgridminame";
            this.Dgridminame.ReadOnly = true;
            // 
            // Drgridmitype
            // 
            this.Drgridmitype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Drgridmitype.DefaultCellStyle = dataGridViewCellStyle4;
            this.Drgridmitype.FillWeight = 50F;
            this.Drgridmitype.HeaderText = "Тип СИ";
            this.Drgridmitype.MinimumWidth = 80;
            this.Drgridmitype.Name = "Drgridmitype";
            this.Drgridmitype.ReadOnly = true;
            // 
            // DgridName
            // 
            this.DgridName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridName.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgridName.FillWeight = 50F;
            this.DgridName.HeaderText = "Модификация";
            this.DgridName.MinimumWidth = 90;
            this.DgridName.Name = "DgridName";
            this.DgridName.ReadOnly = true;
            // 
            // DgridNumber
            // 
            this.DgridNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridNumber.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgridNumber.FillWeight = 50F;
            this.DgridNumber.HeaderText = "Заводской номер";
            this.DgridNumber.MinimumWidth = 80;
            this.DgridNumber.Name = "DgridNumber";
            this.DgridNumber.ReadOnly = true;
            // 
            // DgridDate
            // 
            this.DgridDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgridDate.HeaderText = "Дата поверки";
            this.DgridDate.MinimumWidth = 90;
            this.DgridDate.Name = "DgridDate";
            this.DgridDate.ReadOnly = true;
            this.DgridDate.Width = 95;
            // 
            // Dgriddatefor
            // 
            this.Dgriddatefor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgriddatefor.DefaultCellStyle = dataGridViewCellStyle8;
            this.Dgriddatefor.HeaderText = "Действительна до";
            this.Dgriddatefor.MinimumWidth = 90;
            this.Dgriddatefor.Name = "Dgriddatefor";
            this.Dgriddatefor.ReadOnly = true;
            this.Dgriddatefor.Width = 90;
            // 
            // DgridAppc
            // 
            this.DgridAppc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DgridAppc.HeaderText = "Пригодно";
            this.DgridAppc.MinimumWidth = 60;
            this.DgridAppc.Name = "DgridAppc";
            this.DgridAppc.ReadOnly = true;
            this.DgridAppc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridAppc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DgridAppc.Width = 60;
            // 
            // DgridDocnumLink
            // 
            this.DgridDocnumLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgridDocnumLink.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgridDocnumLink.HeaderText = "№ свидетельства";
            this.DgridDocnumLink.MinimumWidth = 170;
            this.DgridDocnumLink.Name = "DgridDocnumLink";
            this.DgridDocnumLink.ReadOnly = true;
            this.DgridDocnumLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridDocnumLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DgridDocnumLink.Width = 170;
            // 
            // DgridOwner
            // 
            this.DgridOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridOwner.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgridOwner.HeaderText = "Владелец";
            this.DgridOwner.MinimumWidth = 80;
            this.DgridOwner.Name = "DgridOwner";
            this.DgridOwner.ReadOnly = true;
            this.DgridOwner.Width = 80;
            // 
            // LersMeasurePoint
            // 
            this.LersMeasurePoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LersMeasurePoint.DefaultCellStyle = dataGridViewCellStyle11;
            this.LersMeasurePoint.HeaderText = "Точка учёта";
            this.LersMeasurePoint.MinimumWidth = 80;
            this.LersMeasurePoint.Name = "LersMeasurePoint";
            this.LersMeasurePoint.ReadOnly = true;
            this.LersMeasurePoint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MainForm
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 400);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.MainView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgridOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dgridmimitnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dgridminame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drgridmitype;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgridNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgridDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dgriddatefor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgridAppc;
        private System.Windows.Forms.DataGridViewLinkColumn DgridDocnumLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgridOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn LersMeasurePoint;
    }
}