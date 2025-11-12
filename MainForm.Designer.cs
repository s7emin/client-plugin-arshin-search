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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainView = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.DgridLersDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            this.Check,
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
            this.LersMeasurePoint,
            this.DgridLersDate});
            this.MainView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.MainView.Location = new System.Drawing.Point(12, 71);
            this.MainView.Name = "MainView";
            this.MainView.RowHeadersWidth = 4;
            this.MainView.Size = new System.Drawing.Size(1027, 317);
            this.MainView.TabIndex = 0;
            // 
            // Check
            // 
            this.Check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Check.HeaderText = "☑";
            this.Check.MinimumWidth = 30;
            this.Check.Name = "Check";
            this.Check.Width = 30;
            // 
            // DgridOrg
            // 
            this.DgridOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridOrg.DefaultCellStyle = dataGridViewCellStyle25;
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
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgridmimitnumber.DefaultCellStyle = dataGridViewCellStyle26;
            this.Dgridmimitnumber.FillWeight = 50F;
            this.Dgridmimitnumber.HeaderText = "Регномер типа СИ";
            this.Dgridmimitnumber.MinimumWidth = 80;
            this.Dgridmimitnumber.Name = "Dgridmimitnumber";
            this.Dgridmimitnumber.ReadOnly = true;
            // 
            // Dgridminame
            // 
            this.Dgridminame.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgridminame.DefaultCellStyle = dataGridViewCellStyle27;
            this.Dgridminame.HeaderText = "Наименование СИ";
            this.Dgridminame.MinimumWidth = 130;
            this.Dgridminame.Name = "Dgridminame";
            this.Dgridminame.ReadOnly = true;
            // 
            // Drgridmitype
            // 
            this.Drgridmitype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Drgridmitype.DefaultCellStyle = dataGridViewCellStyle28;
            this.Drgridmitype.FillWeight = 50F;
            this.Drgridmitype.HeaderText = "Тип СИ";
            this.Drgridmitype.MinimumWidth = 80;
            this.Drgridmitype.Name = "Drgridmitype";
            this.Drgridmitype.ReadOnly = true;
            // 
            // DgridName
            // 
            this.DgridName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridName.DefaultCellStyle = dataGridViewCellStyle29;
            this.DgridName.FillWeight = 50F;
            this.DgridName.HeaderText = "Модификация";
            this.DgridName.MinimumWidth = 90;
            this.DgridName.Name = "DgridName";
            this.DgridName.ReadOnly = true;
            // 
            // DgridNumber
            // 
            this.DgridNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridNumber.DefaultCellStyle = dataGridViewCellStyle30;
            this.DgridNumber.FillWeight = 50F;
            this.DgridNumber.HeaderText = "Заводской номер";
            this.DgridNumber.MinimumWidth = 80;
            this.DgridNumber.Name = "DgridNumber";
            this.DgridNumber.ReadOnly = true;
            // 
            // DgridDate
            // 
            this.DgridDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridDate.DefaultCellStyle = dataGridViewCellStyle31;
            this.DgridDate.HeaderText = "Дата поверки";
            this.DgridDate.MinimumWidth = 90;
            this.DgridDate.Name = "DgridDate";
            this.DgridDate.ReadOnly = true;
            this.DgridDate.Width = 95;
            // 
            // Dgriddatefor
            // 
            this.Dgriddatefor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgriddatefor.DefaultCellStyle = dataGridViewCellStyle32;
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
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgridDocnumLink.DefaultCellStyle = dataGridViewCellStyle33;
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
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridOwner.DefaultCellStyle = dataGridViewCellStyle34;
            this.DgridOwner.HeaderText = "Владелец";
            this.DgridOwner.MinimumWidth = 80;
            this.DgridOwner.Name = "DgridOwner";
            this.DgridOwner.ReadOnly = true;
            this.DgridOwner.Visible = false;
            // 
            // LersMeasurePoint
            // 
            this.LersMeasurePoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LersMeasurePoint.DefaultCellStyle = dataGridViewCellStyle35;
            this.LersMeasurePoint.HeaderText = "Точка учёта";
            this.LersMeasurePoint.MinimumWidth = 80;
            this.LersMeasurePoint.Name = "LersMeasurePoint";
            this.LersMeasurePoint.ReadOnly = true;
            this.LersMeasurePoint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgridLersDate
            // 
            this.DgridLersDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridLersDate.DefaultCellStyle = dataGridViewCellStyle36;
            this.DgridLersDate.HeaderText = "Дата поверки ЛЭРС";
            this.DgridLersDate.MinimumWidth = 110;
            this.DgridLersDate.Name = "DgridLersDate";
            this.DgridLersDate.ReadOnly = true;
            this.DgridLersDate.Width = 110;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(815, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Найти владельцев СИ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ЦСМ"});
            this.comboBox1.Location = new System.Drawing.Point(308, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(622, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 53);
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
            this.comboBox2.Location = new System.Drawing.Point(85, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(85, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
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
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Зав. номер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Поверитель";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(709, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "загружено/всего";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "20293-10"});
            this.comboBox3.Location = new System.Drawing.Point(308, 12);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(100, 21);
            this.comboBox3.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Рег номер типа СИ";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "100",
            "200",
            "500",
            "1000"});
            this.comboBox5.Location = new System.Drawing.Point(531, 12);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(73, 21);
            this.comboBox5.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Количество записей";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(712, 54);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(92, 10);
            this.progressBar1.TabIndex = 17;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(712, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(92, 20);
            this.textBox2.TabIndex = 18;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(435, 39);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(141, 30);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "Только совпадения со\r\nсправочником ЛЭРС";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 400);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox3);
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
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn DgridLersDate;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}