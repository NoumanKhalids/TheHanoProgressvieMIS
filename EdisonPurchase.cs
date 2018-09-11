using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS_ProgressiveDistributors
{
    public partial class EdisonPurchase : Form
    {
        public EdisonPurchase()
        {
            InitializeComponent();
        }

        private void EdisonPurchase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Edison_Products' table. You can move, or remove it, as needed.
            this.edison_ProductsTableAdapter.Fill(this.dataSet1.Edison_Products);
            // TODO: This line of code loads data into the 'dataSet1.SupplierLists' table. You can move, or remove it, as needed.
            this.supplierListsTableAdapter.Fill(this.dataSet1.SupplierLists);

        }



        private void EP_AddState()
        {
            SP_BtnAdd.Visible = false;
            SP_BtnSave.Visible = true;
            SP_BtnRevert.Visible = true;
            SP_BtnEdit.Visible = false;
            SP_BtnEditSave.Visible = false;
            SP_BtnSearch.Visible = false;
            dataGridView1.Columns[9].Visible = true;
        }


        private void EP_RevertState()
        {
            SP_BtnAdd.Visible = true;
            SP_BtnSave.Visible = false;
            SP_BtnRevert.Visible = false;
            SP_BtnEdit.Visible = true;
            SP_BtnEditSave.Visible = false;
            SP_BtnSearch.Visible = true;
            dataGridView1.Columns[9].Visible = false;

        }



        private void EP_EditSaveState()
        {
            SP_BtnAdd.Visible = false;
            SP_BtnSave.Visible = false;
            SP_BtnRevert.Visible = true;
            SP_BtnEdit.Visible = false;
            SP_BtnEditSave.Visible = true;
            SP_BtnSearch.Visible = false;
            dataGridView1.Columns[9].Visible = true;

        }

        private void EP_EnableAll()
        {
            dateTimePicker1.Enabled = true;
            searchLookUpEdit1.Enabled = true;
            textBox2.Enabled = true;
            searchLookUpEdit2.Enabled = true;
            SP_txtQty.Enabled = true;
            SP_txtRates.Enabled = true;
            SP_txtValue.Enabled = true;
            SP_txtDiscount.Enabled = true;
            SP_txtNetValue.Enabled = true;

        }

        private void EP_DisableAll()
        {
            dateTimePicker1.Enabled = false;
            searchLookUpEdit1.Enabled = false;
            textBox2.Enabled = false;
            searchLookUpEdit2.Enabled = false;
            SP_txtQty.Enabled = false;
            SP_txtRates.Enabled = false;
            SP_txtValue.Enabled = false;
            SP_txtDiscount.Enabled = false;
            SP_txtNetValue.Enabled = false;

        }

        private void EP_ClearAll()
        {
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            searchLookUpEdit1.Text = "";
            textBox2.Text = "";
            searchLookUpEdit2.Text = "";
            SP_txtQty.Text = "";
            SP_txtRates.Text = ""; ;
            SP_txtValue.Text = "";
            SP_txtDiscount.Text = "";
            SP_txtNetValue.Text = "";
            textBox12.Text = "0";
            textBox13.Text = "";
            dataGridView1.Rows.Clear();


        }

        private void EP_ItemClearAll()
        {
            searchLookUpEdit2.Text = "";
            SP_txtQty.Text = "";
            SP_txtRates.Text = ""; ;
            SP_txtValue.Text = "";
            SP_txtDiscount.Text = "";
            SP_txtNetValue.Text = "";
    


        }

        private void SP_BtnAdd_Click(object sender, EventArgs e)
        {
            EP_ClearAll();
            EP_EnableAll();
            EP_AddState();
            dateTimePicker1.Focus();

        }

        private void dateTimePicker1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit1.Focus();
                searchLookUpEdit1.ShowPopup();

            }
        }

        private void searchLookUpEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit2.Focus();
                searchLookUpEdit2.ShowPopup();
            }
        }

        private void searchLookUpEdit2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SP_txtQty.Focus();
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SP_txtRates.Focus();
            }
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SP_txtValue.Focus();
            }
        }

        private void textBox6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SP_txtDiscount.Focus();
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SP_txtNetValue.Focus();
            }
        }

        private void textBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(searchLookUpEdit2.Text))
                {
                    dataGridView1.Rows.Add(null, searchLookUpEdit2.EditValue, searchLookUpEdit2.Text, textBox13.Text, SP_txtQty.Text, SP_txtRates.Text, SP_txtValue.Text, SP_txtDiscount.Text, SP_txtNetValue.Text);
                    if (string.IsNullOrEmpty(textBox12.Text))
                    {
                        textBox12.Text = "0";
                    }

                    textBox12.Text = (Convert.ToDecimal(textBox12.Text) + Convert.ToDecimal(SP_txtNetValue.Text)).ToString();
                    EP_ItemClearAll();
                    searchLookUpEdit2.Focus();
                    searchLookUpEdit2.ShowPopup();

                    int j = 1;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[0].Value = j++;
                    }

                }


            }
            else
            {
                MessageBox.Show("Please Select An Item");
            }

        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit2.Text))
            {
                if (SP_BtnAdd.Visible == false)
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();


                    var getTheOrderDetail = from d in db.Edison_Products
                                            where d.ProductID.Equals(searchLookUpEdit2.EditValue)
                                            select new
                                            {
                                                d.RSSalePrice,
                                                d.ProductDescription,
                                            };

                    if (getTheOrderDetail.Any())
                    {
                        foreach (var AddNew in getTheOrderDetail)
                        {
                            SP_txtRates.Text = AddNew.RSSalePrice.ToString();
                            textBox13.Text = AddNew.ProductDescription.ToString();
                            break;
                        }
                    }

                }
            }
        }

        private void EP_UpdateRates()
        {
            try
            {
                SP_txtValue.Text = (Convert.ToDecimal(SP_txtQty.Text == "" ? "0" : SP_txtQty.Text) * Convert.ToDecimal(SP_txtRates.Text == "" ? "0" : SP_txtRates.Text)).ToString("#,##0.00");

                SP_txtNetValue.Text = (Convert.ToDecimal(SP_txtValue.Text == "" ? "0" : SP_txtValue.Text) - Convert.ToDecimal(SP_txtDiscount.Text == "" ? "0" : SP_txtDiscount.Text)).ToString("#,##0.00");

            }
            catch (Exception err)
            {

            }
        }



        private void SP_txtQty_TextChanged(object sender, EventArgs e)
        {
            EP_UpdateRates();
        }

        private void SP_txtRates_TextChanged(object sender, EventArgs e)
        {
            EP_UpdateRates();
        }

        private void SP_txtDiscount_TextChanged(object sender, EventArgs e)
        {
            EP_UpdateRates();
        }

        private void SP_BtnRevert_Click(object sender, EventArgs e)
        {
            EP_ClearAll();
            EP_RevertState();
            EP_DisableAll();
        }

        private void SP_SaveEntry()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                Edison_SupplierPurch_HDR objCourse = new Edison_SupplierPurch_HDR();

                objCourse.Date = dateTimePicker1.Value.Date;

                objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                objCourse.Remarks = textBox2.Text;

                //objCourse.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);

                objCourse.TotalAmount = Convert.ToDecimal(textBox12.Text);

                //   objCourse.InsertedDatetime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                db.Edison_SupplierPurch_HDRs.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                textBox1.Text = objCourse.Edison_SupplierPurchID.ToString();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    Edison_SupplierPurch_DTL AddItems = new Edison_SupplierPurch_DTL();


                   AddItems.Edison_SupplierPurchID = objCourse.Edison_SupplierPurchID;                                    

                    AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());      
                    AddItems.Qty = Convert.ToInt32(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    AddItems.Rate = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems.Value = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString()); 
                    AddItems.DiscountValue = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.NetValue = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());

                    db.Edison_SupplierPurch_DTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }


                dataGridView1.Columns[9].Visible = false;
                scope.Complete();
                EP_RevertState();
                EP_DisableAll();
                
            }
        }

        private void SP_BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            SP_SaveEntry();
        }

        private void SP_BtnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SP_SaveEntry();
            }
        }

        private void SP_BtnEdit_Click(object sender, EventArgs e)
        {
            EP_EnableAll();
            EP_EditSaveState();
            dateTimePicker1.Focus();

        }

        private void SP_BtnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void SP_BtnSearch_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void EP_SumDataGridNetValue()
        {
            decimal summ = 0;


            int j = 1;



            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {

                if (!string.IsNullOrEmpty(Myrow.Cells[8].Value.ToString()))
                {
                    summ += Convert.ToDecimal(Myrow.Cells[8].Value.ToString());
                    Myrow.Cells[0].Value = j++;
                }


            }
            textBox12.Text = summ.ToString();


        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox1.Text))
            {
                dateTimePicker1.Value = DateTime.Now;
                searchLookUpEdit1.Text = "";
                textBox2.Text = "";
                searchLookUpEdit2.Text = "";
                SP_txtQty.Text = "";
                SP_txtRates.Text = ""; ;
                SP_txtValue.Text = "";
                SP_txtDiscount.Text = "";
                SP_txtNetValue.Text = "";
                textBox12.Text = "0";
                textBox13.Text = "";
                dataGridView1.Rows.Clear();


                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.Edison_SupplierPurch_HDRs
                                         where s.Edison_SupplierPurchID.Equals(textBox1.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach(var ab in getTheSelecteddata)
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(ab.Date);
                        textBox2.Text = ab.Remarks.ToString();
                        searchLookUpEdit1.EditValue = ab.SupplierID;
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Invoice Number");
                    return;
                }


                var getTheSelecteddata1 = from s in db.Edison_SupplierPurch_DTLs
                                          join v in db.Edison_Products on s.PID equals v.ProductID into bookingmGroup
                                          from v in bookingmGroup.DefaultIfEmpty()
                                          where s.Edison_SupplierPurchID.Equals(textBox1.Text)
                                          select new
                                          {
                                              s.PID,
                                              s.Qty,
                                              s.Rate,
                                              s.Value,
                                              s.DiscountValue,
                                              s.NetValue,
                                              v.ProductCode,
                                              v.ProductDescription
                                          };

                if (getTheSelecteddata1.Any())
                {
                    foreach (var ab in getTheSelecteddata1)
                    {
                        dataGridView1.Rows.Add(null, ab.PID, ab.ProductCode, ab.ProductDescription, ab.Qty, ab.Rate, ab.Value, ab.DiscountValue, ab.NetValue);
           
                    }
                }

                EP_SumDataGridNetValue();
            }
        }

        private void SP_BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void SP_BtnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            SP_EditSaveEntry();
        }

        private void SP_BtnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SP_EditSaveEntry();
            }
        }


        private void SP_EditSaveEntry()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {

                var getTheSelecteddata = from s in db.Edison_SupplierPurch_HDRs
                                         where s.Edison_SupplierPurchID.Equals(textBox1.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {
                        objCourse.Date = dateTimePicker1.Value.Date;
                        objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                        objCourse.Remarks = textBox2.Text;
                        objCourse.TotalAmount = Convert.ToDecimal(textBox12.Text);
                        db.SubmitChanges();

                    }

                }



                var a = from s in db.Edison_SupplierPurch_DTLs
                        where s.Edison_SupplierPurchID.Equals(textBox1.Text.Trim())
                        select s;

                if (a.Any())
                {
                    foreach (var d in a)
                    {                     
                        db.Edison_SupplierPurch_DTLs.DeleteOnSubmit(d);
                        db.SubmitChanges();
                    }
                }


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    Edison_SupplierPurch_DTL AddItems = new Edison_SupplierPurch_DTL();


                    AddItems.Edison_SupplierPurchID = Convert.ToInt32(textBox1.Text.Trim());

                    AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.Qty = Convert.ToInt32(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    AddItems.Rate = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems.Value = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                    AddItems.DiscountValue = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.NetValue = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());

                    db.Edison_SupplierPurch_DTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }


                dataGridView1.Columns[9].Visible = false;
                scope.Complete();
                EP_RevertState();
                EP_DisableAll();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 9)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    textBox12.Text = (Convert.ToDecimal(textBox12.Text) - Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[8].Value)).ToString();

                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        private void SC_AddState()
        {
            SC_btnAdd.Visible = false;
            SC_btnSave.Visible = true;
            SC_btnEdit.Visible = false;
            SC_btnRevert.Visible = true;
            SC_btnEditSave.Visible = false;
            SC_btnSearch.Visible = false;
        }

        private void SC_RevertState()
        {
            SC_btnAdd.Visible = true;
            SC_btnSave.Visible = false;
            SC_btnEdit.Visible = true;
            SC_btnRevert.Visible = false;
            SC_btnEditSave.Visible = false;
            SC_btnSearch.Visible = true;
        }

        private void SC_EditState()
        {
            SC_btnAdd.Visible = false;
            SC_btnSave.Visible = false;
            SC_btnEdit.Visible = false;
            SC_btnRevert.Visible = true;
            SC_btnEditSave.Visible = true;
            SC_btnSearch.Visible = false;
        }

        private void SC_ClearAll()
        {
            textBox8.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            searchLookUpEdit3.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        private void SC_EnableAll()
        {
            dateTimePicker2.Enabled = true;
            searchLookUpEdit3.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
        }

        private void SC_DisableAll()
        {
            dateTimePicker2.Enabled = false;
            searchLookUpEdit3.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
        }

        private void SC_btnAdd_Click(object sender, EventArgs e)
        {
            SC_AddState();
            SC_ClearAll();
            SC_EnableAll();
            dateTimePicker2.Focus();
        }

        private void dateTimePicker2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit3.Focus();
                searchLookUpEdit3.ShowPopup();


            }
        }

        private void searchLookUpEdit3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }

        private void textBox10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
            }
        }

        private void textBox11_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(SC_btnSave.Visible == true)
                {

                    SC_btnSave.Focus();
                }
                else
                {
                    SC_btnEditSave.Focus();
                }
            }
        }

        private void SC_btnSave_Click(object sender, EventArgs e)
        {

        }

        private void SC_SaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {



                Edison_SupplierPayment objCourse = new Edison_SupplierPayment();
                objCourse.Date = dateTimePicker2.Value.Date;
                objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit3.EditValue);
                objCourse.Amount = Convert.ToDecimal(textBox9.Text == "" ? "0" : textBox9.Text);
                objCourse.WriteOff = Convert.ToDecimal(textBox10.Text == "" ? "0" : textBox10.Text);

                objCourse.Remarks = textBox11.Text.Trim();

                objCourse.InsertedDateTime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();
                db.Edison_SupplierPayments.InsertOnSubmit(objCourse);

                db.SubmitChanges();

                textBox8.Text = objCourse.SupplierPaymentID.ToString();

                SC_DisableAll();
                SC_RevertState();

                scope.Complete();


            }




        }
        private void SC_btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            SC_SaveAll();
        }

        private void SC_btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SC_SaveAll();
            }
        }

        private void SC_btnRevert_Click(object sender, EventArgs e)
        {
            SC_DisableAll();
            SC_ClearAll();
            SC_RevertState();
        }

        private void SC_btnSearch_Click(object sender, EventArgs e)
        {
            SC_ClearAll();
            textBox8.Enabled = true;
            textBox8.Focus();


        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Value = DateTime.Now;
                searchLookUpEdit3.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";

                if (!string.IsNullOrEmpty(textBox8.Text))
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();


                    var getTheSelecteddata = from s in db.Edison_SupplierPayments
                                             where s.SupplierPaymentID.Equals(textBox8.Text)
                                             select s;

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var objCourse in getTheSelecteddata)
                        {
                            dateTimePicker2.Value = Convert.ToDateTime(objCourse.Date);
                            searchLookUpEdit3.EditValue = Convert.ToInt32(objCourse.SupplierID);
                            textBox9.Text = objCourse.Amount.ToString();
                            textBox10.Text = objCourse.WriteOff.ToString();
                            textBox11.Text = objCourse.Remarks.ToString();
                            break;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter The Correct VCH # ");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter The Voucher #");
                    return;
                }


            }
            }

        private void SC_btnEditSave_Click(object sender, EventArgs e)
        {

        }



        private void SC_EditSaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                var getTheSelecteddata = from s in db.Edison_SupplierPayments
                                         where s.SupplierPaymentID.Equals(textBox8.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {                    
                        objCourse.Date = dateTimePicker2.Value.Date;
                        objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit3.EditValue);
                        objCourse.Amount = Convert.ToDecimal(textBox9.Text == "" ? "0" : textBox9.Text);
                        objCourse.WriteOff = Convert.ToDecimal(textBox10.Text == "" ? "0" : textBox10.Text);
                        objCourse.Remarks = textBox11.Text.Trim();
                        db.SubmitChanges();

                    }
                }

               

                SC_DisableAll();
                SC_RevertState();

                scope.Complete();


            }




        }


        private void SC_btnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            SC_EditSaveAll();
        }

        private void SC_btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SC_EditSaveAll();
            }
        }

        private void SC_btnEdit_Click(object sender, EventArgs e)
        {
            SC_EnableAll();
            SC_EditState();

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            getLedger();
        }

        private void getLedger()
        {
            try
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();

                DataClasses1DataContext db = new DataClasses1DataContext();
                db.ObjectTrackingEnabled = false;

                string code;




                DateTime cdate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                cdate = cdate.AddDays(-60);




                // ---------------------------------------------------------------
                var getopeningbalance = from w in db.Edison_Suppliers
                                        where w.SupplierID.Equals(searchLookUpEdit4.EditValue)
                                        select new
                                        {
                                            w.OpeningBalance,                                           

                                        };


                if (getopeningbalance.Any())
                {


                    foreach (var a in getopeningbalance)
                    {
                        dataGridView2.Rows.Add(null, null, "Opening Balance", null, null, "0", "0", "0", "0" ,a.OpeningBalance);
                        //    this.DataSet1.Ledger.Rows.Clear();

                        code = (searchLookUpEdit4).ToString();

             //           txtBalance.Text = Convert.ToDecimal(a.Balance).ToString("#,##0.00");


                        break;
                    }
                }
                //------------------------------------------------------------------



                var getdata = from d in db.Edison_SupplierPurch_HDRs
                              where d.SupplierID.Equals(searchLookUpEdit4.EditValue) && (d.Date >= Convert.ToDateTime("2015-01-01") && d.Date < LD_FromDate.Value.Date)
                              select new
                              {
                                  d.Edison_SupplierPurchID,
                                  d.Date,
                                  d.Remarks,
                                  d.TotalAmount,

                              };

                if (getdata.Any())
                {


                    foreach (var a in getdata)
                    {
                        dataGridView2.Rows.Add(a.Edison_SupplierPurchID, a.Date, "Billing", null, null,null, a.TotalAmount, "0", "0");
                    }

                }




                var getdata222 = from f in db.Edison_SupplierPurchReturn_HDRs
                               where f.SupplierID.Equals(searchLookUpEdit4.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                               select new
                               {
                                   f.Edison_SupplierPurchReturnID,
                                   f.Date,
                                   f.Remarks,
                                   f.TotalAmount,
                                   


                               };

                if (getdata222.Any())
                {
                    foreach (var b in getdata222)
                    {
                        dataGridView2.Rows.Add(b.Edison_SupplierPurchReturnID, b.Date, "Sales Return", null, "0", "0", "0", "0", b.TotalAmount);
                        //dataGridView2.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }



                var getdata2 = from f in db.Edison_SupplierPayments
                               where f.SupplierID.Equals(searchLookUpEdit4.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                               select new
                               {
                                   f.SupplierPaymentID,
                                   f.Date,
                                   f.Remarks,
                                   f.Amount,                                                      
                                   f.WriteOff


                               };

                if (getdata2.Any())
                {
                    foreach (var b in getdata2)
                    {
                        dataGridView2.Rows.Add(b.SupplierPaymentID, b.Date, "Collection", null, "0", "0", "0", b.Amount, b.WriteOff);
                        //dataGridView2.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }

                dataGridView2.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

                dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Ascending);
                this.dataGridView2.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;




                for (int i = 1; i < dataGridView2.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView2[6, i].Value) == 0) && ((Convert.ToDecimal(dataGridView2[7, i].Value) != 0) || (Convert.ToDecimal(dataGridView2[8, i].Value) != 0)))
                    {
                        dataGridView2[9, i].Value = Convert.ToDecimal(dataGridView2[9, i - 1].Value) - Convert.ToDecimal(dataGridView2[7, i].Value) - Convert.ToDecimal(dataGridView2[8, i].Value);
                    }
                    else
                    {
                        dataGridView2[9, i].Value = (Convert.ToDecimal(dataGridView2[6, i].Value) + Convert.ToDecimal(dataGridView2[8, i].Value) + Convert.ToDecimal(dataGridView2[9, i - 1].Value));

                    }

                }



                //--------------------------------------------------------------------------------------------------------------------------------------------------------------


                decimal getvalue = 0;


                Int32 index = dataGridView2.Rows.Count - 1;

                getvalue = Convert.ToDecimal(dataGridView2[9, index].Value);





                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();


                // ---------------------------------------------------------------

                // dataGridView2.Rows.Add(null, "Opening Balance", null, null, null, null, null, null, getvalue.ToString("#,##0.00"));

                dataGridView2.Rows.Add(null, null, "Opening Balance", null, "0", "0", "0", "0", "0", getvalue.ToString("#,##0.00"), "0");


                //------------------------------------------------------------------

                DataClasses1DataContext connection = new DataClasses1DataContext();

                connection.ObjectTrackingEnabled = false;

                var getdata1 = from d in db.Edison_SupplierPurch_HDRs
                              where d.SupplierID.Equals(searchLookUpEdit4.EditValue) && (d.Date >= LD_FromDate.Value.Date && d.Date <= LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                               select new
                               {
                                   d.Edison_SupplierPurchID,
                                   d.Date,
                                   d.Remarks,
                                   d.TotalAmount,



                               };

                if (getdata1.Any())
                {


                    foreach (var a in getdata1)
                    {
                        dataGridView2.Rows.Add(a.Edison_SupplierPurchID, a.Date, "Billing " + a.Remarks, null, null, null, a.TotalAmount, "0", "0");
                    }

                }







                var getdata2223 = from f in db.Edison_SupplierPurchReturn_HDRs
                                  where f.SupplierID.Equals(searchLookUpEdit4.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                                  select new
                                 {
                                     f.Edison_SupplierPurchReturnID,
                                     f.Date,
                                     f.Remarks,
                                     f.TotalAmount,



                                 };

                if (getdata2223.Any())
                {
                    foreach (var b in getdata2223)
                    {
                        dataGridView2.Rows.Add(b.Edison_SupplierPurchReturnID, b.Date, "Sales Return " + b.Remarks, null, "0", "0", "0", "0", b.TotalAmount);
                        //dataGridView2.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }




                //var getreturn1 = from f in db.tbl_SaleReturnHDRs
                //                 where f.CustID.Equals(searchLookUpEdit4.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                //                 select new
                //                 {
                //                     f.SRNo,
                //                     f.Date,
                //                     f.Remarks,
                //                     f.SaleReturnAmount,
                //                     f.CustID,

                //                 };

                //if (getreturn1.Any())
                //{


                //    foreach (var a in getreturn1)
                //    {
                //        dataGridView2.Rows.Add(a.SRNo, a.Date, "Sale Return", a.SRNo, null, "0", "0", a.SaleReturnAmount);
                //    }

                //}



                var getdata22 = from f in db.Edison_SupplierPayments
                               where f.SupplierID.Equals(searchLookUpEdit4.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                                select new
                                {
                                    f.SupplierPaymentID,
                                    f.Date,
                                    f.Remarks,
                                    f.Amount,
                                    f.WriteOff


                                };

                if (getdata22.Any())
                {
                    foreach (var b in getdata22)
                    {
                        dataGridView2.Rows.Add(b.SupplierPaymentID, b.Date, "Collection " + b.Remarks, null, "0", "0", "0", b.Amount, b.WriteOff);
                        //dataGridView2.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }




                dataGridView2.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";


                dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Ascending);
                this.dataGridView2.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;



                for (int i = 1; i < dataGridView2.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView2[6, i].Value) == 0) && ((Convert.ToDecimal(dataGridView2[7, i].Value) != 0) || (Convert.ToDecimal(dataGridView2[8, i].Value) != 0)))
                    {
                        dataGridView2[9, i].Value = Convert.ToDecimal(dataGridView2[9, i - 1].Value) - Convert.ToDecimal(dataGridView2[7, i].Value) - Convert.ToDecimal(dataGridView2[8, i].Value);
                    }
                    else
                    {
                        dataGridView2[9, i].Value = (Convert.ToDecimal(dataGridView2[6, i].Value) + Convert.ToDecimal(dataGridView2[8, i].Value) + Convert.ToDecimal(dataGridView2[9, i - 1].Value));

                    }

                }




                //for (int i = 1; i < dataGridView2.Rows.Count; i++)
                //{

                //    if ((Convert.ToDecimal(dataGridView2[5, i].Value) == 0) && ((Convert.ToDecimal(dataGridView2[6, i].Value) != 0) || (Convert.ToDecimal(dataGridView2[7, i].Value) != 0)))
                //    {
                //        dataGridView2[8, i].Value = Convert.ToDecimal(dataGridView2[8, i - 1].Value) - Convert.ToDecimal(dataGridView2[6, i].Value) - Convert.ToDecimal(dataGridView2[7, i].Value);
                //    }
                //    else
                //    {
                //        dataGridView2[8, i].Value = (Convert.ToDecimal(dataGridView2[5, i].Value) + Convert.ToDecimal(dataGridView2[7, i].Value) + Convert.ToDecimal(dataGridView2[8, i - 1].Value));

                //    }

                //}




                //foreach (DataGridViewRow Myrow in dataGridView2.Rows)
                //{            //Here 2 cell is target value and 1 cell is Volume



                //    if (Convert.ToInt32(Myrow.Cells[9].Value) == 1)// Or your condition 
                //    {
                //        Myrow.DefaultCellStyle.ForeColor = Color.Green;
                //    }


                //    if (Convert.ToInt32(Myrow.Cells[9].Value) == 2)// Or your condition 
                //    {
                //        Myrow.DefaultCellStyle.ForeColor = Color.Blue;
                //    }

                //}



                //  dataGridView2.Columns[5].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView2.Columns[9].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView2.Columns[8].DefaultCellStyle.BackColor = Color.MistyRose;
                dataGridView2.Columns[7].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                dataGridView2.Columns[6].DefaultCellStyle.BackColor = Color.Khaki;

                //for (int i = 0; i < dataGridView2.Rows.Count; i++)
                //{ //                                                                                  date                                bill #                                     cases                                   bility amount                decription                                   bill amount                coll                                     writeoff                                balance
                //    //DataSet1.Ledger.AddLedgerRow(null, null, null, null, null, null, dataGridView2[0, i].Value.ToString(), dataGridView2[7, i].Value.ToString(), dataGridView2[10, i].Value.ToString(), dataGridView2[12, i].Value.ToString(), dataGridView2[16, i].Value.ToString(), dataGridView2[17, i].Value.ToString(), dataGridView2[18, i].Value.ToString(), dataGridView2[19, i].Value.ToString(), dataGridView2[20, i].Value.ToString());
                //    DataSet1.Ledger.Rows.Add(searchLookUpEdit4.EditValue, LedgerCustomerName.Text, LedgerCAddress.Text, LedgerCity.Text, LD_FromDate.Value.Date, LD_ToDate.Value.DATE, dataGridView2[0, i].Value, dataGridView2[7, i].Value, dataGridView2[10, i].Value, dataGridView2[12, i].Value, dataGridView2[16, i].Value, dataGridView2[18, i].Value, dataGridView2[19, i].Value, dataGridView2[20, i].Value, dataGridView2[21, i].Value);
                //}



                //if (!string.IsNullOrEmpty(dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[10].Value.ToString()) && !string.IsNullOrEmpty(LD_Balance.Text))
                //{
                //    if (dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[10].Value.ToString() != LD_Balance.Text)
                //    {
                //        panel10.BackColor = Color.Red;
                //        panel10.Visible = true;
                //    }
                //    else
                //    {
                //        panel10.Visible = false;
                //    }
                //}


                //LGR_TotalSale.Text = dataGridView2.Rows[dataGridView2.RowCount - 1].Cells[21].Value.ToString();


                dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.RowCount - 1;


                //     sumforledger();



                //   txtPerDay.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)*7) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit4.EditValue + ") And Posted = 1")[0];

                //   txtPerWeekLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit4.EditValue + ") And Posted = 1")[0];

                //   txtPerMonthLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)/4) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit4.EditValue + ") And Posted = 1")[0];

                dataGridView2.ClearSelection();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void searchLookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {
            getLedger();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void purchasereturnEnableAll()
        {
            textBox16.Enabled = true;
            dateTimePicker3.Enabled = true;
            searchLookUpEdit6.Enabled = true;
            textBox17.Enabled = true;
            searchLookUpEdit5.Enabled = true;
      
            comboBoxEdit1.Enabled = true;
            PR_Qty.Enabled = true;
            PR_Rates.Enabled = true;
            PR_Value.Enabled = true;
            PR_Discount.Enabled = true;
            PR_NetValue.Enabled = true;
            textBox4.Enabled = true;
        }

        private void purchasereturnDisableAll()
        {
            textBox16.Enabled = false;
            dateTimePicker3.Enabled = false;
            searchLookUpEdit6.Enabled = false;
            textBox17.Enabled = false;
            searchLookUpEdit5.Enabled = false;

            comboBoxEdit1.Enabled = false;
            PR_Qty.Enabled = false;
            PR_Rates.Enabled = false;
            PR_Value.Enabled = false;
            PR_Discount.Enabled = false;
            PR_NetValue.Enabled = false;
            textBox4.Enabled = false;
        }

        private void purchasereturnClearAll()
        {
            textBox16.Text = "";
            dateTimePicker3.Text = "";
            searchLookUpEdit6.Text = "";
            textBox17.Text = "";
            searchLookUpEdit5.Text = "";
            textBox3.Text = "";
            comboBoxEdit1.Text = "";
            PR_Qty.Text = "";
            PR_Rates.Text = "";
            PR_Value.Text = "";
            PR_Discount.Text = "";
            PR_NetValue.Text = "";
            textBox4.Text = "";

            dataGridView3.Rows.Clear();

        }

        private void purchasereturnAddState()
        {
            PR_Add.Visible = false;
            PR_Save.Visible = true;
            PR_Edit.Visible = false;
            PR_Revert.Visible = true;
            PR_EditSave.Visible = false;
            PR_Search.Visible = false;
        }

        private void purchasereturnRevertState()
        {
            PR_Add.Visible = true;
            PR_Save.Visible = false;
            PR_Edit.Visible = true;
            PR_Revert.Visible = false;
            PR_EditSave.Visible = false;
            PR_Search.Visible = true;

        }

        private void purchasereturnEditState()
        {
            PR_Add.Visible = false;
            PR_Save.Visible = false;
            PR_Edit.Visible = false;
            PR_Revert.Visible = true;
            PR_EditSave.Visible = true;
            PR_Search.Visible = false;
        }


        private void simpleButton6_Click(object sender, EventArgs e)
        {
            purchasereturnClearAll();

            purchasereturnAddState();

            purchasereturnEnableAll();

            dateTimePicker3.Focus();

        }

        private void PR_Revert_Click(object sender, EventArgs e)
        {
            purchasereturnClearAll();
            purchasereturnDisableAll();
            purchasereturnRevertState();
        }

        private void dateTimePicker3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit6.Focus();
                searchLookUpEdit6.ShowPopup();
            }
        }

        private void searchLookUpEdit6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox17.Focus();
            }
        }

        private void textBox17_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit5.Focus();
                searchLookUpEdit5.ShowPopup();
            }
        }

        private void searchLookUpEdit5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                comboBoxEdit1.Focus();
                comboBoxEdit1.ShowPopup();
            }
        }

        private void comboBoxEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PR_Qty.Focus();
            }
                    
        }

        private void textBox14_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PR_Rates.Focus();
            }
        }

        private void textBox7_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PR_Discount.Focus();
            }
        }


        private void PR_UpdateRates()
        {
            try
            {
                PR_Value.Text = (Convert.ToDecimal(PR_Qty.Text == "" ? "0" : PR_Qty.Text) * Convert.ToDecimal(PR_Rates.Text == "" ? "0" : PR_Rates.Text)).ToString("#,##0.00");

                PR_NetValue.Text = (Convert.ToDecimal(PR_Value.Text == "" ? "0" : PR_Value.Text) - Convert.ToDecimal(PR_Discount.Text == "" ? "0" : PR_Discount.Text)).ToString("#,##0.00");

            }
            catch (Exception err)
            {

            }
        }

        private void PR_NetValue_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(searchLookUpEdit5.Text))
                {
                    dataGridView3.Rows.Add(null, searchLookUpEdit5.EditValue, searchLookUpEdit5.Text, textBox3.Text, comboBoxEdit1.Text, PR_Qty.Text, PR_Rates.Text, PR_Value.Text, PR_Discount.Text, PR_NetValue.Text);
                    if (string.IsNullOrEmpty(textBox4.Text))
                    {
                        textBox4.Text = "0";
                    }

                    textBox4.Text = (Convert.ToDecimal(textBox4.Text) + Convert.ToDecimal(PR_NetValue.Text)).ToString();



                    searchLookUpEdit5.Text = "";
                    textBox3.Text = "";
                    comboBoxEdit1.Text = "";
                    PR_Qty.Text = "";
                    PR_Rates.Text = "";
                    PR_Value.Text = "";
                    PR_Discount.Text = "";
                    PR_NetValue.Text = "";

                    searchLookUpEdit5.Focus();
                    searchLookUpEdit5.ShowPopup();

                    int j = 1;
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        row.Cells[0].Value = j++;
                    }

                }


            }
            else
            {
                MessageBox.Show("Please Select An Item");
            }
        }

        private void PR_Discount_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                PR_NetValue.Focus();
            }
        }

        private void PR_Rates_TextChanged(object sender, EventArgs e)
        {
            PR_UpdateRates();
        }

        private void PR_Discount_TextChanged(object sender, EventArgs e)
        {
            PR_UpdateRates();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    textBox4.Text = (Convert.ToDecimal(textBox4.Text) - Convert.ToDecimal(dataGridView3.Rows[e.RowIndex].Cells[9].Value)).ToString();

                    dataGridView3.Rows.RemoveAt(e.RowIndex);
                }
            }
        }



        private void PR_SaveEntry()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                Edison_SupplierPurchReturn_HDR objCourse = new Edison_SupplierPurchReturn_HDR();

                objCourse.Date = dateTimePicker3.Value.Date;

                objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit6.EditValue);
                objCourse.Remarks = textBox17.Text;

                //objCourse.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);

                objCourse.TotalAmount = Convert.ToDecimal(textBox4.Text);

                //   objCourse.InsertedDatetime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                db.Edison_SupplierPurchReturn_HDRs.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                textBox16.Text = objCourse.Edison_SupplierPurchReturnID.ToString();

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {

                    Edison_SupplierPurchReturn_DTL AddItems = new Edison_SupplierPurchReturn_DTL();


                    AddItems.Edison_SupplierPurchID = objCourse.Edison_SupplierPurchReturnID;
                    AddItems.Date = dateTimePicker3.Value;
                    AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.StockType = (row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    AddItems.Qty = Convert.ToInt32(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems.Rate = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                    AddItems.Value = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.DiscountValue = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                    AddItems.NetValue = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());

                    db.Edison_SupplierPurchReturn_DTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }


                dataGridView3.Columns[10].Visible = false;
                scope.Complete();
                purchasereturnRevertState();
                purchasereturnDisableAll();

            }
        }

        private void textBox16_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox16.Text))
            {
         
                dateTimePicker3.Text = "";
                searchLookUpEdit6.Text = "";
                textBox17.Text = "";
                searchLookUpEdit5.Text = "";
                textBox3.Text = "";
                comboBoxEdit1.Text = "";
                PR_Qty.Text = "";
                PR_Rates.Text = "";
                PR_Value.Text = "";
                PR_Discount.Text = "";
                PR_NetValue.Text = "";
                textBox4.Text = "";
                dataGridView3.Rows.Clear();


                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.Edison_SupplierPurchReturn_HDRs
                                         where s.Edison_SupplierPurchReturnID.Equals(textBox16.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var ab in getTheSelecteddata)
                    {
                        dateTimePicker3.Value = Convert.ToDateTime(ab.Date);
                        textBox17.Text = ab.Remarks.ToString();
                        searchLookUpEdit6.EditValue = ab.SupplierID;
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Invoice Number");
                    return;
                }


                var getTheSelecteddata1 = from s in db.Edison_SupplierPurchReturn_DTLs
                                          join v in db.Edison_Products on s.PID equals v.ProductID into bookingmGroup
                                          from v in bookingmGroup.DefaultIfEmpty()
                                          where s.Edison_SupplierPurchID.Equals(textBox16.Text)
                                          select new
                                          {
                                              s.PID,
                                              s.Qty,
                                              s.Rate,
                                              s.Value,
                                              s.DiscountValue,
                                              s.NetValue,
                                              v.ProductCode,
                                              v.ProductDescription,
                                              s.StockType,
                                          };

                if (getTheSelecteddata1.Any())
                {
                    foreach (var ab in getTheSelecteddata1)
                    {
                        dataGridView3.Rows.Add(null, ab.PID, ab.ProductCode, ab.ProductDescription, ab.StockType ,ab.Qty, ab.Rate, ab.Value, ab.DiscountValue, ab.NetValue);

                    }
                }

                PR_SumDataGridNetValue();
            }
        }

        private void PR_SumDataGridNetValue()
        {
            decimal summ = 0;


            int j = 1;



            foreach (DataGridViewRow Myrow in dataGridView3.Rows)
            {

                if (!string.IsNullOrEmpty(Myrow.Cells[9].Value.ToString()))
                {
                    summ += Convert.ToDecimal(Myrow.Cells[9].Value.ToString());
                    Myrow.Cells[0].Value = j++;
                }


            }
            textBox4.Text = summ.ToString();


        }

        private void PR_Save_Click(object sender, EventArgs e)
        {
            PR_SaveEntry();
        }

        private void PR_EditSaveEntry()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {

                var getTheSelecteddata = from s in db.Edison_SupplierPurchReturn_HDRs
                                         where s.Edison_SupplierPurchReturnID.Equals(textBox16.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {
                        objCourse.Date = dateTimePicker3.Value.Date;
                        objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit6.EditValue);
                        objCourse.Remarks = textBox17.Text;
                        objCourse.TotalAmount = Convert.ToDecimal(textBox4.Text);
                        db.SubmitChanges();

                    }

                }



                var a = from s in db.Edison_SupplierPurchReturn_DTLs
                        where s.Edison_SupplierPurchID.Equals(textBox16.Text.Trim())
                        select s;

                if (a.Any())
                {
                    foreach (var d in a)
                    {
                        db.Edison_SupplierPurchReturn_DTLs.DeleteOnSubmit(d);
                        db.SubmitChanges();
                    }
                }


                foreach (DataGridViewRow row in dataGridView3.Rows)
                {

                    Edison_SupplierPurchReturn_DTL AddItems = new Edison_SupplierPurchReturn_DTL();


                    AddItems.Edison_SupplierPurchID = Convert.ToInt32(textBox16.Text);
                    AddItems.Date = dateTimePicker3.Value;
                    AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.StockType = (row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    AddItems.Qty = Convert.ToInt32(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems.Rate = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                    AddItems.Value = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.DiscountValue = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                    AddItems.NetValue = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());

                    db.Edison_SupplierPurchReturn_DTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }



                dataGridView3.Columns[10].Visible = false;
                scope.Complete();
                purchasereturnRevertState();
                purchasereturnDisableAll();

            }
        }

        private void PR_Search_Click(object sender, EventArgs e)
        {
            textBox16.Enabled = true;
            textBox16.Focus();

        }
    }
}


 