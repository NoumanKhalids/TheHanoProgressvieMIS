using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MIS_ProgressiveDistributors
{
    public partial class DispatchExpense : Form
    {
        public DispatchExpense()
        {
            InitializeComponent();
        }

        string DNO = "";
        string EmpCodee = "";

        EdisonSales form1;

        string checkcustid = "";
        public DispatchExpense(string DispatchNo, String EmpCode, EdisonSales form1, string custid)
        {
            InitializeComponent();
            DNO = DispatchNo;
            EmpCodee = EmpCode;
            this.form1 = form1;
            checkcustid = custid;
        }


        private void DispatchExpense_Load(object sender, EventArgs e)
        {

            this.edison_ExpenseTableAdapter.Fill(this.dataSet1.Edison_Expense);

            this.employeListsTableAdapter.Fill(this.dataSet1.EmployeLists);

            this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);

            textBox4.Text = DNO;
            getAll();

            DataClasses1DataContext db = new DataClasses1DataContext();

            var getmazeeddetails = from d in db.Edison_DispatchExpDTLs
                                   join v in db.Edison_Expenses on d.ExpenseID equals v.ExpenseID into bookingmGroup
                                   from v in bookingmGroup.DefaultIfEmpty()
                                   where d.DispatchNo.Equals(DNO)
                                   select new
                                   {
                                       d.ExpenseID,
                                       v.ExpenseDescription,
                                       d.Amount,
                                   };

            if (getmazeeddetails.Any())
            {
                foreach (var a in getmazeeddetails)
                {
                    dataGridView5.Rows.Add(null, a.ExpenseID, a.ExpenseDescription, a.Amount);
                }
            }
            dataGridView5.ClearSelection();
            Expense_SumAll();

            db.Dispose();
        }

        private void getAll()
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                DataClasses1DataContext db = new DataClasses1DataContext();


                var getHDR = from d in db.Edison_DispatchHDRs
                             where d.DispatchNo.Equals(textBox4.Text)
                             select new
                             {
                                 d.VanID,
                                 d.EmpCode,
                                 d.DispatchDate,
                                 d.ReadingIn,
                                 d.ReadingOut
                                 
                             };

                if (getHDR.Any())
                {
                    foreach (var a in getHDR)
                    {
                        InvVanNo.EditValue = a.VanID;
                        InvSalesAgent.EditValue = a.EmpCode;
                        dateTimePicker1.Value = Convert.ToDateTime(a.DispatchDate);



                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Wait! Something is wrong");
                    return;
                }
            }



        }
        private void CD_EnabeAll()
        {
     
            searchLookUpEdit12.Enabled = true;
            textBox24.Enabled = true;

        }

        private void CD_DisableAll()
        {


            searchLookUpEdit12.Enabled = false;
            textBox24.Enabled = false;

        }
        private void CD_AddState()
        {
            CD_BtnAdd.Visible = false;
            CD_BtnRevert.Visible = true;
            CD_BtnSave.Visible = true;
            CD_BtnEdit.Visible = false;
            CD_BtnEditSave.Visible = false;
       
        }

        private void CD_RevertState()
        {
            CD_BtnAdd.Visible = true;
            CD_BtnRevert.Visible = false;
            CD_BtnSave.Visible = false;
            CD_BtnEdit.Visible = true;
            CD_BtnEditSave.Visible = false;

        }

        private void CD_EditSaveState()
        {
            CD_BtnAdd.Visible = false;
            CD_BtnRevert.Visible = true;
            CD_BtnSave.Visible = false;
            CD_BtnEdit.Visible = false;
            CD_BtnEditSave.Visible = true;

        }

        private void CD_ClearAll()
        {
            searchLookUpEdit12.Text = "";
            textBox24.Text = "";
        }

        private void CD_BtnAdd_Click(object sender, EventArgs e)
        {
     

            CD_AddState();
            CD_ClearAll();
            CD_EnabeAll();

            searchLookUpEdit12.Focus();
            searchLookUpEdit12.ShowPopup();
        }

        private void InsertTheDataInToGrid()
        {
            dataGridView5.Rows.Add(null, searchLookUpEdit12.EditValue, searchLookUpEdit12.Text, textBox24.Text);
            searchLookUpEdit12.Text = "";
            textBox24.Text = "";
            Expense_SumAll();
            searchLookUpEdit12.Focus();
            searchLookUpEdit12.ShowPopup();
        }

        private void Expense_SumAll()
        {
            int j = 1;

            Decimal summTotalQty = 0;

            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                row.Cells[0].Value = j++;


                if (!string.IsNullOrEmpty(row.Cells[3].Value.ToString()))
                {
                    summTotalQty += Convert.ToDecimal(row.Cells[3].Value.ToString());
                }

            }

            textBox26.Text = summTotalQty.ToString();
            textBox25.Text = dataGridView5.Rows.Count.ToString();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_MouseClick(object sender, MouseEventArgs e)
        {
            InsertTheDataInToGrid();
        }

        private void simpleButton2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InsertTheDataInToGrid();
            }
        }

        private void CD_BtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void CD_BtnRevert_Click(object sender, EventArgs e)
        {
            CD_DisableAll();
            CD_RevertState();
            CD_ClearAll();
        }

        private void CD_BtnSave_Click(object sender, EventArgs e)
        {
            CDD_SaveEntry();
        }

        private void CDD_SaveEntry()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {
                Edison_DispatchExpHDR objCourse = new Edison_DispatchExpHDR();
                objCourse.DispatchNo = Convert.ToInt32(textBox4.Text);
                objCourse.InsertedDatetime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();
                db.Edison_DispatchExpHDRs.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                foreach (DataGridViewRow row in dataGridView5.Rows)
                {

                    Edison_DispatchExpDTL AddItems = new Edison_DispatchExpDTL();


                    AddItems.DispatchNo = objCourse.DispatchNo;

                    AddItems.ExpenseID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.Amount = Convert.ToDecimal(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());

                    db.Edison_DispatchExpDTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }

                scope.Complete();
                CD_RevertState();
                CD_DisableAll();

            }

            form1.RefreshFormExpense();
        }

        private void CD_BtnEditSave_Click(object sender, EventArgs e)
        {
            CDD_EditSaveEntry();
        }

        private void CDD_EditSaveEntry()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                //Edison_DispatchExpHDR objCourse = new Edison_DispatchExpHDR();

                //objCourse.DispatchNo = Convert.ToInt32(searchLookUpEdit13.EditValue);


                //objCourse.InsertedDatetime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                //db.Edison_DispatchExpHDRs.InsertOnSubmit(objCourse);
                //db.SubmitChanges();


                var a = from s in db.Edison_DispatchExpDTLs
                        where s.DispatchNo.Equals(textBox4.Text)
                        select s;

                if (a.Any())
                {
                    foreach (var d in a)
                    {
                        db.Edison_DispatchExpDTLs.DeleteOnSubmit(d);
                        db.SubmitChanges();
                    }
                }


                foreach (DataGridViewRow row in dataGridView5.Rows)
                {

                    Edison_DispatchExpDTL AddItems = new Edison_DispatchExpDTL();
                    AddItems.DispatchNo = Convert.ToInt32(textBox4.Text);
                    AddItems.ExpenseID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.Amount = Convert.ToDecimal(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());
                    db.Edison_DispatchExpDTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();
                   
                }

                CD_RevertState();
                CD_DisableAll();

                scope.Complete();
                

            }

            form1.RefreshFormExpense();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {


                    dataGridView5.Rows.RemoveAt(e.RowIndex);
                    Expense_SumAll();
                }
            }
        }

        private void CD_BtnSave_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void CD_BtnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CDD_SaveEntry();
            }
        }

        private void CD_BtnEdit_Click(object sender, EventArgs e)
        {
            CD_EnabeAll();
            CD_EditSaveState();

        
        }

        private void searchLookUpEdit12_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox24.Focus();

            }
        }

        private void textBox24_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton2.Focus();

            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            try
            {

                if (keyData == (Keys.Tab))
                {
                    return true;
                }

                if (keyData == (Keys.Alt | Keys.A))
                {
                    CD_BtnAdd.PerformClick();
                    return true;
                }

                if (keyData == (Keys.Alt | Keys.R))
                {
                    CD_BtnRevert.PerformClick();
                    return true;
                }


                if (keyData == (Keys.Alt | Keys.S) && CD_BtnSave.Visible == true)
                {
                    CD_BtnSave.PerformClick();
                    return true;
                }

                if (keyData == (Keys.Alt | Keys.S) && CD_BtnEditSave.Visible == true)
                {
                    CD_BtnEditSave.PerformClick();
                    return true;
                }


                if (keyData == (Keys.Alt | Keys.E))
                {
                    CD_BtnEdit.PerformClick();
                    return true;
                }






                //if (keyData == (Keys.Alt | Keys.R) && CustomersTab.SelectedTab.Name.Equals("OrdersTab"))
                //{
                //    if (RevertOrder.Visible == true)
                //    {
                //        RevertOrder.PerformClick();
                //        return true;
                //    }

                //}

                return base.ProcessCmdKey(ref msg, keyData);


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "ProcessCmdKey");
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }


    }
}
