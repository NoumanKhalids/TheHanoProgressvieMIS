namespace MIS_ProgressiveDistributors
{
    partial class DispatchExpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DispatchExpense));
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.searchLookUpEdit12 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label40 = new System.Windows.Forms.Label();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CD_BtnEditSave = new DevExpress.XtraEditors.SimpleButton();
            this.CD_BtnRevert = new DevExpress.XtraEditors.SimpleButton();
            this.CD_BtnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.CD_BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.CD_BtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.InvSalesAgent = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView17 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label16 = new System.Windows.Forms.Label();
            this.InvVanNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.dataSet1 = new MIS_ProgressiveDistributors.DataSet1();
            this.edisonVanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edison_VanTableAdapter = new MIS_ProgressiveDistributors.DataSet1TableAdapters.Edison_VanTableAdapter();
            this.employeListsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeListsTableAdapter = new MIS_ProgressiveDistributors.DataSet1TableAdapters.EmployeListsTableAdapter();
            this.edisonExpenseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edison_ExpenseTableAdapter = new MIS_ProgressiveDistributors.DataSet1TableAdapters.Edison_ExpenseTableAdapter();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit12.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvSalesAgent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvVanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edisonVanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeListsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edisonExpenseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.simpleButton2.Location = new System.Drawing.Point(623, 142);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(81, 31);
            this.simpleButton2.TabIndex = 131;
            this.simpleButton2.Text = "Add";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            this.simpleButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.simpleButton2_MouseClick);
            this.simpleButton2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.simpleButton2_PreviewKeyDown);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(175, 87);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 20);
            this.label42.TabIndex = 129;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(1057, 24);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(102, 30);
            this.label41.TabIndex = 128;
            this.label41.Text = "Expenses";
            // 
            // textBox24
            // 
            this.textBox24.Enabled = false;
            this.textBox24.Location = new System.Drawing.Point(476, 142);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(131, 27);
            this.textBox24.TabIndex = 127;
            this.textBox24.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox24_PreviewKeyDown);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(472, 119);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(62, 20);
            this.label39.TabIndex = 126;
            this.label39.Text = "Amount";
            // 
            // searchLookUpEdit12
            // 
            this.searchLookUpEdit12.EditValue = "";
            this.searchLookUpEdit12.Enabled = false;
            this.searchLookUpEdit12.Location = new System.Drawing.Point(177, 143);
            this.searchLookUpEdit12.Name = "searchLookUpEdit12";
            this.searchLookUpEdit12.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.searchLookUpEdit12.Properties.Appearance.Options.UseFont = true;
            this.searchLookUpEdit12.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit12.Properties.DataSource = this.edisonExpenseBindingSource;
            this.searchLookUpEdit12.Properties.DisplayMember = "ExpenseDescription";
            this.searchLookUpEdit12.Properties.ValueMember = "ExpenseID";
            this.searchLookUpEdit12.Properties.View = this.gridView10;
            this.searchLookUpEdit12.Size = new System.Drawing.Size(290, 26);
            this.searchLookUpEdit12.TabIndex = 125;
            this.searchLookUpEdit12.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.searchLookUpEdit12_PreviewKeyDown);
            // 
            // gridView10
            // 
            this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView10.Name = "gridView10";
            this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView10.OptionsView.ShowGroupPanel = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(176, 120);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(63, 20);
            this.label40.TabIndex = 124;
            this.label40.Text = "Expense";
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dataGridView5.Location = new System.Drawing.Point(180, 192);
            this.dataGridView5.MultiSelect = false;
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.Size = new System.Drawing.Size(799, 498);
            this.dataGridView5.TabIndex = 123;
            this.dataGridView5.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView5_CellClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "SNo";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 62;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ExpenseID";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 103;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Expense Description";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 153;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Amount";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 87;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Remove";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 69;
            // 
            // CD_BtnEditSave
            // 
            this.CD_BtnEditSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CD_BtnEditSave.Appearance.ForeColor = System.Drawing.Color.Red;
            this.CD_BtnEditSave.Appearance.Options.UseFont = true;
            this.CD_BtnEditSave.Appearance.Options.UseForeColor = true;
            this.CD_BtnEditSave.Image = ((System.Drawing.Image)(resources.GetObject("CD_BtnEditSave.Image")));
            this.CD_BtnEditSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.CD_BtnEditSave.Location = new System.Drawing.Point(1188, 203);
            this.CD_BtnEditSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CD_BtnEditSave.Name = "CD_BtnEditSave";
            this.CD_BtnEditSave.Size = new System.Drawing.Size(109, 33);
            this.CD_BtnEditSave.TabIndex = 136;
            this.CD_BtnEditSave.Text = "Save";
            this.CD_BtnEditSave.Visible = false;
            this.CD_BtnEditSave.Click += new System.EventHandler(this.CD_BtnEditSave_Click);
            // 
            // CD_BtnRevert
            // 
            this.CD_BtnRevert.Image = ((System.Drawing.Image)(resources.GetObject("CD_BtnRevert.Image")));
            this.CD_BtnRevert.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.CD_BtnRevert.Location = new System.Drawing.Point(1303, 81);
            this.CD_BtnRevert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CD_BtnRevert.Name = "CD_BtnRevert";
            this.CD_BtnRevert.Size = new System.Drawing.Size(109, 33);
            this.CD_BtnRevert.TabIndex = 135;
            this.CD_BtnRevert.Text = "Revert";
            this.CD_BtnRevert.Visible = false;
            this.CD_BtnRevert.Click += new System.EventHandler(this.CD_BtnRevert_Click);
            // 
            // CD_BtnEdit
            // 
            this.CD_BtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("CD_BtnEdit.Image")));
            this.CD_BtnEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.CD_BtnEdit.Location = new System.Drawing.Point(1188, 82);
            this.CD_BtnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CD_BtnEdit.Name = "CD_BtnEdit";
            this.CD_BtnEdit.Size = new System.Drawing.Size(109, 33);
            this.CD_BtnEdit.TabIndex = 134;
            this.CD_BtnEdit.Text = "Edit";
            this.CD_BtnEdit.Click += new System.EventHandler(this.CD_BtnEdit_Click);
            // 
            // CD_BtnSave
            // 
            this.CD_BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("CD_BtnSave.Image")));
            this.CD_BtnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.CD_BtnSave.Location = new System.Drawing.Point(1188, 166);
            this.CD_BtnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CD_BtnSave.Name = "CD_BtnSave";
            this.CD_BtnSave.Size = new System.Drawing.Size(109, 33);
            this.CD_BtnSave.TabIndex = 133;
            this.CD_BtnSave.Text = "Save";
            this.CD_BtnSave.Visible = false;
            this.CD_BtnSave.Click += new System.EventHandler(this.CD_BtnSave_Click);
            this.CD_BtnSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CD_BtnSave_MouseClick);
            this.CD_BtnSave.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CD_BtnSave_PreviewKeyDown);
            // 
            // CD_BtnAdd
            // 
            this.CD_BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("CD_BtnAdd.Image")));
            this.CD_BtnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.CD_BtnAdd.Location = new System.Drawing.Point(1188, 119);
            this.CD_BtnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CD_BtnAdd.Name = "CD_BtnAdd";
            this.CD_BtnAdd.Size = new System.Drawing.Size(109, 33);
            this.CD_BtnAdd.TabIndex = 132;
            this.CD_BtnAdd.Text = "Add";
            this.CD_BtnAdd.Click += new System.EventHandler(this.CD_BtnAdd_Click);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(177, 85);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(79, 27);
            this.textBox4.TabIndex = 170;
            // 
            // InvSalesAgent
            // 
            this.InvSalesAgent.EditValue = " ";
            this.InvSalesAgent.Enabled = false;
            this.InvSalesAgent.Location = new System.Drawing.Point(811, 86);
            this.InvSalesAgent.Name = "InvSalesAgent";
            this.InvSalesAgent.Properties.Appearance.BackColor = System.Drawing.Color.Beige;
            this.InvSalesAgent.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.InvSalesAgent.Properties.Appearance.Options.UseBackColor = true;
            this.InvSalesAgent.Properties.Appearance.Options.UseFont = true;
            this.InvSalesAgent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.InvSalesAgent.Properties.DataSource = this.employeListsBindingSource;
            this.InvSalesAgent.Properties.DisplayMember = "EmployeeName";
            this.InvSalesAgent.Properties.ValueMember = "EmployeeID";
            this.InvSalesAgent.Properties.View = this.gridView17;
            this.InvSalesAgent.Size = new System.Drawing.Size(264, 26);
            this.InvSalesAgent.TabIndex = 175;
            // 
            // gridView17
            // 
            this.gridView17.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView17.Name = "gridView17";
            this.gridView17.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView17.OptionsView.ShowGroupPanel = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(807, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 20);
            this.label16.TabIndex = 174;
            this.label16.Text = "Salesman";
            // 
            // InvVanNo
            // 
            this.InvVanNo.EditValue = " ";
            this.InvVanNo.Enabled = false;
            this.InvVanNo.Location = new System.Drawing.Point(512, 86);
            this.InvVanNo.Name = "InvVanNo";
            this.InvVanNo.Properties.Appearance.BackColor = System.Drawing.Color.Beige;
            this.InvVanNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.InvVanNo.Properties.Appearance.Options.UseBackColor = true;
            this.InvVanNo.Properties.Appearance.Options.UseFont = true;
            this.InvVanNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.InvVanNo.Properties.DataSource = this.edisonVanBindingSource;
            this.InvVanNo.Properties.DisplayMember = "VanName";
            this.InvVanNo.Properties.ValueMember = "VanID";
            this.InvVanNo.Properties.View = this.gridView15;
            this.InvVanNo.Size = new System.Drawing.Size(279, 26);
            this.InvVanNo.TabIndex = 173;
            // 
            // gridView15
            // 
            this.gridView15.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView15.Name = "gridView15";
            this.gridView15.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView15.OptionsView.ShowGroupPanel = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(508, 62);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 20);
            this.label32.TabIndex = 172;
            this.label32.Text = "Van Name";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(173, 62);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(91, 20);
            this.label31.TabIndex = 171;
            this.label31.Text = "Dispatch No";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // edisonVanBindingSource
            // 
            this.edisonVanBindingSource.DataMember = "Edison_Van";
            this.edisonVanBindingSource.DataSource = this.dataSet1;
            // 
            // edison_VanTableAdapter
            // 
            this.edison_VanTableAdapter.ClearBeforeFill = true;
            // 
            // employeListsBindingSource
            // 
            this.employeListsBindingSource.DataMember = "EmployeLists";
            this.employeListsBindingSource.DataSource = this.dataSet1;
            // 
            // employeListsTableAdapter
            // 
            this.employeListsTableAdapter.ClearBeforeFill = true;
            // 
            // edisonExpenseBindingSource
            // 
            this.edisonExpenseBindingSource.DataMember = "Edison_Expense";
            this.edisonExpenseBindingSource.DataSource = this.dataSet1;
            // 
            // edison_ExpenseTableAdapter
            // 
            this.edison_ExpenseTableAdapter.ClearBeforeFill = true;
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(476, 716);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(131, 27);
            this.textBox26.TabIndex = 179;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(472, 693);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(100, 20);
            this.label44.TabIndex = 178;
            this.label44.Text = "Total Expense";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(180, 716);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(131, 27);
            this.textBox25.TabIndex = 177;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(176, 693);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(99, 20);
            this.label43.TabIndex = 176;
            this.label43.Text = "Total Records";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 181;
            this.label6.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(271, 85);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 27);
            this.dateTimePicker1.TabIndex = 180;
            // 
            // DispatchExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1460, 767);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox26);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.textBox25);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.InvSalesAgent);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.InvVanNo);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.searchLookUpEdit12);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.dataGridView5);
            this.Controls.Add(this.CD_BtnEditSave);
            this.Controls.Add(this.CD_BtnRevert);
            this.Controls.Add(this.CD_BtnEdit);
            this.Controls.Add(this.CD_BtnSave);
            this.Controls.Add(this.CD_BtnAdd);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DispatchExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DispatchExpense";
            this.Load += new System.EventHandler(this.DispatchExpense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit12.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvSalesAgent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvVanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edisonVanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeListsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edisonExpenseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label39;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit12;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewButtonColumn Column12;
        private DevExpress.XtraEditors.SimpleButton CD_BtnEditSave;
        private DevExpress.XtraEditors.SimpleButton CD_BtnRevert;
        private DevExpress.XtraEditors.SimpleButton CD_BtnEdit;
        private DevExpress.XtraEditors.SimpleButton CD_BtnSave;
        private DevExpress.XtraEditors.SimpleButton CD_BtnAdd;
        private System.Windows.Forms.TextBox textBox4;
        private DevExpress.XtraEditors.SearchLookUpEdit InvSalesAgent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView17;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.SearchLookUpEdit InvVanNo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource edisonVanBindingSource;
        private DataSet1TableAdapters.Edison_VanTableAdapter edison_VanTableAdapter;
        private System.Windows.Forms.BindingSource employeListsBindingSource;
        private DataSet1TableAdapters.EmployeListsTableAdapter employeListsTableAdapter;
        private System.Windows.Forms.BindingSource edisonExpenseBindingSource;
        private DataSet1TableAdapters.Edison_ExpenseTableAdapter edison_ExpenseTableAdapter;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}