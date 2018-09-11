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
    public partial class EdisonSales : Form
    {
        public EdisonSales()
        {
            InitializeComponent();
        }
        GMSoft GM = new GMSoft();
        private void GetCustomersandItems()
        {
            try
            {
                this.customerlistVanWiseTableAdapter.Fill(this.dataSet1.CustomerlistVanWise, Convert.ToInt32(InvVanNo.EditValue));

                this.invoicingItemsTableAdapter.Fill(this.dataSet1.InvoicingItems, Convert.ToInt32(InvDispatchNo.EditValue));
            }
            catch(Exception err)
            {

            }
        }
        private void EdisonSales_Load(object sender, EventArgs e)
        {
            GM.Exec("sp_ResetOrderIdentityAfterRestart");

            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);

            try
            {



                // TODO: This line of code loads data into the 'dataSet12.Edison_ReturnType' table. You can move, or remove it, as needed.
                this.edison_ReturnTypeTableAdapter.Fill(this.dataSet12.Edison_ReturnType);



                // TODO: This line of code loads data into the 'dataSet1.All_SearchCustomers' table. You can move, or remove it, as needed.
                this.all_SearchCustomersTableAdapter.Fill(this.dataSet1.All_SearchCustomers);

                // TODO: This line of code loads data into the 'dataSet1.CustomerlistVanWise' table. You can move, or remove it, as needed.

                // TODO: This line of code loads data into the 'dataSet1.Edison_Expense' table. You can move, or remove it, as needed.
                this.edison_ExpenseTableAdapter.Fill(this.dataSet1.Edison_Expense);

                this.dispatchListReturnSearchEditTableAdapter.Fill(this.dataSet1.DispatchListReturnSearchEdit);

                this.dispatchListReturnTableAdapter.Fill(this.dataSet1.DispatchListReturn);


                this.edison_ProductListTableAdapter.Fill(this.dataSet1.Edison_ProductList);

                this.edison_ProductsTableAdapter.Fill(this.dataSet1.Edison_Products);

                this.edison_EmployeeInfoTableAdapter.Fill(this.dataSet1.Edison_EmployeeInfo);

                this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);
            }
            catch(Exception err)
            {
                MessageBox.Show("Error " + err);
            }

        }

        private void SC_AddState()
        {
            DL_btnAdd.Visible = false;
            DL_btnSave.Visible = true;
            DL_btnEdit.Visible = false;
            DL_btnRevert.Visible = true;
            DL_btnEditSave.Visible = false;
            DL_btnSearch.Visible = false;
        }

        private void SC_RevertState()
        {
            DL_btnAdd.Visible = true;
            DL_btnSave.Visible = false;
            DL_btnEdit.Visible = true;
            DL_btnRevert.Visible = false;
            DL_btnEditSave.Visible = false;
            DL_btnSearch.Visible = true;
        }

        private void SC_EditState()
        {
            DL_btnAdd.Visible = false;
            DL_btnSave.Visible = false;
            DL_btnEdit.Visible = false;
            DL_btnRevert.Visible = true;
            DL_btnEditSave.Visible = true;
            DL_btnSearch.Visible = false;
        }

        private void SC_ClearAll()
        {
            dataGridView1.Rows.Clear();
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            searchLookUpEdit1.Text = "";
            searchLookUpEdit7.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            searchLookUpEdit2.Text = "";
            textBox4.Text = "";

            textBox1.Text = "";
            textBox16.Text = "";
        }

        private void SC_EnableAll()
        {
   
            dateTimePicker1.Enabled = true;
            searchLookUpEdit1.Enabled = true;
            searchLookUpEdit7.Enabled = true;
            textBox3.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            searchLookUpEdit2.Enabled = true;
            textBox4.Enabled = true;
    
        }

        private void SC_DisableAll()
        {
            textBox5.Enabled = false;
            dateTimePicker1.Enabled = false;
            searchLookUpEdit1.Enabled = false;
            searchLookUpEdit7.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            searchLookUpEdit2.Enabled = false;
            textBox4.Enabled = false;
        }


        private void DL_btnAdd_Click(object sender, EventArgs e)
        {
            SC_AddState();
            SC_ClearAll();
            SC_EnableAll();
            dateTimePicker1.Focus();
        }

        private void dateTimePicker1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit1.Focus();
                searchLookUpEdit1.ShowPopup();
            }
        }

        private void searchLookUpEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit7.Focus();
                searchLookUpEdit7.ShowPopup();
            }
        }

        private void searchLookUpEdit7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit2.Focus();
                searchLookUpEdit2.ShowPopup();
            }
        }

        private void DL_SumAll()
        {
            int j = 1;

            Decimal summTotalQty = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = j++;


                if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                {
                    summTotalQty += Convert.ToDecimal(row.Cells[4].Value.ToString());
                }
                
            }

            textBox16.Text = summTotalQty.ToString();
            textBox1.Text = dataGridView1.Rows.Count.ToString();
        }

        private void DispatchAddList()
        {

            DataClasses1DataContext db = new DataClasses1DataContext();

            string getDescription = "";
            string PurchasePrice = "";

            var getTheOrderDetail = from d in db.Edison_Products
                                    where d.ProductID.Equals(searchLookUpEdit2.EditValue)
                                    select new
                                    {                              
                                        d.ProductDescription,
                                        d.PurchasePrice,
                                    };

            if (getTheOrderDetail.Any())
            {
                foreach (var AddNew in getTheOrderDetail)
                {
                    getDescription = AddNew.ProductDescription.ToString();
                    PurchasePrice = AddNew.PurchasePrice.ToString();
                    break;
                }
            }


            dataGridView1.Rows.Add(null, searchLookUpEdit2.EditValue, searchLookUpEdit2.Text , getDescription, textBox4.Text.Trim(),null, PurchasePrice);

            DL_SumAll();

            textBox4.Text = "";
            searchLookUpEdit2.EditValue = 0;
            searchLookUpEdit2.Text = "";


            searchLookUpEdit2.Focus();
            searchLookUpEdit2.ShowPopup();

        }
        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {            
               simpleButton1.Focus();
            }
        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit2.Text))
            {
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_MouseClick(object sender, MouseEventArgs e)
        {
            DispatchAddList();
        }

        private void simpleButton1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DispatchAddList();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {


                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    DL_SumAll();
                }
            }
        }

        private void searchLookUpEdit2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void DL_btnRevert_Click(object sender, EventArgs e)
        {
            SC_DisableAll();
            SC_ClearAll();
            SC_RevertState();
        }

        private void DL_btnSave_Click(object sender, EventArgs e)
        {

        }

        private void DL_btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            DL_SaveAll(); 
        }

        private void DL_btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DL_SaveAll();
            }

        }


        private void DL_SaveAll()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                using (var scope = new System.Transactions.TransactionScope())
                {


                    Edison_DispatchHDR objCourse = new Edison_DispatchHDR();

                    objCourse.DispatchDate = dateTimePicker1.Value.Date;

                    objCourse.VanID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                    objCourse.EmpCode = Convert.ToInt32(searchLookUpEdit7.EditValue);

                    objCourse.ReadingOut = textBox3.Text;
                    objCourse.ReadingIn = textBox2.Text;



                    objCourse.Status = 0;



                    db.Edison_DispatchHDRs.InsertOnSubmit(objCourse);
                    db.SubmitChanges();

                    textBox5.Text = objCourse.DispatchNo.ToString();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        Edison_DispatchDTL AddItems = new Edison_DispatchDTL();


                        AddItems.DispatchNo = objCourse.DispatchNo;

                        AddItems.ProductID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                        AddItems.StockIssued = Convert.ToInt32(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                        AddItems.StockReturn = 0;
                        AddItems.REP = 0;
                        AddItems.TotalDelivered = 0;
                        AddItems.PurchaseValue = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());


                        db.Edison_DispatchDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();


                        //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                    }


                   // dataGridView1.Columns[5].Visible = false;
                    scope.Complete();

                    SC_RevertState();
                    SC_DisableAll();

                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Error on Save " + err);
            }
      
        }

        private void DL_btnSearch_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            textBox5.Focus();
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
         
                if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox5.Text))
                {
                dataGridView1.Rows.Clear();
                
                dateTimePicker1.Value = DateTime.Now;
                searchLookUpEdit1.Text = "";
                searchLookUpEdit7.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                searchLookUpEdit2.Text = "";
                textBox4.Text = "";

                textBox1.Text = "";
                textBox16.Text = "";

                DataClasses1DataContext db = new DataClasses1DataContext();

                    var getTheSelecteddata = from s in db.Edison_DispatchHDRs
                                             where s.DispatchNo.Equals(textBox5.Text)
                                             select s;

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var ab in getTheSelecteddata)
                        {
                            dateTimePicker1.Value = Convert.ToDateTime(ab.DispatchDate);
                        searchLookUpEdit1.EditValue = ab.VanID;
                        searchLookUpEdit7.EditValue = ab.EmpCode;
                        textBox3.Text = ab.ReadingOut.ToString();
                        textBox2.Text = ab.ReadingIn.ToString();                           
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the Correct Dispatch Number");
                        return;
                    }


                    var getTheSelecteddata1 = from s in db.Edison_DispatchDTLs
                                              join v in db.Edison_Products on s.ProductID equals v.ProductID into bookingmGroup
                                              from v in bookingmGroup.DefaultIfEmpty()
                                              where s.DispatchNo.Equals(textBox5.Text)
                                              select new
                                              {
                                                  s.ProductID,
                                                  v.ProductCode,
                                                  v.ProductDescription,
                                                  s.StockIssued,             
                                                  s.PurchaseValue,                                                                            
                                              };

                    if (getTheSelecteddata1.Any())
                    {
                        foreach (var ab in getTheSelecteddata1)
                        {
                            dataGridView1.Rows.Add(null, ab.ProductID, ab.ProductCode, ab.ProductDescription, ab.StockIssued,null,ab.PurchaseValue);

                        }
                    }


                DL_SumAll();


         

            }
            
        }

        private void DL_btnEdit_Click(object sender, EventArgs e)
        {
            SC_EnableAll();
            SC_EditState();
          //  dataGridView1.Columns[5].Visible = true;
        }

        private void DL_btnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void DL_btnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            DL_EditSaveAll();
        }

        private void DL_btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DL_EditSaveAll();
            }
        }

        private void DL_EditSaveAll()
        {
           try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                using (var scope = new System.Transactions.TransactionScope())
                {

                    var getTheSelecteddata = from s in db.Edison_DispatchHDRs
                                             where s.DispatchNo.Equals(textBox5.Text)
                                             select s;

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var objCourse in getTheSelecteddata)
                        {
                            if (objCourse.Status != 0)
                            {
                                MessageBox.Show("Error! You cannot edit dispatch list which is already invoiced");
                                return;
                            }

                            objCourse.DispatchDate = dateTimePicker1.Value.Date;
                            objCourse.VanID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                            objCourse.EmpCode = Convert.ToInt32(searchLookUpEdit7.EditValue);
                            objCourse.ReadingOut = textBox3.Text;
                            objCourse.ReadingIn = textBox2.Text;
                            objCourse.Status = 0;
                            db.SubmitChanges();

                            // textBox5.Text = objCourse.DispatchNo.ToString();
                        }
                    }




                    var a = from s in db.Edison_DispatchDTLs
                            where s.DispatchNo.Equals(textBox5.Text.Trim())
                            select s;

                    if (a.Any())
                    {
                        foreach (var d in a)
                        {
                            db.Edison_DispatchDTLs.DeleteOnSubmit(d);
                            db.SubmitChanges();
                        }
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        Edison_DispatchDTL AddItems = new Edison_DispatchDTL();


                        AddItems.DispatchNo = Convert.ToInt32(textBox5.Text);

                        AddItems.ProductID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                        AddItems.StockIssued = Convert.ToInt32(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                        AddItems.REP = 0;
                        AddItems.StockReturn = 0;
                        AddItems.TotalDelivered = 0;
                        AddItems.PurchaseValue = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());

                        db.Edison_DispatchDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();


                        //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                    }


                    // dataGridView1.Columns[5].Visible = false;
                    scope.Complete();


                }


                SC_RevertState();
                SC_DisableAll();
            }
            catch(Exception err)
            {
                MessageBox.Show("Error in Saving Dispatch" + err);
            }

        }

        private void searchLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit3.Text))
            {
                dataGridView2.Rows.Clear();

                dateTimePicker2.Value = DateTime.Now;
                searchLookUpEdit5.Text = "";
                searchLookUpEdit4.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";

                textBox8.Text = "";
                textBox7.Text = "";
    

                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.Edison_DispatchHDRs
                                         where s.DispatchNo.Equals(searchLookUpEdit3.EditValue)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var ab in getTheSelecteddata)
                    {
                        dateTimePicker2.Value = Convert.ToDateTime(ab.DispatchDate);
                        searchLookUpEdit5.EditValue = ab.VanID;
                        searchLookUpEdit4.EditValue = ab.EmpCode;
                        textBox17.Text = ab.ReadingOut.ToString();
                        textBox18.Text = ab.ReadingIn.ToString();
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Dispatch Number");
                    return;
                }





                //     this.dispatchReturnDTLTableAdapter.Fill(this.dataSet1.DispatchReturnDTL, Convert.ToInt32(searchLookUpEdit3.EditValue));



                var getdetaildata = from Edison_Products in db.Edison_Products
                                    join Edison_DispatchDTL in db.Edison_DispatchDTLs on new { ProductID = Edison_Products.ProductID } equals new { ProductID = Convert.ToInt32(Edison_DispatchDTL.ProductID) }
                                    where
                                      Edison_DispatchDTL.DispatchNo == Convert.ToInt32(searchLookUpEdit3.EditValue)
                                    select new
                                    {
                                        Edison_DispatchDTL.Dispatch_DTL_ID,
                                        ProductID = (int?)Edison_DispatchDTL.ProductID,
                                        Edison_Products.ProductCode,
                                        Edison_Products.ProductDescription,
                                        Edison_DispatchDTL.StockIssued,
                                        Edison_DispatchDTL.StockReturn,
                                        Edison_DispatchDTL.TotalDelivered,
                                        Edison_DispatchDTL.REP,
                                        Edison_DispatchDTL.DispatchNo,
                                        Edison_Products.RSSalePrice,
                                        WholeSaleRate = ((System.Decimal?)Edison_Products.WSSalePrice ?? (System.Decimal?)0)
                                    };
                if(getdetaildata.Any())
                {
                    foreach(var ab in getdetaildata)
                    {
                      if(ab.StockIssued == null)
                        {
                            //ab.StockIssued = 0;
                        }



                        dataGridView2.Rows.Add("", ab.Dispatch_DTL_ID, ab.ProductID, ab.ProductCode, ab.ProductDescription, ab.StockIssued, ab.StockReturn, ab.REP , (ab.StockIssued - ab.StockReturn - ab.REP), ab.DispatchNo, "", ab.RSSalePrice, "", "", ab.WholeSaleRate, "");
                        

                    }
                }



                //foreach (DataGridViewRow row in dataGridView2.Rows)
                //{
                //    row.Cells[8].Value = Convert.ToInt32(row.Cells[5].Value) + Convert.ToInt32(row.Cells[6].Value);
                //}

                DLReturn_SumAll();

                dataGridView2.ClearSelection();

            }
        }

        private void DLReturn_SumAll()
        {
            int j = 1;

            Decimal summTotalQty = 0;
            Decimal TotalQtyinNos = 0;
            Decimal TotalQtyinNo1s = 0;
            Decimal testQty = 0;


            Decimal wholesaleQty = 0;
            Decimal wholesaleretailvalue = 0;

            Decimal RetailsaleQty = 0;
            Decimal RetailSaleValue = 0;



            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = j++;


                if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                {
                    summTotalQty += Convert.ToDecimal(row.Cells[5].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[6].Value.ToString()))
                {
                    TotalQtyinNos += Convert.ToDecimal(row.Cells[6].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                {
                    TotalQtyinNo1s += Convert.ToDecimal(row.Cells[7].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[8].Value.ToString()))
                {
                    testQty += Convert.ToDecimal(row.Cells[8].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[10].Value.ToString()))
                {
                    RetailsaleQty += Convert.ToDecimal(row.Cells[10].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[12].Value.ToString()))
                {
                    RetailSaleValue += Convert.ToDecimal(row.Cells[12].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[13].Value.ToString()))
                {
                    wholesaleQty += Convert.ToDecimal(row.Cells[13].Value.ToString());
                }

                if (!string.IsNullOrEmpty(row.Cells[15].Value.ToString()))
                {
                    wholesaleretailvalue += Convert.ToDecimal(row.Cells[15].Value.ToString());
                }


            
          


            }

            textBox7.Text = summTotalQty.ToString();
            textBox6.Text = TotalQtyinNos.ToString();
            textBox9.Text = TotalQtyinNo1s.ToString();
            textBox10.Text = testQty.ToString();


            textBox52.Text = RetailsaleQty.ToString();
            textBox53.Text = RetailSaleValue.ToString();

            textBox54.Text = wholesaleQty.ToString();
            textBox58.Text = wholesaleretailvalue.ToString();


            textBox8.Text = dataGridView2.Rows.Count.ToString();

            textBox59.Text = (Convert.ToDecimal(textBox53.Text == "" ? "0" : textBox53.Text) + (Convert.ToDecimal(textBox58.Text == "" ? "0" : textBox58.Text))).ToString();

        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           try
            {
                if (e.RowIndex > -1)
                {
                    if (dataGridView2.Rows[e.RowIndex].Cells[6].FormattedValue.ToString() != "")
                    {
                        //look for which column is being Changed and 
                        //After checking which Cell's value is Changed, 
                        //Calculate the "Total Amount" value for Auto-Calculated Cell as follows...

                        dataGridView2.Rows[e.RowIndex].Cells[16].Value = Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString())  - (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString())  + Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString()));

                        if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                        {
                            if (dataGridView2.Rows[e.RowIndex].Cells[16].Value != null)
                            {
                                if (dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString()  == "0")
                                {
                                    if (Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[5].Value) > 0)
                                    {
                                        dataGridView2.Rows[e.RowIndex].Cells[8].Value = dataGridView2.Rows[e.RowIndex].Cells[5].Value;
                                    }
                                    else
                                    {
                                        MessageBox.Show("You Have no Remaining Qty to Edit, Please Change Retail & Whole Sale Qty");
                                        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                                        return;
                                    }
                                   
                                }
                            }
                            Decimal SumReturnRep = Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[6].Value) + Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[7].Value);

                            if (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[5].Value) < SumReturnRep)
                            {
                                //dataGridView2.Rows[e.RowIndex].Cells[6].Value = "0";
                                //   dataGridView2.Rows[e.RowIndex].Cells[8].Value = "0";
                                dataGridView2.Rows[e.RowIndex].Cells[8].Value = (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[5].Value) - SumReturnRep).ToString();
                                DLReturn_SumAll();
                            }
                            else
                            {
                                dataGridView2.Rows[e.RowIndex].Cells[8].Value = (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[5].Value) - SumReturnRep).ToString();
                                DLReturn_SumAll();
                            }


                        }
         
                    }


                    if (dataGridView2.Rows[e.RowIndex].Cells[10].FormattedValue.ToString() != "")
                    {

                        dataGridView2.Rows[e.RowIndex].Cells[16].Value = Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString()) - (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString()) + Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString()));

                        if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
                        {
                            Decimal SumReturnRep = ((Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString())) - (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString())));

                            if (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[10].Value) <= SumReturnRep)
                            {
                                dataGridView2.Rows[e.RowIndex].Cells[12].Value = (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[10].Value) * Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[11].Value)).ToString();
                                DLReturn_SumAll();
                            }
                            else
                            {
                                MessageBox.Show("Error! You cannot sell more then the total delivered items! ");
                                dataGridView2.Rows[e.RowIndex].Cells[12].Value = 0;
                                dataGridView2.Rows[e.RowIndex].Cells[10].Value = 0;
                                return;
                            }

                        }
                    }

                    if (dataGridView2.Rows[e.RowIndex].Cells[13].FormattedValue.ToString() != "")
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[16].Value = Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString()) - (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString()) + Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[13].Value.ToString()));

                        if (e.ColumnIndex == 13  || e.ColumnIndex == 14)
                        {
                            Decimal SumReturnRep = ((Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString())) - (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString() == "" ? "0" : dataGridView2.Rows[e.RowIndex].Cells[10].Value.ToString())));

                            if (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[13].Value) <= SumReturnRep)
                            {

                                dataGridView2.Rows[e.RowIndex].Cells[15].Value = (Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[13].Value) * Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells[14].Value)).ToString();
                                DLReturn_SumAll();
                            }
                            else
                            {
                                MessageBox.Show("Error! You cannot sell more then the total delivered items! ");
                                dataGridView2.Rows[e.RowIndex].Cells[13].Value = 0;
                                dataGridView2.Rows[e.RowIndex].Cells[15].Value = 0;
                                return;
                            }
                        }
                    }



                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Error Please Check " + err);
            }
        }

        private void IC_AddState()
        {
            IC_BtnAdd.Visible = false;
            IC_BtnEdit.Visible = false;
            IC_BtnRevert.Visible = true;
            IC_BtnEditSave.Visible = false;
            IC_BtnSave.Visible = true;
            IC_BtnSearch.Visible = false;
        }

        private void IC_RevertState()
        {
            IC_BtnAdd.Visible = true;
            IC_BtnEdit.Visible = true;
            IC_BtnRevert.Visible = false;
            IC_BtnEditSave.Visible = false;
            IC_BtnSave.Visible = false;
            IC_BtnSearch.Visible = true;
        }

        private void IC_EditSaveState()
        {
            IC_BtnAdd.Visible = false;
            IC_BtnEdit.Visible = false;
            IC_BtnRevert.Visible = true;
            IC_BtnEditSave.Visible = true;
            IC_BtnSave.Visible = false;
            IC_BtnSearch.Visible = false;
        }

        private void IC_ClearAll()
        {

            dataGridView2.Rows.Clear();
            searchLookUpEdit8.Visible = false;
            searchLookUpEdit8.Text = "";
            searchLookUpEdit8.EditValue = 0;

            searchLookUpEdit3.Text = "";
            searchLookUpEdit3.EditValue = 0;


            dateTimePicker2.Value = DateTime.Now;

            searchLookUpEdit5.Text = "";
            searchLookUpEdit4.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";

            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            this.dispatchReturnDTLTableAdapter.Fill(this.dataSet1.DispatchReturnDTL, Convert.ToInt32(searchLookUpEdit3.EditValue.ToString() == "" ? "0" : searchLookUpEdit3.EditValue.ToString()));

        }

        private void IC_EnableAll()
        {
            searchLookUpEdit3.Enabled = true;
            dataGridView2.ReadOnly = false;

        }

        private void IC_DisableAll()
        {
            searchLookUpEdit3.Enabled = false;
            dataGridView2.ReadOnly = true;

        }
        private void IC_BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.dispatchListReturnSearchEditTableAdapter.Fill(this.dataSet1.DispatchListReturnSearchEdit);
                this.dispatchListReturnTableAdapter.Fill(this.dataSet1.DispatchListReturn);
                IC_AddState();
                IC_ClearAll();
                IC_EnableAll();



            }
            catch(Exception err)
            {
                MessageBox.Show("Error " + err);
            }
            
        }

        private void IC_BtnRevert_Click(object sender, EventArgs e)
        {
            IC_RevertState();
            IC_ClearAll();
            IC_DisableAll();
        }

        private void IC_BtnEdit_Click(object sender, EventArgs e)
        {
            IC_EditSaveState();
            IC_EnableAll();

        }

        private void IC_EditSaveEntry()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {

                var getDispatch = from s in db.Edison_DispatchHDRs
                                         where s.DispatchNo.Equals(searchLookUpEdit8.EditValue)
                                         select s;

                if (getDispatch.Any())
                {
                    foreach (var AddItems in getDispatch)
                    {
                        AddItems.VanID = Convert.ToInt32(searchLookUpEdit5.EditValue);
                        AddItems.EmpCode = Convert.ToInt32(searchLookUpEdit4.EditValue);
                        break;
                    }
                }


                        foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    var getTheSelecteddata = from s in db.Edison_DispatchDTLs
                                             where s.Dispatch_DTL_ID.Equals(row.Cells[1].Value.ToString())
                                             select s;

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var AddItems in getTheSelecteddata)
                        {
                            AddItems.StockIssued = Convert.ToInt32(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                            AddItems.StockReturn = Convert.ToInt32(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                            AddItems.REP = Convert.ToInt32(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                            AddItems.TotalDelivered = Convert.ToInt32(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                            AddItems.RQtySold = Convert.ToInt32(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                            AddItems.RRSSale = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                            AddItems.RValue = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                            AddItems.WQtySold = Convert.ToInt32(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                            AddItems.WSaleRate = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                            AddItems.WValue = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());
                            db.SubmitChanges();
                        }
                    }
                    else
                    {
                        Edison_DispatchDTL AddItems = new Edison_DispatchDTL();


                        AddItems.DispatchNo = Convert.ToInt32(searchLookUpEdit8.EditValue);

                        AddItems.ProductID = Convert.ToInt32(row.Cells[2].Value.ToString() == "" ? "0" : row.Cells[2].Value.ToString());

                        AddItems.StockIssued = Convert.ToInt32(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                        AddItems.StockReturn = Convert.ToInt32(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                        AddItems.REP = Convert.ToInt32(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                        AddItems.TotalDelivered = Convert.ToInt32(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                        AddItems.RQtySold = Convert.ToInt32(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                        AddItems.RRSSale = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                        AddItems.RValue = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                        AddItems.WQtySold = Convert.ToInt32(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                        AddItems.WSaleRate = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                        AddItems.WValue = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());



                        db.Edison_DispatchDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();
                    }
                }

                IC_RevertState();
                IC_DisableAll();
      
                scope.Complete();
  
            }



            dataGridView2.Rows.Clear();
            var getdetaildata = from Edison_Products in db.Edison_Products
                                join Edison_DispatchDTL in db.Edison_DispatchDTLs on new { ProductID = Edison_Products.ProductID } equals new { ProductID = Convert.ToInt32(Edison_DispatchDTL.ProductID) }
                                where
                                  Edison_DispatchDTL.DispatchNo == Convert.ToInt32(searchLookUpEdit8.EditValue)
                                select new
                                {
                                    Edison_DispatchDTL.Dispatch_DTL_ID,
                                    ProductID = (int?)Edison_DispatchDTL.ProductID,
                                    Edison_Products.ProductCode,
                                    Edison_Products.ProductDescription,
                                    Edison_DispatchDTL.StockIssued,
                                    Edison_DispatchDTL.StockReturn,
                                    Edison_DispatchDTL.TotalDelivered,
                                    Edison_DispatchDTL.REP,
                                    Edison_DispatchDTL.DispatchNo,
                                  //  Edison_Products.RSSalePrice,
                                //    WholeSaleRate = ((System.Decimal?)Edison_Products.WSSalePrice ?? (System.Decimal?)0)
                                    Edison_DispatchDTL.RQtySold,
                                    Edison_DispatchDTL.RRSSale,
                                    Edison_DispatchDTL.RValue,
                                    Edison_DispatchDTL.WQtySold,
                                    Edison_DispatchDTL.WSaleRate,
                                    Edison_DispatchDTL.WValue,

                                };
            if (getdetaildata.Any())
            {
                foreach (var ab in getdetaildata)
                {

                    dataGridView2.Rows.Add("", ab.Dispatch_DTL_ID, ab.ProductID, ab.ProductCode, ab.ProductDescription, ab.StockIssued, ab.StockReturn, ab.REP, ab.TotalDelivered, ab.DispatchNo, ab.RQtySold, ab.RRSSale, ab.RValue, ab.WQtySold, ab.WSaleRate, ab.WValue);


                }
            }


            this.dispatchListReturnSearchEditTableAdapter.Fill(this.dataSet1.DispatchListReturnSearchEdit);
            this.dispatchListReturnTableAdapter.Fill(this.dataSet1.DispatchListReturn);
        }

        private void IC_BtnEditSave_Click(object sender, EventArgs e)
        {
            IC_EditSaveEntry();

        }

        private void IC_BtnSearch_Click(object sender, EventArgs e)
        {
            searchLookUpEdit8.Text = "";
            searchLookUpEdit8.Visible = true;
            searchLookUpEdit8.Enabled = true;

        }

        private void searchLookUpEdit8_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit8.Text))
            {
                dataGridView2.Rows.Clear();

                dateTimePicker2.Value = DateTime.Now;
                searchLookUpEdit5.Text = "";
                searchLookUpEdit4.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";

                textBox8.Text = "";
                textBox7.Text = "";


                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.Edison_DispatchHDRs
                                         where s.DispatchNo.Equals(searchLookUpEdit8.EditValue)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var ab in getTheSelecteddata)
                    {
                        dateTimePicker2.Value = Convert.ToDateTime(ab.DispatchDate);
                        searchLookUpEdit5.EditValue = ab.VanID;
                        searchLookUpEdit4.EditValue = ab.EmpCode;
                        textBox17.Text = ab.ReadingOut.ToString();
                        textBox18.Text = ab.ReadingIn.ToString();
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Dispatch Number");
                    return;
                }


                var getdetaildata = from Edison_Products in db.Edison_Products
                                    join Edison_DispatchDTL in db.Edison_DispatchDTLs on new { ProductID = Edison_Products.ProductID } equals new { ProductID = Convert.ToInt32(Edison_DispatchDTL.ProductID) }
                                    where
                                      Edison_DispatchDTL.DispatchNo == Convert.ToInt32(searchLookUpEdit8.EditValue)
                                    select new
                                    {
                                        Edison_DispatchDTL.Dispatch_DTL_ID,
                                        ProductID = (int?)Edison_DispatchDTL.ProductID,
                                        Edison_Products.ProductCode,
                                        Edison_Products.ProductDescription,
                                        Edison_DispatchDTL.StockIssued,
                                        Edison_DispatchDTL.StockReturn,
                                        Edison_DispatchDTL.TotalDelivered,
                                        Edison_DispatchDTL.REP,
                                        Edison_DispatchDTL.DispatchNo,
                                        //  Edison_Products.RSSalePrice,
                                        //    WholeSaleRate = ((System.Decimal?)Edison_Products.WSSalePrice ?? (System.Decimal?)0)
                                        Edison_DispatchDTL.RQtySold,
                                        Edison_DispatchDTL.RRSSale,
                                        Edison_DispatchDTL.RValue,
                                        Edison_DispatchDTL.WQtySold,
                                        Edison_DispatchDTL.WSaleRate,
                                        Edison_DispatchDTL.WValue,

                                    };
                if (getdetaildata.Any())
                {
                    foreach (var ab in getdetaildata)
                    {

                        dataGridView2.Rows.Add("", ab.Dispatch_DTL_ID, ab.ProductID, ab.ProductCode, ab.ProductDescription, ab.StockIssued, ab.StockReturn, ab.REP, ab.TotalDelivered, ab.DispatchNo, ab.RQtySold, ab.RRSSale, ab.RValue, ab.WQtySold, ab.WSaleRate, ab.WValue);


                    }
                }



                // this.dispatchReturnDTLTableAdapter.Fill(this.dataSet1.DispatchReturnDTL, Convert.ToInt32(searchLookUpEdit8.EditValue));





                DLReturn_SumAll();

            }
        }



   

        private void CD_BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void CD_BtnSave_Click(object sender, EventArgs e)
        {

        }

   




        private void simpleButton2_MouseClick(object sender, MouseEventArgs e)
        {

   


        }

        private void simpleButton2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
            

            }
        }


        private void CD_BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void CD_BtnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
       
        }

        private void CD_BtnRevert_Click(object sender, EventArgs e)
        {
    
        }

        private void CD_BtnSearch_Click(object sender, EventArgs e)
        {
         

        }

        private void searchLookUpEdit14_EditValueChanged(object sender, EventArgs e)
        {
         
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void CD_BtnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit9_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(InvDispatchNo.Text))
                {
                    InvVanNo.Text = "";
                    InvDate.Value = DateTime.Now;
                    InvSalesAgent.Text = "";
                    txtInvoicingAmount.Text = "";
                    txtCollectionAmount.Text = "";
                    txtReplacementAmount.Text = "";
                    //textBox55.Text = "";
                    textBox51.Text = "";
                    textBox12.Text = "";
                    txtExpenses.Text = "";
                    txtNetAmount.Text = "";
                    txtCashReceived.Text = "";
                    txtRemaining.Text = "";
                    txtTotalSale.Text = "";
                    textBox11.Text = "";
                    textBox19.Text = "";
                    textBox14.Text = "";
                    textBox28.Text = "";
                    txtExpenses.Text = "";
                    textBox38.Text = "";
                    txtCashReceived.Text = "";
                    txtRemaining.Text = "";
                    textBox22.Text = "";
                    textBox23.Text = "";
                    txtInvoicingAmount.Text = "";

                  

                    DataClasses1DataContext db = new DataClasses1DataContext();


                    var getHDR = from d in db.Edison_DispatchHDRs
                                 where d.DispatchNo.Equals(InvDispatchNo.EditValue)
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
                            InvDate.Value = Convert.ToDateTime(a.DispatchDate);
                            textBox22.Text = a.ReadingOut;
                            textBox23.Text = a.ReadingIn;

                            GetCustomersandItems();
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wait! Something is wrong");
                        return;
                    }



                  

                    var getExpense = from Edison_DispatchExpDTL in
    (from Edison_DispatchExpDTL in db.Edison_DispatchExpDTLs
     where
       Edison_DispatchExpDTL.DispatchNo == Convert.ToInt32(InvDispatchNo.EditValue)
     select new
     {
         Edison_DispatchExpDTL.Amount,
         Dummy = "x"
     })
                                     group Edison_DispatchExpDTL by new { Edison_DispatchExpDTL.Dummy } into g
                                     select new
                                     {
                                         Column1 = (decimal?)g.Sum(p => p.Amount)
                                     };

                    if (getExpense.Any())
                    {
                        foreach (var a in getExpense)
                        {
                            txtExpenses.Text = a.Column1.ToString();
                            break;
                        }
                    }
                    else
                    {
                        txtExpenses.Text = "";
                    }


                    this.creditRecoveryTableAdapter.Fill(this.dataSet1.CreditRecovery, Convert.ToInt32(InvDispatchNo.EditValue), InvDate.Value.Date);


                    //  dataGridView7.Rows.Clear();

                    //var getStockDetails = from d in db.Edison_DispatchDTLs
                    //                      join v in db.Edison_Products on d.ProductID equals v.ProductID into bookingmGroup
                    //                      from v in bookingmGroup.DefaultIfEmpty()
                    //                      where d.DispatchNo.Equals(InvDispatchNo.EditValue)
                    //                      select new
                    //                      {
                    //                          d.ProductID,
                    //                          v.ProductCode,
                    //                          d.StockIssued,
                    //                          d.StockReturn,
                    //                          d.TotalDelivered,
                    //                      };

                    //if (getStockDetails.Any())
                    //{
                    //    foreach (var a in getStockDetails)
                    //    {
                    //        dataGridView7.Rows.Add(a.ProductID, a.ProductCode, a.StockIssued, a.StockReturn, a.TotalDelivered, "0", a.TotalDelivered);

                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Wait! Something is wrong");
                    //    return;
                    //}




                    //decimal ReplacementAmount = 0;
                    //decimal ReplacementQty = 0;

                    //var getReplacementAmount = from d in db.Edison_SalesReturnHDRs

                    //                           join u in db.Edison_SalesReturnDTLs on d.SalesReturnID equals u.SalesReturnID into bookingmGroup1
                    //                           from u in bookingmGroup1.DefaultIfEmpty()


                    //                           join v in db.Edison_Products on u.PID equals v.ProductID into bookingmGroup
                    //                           from v in bookingmGroup.DefaultIfEmpty()

                    //                           where d.DispatchNo.Equals(InvDispatchNo.EditValue) && d.CustID.Equals(364)
                    //                           select new
                    //                           {
                    //                               d.CustID,
                    //                               v.ProductID,
                    //                               v.ProductCode,
                    //                               u.ReturnQty,
                    //                               u.Rate,
                    //                               u.Amount,
                    //                           };

                    //if (getReplacementAmount.Any())
                    //{
                    //    foreach (var a in getReplacementAmount)
                    //    {
                    //        if (a.ReturnQty > 0)
                    //        {
                    //            ReplacementAmount = ReplacementAmount + (Convert.ToInt32(a.ReturnQty) * Convert.ToDecimal(a.Rate));
                    //            ReplacementQty = ReplacementQty + Convert.ToInt32(a.ReturnQty);
                    //        }


                    //    }
                    //}


                    decimal ReplacementAmount = 0;
                    decimal ReplacementQty = 0;

                    var getReplacementAmount = from d in db.Edison_DispatchDTLs
                                               join v in db.Edison_Products on d.ProductID equals v.ProductID into bookingmGroup
                                               from v in bookingmGroup.DefaultIfEmpty()
                                               where d.DispatchNo.Equals(InvDispatchNo.EditValue)
                                               select new
                                               {
                                                   d.ProductID,
                                                   v.ProductCode,
                                                   d.StockIssued,
                                                   d.StockReturn,
                                                   d.TotalDelivered,
                                                   v.RSSalePrice,
                                                   d.REP,
                                                   d.RQtySold,
                                                   d.RRSSale,
                                                   d.RValue,
                                                   d.WQtySold,
                                                   d.WSaleRate,
                                                   d.WValue,

                                               };

                    if (getReplacementAmount.Any())
                    {
                        txtReplacementAmount.Text = "0";
                        foreach (var a in getReplacementAmount)
                        {
                            if (a.RQtySold < 0)
                            {
                                txtReplacementAmount.Text = (Convert.ToDecimal(txtReplacementAmount.Text) + Convert.ToInt32(a.RQtySold) * Convert.ToInt32(a.RRSSale)).ToString();
                            }

                            if (a.WQtySold < 0)
                            {
                                txtReplacementAmount.Text = (Convert.ToDecimal(txtReplacementAmount.Text) + Convert.ToInt32(a.WQtySold) * Convert.ToInt32(a.WSaleRate)).ToString();
                            }

                        }
                    }

                    //    txtReplacementAmount.Text = ReplacementAmount.ToString();
                    //    textBox55.Text = ReplacementQty.ToString();


                }
                getSumofRemaining();


                makesalesdetail();
            }
            catch(Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void INV_AddState()
        {
            INV_btnAdd.Visible = false;
            INV_btnEdit.Visible = false;
            INV_btnRevert.Visible = true;
            INV_btnSave.Visible = true;
            INV_btnEditSave.Visible = false;
            INV_btnSearch.Visible = false;
        }

        private void INV_RevertState()
        {
            INV_btnAdd.Visible = true;
            INV_btnEdit.Visible = true;
            INV_btnRevert.Visible = false;
            INV_btnSave.Visible = false;
            INV_btnEditSave.Visible = false;
            INV_btnSearch.Visible = true;
        }

        private void INV_EditSaveState()
        {
            INV_btnAdd.Visible = false;
            INV_btnEdit.Visible = false;
            INV_btnRevert.Visible = true;
            INV_btnSave.Visible = false;
            INV_btnEditSave.Visible = true;
            INV_btnSearch.Visible = false;
        }

        private void Inv_EnableAll()
        {
            InvDispatchNo.Enabled = true;
    


            //InvColCustomerList.Enabled = true;
            //invAmountReceived.Enabled = true;

        }

        private void Inv_DisableAll()
        {

            InvDispatchNo.Enabled = false;
   


            //InvColCustomerList.Enabled = false;
            //invAmountReceived.Enabled = false;
        }

        private void Inv_ClearAll()
        {
        
           // dataGridView6.DataBind();


            //textBox11.Text = "";




            //dataGridView3.Rows.Clear();

      

            InvDispatchNo.Text = "";
            InvVanNo.Text = "";
            InvDate.Value = DateTime.Now;
            InvSalesAgent.Text = "";



            //InvColCustomerList.Text = "";
            //invAmountReceived.Text = "";


            txtInvoicingAmount.Text = "";

            txtCollectionAmount.Text = "";
            txtReplacementAmount.Text = "";
            //textBox55.Text = "";
            textBox51.Text = "";
            textBox12.Text = "";
            txtExpenses.Text = "";
            txtNetAmount.Text = "";
            txtCashReceived.Text = "";
            txtRemaining.Text = "";
            //textBox13.Text = "";
            //textBox14.Text = "";

            txtTotalSale.Text = "";
            textBox11.Text = "";
            textBox19.Text = "";
            textBox14.Text = "";
            textBox28.Text = "";
            txtExpenses.Text = "";
            textBox38.Text = "";
            txtCashReceived.Text = "";
            txtRemaining.Text = "";


            textBox22.Text = "";
            textBox23.Text = "";

            txtInvoicingAmount.Text = "";

        }


        private void INV_btnAdd_Click(object sender, EventArgs e)
        {
            searchLookUpEdit12.Visible = false;

            this.dispatchListExpenseListTableAdapter.Fill(this.dataSet1.DispatchListExpenseList);

            //this.dispatchListExpenseEditListTableAdapter.Fill(this.dataSet1.DispatchListExpenseEditList);

            INV_AddState();
            Inv_ClearAll();
            Inv_EnableAll();

            InvDispatchNo.Focus();
            InvDispatchNo.ShowPopup();


        }

        private void InvDispatchNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
       
            }
        }

        private void InvCustomerList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
           
            }
        }

        private void InvItemList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
      

            }
        }

        private void InvQty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
             //   InvRate.Focus();

            }
        }

        private void InvRate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               // txtAmount.Focus();

            }
        }

        private void txtAmount_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               // btnInvoiceListAdd.Focus();

            }
        }

        
        private void btnInvoiceListAdd_MouseClick(object sender, MouseEventArgs e)
        {
            //InvoiceAddList();
        }

        private void btnInvoiceListAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if(e.KeyCode == Keys.Enter)
            //{
            //    InvoiceAddList();
            //}
        }

        private void btnInvoiceListAdd_Click(object sender, EventArgs e)
        {

        }

        //private void invoicinggridSumCalculator()
        //{
        //    int j = 1;

        //    Decimal summTotalQty = 0;
        //    Decimal TotalQtyinNos = 0;


        //    foreach (DataGridViewRow row in dataGridView4.Rows)
        //    {
        //        row.Cells[0].Value = j++;


        //        if (!string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
        //        {
        //            summTotalQty += Convert.ToDecimal(row.Cells[7].Value.ToString());
        //        }


        //        if (!string.IsNullOrEmpty(row.Cells[9].Value.ToString()))
        //        {
        //            TotalQtyinNos += Convert.ToDecimal(row.Cells[9].Value.ToString());
        //        }            

        //    }

        //    textBox11.Text = summTotalQty.ToString();
        //    txtInvoicingAmount.Text = TotalQtyinNos.ToString();

        //    textBox12.Text = dataGridView4.Rows.Count.ToString();


        //    foreach (DataGridViewRow row in dataGridView7.Rows)
        //    {
        //        GetSumInv = 0;
        //        foreach (DataGridViewRow row2 in dataGridView4.Rows)
        //        {

        //            if (!string.IsNullOrEmpty(row2.Cells[7].Value.ToString()))
        //            {
        //                if (row2.Cells[5].Value.ToString() == row.Cells[0].Value.ToString())
        //                {
        //                    GetSumInv += Convert.ToDecimal(row2.Cells[7].Value.ToString());

        //                }
        //            }


        //        }
        //        row.Cells[5].Value = GetSumInv;


        //    }



        //    foreach (DataGridViewRow row in dataGridView7.Rows)
        //    {
        //        row.Cells[6].Value = Convert.ToInt32(row.Cells[4].Value) - Convert.ToInt32(row.Cells[5].Value);
        //    }


        //    getSumofRemaining();


        //}


        private void getSumofRemaining()
        {


            Decimal InvoiceTotalRecords = 0;
            Decimal InvoiceSold = 0;
            Decimal InvoiceLeft = 0;
            Decimal invoiced = 0;
            Decimal InvoiceSale = 0;

            Decimal InvoiceRecovery = 0;
            Decimal CashRecovery = 0;

            int j = 1;

            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                row.Cells[0].Value = j++;

                if (!string.IsNullOrEmpty(row.Cells[6].Value.ToString()))
                {
                    InvoiceSold += Convert.ToDecimal(row.Cells[6].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                {
                    InvoiceLeft += Convert.ToDecimal(row.Cells[7].Value.ToString());


                    if ((row.Cells[1].Value.ToString() != "363"))
                    {
                        InvoiceRecovery += Convert.ToDecimal(row.Cells[7].Value.ToString());
                    }

                    if ((row.Cells[1].Value.ToString() == "363"))
                    {
                        CashRecovery += Convert.ToDecimal(row.Cells[7].Value.ToString());
                    }



                }

                if (!string.IsNullOrEmpty(row.Cells[6].Value.ToString()))
                {
                    if ((row.Cells[1].Value.ToString() != "363"))
                    {
                        invoiced += Convert.ToDecimal(row.Cells[6].Value.ToString());
                    }

                    if ((row.Cells[1].Value.ToString() == "363"))
                    {
                        InvoiceSale += Convert.ToDecimal(row.Cells[6].Value.ToString());
                    }

                }

                row.Cells[8].Value = ((Convert.ToDecimal(row.Cells[5].Value) + Convert.ToDecimal(row.Cells[6].Value)) - Convert.ToDecimal(row.Cells[7].Value)).ToString();

            }

            textBox14.Text = InvoiceRecovery.ToString();
            textBox15.Text = CashRecovery.ToString();

            textBox12.Text = dataGridView6.Rows.Count.ToString();

            txtInvoicingAmount.Text = InvoiceSold.ToString();
            txtCollectionAmount.Text = InvoiceLeft.ToString();
            textBox11.Text = invoiced.ToString();
            textBox13.Text = InvoiceSale.ToString();

            //textBox19.Text = InvoiceLeft.ToString();
            //textBox15.Text = invoiced.ToString();


            //textBox57.Text = (Convert.ToDecimal((textBox15.Text) == "" ? "0" : textBox15.Text) + Convert.ToDecimal((textBox56.Text) == "" ? "0" : textBox56.Text)).ToString();


        }
        private void getCalculateTheRemainingStock()
        {
            //foreach (DataGridViewRow row in dataGridView4.Rows)
            //{     

            //    if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
            //    {
            //        summTotalQty += Convert.ToDecimal(row.Cells[3].Value.ToString());
            //    }


            //}
        }
        //private void InvoiceAddList()
        //{
        //    try
        //    {

        //        DataClasses1DataContext db = new DataClasses1DataContext();

        //        string getPID = "";
        //        string getCity = "";
        //        string getAddress = "";

        //        var getTheSelecteddata = from s in db.Edison_DispatchDTLs
        //                                 where s.Dispatch_DTL_ID.Equals(InvItemList.EditValue)
        //                                 select new
        //                                 {
        //                                     s.ProductID,
        //                                 };

        //        if (getTheSelecteddata.Any())
        //        {
        //            foreach (var objCourse in getTheSelecteddata)
        //            {
        //                getPID = objCourse.ProductID.ToString();
        //                break;
        //            }
        //        }



        //        var GetCustomers = from s in db.All_Customers
        //                           join v in db.All_Cities on s.City equals v.CityID into bookingmGroup
        //                           from v in bookingmGroup.DefaultIfEmpty()
        //                           where s.CustID.Equals(InvCustomerList.EditValue)
        //                           select new
        //                           {
        //                               s.CustID,
        //                               s.CustomerName,
        //                               s.CustomerAddress,
        //                               v.CityName
        //                           };

        //        if (GetCustomers.Any())
        //        {
        //            foreach (var objCourse in GetCustomers)
        //            {
        //                getAddress = objCourse.CustomerAddress.ToString();
        //                getCity = objCourse.CityName.ToString();
        //                break;
        //            }
        //        }







        //        dataGridView4.Rows.Add(null, InvCustomerList.EditValue, InvCustomerList.Text, getAddress, getCity, getPID, InvItemList.Text, InvQty.Text, InvRate.Text, txtAmount.Text);
        //        invoicinggridSumCalculator();




        //        InvCustomerList.Text = "";
        //        InvItemList.Text = "";
        //        InvQty.Text = "";
        //        InvRate.Text = "";
        //        txtAmount.Text = "";

        //        InvCustomerList.Focus();
        //        InvCustomerList.ShowPopup();

        //    }
        //    catch(Exception err)
        //    {
        //        MessageBox.Show("Error " + err);
        //    }
    
        //}

        decimal GetSumInv = 0;
        private void CalculatedInvoiceThings()
        {
       //     txtAmount.Text = (Convert.ToDecimal(InvQty.Text == "" ? "0" : InvQty.Text) * Convert.ToDecimal(InvRate.Text == "" ? "0" : InvRate.Text)).ToString("#,##0.00");
        }
        private void InvQty_TextChanged(object sender, EventArgs e)
        {
            CalculatedInvoiceThings();
        }

        private void InvRate_TextChanged(object sender, EventArgs e)
        {
            CalculatedInvoiceThings();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 10)
            //{
            //    DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    if (res == DialogResult.OK)
            //    {


            //        dataGridView4.Rows.RemoveAt(e.RowIndex);
            //        invoicinggridSumCalculator();
            //    }
            //}
        }

        private void InvColCustomerList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //invAmountReceived.Focus();

            }
        }

        private void invAmountReceived_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               // btnColAdd.Focus();
            }
        }

        private void btnColAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EnterCollection();
            }
        }

        private void btnColAdd_MouseClick(object sender, MouseEventArgs e)
        {
            EnterCollection();
        }

        private void btnColAdd_Click(object sender, EventArgs e)
        {

        }

        private void EnterCollection()
        {
            //dataGridView3.Rows.Add(null, InvColCustomerList.EditValue, InvColCustomerList.Text, invAmountReceived.Text);
            //ColTotal();
            //InvColCustomerList.Text = "";
            //invAmountReceived.Text = "";

            //InvColCustomerList.ShowPopup();
        }

        //private void ColTotal()
        //{
        //    int j = 1;

        //    Decimal summTotalQty = 0;
        //    Decimal TotalQtyinNos = 0;
        //    Decimal TotalValueInDollar = 0;
        //    Decimal TotalValueInPKRS = 0;
        //    Decimal TotalValuePerPcsInPKRS = 0;

        //    foreach (DataGridViewRow row in dataGridView3.Rows)
        //    {
        //        row.Cells[0].Value = j++;
        //        if (!string.IsNullOrEmpty(row.Cells[3].Value.ToString()))
        //        {
        //            summTotalQty += Convert.ToDecimal(row.Cells[3].Value.ToString());
        //        }


        //    }
        
        //    textBox14.Text = summTotalQty.ToString();
        //    textBox13.Text = dataGridView3.Rows.Count.ToString();
        //    txtCollectionAmount.Text = textBox14.Text;
        //}

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4)
            //{
            //    DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    if (res == DialogResult.OK)
            //    {


            //        dataGridView7.Rows.RemoveAt(e.RowIndex);
            //        ColTotal();
            //    }
            //}
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void millegecalculatorinreturn()
        {
            try
            {

                textBox20.Text = (Convert.ToInt32(textBox18.Text == "" ? "0" : textBox18.Text) - Convert.ToInt32(textBox17.Text == "" ? "0" : textBox17.Text)).ToString();

                if(Convert.ToInt32(textBox20.Text) < 0)
                {
                    textBox20.Text = "";
                }
            }
            catch(Exception err)
            {

            }
        }
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            millegecalculatorinreturn();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            millegecalculatorinreturn();
        }



        private void Invoice_SaveAll()
        {
            try
            {
                //if(Convert.ToInt32(textBox15.Text) != 0)
                //{
                //    MessageBox.Show("Please Make Complete Invoices, Thank you!");
                //    return;
                //}



                DataClasses1DataContext db = new DataClasses1DataContext();

                using (var scope = new System.Transactions.TransactionScope())
                {


                    var getTheSelecteddata1 = from s in db.Edison_DispatchHDRs
                                              where s.DispatchNo.Equals(InvDispatchNo.EditValue)
                                              select s;

                    if (getTheSelecteddata1.Any())
                    {
                        foreach (var AddItems in getTheSelecteddata1)
                        {
                            AddItems.Status = 2;
                            AddItems.CashReceived = Convert.ToDecimal(txtCashReceived.Text);
                            AddItems.RemainingAmount = Convert.ToDecimal(txtRemaining.Text);
                            db.SubmitChanges();
                            break;
                        }
                    }

                    //Edison_DispatchInvHDR objCourse = new Edison_DispatchInvHDR();

                    //objCourse.InvoiceDate = InvDate.Value.Date;

                    //objCourse.DispatchNo = Convert.ToInt32(InvDispatchNo.EditValue);
                    //objCourse.ProductiveCall = textBox27.Text.Trim();
                    //objCourse.VanNo = Convert.ToInt32(InvVanNo.EditValue);
                    //objCourse.EmpCode = Convert.ToInt32(InvSalesAgent.EditValue);

                    //objCourse.TotalAmount = Convert.ToDecimal(txtInvoicingAmount.Text == "" ? "0" : txtInvoicingAmount.Text);

                    //objCourse.RepAmount = Convert.ToDecimal(txtReplacementAmount.Text == "" ? "0" : txtReplacementAmount.Text);
                
                    //objCourse.CollectedAmount = Convert.ToDecimal(txtCollectionAmount.Text == "" ? "0" : txtCollectionAmount.Text);
                    //objCourse.CashReceived = Convert.ToDecimal(txtCashReceived.Text == "" ? "0" : txtCashReceived.Text);
                    //objCourse.Remaining = Convert.ToDecimal(txtRemaining.Text == "" ? "0" : txtRemaining.Text);



                    //db.Edison_DispatchInvHDRs.InsertOnSubmit(objCourse);
                    //db.SubmitChanges();

                    // textBox5.Text = objCourse.DispatchNo.ToString();

                    //dataGridView4.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                    //this.dataGridView4.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;

                    string CheckCustID = "";
                    string MakeBillNo = "";
                    int i = 1;

             //       foreach (DataGridViewRow row in dataGridView4.Rows)
                  //  {

          
                        //Edison_DispatchInvDTL AddItems = new Edison_DispatchInvDTL();

          

                       

                        //if (CheckCustID == "" || CheckCustID != row.Cells[1].Value.ToString())
                        //{
                        //    MakeBillNo = InvDate.Value.ToString("dd-MM-yy") + "/" + i++ ;
                        //}
                       
                   



                        //AddItems.SNo = Convert.ToInt32(row.Cells[0].Value.ToString() == "" ? "0" : row.Cells[0].Value.ToString());

                        //AddItems.CustID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());

                        //AddItems.PID = Convert.ToInt32(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                        //AddItems.Qty = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                        //AddItems.Rate = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                        //AddItems.TotalAmount = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                        //AddItems.DipatchNo = Convert.ToInt32(InvDispatchNo.EditValue);
                        //AddItems.VanNo = Convert.ToInt32(InvVanNo.EditValue);
                        //AddItems.EmpCode = Convert.ToInt32(InvSalesAgent.EditValue);
                        //AddItems.InvDate = InvDate.Value;
                        //AddItems.BillNo = MakeBillNo;



                        //CheckCustID = AddItems.CustID.ToString();


                        //db.Edison_DispatchInvDTLs.InsertOnSubmit(AddItems);
                        //db.SubmitChanges();


                        //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


               //     }



                    //foreach (DataGridViewRow row in dataGridView3.Rows)
                    //{

                    //    Edison_DispatchPayment AddItems1 = new Edison_DispatchPayment();


                    //    AddItems1.Date = InvDate.Value;
                    //    AddItems1.CustID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    //    AddItems1.Amount = Convert.ToDecimal(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());
                    //    AddItems1.VanNo = Convert.ToInt32(InvVanNo.EditValue);
                    //    AddItems1.EmpCode = Convert.ToInt32(InvSalesAgent.EditValue);
                    //    AddItems1.DispatchNo = Convert.ToInt32(InvDispatchNo.EditValue);

                    //    db.Edison_DispatchPayments.InsertOnSubmit(AddItems1);
                    //    db.SubmitChanges();


                    //}



                    scope.Complete();

                    INV_RevertState();
                    Inv_DisableAll();

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error on Save " + err);
            }

        }

        private void INV_btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void INV_btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            Invoice_SaveAll();
        }

        private void INV_btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Invoice_SaveAll();
            }
        }

        private void INV_btnRevert_Click(object sender, EventArgs e)
        {
            //dataGridView6.DataSource = null;
            searchLookUpEdit12.Visible = false;
            this.dataSet1.CreditRecovery.Rows.Clear();
            //dataGridView6.DataBind();

            Inv_DisableAll();
            Inv_ClearAll();
            INV_RevertState();

        }

        private void INV_btnEdit_Click(object sender, EventArgs e)
        {
            Inv_EnableAll();
            INV_EditSaveState();
        }

        private void INV_millegecalculator()
        {
            try
            {

                textBox21.Text = (Convert.ToInt32(textBox23.Text == "" ? "0" : textBox23.Text) - Convert.ToInt32(textBox22.Text == "" ? "0" : textBox22.Text)).ToString();

                if (Convert.ToInt32(textBox21.Text) < 0)
                {
                    textBox21.Text = "";
                }
            }
            catch (Exception err)
            {

            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            INV_millegecalculator();
        }

        private void searchLookUpEdit18_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void INV_btnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void INV_btnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            INV_EditSave();

        }

        private void INV_btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                INV_EditSave();
            }
        }

        private void INV_EditSave()
        {
            try
            {
                //if (Convert.ToInt32(textBox15.Text) != 0)
                //{
                //    MessageBox.Show("Please Make Complete Invoices, Thank you!");
                //    return;
                //}



                DataClasses1DataContext db = new DataClasses1DataContext();

                using (var scope = new System.Transactions.TransactionScope())
                {

                    var getTheSelecteddata1 = from s in db.Edison_DispatchHDRs
                                              where s.DispatchNo.Equals(searchLookUpEdit12.EditValue)
                                              select s;

                    if (getTheSelecteddata1.Any())
                    {
                        foreach (var AddItems in getTheSelecteddata1)
                        {
                            AddItems.Status = 2;
                            AddItems.CashReceived = Convert.ToDecimal(txtCashReceived.Text);
                            AddItems.RemainingAmount = Convert.ToDecimal(txtRemaining.Text);
                            AddItems.ProductiveCall = textBox27.Text.ToString() == "" ? "0" : textBox27.Text.ToString() ;


                            db.SubmitChanges();
                            break;
                        }
                    }

                    scope.Complete();

                    INV_RevertState();
                    Inv_DisableAll();

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error on Save " + err);
            }

        }

        private void dataGridView10_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView10.Columns[e.ColumnIndex].Name == "Select")
                {
                    //   MessageBox.Show(ReceivingCashGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    if (Convert.ToBoolean(dataGridView10.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                    {
                        if (textBox39.Text == "0" || textBox40.Text == "0")
                        {
                            textBox39.Text = "1";
                            textBox40.Text = (Convert.ToDecimal(dataGridView10.Rows[e.RowIndex].Cells[8].Value)).ToString();
                 
                        }
                        else
                        {
                            textBox39.Text = (Convert.ToInt32(textBox39.Text) + 1).ToString();
                            textBox40.Text = (Convert.ToDecimal(textBox40.Text) + Convert.ToDecimal(dataGridView10.Rows[e.RowIndex].Cells[8].Value)).ToString();
                        }
                    }
                    else if (Convert.ToBoolean(dataGridView10.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == false)
                    {
                        textBox39.Text = (Convert.ToInt32(textBox39.Text) - 1).ToString();
                        textBox40.Text = (Convert.ToDecimal(textBox40.Text) - Convert.ToDecimal(dataGridView10.Rows[e.RowIndex].Cells[8].Value)).ToString();

                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR Please Check " + err);
            }

        }

        private void dataGridView10_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView10.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            this.receiveCollectionsTableAdapter.Fill(this.dataSet1.ReceiveCollections);
            textBox39.Text = "0";
            textBox40.Text = "0";


        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                for (int b = 0; b < dataGridView10.Rows.Count; b++)
                {

                    if (Convert.ToBoolean(dataGridView10.Rows[b].Cells[0].Value) == true)
                    {


                        var getTheSelecteddata = from s in db.Edison_DispatchHDRs
                                                 where s.DispatchNo.Equals(dataGridView10.Rows[b].Cells[2].Value.ToString())
                                                 select s;

                        if (getTheSelecteddata.Any())
                        {
                            foreach (var nowupdate in getTheSelecteddata)
                            {
                                nowupdate.Status = 3;
                                db.SubmitChanges();
                            }
                        }
                    }
                }

                this.receiveCollectionsTableAdapter.Fill(this.dataSet1.ReceiveCollections);
                textBox39.Text = "0";
                textBox40.Text = "0";

            }
            catch(Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void searchLookUpEdit11_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit11.Text))
            {


                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.All_Customers
                                         join v in db.All_Cities on s.City equals v.CityID into bookingmGroup
                                         from v in bookingmGroup.DefaultIfEmpty()
                                         where s.CustID.Equals(searchLookUpEdit11.EditValue)
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
                        textBox31.Text = ab.CustomerAddress;
                        textBox41.Text = ab.CityName;
                        searchLookUpEdit10.EditValue = ab.VanID;

                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Dispatch Number");
                    return;
                }
            }
            }

        private void InvVanNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SR_EnableAll()
        {
            textBox30.Enabled = true;
            dateTimePicker3.Enabled = true;
            textBox29.Enabled = true;
            searchLookUpEdit11.Enabled = true;

            textBox31.Enabled = true;
            textBox41.Enabled = true;
            searchLookUpEdit10.Enabled = true;

            searchLookUpEdit16.Enabled = true;
            textBox37.Enabled = true;
            textBox35.Enabled = true;
            textBox36.Enabled = true;

            textBox32.Enabled = true;
            textBox33.Enabled = true;
            textBox34.Enabled = true;

            searchLookUpEdit9.Enabled = true;
        }

        private void SR_DisableAll()
        {
            textBox30.Enabled = false;
            dateTimePicker3.Enabled = false;
            textBox29.Enabled = false;
            searchLookUpEdit11.Enabled = false;

            textBox31.Enabled = false;
            textBox41.Enabled = false;
            searchLookUpEdit10.Enabled = false;

            searchLookUpEdit16.Enabled = false;
            textBox37.Enabled = false;
            textBox35.Enabled = false;
            textBox36.Enabled = false;

            textBox32.Enabled = false;
            textBox33.Enabled = false;
            textBox34.Enabled = false;

            searchLookUpEdit9.Enabled = false;
        }

        private void SR_ClearAll()
        {
            textBox30.Enabled = false;

            searchLookUpEdit9.Text = "";
            textBox42.Text = "";

            textBox30.Text = "";
            dateTimePicker3.Text = "";
            textBox29.Text = "";
            searchLookUpEdit11.Text = "";

            textBox31.Text = "";
            textBox41.Text = "";
            searchLookUpEdit10.Text = "";

            searchLookUpEdit16.Text = "";
            textBox37.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";

            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";

            searchLookUpEdit9.Text = "";

            dataGridView9.Rows.Clear();

        }

        private void SR_AddState()
        {
            
            SR_Add.Visible = false;
            SR_Save.Visible = true;
            SR_Revert.Visible = true;
            SR_Edit.Visible = false;
            SR_EditSave.Visible = false;
            SR_Search.Visible = false; 
        
        }

        private void SR_RevertState()
        {
            SR_Add.Visible = true;
            SR_Save.Visible = false;
            SR_Revert.Visible = false;
            SR_Edit.Visible = true;
            SR_EditSave.Visible = false;
            SR_Search.Visible = true;

        }

        private void SR_EditSaveState()
        {
            SR_Add.Visible = false;
            SR_Save.Visible = false;
            SR_Revert.Visible = true;
            SR_Edit.Visible = false;
            SR_EditSave.Visible = true;
            SR_Search.Visible = false;

        }

        private void SR_Add_Click(object sender, EventArgs e)
        {
            SR_ClearAll();
            SR_AddState();
            SR_EnableAll();
            dateTimePicker3.Focus();

        }

        private void SR_Revert_Click(object sender, EventArgs e)
        {
            SR_ClearAll();
            SR_RevertState();
            SR_DisableAll();
        }

        private void dateTimePicker3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox29.Focus();
            }
        }

        private void textBox29_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit11.Focus();
                searchLookUpEdit11.ShowPopup();
            }
        }

        private void searchLookUpEdit11_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit16.Focus();
                searchLookUpEdit16.ShowPopup();
            }
        }

        private void textBox42_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                dataGridView11.Visible = true;
                this.salesReturnBillCheckTableAdapter.Fill(this.dataSet1.SalesReturnBillCheck, Convert.ToInt32(searchLookUpEdit16.EditValue), Convert.ToInt32(searchLookUpEdit11.EditValue));
              }


            if (e.KeyCode.Equals(Keys.Down) && dataGridView11.Visible == true && dataGridView11.Rows.Count >= 1)
            {
                dataGridView11.Focus();
                dataGridView11.Rows[0].Selected = true;
            }


            if (e.KeyCode.Equals(Keys.Escape))
            {
                dataGridView11.Visible = false;
            }

            if(e.KeyCode.Equals(Keys.Enter))
            {
                textBox37.Focus();
            }

        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView11_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
                if (e.KeyCode.Equals(Keys.Enter))
                {



                SalesReturnInvoiceDate.Value = Convert.ToDateTime(dataGridView11.SelectedCells[3].Value);
                textBox42.Text = dataGridView11.SelectedCells[7].Value.ToString();
                textBox43.Text = dataGridView11.SelectedCells[4].Value.ToString();
                textBox44.Text = dataGridView11.SelectedCells[5].Value.ToString();
                textBox42.Focus();

            }

            if (e.KeyCode.Equals(Keys.Escape))
            { 
                dataGridView11.Visible = false;
            }

        }

        private void textBox37_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox35.Focus();
            }
        }

        private void textBox35_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox36.Focus();
            }
        }
        
        private void InsertRowInGrid()
        {

        }
        private void simpleButton4_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void simpleButton4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

            }
        }

        private void SR_Calculator()
        {
            try
            {

                textBox36.Text = (Convert.ToDecimal(textBox37.Text == "" ? "0" : textBox37.Text) * Convert.ToDecimal(textBox35.Text == "" ? "0" : textBox35.Text)).ToString("#,##0.00");
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }
        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            SR_Calculator();
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            SR_Calculator();
        }

        private void SR_ItemsClear()
        {
            searchLookUpEdit9.Text = "";
            searchLookUpEdit16.Text = "";
            textBox42.Text = "";
            SalesReturnInvoiceDate.Value = DateTime.Now;
            textBox43.Text = "";
            textBox44.Text = "";
            textBox37.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
        }

        private void SR_GridCalculator()
        {
            int j = 1;

            Decimal summTotalQty = 0;

            Decimal summTotalss = 0;


            foreach (DataGridViewRow row in dataGridView9.Rows)
            {
                row.Cells[0].Value = j++;


                if (!string.IsNullOrEmpty(row.Cells[9].Value.ToString()))
                {
                    summTotalQty += Convert.ToDecimal(row.Cells[9].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[11].Value.ToString()))
                {
                    summTotalss += Convert.ToDecimal(row.Cells[11].Value.ToString());
                }
            }

            textBox33.Text = summTotalQty.ToString();
            textBox34.Text = summTotalss.ToString();
            textBox32.Text = dataGridView9.Rows.Count.ToString();
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(searchLookUpEdit16.Text))
                {
                    if (!string.IsNullOrEmpty(textBox37.Text))
                    {
                        if (!string.IsNullOrEmpty(textBox36.Text))
                        {
                            int ReturnType = -1;
                    

                            if (!string.IsNullOrEmpty(textBox42.Text))
                                {                               
                                    dataGridView9.Rows.Add(null, searchLookUpEdit16.EditValue, searchLookUpEdit16.Text, searchLookUpEdit9.EditValue, searchLookUpEdit9.Text, "", SalesReturnInvoiceDate.Value, textBox43.Text, textBox44.Text, textBox37.Text, textBox35.Text, textBox36.Text);
                                    SR_ItemsClear();
                                    SR_GridCalculator();
                                searchLookUpEdit16.Focus();
                                searchLookUpEdit16.ShowPopup();
                                }
                                else
                                {
                                    dataGridView9.Rows.Add(null, searchLookUpEdit16.EditValue, searchLookUpEdit16.Text, searchLookUpEdit9.EditValue, searchLookUpEdit9.Text, "", "", "", "", textBox37.Text, textBox35.Text, textBox36.Text);
                                    SR_ItemsClear();
                                    SR_GridCalculator();

                                searchLookUpEdit16.Focus();
                                searchLookUpEdit16.ShowPopup();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Amount Cannot be Empty");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error! Please Enter the return Quantity");
                            return;
                    }
                }
                else
                {
                    MessageBox.Show("Error! Please select an Product" );
                    return;

                }
     
           

            }
            catch(Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void searchLookUpEdit16_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit9.Focus();
                searchLookUpEdit9.ShowPopup();
            }
        }

        private void textBox36_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                simpleButton4.Focus();
            }
        }

        private void searchLookUpEdit9_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox42.Focus();
            }
        }

        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {


                    dataGridView9.Rows.RemoveAt(e.RowIndex);
                    SR_GridCalculator();
                }
            }
        }

        private void SR_AddItem()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                using (var scope = new System.Transactions.TransactionScope())
                {


                    Edison_SalesReturnHDR objCourse = new Edison_SalesReturnHDR();

                    objCourse.Date = dateTimePicker3.Value.Date;
                    objCourse.DispatchNo = textBox29.Text.Trim();

                    objCourse.CustID = Convert.ToInt32(searchLookUpEdit11.EditValue);

                    objCourse.TotalAmount = Convert.ToDecimal(textBox34.Text);


                    db.Edison_SalesReturnHDRs.InsertOnSubmit(objCourse);
                    db.SubmitChanges();

                    textBox30.Text = objCourse.SalesReturnID.ToString();

                    foreach (DataGridViewRow row in dataGridView9.Rows)
                    {

                        Edison_SalesReturnDTL AddItems = new Edison_SalesReturnDTL();


                        AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());

                        AddItems.ReturnTypeID = Convert.ToInt32(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());

                        if (row.Cells[6].Value == null)
                        {

                        }
                        else
                        {
                            AddItems.BillDate = Convert.ToDateTime(row.Cells[6].Value.ToString() == "" ? null : row.Cells[6].Value.ToString());
                        }


                        AddItems.BillQty = Convert.ToInt32(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());

                        AddItems.BillRate = Convert.ToInt32(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());

                        AddItems.ReturnQty = Convert.ToInt32(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());


                        AddItems.Rate = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());


                        AddItems.Amount = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());

                        AddItems.SalesReturnID = Convert.ToInt32(textBox30.Text);


                        db.Edison_SalesReturnDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();



                        //var getTheSelecteddata = from s in db.Edison_DispatchDTLs
                        //                         where s.DispatchNo.Equals(textBox29.Text) && s.ProductID.Equals(Convert.ToInt32(AddItems.PID))
                        //                         select s;

                        //if (getTheSelecteddata.Any())
                        //{
                        //    foreach (var ab in getTheSelecteddata)
                        //    {
                        //        if (AddItems.ReturnTypeID == 2)
                        //        {
                        //            ab.SalesReturn = ab.SalesReturn + AddItems.ReturnQty;
                        //        }
                        //        else if (AddItems.ReturnTypeID == 1)
                        //        {
                        //            ab.REP = ab.REP + AddItems.ReturnQty;
                        //        }
                        //        ab.SalesReturnID = AddItems.SalesReturnID;
                        //        ab.SalesReturn_DTL_ID = AddItems.SalesReturn_DTL_ID;

                        //        db.SubmitChanges();
                        //    }
                        //}
                        //else
                        //{
                        //    Edison_DispatchDTL addDispatch = new Edison_DispatchDTL();

                        //    addDispatch.ProductID = AddItems.PID;
                        //    addDispatch.StockIssued = 0;
                        //    addDispatch.StockReturn = 0;

                        //    if (AddItems.ReturnTypeID == 2)
                        //    {
                        //        addDispatch.SalesReturn = AddItems.ReturnQty;
                        //    }
                        //    else if (AddItems.ReturnTypeID == 1)
                        //    {
                        //        addDispatch.REP = AddItems.ReturnQty;
                        //    }

                        //    addDispatch.REP = 0;
                        //    addDispatch.TotalDelivered = 0;


                        //    addDispatch.DispatchNo = Convert.ToInt32(textBox29.Text);

                        //    addDispatch.SalesReturnID = AddItems.SalesReturnID;
                        //    addDispatch.SalesReturn_DTL_ID = AddItems.SalesReturn_DTL_ID;

                        //    db.Edison_DispatchDTLs.InsertOnSubmit(addDispatch);
                        //    db.SubmitChanges();
                        //}







                    }



                    scope.Complete();

                    SR_RevertState();
                    SR_DisableAll();

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error on Save " + err);
            }

        }

        private void SR_Save_MouseClick(object sender, MouseEventArgs e)
        {
            SR_AddItem();
        }

        private void SR_Save_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SR_AddItem();
            }
                    
        }

        private void SR_Save_Click(object sender, EventArgs e)
        {

        }

        private void textBox30_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {


                dateTimePicker3.Text = "";
                textBox29.Text = "";
                searchLookUpEdit11.Text = "";

                textBox31.Text = "";
                textBox41.Text = "";
                searchLookUpEdit10.Text = "";

                searchLookUpEdit16.Text = "";
                textBox37.Text = "";
                textBox35.Text = "";
                textBox36.Text = "";

                textBox32.Text = "";
                textBox33.Text = "";
                textBox34.Text = "";

                searchLookUpEdit9.Text = "";

                dataGridView9.Rows.Clear();

                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.Edison_SalesReturnHDRs
                                         where s.SalesReturnID.Equals(textBox30.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var ab in getTheSelecteddata)
                    {
                        dateTimePicker3.Value = Convert.ToDateTime(ab.Date);
                        textBox29.Text = ab.DispatchNo.ToString();
                        searchLookUpEdit11.EditValue = Convert.ToInt32(ab.CustID);
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Dispatch Number");
                    return;
                }


                var getTheSelecteddata1 = from s in db.Edison_SalesReturnDTLs
                                          join v in db.Edison_Products on s.PID equals v.ProductID into bookingmGroup
                                          from v in bookingmGroup.DefaultIfEmpty()
                                          join l in db.Edison_ReturnTypes on s.ReturnTypeID equals l.ReturnTypeID into bookingmGroupl
                                          from l in bookingmGroupl.DefaultIfEmpty()
                                          where s.SalesReturnID.Equals(textBox30.Text)
                                          select new
                                          {
                                              s.PID,
                                              v.ProductCode,
                                              s.ReturnTypeID,
                                              l.ReturnTypeName,
                                              s.BillDate,
                                              s.BillQty,
                                              s.BillRate,
                                              s.ReturnQty,
                                              s.Rate,
                                              s.Amount,
                                          };
                if (getTheSelecteddata1.Any())
                {
                    foreach (var ab in getTheSelecteddata1)
                    {
                        dataGridView9.Rows.Add(null, ab.PID, ab.ProductCode, ab.ReturnTypeID, ab.ReturnTypeName,null, ab.BillDate, ab.BillQty, ab.BillRate, ab.ReturnQty, ab.Rate, ab.Amount);                    
                    }
                }

                SR_ItemsClear();
                SR_GridCalculator();

            }
        }

        private void SR_Search_Click(object sender, EventArgs e)
        {
            textBox30.Enabled = true;
            textBox30.Focus();
        }

        private void SR_Edit_Click(object sender, EventArgs e)
        {
            SR_EnableAll();
            SR_EditSaveState();
        }

        private void SR_EditSave_Click(object sender, EventArgs e)
        {

        }

        private void SR_EditSave_MouseClick(object sender, MouseEventArgs e)
        {
            SR_EditSaveButton();
        }

        private void SR_EditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SR_EditSaveButton();
            }
        }

        private void SR_EditSaveButton()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                using (var scope = new System.Transactions.TransactionScope())
                {
               

                    var getTheSelecteddata = from s in db.Edison_SalesReturnHDRs
                                             where s.SalesReturnID.Equals(textBox30.Text)
                                             select s;

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var objCourse in getTheSelecteddata)
                        {

                            objCourse.Date = dateTimePicker3.Value.Date;
                            objCourse.DispatchNo = textBox29.Text.Trim();
                            objCourse.CustID = Convert.ToInt32(searchLookUpEdit11.EditValue);
                            objCourse.TotalAmount = Convert.ToDecimal(textBox34.Text);
                            db.SubmitChanges();
                        }
                    }

                    var a = from s in db.Edison_SalesReturnDTLs
                            where s.SalesReturnID.Equals(textBox30.Text.Trim())
                            select s;

                    if (a.Any())
                    {
                        foreach (var d in a)
                        {
                            db.Edison_SalesReturnDTLs.DeleteOnSubmit(d);
                            db.SubmitChanges();
                        }
                    }

                    //   textBox30.Text = objCourse.SalesReturnID.ToString();

                    foreach (DataGridViewRow row in dataGridView9.Rows)
                    {

                        Edison_SalesReturnDTL AddItems = new Edison_SalesReturnDTL();


                        AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());

                        AddItems.ReturnTypeID = Convert.ToInt32(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());

                        if (row.Cells[6].Value == null)
                        {

                        }
                        else
                        {
                            AddItems.BillDate = Convert.ToDateTime(row.Cells[6].Value.ToString() == "" ? null : row.Cells[6].Value.ToString());
                        }


                        AddItems.BillQty = Convert.ToInt32(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());

                        AddItems.BillRate = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());

                        AddItems.ReturnQty = Convert.ToInt32(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());


                        AddItems.Rate = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());


                        AddItems.Amount = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());

                        AddItems.SalesReturnID = Convert.ToInt32(textBox30.Text);


                        db.Edison_SalesReturnDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();


                        //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                    }



                    scope.Complete();

                    SR_RevertState();
                    SR_DisableAll();

                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error on Save " + err);
            }
        }

        private void searchLookUpEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void InvCustomerList_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void InvItemList_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void CalculateTheIlTotals()
        {
            try
            {
                decimal sum3 = 0;
              

                for (int i = 0; i < dataGridView12.Rows.Count; ++i)
                {
                    if (dataGridView12.Rows[i].Cells[5].Value == null || dataGridView12.Rows[i].Cells[5].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView12.Rows[i].Cells[5].Value.ToString()))
                    {

                    }
                    else
                    {
                        sum3 += Convert.ToDecimal(dataGridView12.Rows[i].Cells[5].Value);
                    }

                   


                }

                textBox24.Text = sum3.ToString();
                textBox25.Text = dataGridView12.Rows.Count.ToString();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnCustomerListRefresh_Click(object sender, EventArgs e)
        {
            this.customersListTableAdapter.Fill(this.dataSet1.CustomersList);
            CalculateTheIlTotals();


        }

        private void SearchCustomer()
        {
            try
            {

                DataView DV = new DataView(this.dataSet1.CustomersList);

                DV.RowFilter = "(convert(CustID, 'System.String') like '%" + textBox49.Text + "%' OR convert(CustID, 'System.String') IS Null) AND (convert(CustomerName, 'System.String') like '%" + textBox45.Text + "%' OR convert(CustomerName, 'System.String') IS Null) AND (CustomerAddress like '%" + textBox46.Text + "%' OR CustomerAddress IS Null) AND (CityName like '%" + textBox47.Text + "%' OR CityName IS Null ) AND (convert(VanName, 'System.String') like '%" + textBox48.Text + "%' OR convert(VanName, 'System.String') IS Null) ";
                dataGridView12.DataSource = DV;
                CalculateTheIlTotals();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

           
            if (IC_BtnSave.Visible == true)
            {
                //DataClasses1DataContext db = new DataClasses1DataContext();

                //Edison_DispatchDTL AddItems = new Edison_DispatchDTL();
                //AddItems.DispatchNo = Convert.ToInt32(searchLookUpEdit3.EditValue);
                //AddItems.ProductID = Convert.ToInt32(searchLookUpEdit17.EditValue == "" ? "0" : searchLookUpEdit17.EditValue);
                //AddItems.StockIssued = 0;
                //AddItems.StockReturn = 0;
                //AddItems.TotalDelivered = 0;
                //AddItems.REP = Convert.ToInt32(textBox50.Text);

                //db.Edison_DispatchDTLs.InsertOnSubmit(AddItems);
                //db.SubmitChanges();

                //this.dispatchReturnDTLTableAdapter.Fill(this.dataSet1.DispatchReturnDTL, Convert.ToInt32(searchLookUpEdit3.EditValue));

                //if(string.IsNullOrEmpty(textBox50.Text))
                //{
                //    MessageBox.Show("Error! Please enter the replacement quantity");
                //    return;
                //}

                string values = "";

                values = (Convert.ToInt32(textBox26.Text == "" ? "0" : textBox26.Text) + Convert.ToInt32(textBox50.Text == "" ? "0" : textBox50.Text)).ToString();

                dataGridView2.Rows.Add("0", "0", searchLookUpEdit17.EditValue, searchLookUpEdit17.Text, "", "0", textBox26.Text == "" ? "0" : textBox26.Text, textBox50.Text == "" ? "0" : textBox50.Text, Convert.ToInt32(values) *-1, searchLookUpEdit3.Text, "0", "0", "0", "0", "0", "0");


                


                DLReturn_SumAll();

                textBox26.Text = "";
                textBox50.Text = "";
                searchLookUpEdit17.Text = "";
                searchLookUpEdit17.EditValue = 0;
                searchLookUpEdit17.Focus();
                searchLookUpEdit17.ShowPopup();


            }
            else if (IC_BtnEditSave.Visible == true)
            {

                
                //DataClasses1DataContext db = new DataClasses1DataContext();

                //Edison_DispatchDTL AddItems = new Edison_DispatchDTL();
                //AddItems.DispatchNo = Convert.ToInt32(searchLookUpEdit8.EditValue);
                //AddItems.ProductID = Convert.ToInt32(searchLookUpEdit17.EditValue == "" ? "0" : searchLookUpEdit17.EditValue);
                //AddItems.StockIssued = 0;
                //AddItems.StockReturn = 0;
                //AddItems.TotalDelivered = 0;
                //AddItems.REP = Convert.ToInt32(textBox50.Text);

                //db.Edison_DispatchDTLs.InsertOnSubmit(AddItems);
                //db.SubmitChanges();

                //this.dispatchReturnDTLTableAdapter.Fill(this.dataSet1.DispatchReturnDTL, Convert.ToInt32(searchLookUpEdit8.EditValue));

                if (string.IsNullOrEmpty(textBox50.Text))
                {
                    MessageBox.Show("Error! Please enter the replacement quantity");
                    return;
                }

                dataGridView2.Rows.Add("0", "0", searchLookUpEdit17.EditValue, searchLookUpEdit17.Text, "", "0", "0", textBox50.Text, Convert.ToInt32(textBox50.Text) * -1, searchLookUpEdit8.Text, "0", "0", "0", "0", "0", "0");
                DLReturn_SumAll();
                textBox50.Text = "";
                searchLookUpEdit17.Text = "";
                searchLookUpEdit17.EditValue = 0;

            }
            else
            {
                MessageBox.Show("Error ");
            }

        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            getInvoicingCalculation();

        }

        private void makesalesdetail()
        {
            txtTotalSale.Text = (Convert.ToDecimal((txtInvoicingAmount.Text) == "" ? "0" : txtInvoicingAmount.Text) - (Convert.ToDecimal((txtReplacementAmount.Text) == "" ? "0" : txtReplacementAmount.Text) *-1)).ToString();


            textBox19.Text = (Convert.ToDecimal((textBox15.Text) == "" ? "0" : textBox15.Text) - (Convert.ToDecimal((txtReplacementAmount.Text) == "" ? "0" : txtReplacementAmount.Text) *-1)).ToString();

            textBox28.Text = (Convert.ToDecimal((textBox19.Text) == "" ? "0" : textBox19.Text) + (Convert.ToDecimal((textBox14.Text) == "" ? "0" : textBox14.Text))).ToString();

            textBox38.Text = (Convert.ToDecimal((textBox28.Text) == "" ? "0" : textBox28.Text) - (Convert.ToDecimal((txtExpenses.Text) == "" ? "0" : txtExpenses.Text))).ToString();

            
        }

        private void getInvoicingCalculation()
        {
            try
            {

                txtNetAmount.Text = (Convert.ToDecimal((txtCollectionAmount.Text) == "" ? "0" : txtCollectionAmount.Text) - (Convert.ToDecimal((txtReplacementAmount.Text) == "" ? "0" : txtReplacementAmount.Text) + Convert.ToDecimal((txtExpenses.Text) == "" ? "0" : txtExpenses.Text))).ToString();

                txtRemaining.Text = (Convert.ToDecimal((textBox38.Text) == "" ? "0" : textBox38.Text) - Convert.ToDecimal((txtCashReceived.Text) == "" ? "0" : txtCashReceived.Text)).ToString();

                textBox51.Text = (Convert.ToDecimal((txtInvoicingAmount.Text) == "" ? "0" : txtInvoicingAmount.Text) - Convert.ToDecimal((txtReplacementAmount.Text) == "" ? "0" : txtReplacementAmount.Text)).ToString();

           //     makesalesdetail();

            }
            catch(Exception err)
            {

            }
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {
            getInvoicingCalculation();
        }

        private void textBox52_TextChanged(object sender, EventArgs e)
        {
            getInvoicingCalculation();
        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {
            getInvoicingCalculation();
        }

        private void textBox54_TextChanged(object sender, EventArgs e)
        {
            getInvoicingCalculation();
        }

        private void textBox55_TextChanged(object sender, EventArgs e)
        {
            //textBox56.Text = textBox55.Text;
        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            getInvoicingCalculation();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            getLedger();
        }

        private void getLedger()
        {
            try
            {
                dataGridView8.Rows.Clear();
                dataGridView8.Refresh();

                DataClasses1DataContext db = new DataClasses1DataContext();
                db.ObjectTrackingEnabled = false;

                string code;




                DateTime cdate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                cdate = cdate.AddDays(-60);




                // ---------------------------------------------------------------
                var getopeningbalance = from w in db.All_Customers
                                        where w.CustID.Equals(searchLookUpEdit6.EditValue)
                                        select new
                                        {
                                            w.OpeningBalance1,

                                        };


                if (getopeningbalance.Any())
                {


                    foreach (var a in getopeningbalance)
                    {
                        dataGridView8.Rows.Add(null, null, "Opening Balance", null, null, "0", "0", "0", "0", a.OpeningBalance1);
                        //    this.DataSet1.Ledger.Rows.Clear();

                        code = (searchLookUpEdit6).ToString();

                        //           txtBalance.Text = Convert.ToDecimal(a.Balance).ToString("#,##0.00");


                        break;
                    }
                }
                //------------------------------------------------------------------



                var getdata = from f in db.Edison_InvoiceHDRs
                                  where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                                  select new
                                  {
                                      f.InvoiceID,
                                      f.Date,
                                      f.DispatchNo,
                                      f.TotalAmount,
                                      f.CustID,

                                  };

                if (getdata.Any())
                {


                    foreach (var a in getdata)
                    {
                        dataGridView8.Rows.Add(a.InvoiceID, a.Date, "Invoice", a.DispatchNo, null, null, a.TotalAmount, "0", "0");
                    }

                }



                var getreturn11 = from f in db.Edison_SalesReturnHDRs
                                 where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                                  select new
                                 {
                                     f.SalesReturnID,
                                     f.Date,
                                     f.DispatchNo,
                                     f.TotalAmount,
                                     f.CustID,

                                 };

                if (getreturn11.Any())
                {


                    foreach (var a in getreturn11)
                    {
                        dataGridView8.Rows.Add(a.SalesReturnID, a.Date, "Sale Return", a.DispatchNo, null, null ,"0", "0", a.TotalAmount);
                    }

                }


                var getdata2 = from f in db.Edison_DispatchPayments
                               where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                               select new
                               {
                                   f.PaymentID,
                                   f.Date,
                                   //f.Remarks,
                                   f.Amount,
                                  // f.Write


                               };

                if (getdata2.Any())
                {
                    foreach (var b in getdata2)
                    {
                        dataGridView8.Rows.Add(b.PaymentID, b.Date, "Collection", null, "0", "0", "0", b.Amount, "0");
                        //dataGridView8.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }

                dataGridView8.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

                dataGridView8.Sort(dataGridView8.Columns[1], ListSortDirection.Ascending);
                this.dataGridView8.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;




                for (int i = 1; i < dataGridView8.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView8[6, i].Value) == 0) && ((Convert.ToDecimal(dataGridView8[7, i].Value) != 0) || (Convert.ToDecimal(dataGridView8[8, i].Value) != 0)))
                    {
                        dataGridView8[9, i].Value = Convert.ToDecimal(dataGridView8[9, i - 1].Value) - Convert.ToDecimal(dataGridView8[7, i].Value) - Convert.ToDecimal(dataGridView8[8, i].Value);
                    }
                    else
                    {
                        dataGridView8[9, i].Value = (Convert.ToDecimal(dataGridView8[6, i].Value) + Convert.ToDecimal(dataGridView8[8, i].Value) + Convert.ToDecimal(dataGridView8[9, i - 1].Value));

                    }

                }



                //--------------------------------------------------------------------------------------------------------------------------------------------------------------


                decimal getvalue = 0;


                Int32 index = dataGridView8.Rows.Count - 1;

                getvalue = Convert.ToDecimal(dataGridView8[9, index].Value);





                dataGridView8.Rows.Clear();
                dataGridView8.Refresh();


                // ---------------------------------------------------------------

                // dataGridView8.Rows.Add(null, "Opening Balance", null, null, null, null, null, null, getvalue.ToString("#,##0.00"));

                dataGridView8.Rows.Add(null, null, "Opening Balance", null, "0", "0", "0", "0", "0", getvalue.ToString("#,##0.00"), "0");


                //------------------------------------------------------------------

                DataClasses1DataContext connection = new DataClasses1DataContext();

                connection.ObjectTrackingEnabled = false;



                //var getdata1 = from Edison_DispatchInvDTLs in db.Edison_DispatchInvDTLs
                //               group Edison_DispatchInvDTLs by new
                //               {
                //                   Edison_DispatchInvDTLs.CustID,
                //                   Edison_DispatchInvDTLs.InvDate,
                //                   Edison_DispatchInvDTLs.BillNo
                //               } into g
                //               where g.Key.CustID == Convert.ToInt32(searchLookUpEdit6.EditValue) &&
                //                 g.Key.InvDate  >= LD_FromDate.Value.Date &&
                //                 g.Key.InvDate <= LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
                //               select new
                //               {
                //                   g.Key.CustID,
                //                   g.Key.InvDate,
                //                   g.Key.BillNo,
                //                   Expr1 = (decimal?)g.Sum(p => p.TotalAmount)
                //               };


                //if (getdata1.Any())
                //{
                //    foreach (var b in getdata1)
                //    {

                //        dataGridView8.Rows.Add(null, b.InvDate, "Invoicing", null, "0", "0", b.Expr1, "0", "0");
                //    }

                //}

                var getdata1 = from f in db.Edison_InvoiceHDRs
                              where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                              select new
                              {
                                  f.InvoiceID,
                                  f.Date,
                                  f.DispatchNo,
                                  f.TotalAmount,
                                  f.CustID,

                              };

                if (getdata1.Any())
                {


                    foreach (var a in getdata1)
                    {
                        dataGridView8.Rows.Add(a.InvoiceID, a.Date, "Invoice (Dispatch # " + a.DispatchNo + ")", a.InvoiceID, null, null, a.TotalAmount, "0", "0");
                    }

                }






                var getreturn1 = from f in db.Edison_SalesReturnHDRs
                                 where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                                 select new
                                 {
                                     f.SalesReturnID,
                                     f.Date,
                                     f.DispatchNo,
                                     f.TotalAmount,
                                     f.CustID,

                                 };

                if (getreturn1.Any())
                {


                    foreach (var a in getreturn1)
                    {
                        dataGridView8.Rows.Add(a.SalesReturnID, a.Date, "Sale Return", a.DispatchNo, null, null, "0", "0", a.TotalAmount);
                    }

                }


                var getdata22 = from f in db.Edison_DispatchPayments
                               where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                               select new
                               {
                                   f.PaymentID,
                                   f.Date,
                                   //f.Remarks,
                                   f.Amount,
                                   // f.Write


                               };

                if (getdata22.Any())
                {
                    foreach (var b in getdata22)
                    {
                        dataGridView8.Rows.Add(b.PaymentID, b.Date, "Collection", null, "0", "0", "0", b.Amount, "0");
                        //dataGridView8.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }




                dataGridView8.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";


                dataGridView8.Sort(dataGridView8.Columns[1], ListSortDirection.Ascending);
                this.dataGridView8.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;



                for (int i = 1; i < dataGridView8.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView8[6, i].Value) == 0) && ((Convert.ToDecimal(dataGridView8[7, i].Value) != 0) || (Convert.ToDecimal(dataGridView8[8, i].Value) != 0)))
                    {
                        dataGridView8[9, i].Value = Convert.ToDecimal(dataGridView8[9, i - 1].Value) - Convert.ToDecimal(dataGridView8[7, i].Value) - Convert.ToDecimal(dataGridView8[8, i].Value);
                    }
                    else
                    {
                        dataGridView8[9, i].Value = (Convert.ToDecimal(dataGridView8[6, i].Value) + Convert.ToDecimal(dataGridView8[8, i].Value) + Convert.ToDecimal(dataGridView8[9, i - 1].Value));

                    }

                }




                //for (int i = 1; i < dataGridView8.Rows.Count; i++)
                //{

                //    if ((Convert.ToDecimal(dataGridView8[5, i].Value) == 0) && ((Convert.ToDecimal(dataGridView8[6, i].Value) != 0) || (Convert.ToDecimal(dataGridView8[7, i].Value) != 0)))
                //    {
                //        dataGridView8[8, i].Value = Convert.ToDecimal(dataGridView8[8, i - 1].Value) - Convert.ToDecimal(dataGridView8[6, i].Value) - Convert.ToDecimal(dataGridView8[7, i].Value);
                //    }
                //    else
                //    {
                //        dataGridView8[8, i].Value = (Convert.ToDecimal(dataGridView8[5, i].Value) + Convert.ToDecimal(dataGridView8[7, i].Value) + Convert.ToDecimal(dataGridView8[8, i - 1].Value));

                //    }

                //}




                //foreach (DataGridViewRow Myrow in dataGridView8.Rows)
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



                //  dataGridView8.Columns[5].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView8.Columns[9].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView8.Columns[8].DefaultCellStyle.BackColor = Color.MistyRose;
                dataGridView8.Columns[7].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                dataGridView8.Columns[6].DefaultCellStyle.BackColor = Color.Khaki;

                //for (int i = 0; i < dataGridView8.Rows.Count; i++)
                //{ //                                                                                  date                                bill #                                     cases                                   bility amount                decription                                   bill amount                coll                                     writeoff                                balance
                //    //DataSet1.Ledger.AddLedgerRow(null, null, null, null, null, null, dataGridView8[0, i].Value.ToString(), dataGridView8[7, i].Value.ToString(), dataGridView8[10, i].Value.ToString(), dataGridView8[12, i].Value.ToString(), dataGridView8[16, i].Value.ToString(), dataGridView8[17, i].Value.ToString(), dataGridView8[18, i].Value.ToString(), dataGridView8[19, i].Value.ToString(), dataGridView8[20, i].Value.ToString());
                //    DataSet1.Ledger.Rows.Add(searchLookUpEdit6.EditValue, LedgerCustomerName.Text, LedgerCAddress.Text, LedgerCity.Text, LD_FromDate.Value.Date, LD_ToDate.Value.DATE, dataGridView8[0, i].Value, dataGridView8[7, i].Value, dataGridView8[10, i].Value, dataGridView8[12, i].Value, dataGridView8[16, i].Value, dataGridView8[18, i].Value, dataGridView8[19, i].Value, dataGridView8[20, i].Value, dataGridView8[21, i].Value);
                //}



                //if (!string.IsNullOrEmpty(dataGridView8.Rows[dataGridView8.RowCount - 1].Cells[10].Value.ToString()) && !string.IsNullOrEmpty(LD_Balance.Text))
                //{
                //    if (dataGridView8.Rows[dataGridView8.RowCount - 1].Cells[10].Value.ToString() != LD_Balance.Text)
                //    {
                //        panel10.BackColor = Color.Red;
                //        panel10.Visible = true;
                //    }
                //    else
                //    {
                //        panel10.Visible = false;
                //    }
                //}


                //LGR_TotalSale.Text = dataGridView8.Rows[dataGridView8.RowCount - 1].Cells[21].Value.ToString();


                dataGridView8.FirstDisplayedScrollingRowIndex = dataGridView8.RowCount - 1;


                //     sumforledger();



                //   txtPerDay.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)*7) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit6.EditValue + ") And Posted = 1")[0];

                //   txtPerWeekLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit6.EditValue + ") And Posted = 1")[0];

                //   txtPerMonthLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)/4) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit6.EditValue + ") And Posted = 1")[0];

                dataGridView8.ClearSelection();


                decimal getvalue11 = 0;
                Int32 index11 = dataGridView8.Rows.Count - 1;
                getvalue11 = Convert.ToDecimal(dataGridView8[9, index].Value);
                textBox55.Text = getvalue11.ToString();

       

                DateTime GETDATES = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                for (int i = dataGridView8.Rows.Count-1; i > 0; i--)
                {

                    if(dataGridView8[6, i].Value != null)
                    {
                        if ((Convert.ToDecimal(dataGridView8[6, i].Value) > 0))
                        {
                            getvalue11 = getvalue11 - Convert.ToDecimal(dataGridView8[6, i].Value);

                           

                            TimeSpan result = GETDATES.Subtract(Convert.ToDateTime(dataGridView8[1, i].Value));

                            dataGridView8[11, i].Value = result.Days.ToString();
                        }
                    }

                  


                

                }



            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
           // txtCollectionAmount.Text = textBox14.Text;
        }

        private void textBox52_TextChanged_1(object sender, EventArgs e)
        {
            getInvoicingCalculation();
        }

        private void INV_btnSearch_Click(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            searchLookUpEdit12.Visible = true;
            Inv_ClearAll();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 4)
            //{
            //    DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //    if (res == DialogResult.OK)
            //    {


            //        dataGridView3.Rows.RemoveAt(e.RowIndex);
            //        ColTotal();
            //    }
            //}
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            try
            { 
               

                if (!string.IsNullOrEmpty(InvDispatchNo.Text))
                {
                    string[] sp = new string[] { "DispatchConsolidate " + InvDispatchNo.EditValue, "CreditRecovery " + InvDispatchNo.Text + ",'" + InvDate.Value.ToString("yyyy-MM-dd") + "'", "DispatchExpense " + InvDispatchNo.EditValue, "DispatchDSR " + InvDispatchNo.EditValue };
                    ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DSR.rdlc", "", "", "");
                    Viewer.ShowDialog();
                }
                else if (!string.IsNullOrEmpty(searchLookUpEdit12.Text))
                {
                    string[] sp = new string[] { "DispatchConsolidate " + searchLookUpEdit12.EditValue, "CreditRecovery " + searchLookUpEdit12.Text + ",'" + InvDate.Value.ToString("yyyy-MM-dd") + "'", "DispatchExpense " + searchLookUpEdit12.EditValue, "DispatchDSR " + searchLookUpEdit12.EditValue };
                    ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DSR.rdlc", "", "", "");
                    Viewer.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please Select the Dispatch Number to Print the Records");
                    return;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "Printing Error");
            }
        }

      //  private void simpleButton6_Click(object sender, EventArgs e)
        //{
        //    int j = 0;
        //  foreach (DataGridViewRow row in dataGridView4.Rows)
        //    {
       


        //        //if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString()))
        //        //{
        //        //    summTotalQty += Convert.ToDecimal(row.Cells[4].Value.ToString());
        //        //}

        //        foreach (DataGridViewRow row2 in dataGridView6.Rows)
        //        { 
        //            dataGridView6.Rows.Add(row.Cells[1].Value);





        //            row2.Cells[0].Value = j++;
        //        }


        //    }
      //  }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0 && dataGridView2.Focused)
                {
                    if (e.RowIndex == dataGridView2.CurrentCell.RowIndex && e.ColumnIndex == dataGridView2.CurrentCell.ColumnIndex)
                    {
                        e.CellStyle.SelectionForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = Color.Green;
                        return;
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "StockMovGrid_CellPainting"); return;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit17_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void IC_BtnSave_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                var getTheSelecteddata1 = from s in db.Edison_DispatchHDRs
                                          where s.DispatchNo.Equals(searchLookUpEdit3.EditValue)
                                          select s;

                if (getTheSelecteddata1.Any())
                {
                    foreach (var AddItems in getTheSelecteddata1)
                    {
                        AddItems.Status = 1;
                        db.SubmitChanges();
                        break;
                    }
                }

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    var getTheSelecteddata = from s in db.Edison_DispatchDTLs
                                             where s.Dispatch_DTL_ID.Equals(row.Cells[1].Value.ToString())
                                             select s;

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var AddItems in getTheSelecteddata)
                        {
                            AddItems.StockIssued = Convert.ToInt32(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                            AddItems.StockReturn = Convert.ToInt32(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                            AddItems.REP = Convert.ToInt32(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                            AddItems.TotalDelivered = Convert.ToInt32(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                            AddItems.RQtySold = Convert.ToInt32(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                            AddItems.RRSSale = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                            AddItems.RValue = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                            AddItems.WQtySold = Convert.ToInt32(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                            AddItems.WSaleRate = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                            AddItems.WValue = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());

                            db.SubmitChanges();
                        }
                    }
                    else
                    {

                        Edison_DispatchDTL AddItems = new Edison_DispatchDTL();


                        AddItems.DispatchNo = Convert.ToInt32(searchLookUpEdit3.EditValue);

                        AddItems.ProductID = Convert.ToInt32(row.Cells[2].Value.ToString() == "" ? "0" : row.Cells[2].Value.ToString());

                        AddItems.StockIssued = Convert.ToInt32(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                        AddItems.StockReturn = Convert.ToInt32(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                        AddItems.REP = Convert.ToInt32(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                        AddItems.TotalDelivered = Convert.ToInt32(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                        AddItems.RQtySold = Convert.ToInt32(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                        AddItems.RRSSale = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                        AddItems.RValue = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                        AddItems.WQtySold = Convert.ToInt32(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                        AddItems.WSaleRate = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                        AddItems.WValue = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());



                        db.Edison_DispatchDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();
                    }

                }


                IC_RevertState();
                IC_DisableAll();
                scope.Complete();



            }

            dataGridView2.Rows.Clear();
            var getdetaildata = from Edison_Products in db.Edison_Products
                                join Edison_DispatchDTL in db.Edison_DispatchDTLs on new { ProductID = Edison_Products.ProductID } equals new { ProductID = Convert.ToInt32(Edison_DispatchDTL.ProductID) }
                                where
                                  Edison_DispatchDTL.DispatchNo == Convert.ToInt32(searchLookUpEdit3.EditValue)
                                select new
                                {
                                    Edison_DispatchDTL.Dispatch_DTL_ID,
                                    ProductID = (int?)Edison_DispatchDTL.ProductID,
                                    Edison_Products.ProductCode,
                                    Edison_Products.ProductDescription,
                                    Edison_DispatchDTL.StockIssued,
                                    Edison_DispatchDTL.StockReturn,
                                    Edison_DispatchDTL.TotalDelivered,
                                    Edison_DispatchDTL.REP,
                                    Edison_DispatchDTL.DispatchNo,
                                    //  Edison_Products.RSSalePrice,
                                    //    WholeSaleRate = ((System.Decimal?)Edison_Products.WSSalePrice ?? (System.Decimal?)0)
                                    Edison_DispatchDTL.RQtySold,
                                    Edison_DispatchDTL.RRSSale,
                                    Edison_DispatchDTL.RValue,
                                    Edison_DispatchDTL.WQtySold,
                                    Edison_DispatchDTL.WSaleRate,
                                    Edison_DispatchDTL.WValue,

                                };
            if (getdetaildata.Any())
            {
                foreach (var ab in getdetaildata)
                {

                    dataGridView2.Rows.Add("", ab.Dispatch_DTL_ID, ab.ProductID, ab.ProductCode, ab.ProductDescription, ab.StockIssued, ab.StockReturn, ab.REP, ab.TotalDelivered, ab.DispatchNo, ab.RQtySold, ab.RRSSale, ab.RValue, ab.WQtySold, ab.WSaleRate, ab.WValue);


                }
            }


            DLReturn_SumAll();

        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            



            if (!string.IsNullOrEmpty(InvDispatchNo.Text))
            {

                using (DispatchInvoicing frm = new DispatchInvoicing(InvDispatchNo.Text, "0", this, "0"))
                {
                    frm.ShowDialog();
                }

            }
            else if (!string.IsNullOrEmpty(searchLookUpEdit12.Text))
            {
                using (DispatchInvoicing frm = new DispatchInvoicing(searchLookUpEdit12.Text, "0", this, "0"))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("ERROR, PLEASE SELECT ANY DISPATCH NUMBER");
            }
        }

        public void RefreshForm()
        {
         try
            {
                if (!string.IsNullOrEmpty(InvDispatchNo.Text.Trim()))
                {
                    this.creditRecoveryTableAdapter.Fill(this.dataSet1.CreditRecovery, Convert.ToInt32(InvDispatchNo.EditValue), InvDate.Value.Date);
                }
                else
                {
                    this.creditRecoveryTableAdapter.Fill(this.dataSet1.CreditRecovery, Convert.ToInt32(searchLookUpEdit12.EditValue), InvDate.Value.Date);
                }

                getSumofRemaining();
                makesalesdetail();
                getInvoicingCalculation();
            }
            catch(Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        public void RefreshFormExpense()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var getExpense = from Edison_DispatchExpDTL in
  (from Edison_DispatchExpDTL in db.Edison_DispatchExpDTLs
   where
     Edison_DispatchExpDTL.DispatchNo == Convert.ToInt32(InvDispatchNo.EditValue)
   select new
   {
       Edison_DispatchExpDTL.Amount,
       Dummy = "x"
   })
                             group Edison_DispatchExpDTL by new { Edison_DispatchExpDTL.Dummy } into g
                             select new
                             {
                                 Column1 = (decimal?)g.Sum(p => p.Amount)
                             };

            if (getExpense.Any())
            {
                foreach (var a in getExpense)
                {
                    txtExpenses.Text = a.Column1.ToString();
                    break;
                }
            }
            else
            {
                txtExpenses.Text = "";
            }

            db.Dispose();
            getSumofRemaining();
            makesalesdetail();
            getInvoicingCalculation();
        }




        private void dataGridView6_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           


            if (!string.IsNullOrEmpty(InvDispatchNo.Text))
            {

                using (DispatchInvoicing frm = new DispatchInvoicing(InvDispatchNo.Text, "0", this, dataGridView6.SelectedCells[1].Value.ToString()))
                {
                    frm.ShowDialog();
                }

            }
            else if (!string.IsNullOrEmpty(searchLookUpEdit12.Text))
            {
                using (DispatchInvoicing frm = new DispatchInvoicing(searchLookUpEdit12.Text, "0", this, dataGridView6.SelectedCells[1].Value.ToString()))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("ERROR, PLEASE SELECT ANY DISPATCH NUMBER");
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(InvDispatchNo.Text))
            {

                using (DispatchPayments frm = new DispatchPayments(InvDispatchNo.Text, "0", this, "0"))
                {
                    frm.ShowDialog();
                }

            }
            else if (!string.IsNullOrEmpty(searchLookUpEdit12.Text))
            {
                using (DispatchPayments frm = new DispatchPayments(searchLookUpEdit12.Text, "0", this, "0"))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("ERROR, PLEASE SELECT ANY DISPATCH NUMBER");
            }



        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            using (DispatchInvoicing frm = new DispatchInvoicing(InvDispatchNo.Text, "0", this, dataGridView6.SelectedCells[1].Value.ToString()))
            {
                frm.ShowDialog();
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInvoiceExpense_Click(object sender, EventArgs e)
        {

    


            if (!string.IsNullOrEmpty(InvDispatchNo.Text))
            {

                using (DispatchExpense frm = new DispatchExpense(InvDispatchNo.Text, "0", this, "0"))
                {
                    frm.ShowDialog();
                }

            }
            else if (!string.IsNullOrEmpty(searchLookUpEdit12.Text))
            {
                using (DispatchExpense frm = new DispatchExpense(searchLookUpEdit12.Text, "0", this, "0"))
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("ERROR, PLEASE SELECT ANY DISPATCH NUMBER");
            }
        }

        private void searchLookUpEdit12_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit12_EditValueChanged_1(object sender, EventArgs e)
        {
            try
            {

                string cashreceivedf = "";

                if (!string.IsNullOrEmpty(searchLookUpEdit12.Text))
                {
                    InvVanNo.Text = "";
                    InvDate.Value = DateTime.Now;
                    InvSalesAgent.Text = "";
                    txtInvoicingAmount.Text = "";
                    txtCollectionAmount.Text = "";
                    txtReplacementAmount.Text = "";
                    //textBox55.Text = "";
                    textBox51.Text = "";
                    textBox12.Text = "";
                    txtExpenses.Text = "";
                    txtNetAmount.Text = "";
                    txtCashReceived.Text = "";
                    txtRemaining.Text = "";
                    txtTotalSale.Text = "";
                    textBox11.Text = "";
                    textBox19.Text = "";
                    textBox14.Text = "";
                    textBox28.Text = "";
                    txtExpenses.Text = "";
                    textBox38.Text = "";
                    txtCashReceived.Text = "";
                    txtRemaining.Text = "";
                    textBox22.Text = "";
                    textBox23.Text = "";
                    txtInvoicingAmount.Text = "";


                   
                    DataClasses1DataContext db = new DataClasses1DataContext();


                    var getHDR = from d in db.Edison_DispatchHDRs
                                 where d.DispatchNo.Equals(searchLookUpEdit12.EditValue)
                                 select new
                                 {
                                     d.VanID,
                                     d.EmpCode,
                                     d.DispatchDate,
                                     d.ReadingIn,
                                     d.ReadingOut,
                                     d.CashReceived,
                                     
                                 };

                    if (getHDR.Any())
                    {
                        foreach (var a in getHDR)
                        {
                            InvVanNo.EditValue = a.VanID;
                            InvSalesAgent.EditValue = a.EmpCode;
                            InvDate.Value = Convert.ToDateTime(a.DispatchDate);
                            textBox22.Text = a.ReadingOut;
                            textBox23.Text = a.ReadingIn;
                            cashreceivedf = a.CashReceived.ToString();
                            GetCustomersandItems();
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wait! Something is wrong");
                        return;
                    }



                    this.creditRecoveryTableAdapter.Fill(this.dataSet1.CreditRecovery, Convert.ToInt32(searchLookUpEdit12.EditValue), InvDate.Value.Date);

                    var getExpense = from Edison_DispatchExpDTL in
    (from Edison_DispatchExpDTL in db.Edison_DispatchExpDTLs
     where
       Edison_DispatchExpDTL.DispatchNo == Convert.ToInt32(searchLookUpEdit12.EditValue)
     select new
     {
         Edison_DispatchExpDTL.Amount,
         Dummy = "x"
     })
                                     group Edison_DispatchExpDTL by new { Edison_DispatchExpDTL.Dummy } into g
                                     select new
                                     {
                                         Column1 = (decimal?)g.Sum(p => p.Amount)
                                     };

                    if (getExpense.Any())
                    {
                        foreach (var a in getExpense)
                        {
                            txtExpenses.Text = a.Column1.ToString();
                            break;
                        }
                    }
                    else
                    {
                        txtExpenses.Text = "";
                    }




                    //  dataGridView7.Rows.Clear();

                    //var getStockDetails = from d in db.Edison_DispatchDTLs
                    //                      join v in db.Edison_Products on d.ProductID equals v.ProductID into bookingmGroup
                    //                      from v in bookingmGroup.DefaultIfEmpty()
                    //                      where d.DispatchNo.Equals(InvDispatchNo.EditValue)
                    //                      select new
                    //                      {
                    //                          d.ProductID,
                    //                          v.ProductCode,
                    //                          d.StockIssued,
                    //                          d.StockReturn,
                    //                          d.TotalDelivered,
                    //                      };

                    //if (getStockDetails.Any())
                    //{
                    //    foreach (var a in getStockDetails)
                    //    {
                    //        dataGridView7.Rows.Add(a.ProductID, a.ProductCode, a.StockIssued, a.StockReturn, a.TotalDelivered, "0", a.TotalDelivered);

                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Wait! Something is wrong");
                    //    return;
                    //}




                    //decimal ReplacementAmount = 0;
                    //decimal ReplacementQty = 0;

                    //var getReplacementAmount = from d in db.Edison_SalesReturnHDRs

                    //                           join u in db.Edison_SalesReturnDTLs on d.SalesReturnID equals u.SalesReturnID into bookingmGroup1
                    //                           from u in bookingmGroup1.DefaultIfEmpty()


                    //                           join v in db.Edison_Products on u.PID equals v.ProductID into bookingmGroup
                    //                           from v in bookingmGroup.DefaultIfEmpty()

                    //                           where d.DispatchNo.Equals(InvDispatchNo.EditValue) && d.CustID.Equals(364)
                    //                           select new
                    //                           {
                    //                               d.CustID,
                    //                               v.ProductID,
                    //                               v.ProductCode,
                    //                               u.ReturnQty,
                    //                               u.Rate,
                    //                               u.Amount,
                    //                           };

                    //if (getReplacementAmount.Any())
                    //{
                    //    foreach (var a in getReplacementAmount)
                    //    {
                    //        if (a.ReturnQty > 0)
                    //        {
                    //            ReplacementAmount = ReplacementAmount + (Convert.ToInt32(a.ReturnQty) * Convert.ToDecimal(a.Rate));
                    //            ReplacementQty = ReplacementQty + Convert.ToInt32(a.ReturnQty);
                    //        }


                    //    }
                    //}


                    decimal ReplacementAmount = 0;
                    decimal ReplacementQty = 0;

                    var getReplacementAmount = from d in db.Edison_DispatchDTLs
                                               join v in db.Edison_Products on d.ProductID equals v.ProductID into bookingmGroup
                                               from v in bookingmGroup.DefaultIfEmpty()
                                               where d.DispatchNo.Equals(searchLookUpEdit12.EditValue)
                                               select new
                                               {
                                                   d.ProductID,
                                                   v.ProductCode,
                                                   d.StockIssued,
                                                   d.StockReturn,
                                                   d.TotalDelivered,
                                                   v.RSSalePrice,
                                                   d.REP,
                                                   d.RQtySold,
                                                   d.RRSSale,
                                                   d.RValue,
                                                   d.WQtySold,
                                                   d.WSaleRate,
                                                   d.WValue,

                                               };

                    if (getReplacementAmount.Any())
                    {
                        txtReplacementAmount.Text = "0";
                        foreach (var a in getReplacementAmount)
                        {
                            if (a.RQtySold < 0)
                            {
                                txtReplacementAmount.Text = (Convert.ToDecimal(txtReplacementAmount.Text) + Convert.ToInt32(a.RQtySold) * Convert.ToInt32(a.RRSSale)).ToString();
                            }

                            if (a.WQtySold < 0)
                            {
                                txtReplacementAmount.Text = (Convert.ToDecimal(txtReplacementAmount.Text) + Convert.ToInt32(a.WQtySold) * Convert.ToInt32(a.WSaleRate)).ToString();
                            }

                        }
                    }

                    //    txtReplacementAmount.Text = ReplacementAmount.ToString();
                    //    textBox55.Text = ReplacementQty.ToString();


                }

            
                getSumofRemaining();

                makesalesdetail();

                txtCashReceived.Text = cashreceivedf;
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void searchLookUpEdit17_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox50.Focus();
            }
        }

        private void textBox50_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton5.Focus();
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(searchLookUpEdit3.Text))
            {
                string[] sp = new string[] { "DispatchReturn " + searchLookUpEdit3.EditValue };
                ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DispatchReturn.rdlc", "", "", "");
                Viewer.ShowDialog();
            }
            else if (!string.IsNullOrEmpty(searchLookUpEdit8.Text))
            {
                string[] sp = new string[] { "DispatchReturn " + searchLookUpEdit8.EditValue };
                ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DispatchReturn.rdlc", "", "", "");
                Viewer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please Select the Dispatch Number to Print the Records");
                return;
            }
           
        }

        private void searchLookUpEdit6_EditValueChanged(object sender, EventArgs e)
        {
            getLedger();
        }
    }

}