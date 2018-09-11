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
    public partial class DispatchPayments : Form
    {
        string DNO = "";
        string EmpCodee = "";

        EdisonSales form1;

        string checkcustid = "";

        public DispatchPayments(string DispatchNo, String EmpCode, EdisonSales form1, string custid)
        {
            InitializeComponent();
            DNO = DispatchNo;
            EmpCodee = EmpCode;
            this.form1 = form1;
            checkcustid = custid;
        }
      
        private void DispatchPayments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.EmployeLists' table. You can move, or remove it, as needed.
            this.employeListsTableAdapter.Fill(this.dataSet1.EmployeLists);
            // TODO: This line of code loads data into the 'dataSet1.Edison_Van' table. You can move, or remove it, as needed.
            this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);

            textBox4.Text = DNO;



            getAll();


            DataClasses1DataContext db = new DataClasses1DataContext();
            var getTheSelecteddata = from s in db.Edison_DispatchPayments
                                     join v in db.All_Customers on s.CustID equals v.CustID into bookingmGroup
                                     from v in bookingmGroup.DefaultIfEmpty()
                                     join x in db.All_Cities on v.City equals x.CityID into bookingmGroup1
                                     from x in bookingmGroup1.DefaultIfEmpty()
                                     where s.DispatchNo.Equals(DNO)
                                     select new
                                     {
                                         s.CustID,
                                         v.CustomerName,
                                         v.CustomerAddress,
                                         x.CityName,
                                         s.Amount,
                                     };

            if (getTheSelecteddata.Any())
            {
                foreach (var ab in getTheSelecteddata)
                {
                    dataGridView3.Rows.Add("", ab.CustID, ab.CustomerName, ab.CustomerAddress, ab.CityName, ab.Amount);
                }
            }

            Collection_SumAll();

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

            this.customerlistVanWiseTableAdapter.Fill(this.dataSet1.CustomerlistVanWise, Convert.ToInt32(InvVanNo.EditValue));

        }
        private void INV_AddState()
        {
            INV_btnAdd.Visible = false;
            INV_btnEdit.Visible = false;
            INV_btnRevert.Visible = true;
            INV_btnSave.Visible = true;
            INV_btnEditSave.Visible = false;
 
        }

        private void INV_RevertState()
        {
            INV_btnAdd.Visible = true;
            INV_btnEdit.Visible = true;
            INV_btnRevert.Visible = false;
            INV_btnSave.Visible = false;
            INV_btnEditSave.Visible = false;
 
        }

        private void INV_EditSaveState()
        {
            INV_btnAdd.Visible = false;
            INV_btnEdit.Visible = false;
            INV_btnRevert.Visible = true;
            INV_btnSave.Visible = false;
            INV_btnEditSave.Visible = true;

        }

        private void Inv_EnableAll()
        {
            InvColCustomerList.Enabled = true;
            textBox1.Enabled = true;
            textBox6.Enabled = true;
            invAmountReceived.Enabled = true;

        }

        private void Inv_DisableAll()
        {

            InvColCustomerList.Enabled = false;
            textBox1.Enabled = false;
            textBox6.Enabled = false;
            invAmountReceived.Enabled = false;
        }

        private void Inv_ClearAll()
        {
            InvColCustomerList.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";
            invAmountReceived.Text = "";



        }

        private void INV_btnAdd_Click(object sender, EventArgs e)
        {
            INV_AddState();
            Inv_ClearAll();

            Inv_EnableAll();

            InvColCustomerList.Focus();
            InvColCustomerList.ShowPopup();
        }

        private void InvColCustomerList_EditValueChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(InvColCustomerList.Text))
            {


                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.All_Customers
                                         join v in db.All_Cities on s.City equals v.CityID into bookingmGroup
                                         from v in bookingmGroup.DefaultIfEmpty()
                                         where s.CustID.Equals(InvColCustomerList.EditValue)
                                         select new
                                         {
                                             s.CustID,
                                             s.CustomerName,
                                             s.CustomerAddress,
                                             v.CityName,
                                             s.VanID,


                                         };

                if (getTheSelecteddata.Any())
                {
                    foreach (var ab in getTheSelecteddata)
                    {
                        textBox1.Text = ab.CustomerAddress;
                        textBox6.Text = ab.CityName;
                        //   searchLookUpEdit10.EditValue = ab.VanID;

                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Dispatch Number");
                    return;
                }
            }

            getPrevBalance();
        }

        private void InvColCustomerList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                invAmountReceived.Focus();

            }
        }

        private void btnColAdd_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnColAdd_Click(object sender, EventArgs e)
        {
            AddRowInCollection();
        }

        private void btnColAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AddRowInCollection();
            }
        }

        private void AddRowInCollection()
        {
            if(string.IsNullOrEmpty(InvColCustomerList.Text) || string.IsNullOrEmpty(invAmountReceived.Text))
            {
                MessageBox.Show("Error! Please Select a Customer & Enter the Amount!");
                return;
            }
            else
            {
                dataGridView3.Rows.Add("", InvColCustomerList.EditValue, InvColCustomerList.Text, textBox1.Text, textBox6.Text, invAmountReceived.Text);
                Collection_SumAll();

                InvColCustomerList.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                invAmountReceived.Text = "";
                textBox5.Text = "";

                InvColCustomerList.Focus();
                InvColCustomerList.ShowPopup();
            }
       
        }

        private void INV_btnRevert_Click(object sender, EventArgs e)
        {
            INV_RevertState();
            Inv_ClearAll();
            Inv_DisableAll();
        }

        private void Collection_SumAll()
        {
            int j = 1;

            Decimal summTotalQty = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                row.Cells[0].Value = j++;


                if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                {
                    summTotalQty += Convert.ToDecimal(row.Cells[5].Value.ToString());
                }

            }

            textBox2.Text = summTotalQty.ToString();
            textBox3.Text = dataGridView3.Rows.Count.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {


                    dataGridView3.Rows.RemoveAt(e.RowIndex);
                    Collection_SumAll();
                }
            }
        }

        private void INV_btnSave_Click(object sender, EventArgs e)
        {

        }

        private void INV_btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            SaveCollection();
        }

        private void INV_btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveCollection();
            }
        }

        private void SaveCollection()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    Edison_DispatchPayment AddItems1 = new Edison_DispatchPayment();
                    AddItems1.Date = dateTimePicker1.Value;
                    AddItems1.CustID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems1.Amount = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems1.DispatchNo = Convert.ToInt32(textBox4.Text);
                    db.Edison_DispatchPayments.InsertOnSubmit(AddItems1);
                    db.SubmitChanges();
                }



                scope.Complete();

            }

            INV_RevertState();
            Inv_DisableAll();

            db.Dispose();

            form1.RefreshForm();

        }

        private void INV_btnEditSave_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {

                var ba = from s in db.Edison_DispatchPayments
                         where s.DispatchNo.Equals(textBox4.Text)
                         select s;

                if (ba.Any())
                {
                    foreach (var d in ba)
                    {
                        db.Edison_DispatchPayments.DeleteOnSubmit(d);
                        db.SubmitChanges();
                    }
                }


                foreach (DataGridViewRow row in dataGridView3.Rows)
                {

                    Edison_DispatchPayment AddItems1 = new Edison_DispatchPayment();


                    AddItems1.Date = dateTimePicker1.Value;
                    AddItems1.CustID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems1.Amount = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems1.VanNo = Convert.ToInt32(InvVanNo.EditValue);
                    AddItems1.EmpCode = Convert.ToInt32(InvSalesAgent.EditValue);
                    AddItems1.DispatchNo = Convert.ToInt32(textBox4.Text);

                    db.Edison_DispatchPayments.InsertOnSubmit(AddItems1);
                    db.SubmitChanges();


                }
                INV_RevertState();
                Inv_DisableAll();

                scope.Complete();
            }
            form1.RefreshForm();
        }

        private void INV_btnEdit_Click(object sender, EventArgs e)
        {
            INV_EditSaveState();
            Inv_EnableAll();
        }

        private void invAmountReceived_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnColAdd.Focus();
           

            }
            
        }


        private void getPrevBalance()
        {

            if(InvColCustomerList.EditValue != "")
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getPrevBalance = from All_Customers in db.All_Customers
                                     where
                                       All_Customers.CustID == Convert.ToInt32(InvColCustomerList.EditValue)
                                     select new
                                     {
                                         All_Customers.CustID,
                                         All_Customers.CustomerName,
                                         Balance = (All_Customers.OpeningBalance1 + ((System.Decimal?)
                             (from Edison_InvoiceHDR in db.Edison_InvoiceHDRs
                              where
          Edison_InvoiceHDR.CustID == All_Customers.CustID &&
          Edison_InvoiceHDR.Date < dateTimePicker1.Value.Date
                              select new
                              {
                                  Edison_InvoiceHDR.TotalAmount
                              }).Sum(p => p.TotalAmount) ?? (System.Decimal?)0) - ((System.Decimal?)
                             (from Edison_DispatchPayment in db.Edison_DispatchPayments
                              where
          Edison_DispatchPayment.CustID == All_Customers.CustID &&
          Edison_DispatchPayment.Date < dateTimePicker1.Value.Date
                              select new
                              {
                                  Column1 = (((System.Decimal?)Edison_DispatchPayment.Amount ?? (System.Decimal?)0) + ((System.Decimal?)Edison_DispatchPayment.WriteOff ?? (System.Decimal?)0))
                              }).Sum(p => p.Column1) ?? (System.Decimal?)0) - ((System.Decimal?)
                             (from Edison_SalesReturnHDR in db.Edison_SalesReturnHDRs
                              where
          Edison_SalesReturnHDR.CustID == All_Customers.CustID &&
          Edison_SalesReturnHDR.Date < dateTimePicker1.Value.Date
                              select new
                              {
                                  Edison_SalesReturnHDR.TotalAmount
                              }).Sum(p => p.TotalAmount) ?? (System.Decimal?)0))
                                     };

                if (getPrevBalance.Any())
                {
                    foreach (var ab in getPrevBalance)
                    {

                        textBox5.Text = ab.Balance.ToString();
                        break;
                    }
                }

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
                    INV_btnAdd.PerformClick();
                    return true;
                }

                if (keyData == (Keys.Alt | Keys.R))
                {
                    INV_btnRevert.PerformClick();
                    return true;
                }


                if (keyData == (Keys.Alt | Keys.S) && INV_btnSave.Visible == true)
                {
                    INV_btnSave.PerformClick();
                    return true;
                }

                if (keyData == (Keys.Alt | Keys.S) && INV_btnEditSave.Visible == true)
                {
                    INV_btnEditSave.PerformClick();
                    return true;
                }


                if (keyData == (Keys.Alt | Keys.E))
                {
                    INV_btnEdit.PerformClick();
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
