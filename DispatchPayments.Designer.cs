namespace MIS_ProgressiveDistributors
{
    partial class DispatchPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DispatchPayments));
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column29 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnColAdd = new DevExpress.XtraEditors.SimpleButton();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.invAmountReceived = new System.Windows.Forms.TextBox();
            this.InvColCustomerList = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.customerlistVanWiseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new MIS_ProgressiveDistributors.DataSet1();
            this.gridView16 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.customerlistVanWiseTableAdapter = new MIS_ProgressiveDistributors.DataSet1TableAdapters.CustomerlistVanWiseTableAdapter();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.InvSalesAgent = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.employeListsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView17 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label16 = new System.Windows.Forms.Label();
            this.InvVanNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.edisonVanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.edison_VanTableAdapter = new MIS_ProgressiveDistributors.DataSet1TableAdapters.Edison_VanTableAdapter();
            this.employeListsTableAdapter = new MIS_ProgressiveDistributors.DataSet1TableAdapters.EmployeListsTableAdapter();
            this.INV_btnEditSave = new DevExpress.XtraEditors.SimpleButton();
            this.INV_btnRevert = new DevExpress.XtraEditors.SimpleButton();
            this.INV_btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.INV_btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.INV_btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvColCustomerList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerlistVanWiseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvSalesAgent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeListsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvVanNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edisonVanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column1,
            this.Column2,
            this.Column27,
            this.Column29});
            this.dataGridView3.Location = new System.Drawing.Point(29, 255);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(1343, 375);
            this.dataGridView3.TabIndex = 66;
            this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellClick);
            // 
            // Column24
            // 
            this.Column24.HeaderText = "SNo";
            this.Column24.Name = "Column24";
            this.Column24.ReadOnly = true;
            this.Column24.Width = 62;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "CustID";
            this.Column25.Name = "Column25";
            this.Column25.ReadOnly = true;
            this.Column25.Width = 77;
            // 
            // Column26
            // 
            this.Column26.HeaderText = "CustName";
            this.Column26.Name = "Column26";
            this.Column26.ReadOnly = true;
            this.Column26.Width = 102;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Area";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 65;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "City";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 59;
            // 
            // Column27
            // 
            this.Column27.HeaderText = "Amount";
            this.Column27.Name = "Column27";
            this.Column27.ReadOnly = true;
            this.Column27.Width = 87;
            // 
            // Column29
            // 
            this.Column29.HeaderText = "Rmv";
            this.Column29.Name = "Column29";
            this.Column29.ReadOnly = true;
            this.Column29.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column29.Width = 63;
            // 
            // btnColAdd
            // 
            this.btnColAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnColAdd.Location = new System.Drawing.Point(1200, 194);
            this.btnColAdd.Name = "btnColAdd";
            this.btnColAdd.Size = new System.Drawing.Size(55, 31);
            this.btnColAdd.TabIndex = 71;
            this.btnColAdd.Text = "Add";
            this.btnColAdd.Click += new System.EventHandler(this.btnColAdd_Click);
            this.btnColAdd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnColAdd_MouseClick);
            this.btnColAdd.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btnColAdd_PreviewKeyDown);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(1053, 165);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(126, 20);
            this.label47.TabIndex = 70;
            this.label47.Text = "Amount Received";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(25, 165);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(116, 20);
            this.label46.TabIndex = 67;
            this.label46.Text = "Select Customer";
            // 
            // invAmountReceived
            // 
            this.invAmountReceived.Enabled = false;
            this.invAmountReceived.Location = new System.Drawing.Point(1057, 195);
            this.invAmountReceived.Name = "invAmountReceived";
            this.invAmountReceived.Size = new System.Drawing.Size(134, 27);
            this.invAmountReceived.TabIndex = 69;
            this.invAmountReceived.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.invAmountReceived_PreviewKeyDown);
            // 
            // InvColCustomerList
            // 
            this.InvColCustomerList.EditValue = " ";
            this.InvColCustomerList.Location = new System.Drawing.Point(29, 195);
            this.InvColCustomerList.Name = "InvColCustomerList";
            this.InvColCustomerList.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.InvColCustomerList.Properties.Appearance.Options.UseFont = true;
            this.InvColCustomerList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.InvColCustomerList.Properties.DataSource = this.customerlistVanWiseBindingSource;
            this.InvColCustomerList.Properties.DisplayMember = "CustomerName";
            this.InvColCustomerList.Properties.ValueMember = "CustID";
            this.InvColCustomerList.Properties.View = this.gridView16;
            this.InvColCustomerList.Size = new System.Drawing.Size(262, 26);
            this.InvColCustomerList.TabIndex = 68;
            this.InvColCustomerList.EditValueChanged += new System.EventHandler(this.InvColCustomerList_EditValueChanged);
            this.InvColCustomerList.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.InvColCustomerList_PreviewKeyDown);
            // 
            // customerlistVanWiseBindingSource
            // 
            this.customerlistVanWiseBindingSource.DataMember = "CustomerlistVanWise";
            this.customerlistVanWiseBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView16
            // 
            this.gridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView16.Name = "gridView16";
            this.gridView16.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView16.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(708, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 30);
            this.label1.TabIndex = 72;
            this.label1.Text = "Dispatch Payments";
            // 
            // customerlistVanWiseTableAdapter
            // 
            this.customerlistVanWiseTableAdapter.ClearBeforeFill = true;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Beige;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(637, 194);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(204, 27);
            this.textBox6.TabIndex = 157;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 156;
            this.label2.Text = "City";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Beige;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(297, 194);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(334, 27);
            this.textBox1.TabIndex = 154;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 155;
            this.label3.Text = "Area";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1028, 635);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 159;
            this.label4.Text = "Total Amount";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(1032, 666);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 27);
            this.textBox2.TabIndex = 158;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 635);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 161;
            this.label5.Text = "Total Records";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(29, 666);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(122, 27);
            this.textBox3.TabIndex = 160;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(713, 101);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 27);
            this.dateTimePicker1.TabIndex = 162;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 163;
            this.label6.Text = "Date";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(29, 103);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(79, 27);
            this.textBox4.TabIndex = 164;
            // 
            // InvSalesAgent
            // 
            this.InvSalesAgent.EditValue = " ";
            this.InvSalesAgent.Enabled = false;
            this.InvSalesAgent.Location = new System.Drawing.Point(425, 103);
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
            this.InvSalesAgent.TabIndex = 169;
            // 
            // employeListsBindingSource
            // 
            this.employeListsBindingSource.DataMember = "EmployeLists";
            this.employeListsBindingSource.DataSource = this.dataSet1;
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
            this.label16.Location = new System.Drawing.Point(421, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 20);
            this.label16.TabIndex = 168;
            this.label16.Text = "Salesman";
            // 
            // InvVanNo
            // 
            this.InvVanNo.EditValue = " ";
            this.InvVanNo.Enabled = false;
            this.InvVanNo.Location = new System.Drawing.Point(125, 104);
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
            this.InvVanNo.TabIndex = 167;
            // 
            // edisonVanBindingSource
            // 
            this.edisonVanBindingSource.DataMember = "Edison_Van";
            this.edisonVanBindingSource.DataSource = this.dataSet1;
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
            this.label32.Location = new System.Drawing.Point(121, 81);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 20);
            this.label32.TabIndex = 166;
            this.label32.Text = "Van Name";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(25, 79);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(91, 20);
            this.label31.TabIndex = 165;
            this.label31.Text = "Dispatch No";
            // 
            // edison_VanTableAdapter
            // 
            this.edison_VanTableAdapter.ClearBeforeFill = true;
            // 
            // employeListsTableAdapter
            // 
            this.employeListsTableAdapter.ClearBeforeFill = true;
            // 
            // INV_btnEditSave
            // 
            this.INV_btnEditSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INV_btnEditSave.Appearance.ForeColor = System.Drawing.Color.Red;
            this.INV_btnEditSave.Appearance.Options.UseFont = true;
            this.INV_btnEditSave.Appearance.Options.UseForeColor = true;
            this.INV_btnEditSave.Image = ((System.Drawing.Image)(resources.GetObject("INV_btnEditSave.Image")));
            this.INV_btnEditSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.INV_btnEditSave.Location = new System.Drawing.Point(1391, 55);
            this.INV_btnEditSave.Name = "INV_btnEditSave";
            this.INV_btnEditSave.Size = new System.Drawing.Size(115, 33);
            this.INV_btnEditSave.TabIndex = 151;
            this.INV_btnEditSave.Text = "Save";
            this.INV_btnEditSave.Visible = false;
            this.INV_btnEditSave.Click += new System.EventHandler(this.INV_btnEditSave_Click);
            // 
            // INV_btnRevert
            // 
            this.INV_btnRevert.Image = ((System.Drawing.Image)(resources.GetObject("INV_btnRevert.Image")));
            this.INV_btnRevert.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.INV_btnRevert.Location = new System.Drawing.Point(1391, 142);
            this.INV_btnRevert.Name = "INV_btnRevert";
            this.INV_btnRevert.Size = new System.Drawing.Size(115, 33);
            this.INV_btnRevert.TabIndex = 150;
            this.INV_btnRevert.Text = "Revert";
            this.INV_btnRevert.Visible = false;
            this.INV_btnRevert.Click += new System.EventHandler(this.INV_btnRevert_Click);
            // 
            // INV_btnEdit
            // 
            this.INV_btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("INV_btnEdit.Image")));
            this.INV_btnEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.INV_btnEdit.Location = new System.Drawing.Point(1391, 101);
            this.INV_btnEdit.Name = "INV_btnEdit";
            this.INV_btnEdit.Size = new System.Drawing.Size(115, 33);
            this.INV_btnEdit.TabIndex = 149;
            this.INV_btnEdit.Text = "Edit";
            this.INV_btnEdit.Click += new System.EventHandler(this.INV_btnEdit_Click);
            // 
            // INV_btnSave
            // 
            this.INV_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("INV_btnSave.Image")));
            this.INV_btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.INV_btnSave.Location = new System.Drawing.Point(1391, 227);
            this.INV_btnSave.Name = "INV_btnSave";
            this.INV_btnSave.Size = new System.Drawing.Size(115, 33);
            this.INV_btnSave.TabIndex = 148;
            this.INV_btnSave.Text = "Save";
            this.INV_btnSave.Visible = false;
            this.INV_btnSave.Click += new System.EventHandler(this.INV_btnSave_Click);
            this.INV_btnSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.INV_btnSave_MouseClick);
            this.INV_btnSave.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.INV_btnSave_PreviewKeyDown);
            // 
            // INV_btnAdd
            // 
            this.INV_btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("INV_btnAdd.Image")));
            this.INV_btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.INV_btnAdd.Location = new System.Drawing.Point(1391, 188);
            this.INV_btnAdd.Name = "INV_btnAdd";
            this.INV_btnAdd.Size = new System.Drawing.Size(115, 33);
            this.INV_btnAdd.TabIndex = 147;
            this.INV_btnAdd.Text = "Add";
            this.INV_btnAdd.Click += new System.EventHandler(this.INV_btnAdd_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.MistyRose;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(847, 194);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(204, 27);
            this.textBox5.TabIndex = 171;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(843, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 170;
            this.label7.Text = "Prev Balance";
            // 
            // DispatchPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1543, 698);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.InvSalesAgent);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.InvVanNo);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.INV_btnEditSave);
            this.Controls.Add(this.INV_btnRevert);
            this.Controls.Add(this.INV_btnEdit);
            this.Controls.Add(this.INV_btnSave);
            this.Controls.Add(this.INV_btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.btnColAdd);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.invAmountReceived);
            this.Controls.Add(this.InvColCustomerList);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DispatchPayments";
            this.Text = "DispatchPayments";
            this.Load += new System.EventHandler(this.DispatchPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvColCustomerList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerlistVanWiseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvSalesAgent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeListsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvVanNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edisonVanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView3;
        private DevExpress.XtraEditors.SimpleButton btnColAdd;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox invAmountReceived;
        private DevExpress.XtraEditors.SearchLookUpEdit InvColCustomerList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource customerlistVanWiseBindingSource;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.CustomerlistVanWiseTableAdapter customerlistVanWiseTableAdapter;
        private DevExpress.XtraEditors.SimpleButton INV_btnEditSave;
        private DevExpress.XtraEditors.SimpleButton INV_btnRevert;
        private DevExpress.XtraEditors.SimpleButton INV_btnEdit;
        private DevExpress.XtraEditors.SimpleButton INV_btnSave;
        private DevExpress.XtraEditors.SimpleButton INV_btnAdd;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column27;
        private System.Windows.Forms.DataGridViewButtonColumn Column29;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private DevExpress.XtraEditors.SearchLookUpEdit InvSalesAgent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView17;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.SearchLookUpEdit InvVanNo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.BindingSource edisonVanBindingSource;
        private DataSet1TableAdapters.Edison_VanTableAdapter edison_VanTableAdapter;
        private System.Windows.Forms.BindingSource employeListsBindingSource;
        private DataSet1TableAdapters.EmployeListsTableAdapter employeListsTableAdapter;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
    }
}