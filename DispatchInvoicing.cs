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
    public partial class DispatchInvoicing : Form
    {
        public DispatchInvoicing()
        {
            InitializeComponent();
        }

        string DNO = "";
        string EmpCodee = "";

        EdisonSales form1;

        string checkcustid = "";
        public DispatchInvoicing(string DispatchNo, String EmpCode, EdisonSales form1, string custid)
        {
            InitializeComponent();
            DNO = DispatchNo;
            EmpCodee = EmpCode;
            this.form1 = form1;
            checkcustid = custid;
        }



//        form_closing
//{
//    form1.RefreshForm();
//}



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
            InvCustomerList.Enabled = true;
            InvItemList.Enabled = true;
            InvQty.Enabled = true;
            searchLookUpEdit1.Enabled = true;
            txtAmount.Enabled = true;
            textBox4.Enabled = true;
            textBox3.Enabled = true;

        }

        private void Inv_DisableAll()
        {
            InvCustomerList.Enabled = false;
            InvItemList.Enabled = false;
            InvQty.Enabled = false;
            searchLookUpEdit1.Enabled = false;
            txtAmount.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
        }

        private void Inv_ClearAll()
        {
            //InvDate.Value = DateTime.Now;

            InvCustomerList.Text = "";
            InvCustomerList.EditValue = 0;


            txtInvoicingAmount.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";

      

            dataGridView4.Rows.Clear();

     


            InvCustomerList.Text = "";
            InvItemList.Text = "";

            InvQty.Text = "";
            searchLookUpEdit1.Text = "";
            txtAmount.Text = "";

   

            txtInvoicingAmount.Text = "";



        }



        private void DispatchInvoicing_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DispatchInvoingItemsWithStock' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dataSet1.All_SearchCustomers' table. You can move, or remove it, as needed.
            this.all_SearchCustomersTableAdapter.Fill(this.dataSet1.All_SearchCustomers);
            try
            {
                // TODO: This line of code loads data into the 'dataSet1.ItemsInvoicesRate' table. You can move, or remove it, as needed.
                this.itemsInvoicesRateTableAdapter.Fill(this.dataSet1.ItemsInvoicesRate);
                // TODO: This line of code loads data into the 'dataSet1.ItemsInvoice' table. You can move, or remove it, as needed.



                this.edison_EmployeeInfoTableAdapter.Fill(this.dataSet1.Edison_EmployeeInfo);
                this.all_CityTableAdapter.Fill(this.dataSet1.All_City);
                this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);

                textBox2.Text = DNO;

                getAll();


                this.customerlistVanWiseTableAdapter.Fill(this.dataSet1.CustomerlistVanWise, Convert.ToInt32(InvVanNo.EditValue));
                this.itemsInvoiceTableAdapter.Fill(this.dataSet1.ItemsInvoice, Convert.ToInt32(textBox2.Text));



                if(Convert.ToInt32(checkcustid) > 0)
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();


                    var getHDR = from d in db.Edison_InvoiceHDRs
                                 where d.DispatchNo.Equals(textBox2.Text) && d.CustID.Equals(checkcustid)
                                 select d;

                    if (getHDR.Any())
                    {
                        foreach (var a in getHDR)
                        {
                            textBox9.Text = a.InvoiceID.ToString();
                            InvCustomerList.EditValue = Convert.ToInt32(a.CustID);
                            txtInvoicingAmount.Text = a.TotalAmount.ToString();
                            textBox3.Text = a.DiscountAmount.ToString();
                            textBox4.Text = a.DiscountPercentage.ToString();
                            textBox8.Text = a.PrevBalance.ToString();

                            break;
                        }
                    }


                    var getTheSelecteddata = from s in db.Edison_InvoiceDTLs
                                             join v in db.Edison_Products on s.PID equals v.ProductID into bookingmGroup
                                             from v in bookingmGroup.DefaultIfEmpty()
                                             where s.InvoiceID.Equals(textBox9.Text)
                                             select new
                                             {
                                                 s.PID,
                                                 v.ProductCode,
                                                 s.Qty,
                                                 s.Rate,
                                                 s.TotalAmount,


                                             };

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var ab in getTheSelecteddata)
                        {
                            dataGridView4.Rows.Add("", ab.PID, ab.ProductCode, ab.Qty, ab.Rate, ab.TotalAmount);
                        
                        }
                    }

                    //searchLookUpEdit2.Visible = true;
                }
                invoicinggridSumCalculator();
            }
            catch(Exception err)
            {
                MessageBox.Show("Error Please Check " + err);
            }
        }



     

        private void getAll()
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                DataClasses1DataContext db = new DataClasses1DataContext();


                var getHDR = from d in db.Edison_DispatchHDRs
                             where d.DispatchNo.Equals(textBox2.Text)
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

        private void INV_btnAdd_Click(object sender, EventArgs e)
        {
            //searchLookUpEdit2.Visible = false;
            Inv_ClearAll();
            INV_AddState();
            Inv_EnableAll();

            this.dispatchInvoingItemsWithStockTableAdapter.Fill(this.dataSet1.DispatchInvoingItemsWithStock, Convert.ToInt32(textBox2.Text));

            InvCustomerList.Focus();
            InvCustomerList.ShowPopup();

        }

        private void InvCustomerList_EditValueChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(InvCustomerList.Text))
            {


                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.All_Customers
                                         join v in db.All_Cities on s.City equals v.CityID into bookingmGroup
                                         from v in bookingmGroup.DefaultIfEmpty()
                                         where s.CustID.Equals(InvCustomerList.EditValue)
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


                var getBalance = from All_Customers in db.All_Customers
                                 where
                                   All_Customers.CustID == Convert.ToInt32(InvCustomerList.EditValue)
                                 select new
                                 {
                                     Balance = (All_Customers.OpeningBalance1 + ((System.Decimal?)
                                     (from Edison_InvoiceHDR in db.Edison_InvoiceHDRs
                                      where
      Edison_InvoiceHDR.CustID == All_Customers.CustID
                                      select new
                                      {
                                          Edison_InvoiceHDR.TotalAmount
                                      }).Sum(p => p.TotalAmount) ?? (System.Decimal?)0) - ((System.Decimal?)
                                     (from Edison_DispatchPayment in db.Edison_DispatchPayments
                                      where
      Edison_DispatchPayment.CustID == All_Customers.CustID
                                      select new
                                      {
                                          Column1 = (((System.Decimal?)Edison_DispatchPayment.Amount ?? (System.Decimal?)0) + ((System.Decimal?)Edison_DispatchPayment.WriteOff ?? (System.Decimal?)0))
                                      }).Sum(p => p.Column1) ?? (System.Decimal?)0) - ((System.Decimal?)
                                     (from Edison_SalesReturnHDR in db.Edison_SalesReturnHDRs
                                      where
      Edison_SalesReturnHDR.CustID == All_Customers.CustID
                                      select new
                                      {
                                          Edison_SalesReturnHDR.TotalAmount
                                      }).Sum(p => p.TotalAmount) ?? (System.Decimal?)0))
                                 };
                if(getBalance.Any())
                {
                    foreach(var ab in getBalance)
                    {
                        textBox8.Text = ab.Balance.ToString();
                        break;
                    }
                }


            }
        }

        private void InvCustomerList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InvItemList.Focus();
                InvItemList.ShowPopup();
            }
        }

        private void InvQty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit1.Focus();
               // searchLookUpEdit1.ShowPopup();
            }
        }

        private void InvItemList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InvQty.Focus();
            }
        }

        private void searchLookUpEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
            }
        }

        private void btnInvoiceListAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoiceListAdd_MouseClick(object sender, MouseEventArgs e)
        {
            InvoiceAddList();
        }

        private void btnInvoiceListAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InvoiceAddList();
            }
        }

        private void InvoiceAddList()
        {
            try
            {
                if(string.IsNullOrEmpty(InvItemList.Text)  || string.IsNullOrEmpty(InvQty.Text))
                {
                    MessageBox.Show("Error! Please select an item & enter the quantity");
                    return;
                }
                else
                {
                    //  DataClasses1DataContext db = new DataClasses1DataContext();

                   

                    //this.dispatchInvoingItemsWithStockTableAdapter.Fill(this.dataSet1.DispatchInvoingItemsWithStock, Convert.ToInt32(textBox2.Text));


                     if(InvQty.Text == "0")
                    {
                        MessageBox.Show("Stock of this Item is already 0! Please Check");
                    }
                     else
                    {
                        if(Convert.ToInt32(txtStocks.Text) >=  Convert.ToInt32(InvQty.Text))
                        {


                            string getPID = "";
                            string getCity = "";
                            string getAddress = "";




                            dataGridView4.Rows.Add(null, InvItemList.EditValue, InvItemList.Text, InvQty.Text, searchLookUpEdit1.Text, txtAmount.Text);
                            invoicinggridSumCalculator();




                            //  }




                            //   }

                            object marketId = this.InvItemList.Properties.View.GetFocusedRowCellValue("QTY");
                            object rateid = this.InvItemList.Properties.View.GetFocusedRowCellValue("Rate");
                            object ProductID = this.InvItemList.Properties.View.GetFocusedRowCellValue("ProductID");

                            string gridProduct = ProductID.ToString();
                            string gridrate = rateid.ToString();

                            for (int j = 0; j < this.dataSet1.DispatchInvoingItemsWithStock.Rows.Count; j++)
                            {
                                string DatatableProduct = this.dataSet1.DispatchInvoingItemsWithStock.Rows[j]["ProductID"].ToString();
                                string datatablerate = this.dataSet1.DispatchInvoingItemsWithStock.Rows[j]["Rate"].ToString();
                                if (DatatableProduct == gridProduct)
                                {
                                    if (datatablerate == gridrate)
                                    {
                                        this.dataSet1.DispatchInvoingItemsWithStock.Rows[j]["QTY"] = Convert.ToDecimal(marketId) - Convert.ToDecimal(InvQty.Text);
                                        break;
                                    }
                                }

                            }


                            txtStocks.Text = "";
                            InvItemList.Text = "";
                            InvQty.Text = "";
                            searchLookUpEdit1.Text = "";
                            txtAmount.Text = "";






                            InvItemList.Focus();
                            InvItemList.ShowPopup();
                        }
                        else
                        {
                            MessageBox.Show("You cannot add more then the stock");
                        }

                    }

                    //db.Dispose();
                }
                

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }

        }

        private void invoicinggridSumCalculator()
        {
            int j = 1;

            Decimal summTotalQty = 0;
            Decimal TotalQtyinNos = 0;


            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                row.Cells[0].Value = j++;


                if (!string.IsNullOrEmpty(row.Cells[3].Value.ToString()))
                {
                    summTotalQty += Convert.ToDecimal(row.Cells[3].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                {
                    TotalQtyinNos += Convert.ToDecimal(row.Cells[5].Value.ToString());
                }

            }

            textBox11.Text = summTotalQty.ToString();
            txtInvoicingAmount.Text = TotalQtyinNos.ToString();

            textBox12.Text = dataGridView4.Rows.Count.ToString();


        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Calculated();
        }

        private void InvQty_TextChanged(object sender, EventArgs e)
        {
            Calculated();
        }

        private void Calculated()
        {
            try
            {
                txtAmount.Text = (Convert.ToDecimal(InvQty.Text == "" ? "0" : InvQty.Text) * Convert.ToDecimal(searchLookUpEdit1.Text == "" ? "0" : searchLookUpEdit1.Text)).ToString("#,##0.00");
            }
            catch (Exception err)
            {

            }
        }

        private void txtInvoicingAmount_TextChanged(object sender, EventArgs e)
        {
            invoicefunction();
        }

        private void invoicefunction()
        {

            try
            {
                textBox5.Text = (Convert.ToDecimal(txtInvoicingAmount.Text == "" ? "0" : txtInvoicingAmount.Text) - Convert.ToDecimal(textBox3.Text == "" ? "0" : textBox3.Text)).ToString("#,##0.00");

                textBox7.Text = (Convert.ToDecimal(textBox5.Text == "" ? "0" : textBox5.Text) + Convert.ToDecimal(textBox8.Text == "" ? "0" : textBox8.Text)).ToString("#,##0.00");

            }
            catch (Exception err)
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            invoicefunction();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            invoicefunction();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = (Convert.ToDecimal(txtInvoicingAmount.Text == "" ? "0" : txtInvoicingAmount.Text) / 100 * Convert.ToDecimal(textBox4.Text == "" ? "0" : textBox4.Text)).ToString("#,##0.00");
            }
            catch (Exception err)
            {

            }
        }

        private void INV_btnSave_Click(object sender, EventArgs e)
        {
            Invoice_SaveAll();
        }

        private void Invoice_SaveAll()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();


                var validation = from s in db.Edison_InvoiceHDRs
                                         where s.DispatchNo.Equals(textBox2.Text) && s.CustID.Equals(InvCustomerList.EditValue)
                                         select s;

                if (validation.Any())
                {
                    MessageBox.Show("You cannot Make Another Bill Of the Same Customer, Please Check!!");
                    return;
                }


                        using (var scope = new System.Transactions.TransactionScope())
                {

                    Edison_InvoiceHDR objCourse = new Edison_InvoiceHDR();

                    objCourse.Date = InvDate.Value.Date;

                    objCourse.DispatchNo = Convert.ToInt32(textBox2.Text);

                    objCourse.CustID = Convert.ToInt32(InvCustomerList.EditValue);


                    objCourse.TotalAmount = Convert.ToDecimal(txtInvoicingAmount.Text == "" ? "0" : txtInvoicingAmount.Text);

                    objCourse.DiscountAmount = Convert.ToDecimal(textBox3.Text == "" ? "0" : textBox3.Text);
                    objCourse.DiscountPercentage = Convert.ToDecimal(textBox4.Text == "" ? "0" : textBox4.Text);
                    objCourse.NetAmount = Convert.ToDecimal(textBox5.Text == "" ? "0" : textBox5.Text);
                    objCourse.PrevBalance = Convert.ToDecimal(textBox8.Text == "" ? "0" : textBox8.Text);
                    objCourse.GrandTotal = Convert.ToDecimal(textBox7.Text == "" ? "0" : textBox7.Text);

                    db.Edison_InvoiceHDRs.InsertOnSubmit(objCourse);
                    db.SubmitChanges();

                    textBox9.Text = objCourse.InvoiceID.ToString();

                    //dataGridView4.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                    //this.dataGridView4.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;

                
                    int i = 1;

                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {


                        Edison_InvoiceDTL AddItems = new Edison_InvoiceDTL();

                        AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                        AddItems.Qty = Convert.ToInt32(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());
                        AddItems.Rate = Convert.ToDecimal(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                        AddItems.TotalAmount = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                        AddItems.DispatchNo = Convert.ToInt32(textBox2.Text);


                        var getTheSelecteddata = from s in db.Edison_Products
                                                 where s.ProductID.Equals(AddItems.PID)
                                                 select s;

                        if (getTheSelecteddata.Any())
                        {
                            foreach (var ab in getTheSelecteddata)
                            {
                                AddItems.OriginalRetailSaleRate = ab.RSSalePrice;
                                AddItems.OriginalWholeSaleRate = ab.WSSalePrice;
                                AddItems.OriginalPurchRate = ab.PurchasePrice;

                                break;
                            }
                        }
                        else
                        {
                            AddItems.OriginalRetailSaleRate = 0;
                            AddItems.OriginalWholeSaleRate = 0;
                            AddItems.OriginalPurchRate = 0;
                        }

                        AddItems.InvoiceID = Convert.ToInt32(textBox9.Text);
                        db.Edison_InvoiceDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();

                    }

                    scope.Complete();
                    INV_RevertState();
                    Inv_DisableAll();

                }

                form1.RefreshForm();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error on Save " + err);
            }

        }

        private void InvItemList_EditValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(InvItemList.Text))
            {

                object Stocks = this.InvItemList.Properties.View.GetFocusedRowCellValue("QTY");
                txtStocks.Text = Stocks.ToString();


                object Price = this.InvItemList.Properties.View.GetFocusedRowCellValue("Rate");
                searchLookUpEdit1.Text = Price.ToString();

            }


        }

        private void INV_btnRevert_Click(object sender, EventArgs e)
        {
            //searchLookUpEdit2.Visible = false;
            Inv_DisableAll();
            Inv_ClearAll();
            INV_RevertState();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {


         
                    string gridProduct = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string gridrate = dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string gridqty = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();

                    bool checkifdone = false;

                    for (int j = 0; j < this.dataSet1.DispatchInvoingItemsWithStock.Rows.Count; j++)
                    {
                        string DatatableProduct = this.dataSet1.DispatchInvoingItemsWithStock.Rows[j]["ProductID"].ToString();
                        string datatablerate = this.dataSet1.DispatchInvoingItemsWithStock.Rows[j]["Rate"].ToString();

                        if (DatatableProduct == gridProduct)
                        {
                            if (datatablerate == gridrate)
                            {
                                this.dataSet1.DispatchInvoingItemsWithStock.Rows[j]["QTY"] = Convert.ToDecimal(this.dataSet1.DispatchInvoingItemsWithStock.Rows[j]["QTY"]) + Convert.ToDecimal(gridqty);
                                checkifdone = true;
                                break;
                            }
                        }

                    }

                    if(checkifdone == false)
                    {
                        this.dataSet1.DispatchInvoingItemsWithStock.Rows.Add(dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString(), dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString());
                    }


                    dataGridView4.Rows.RemoveAt(e.RowIndex);
                    invoicinggridSumCalculator();
                }
            }
        }

        private void INV_btnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void INV_btnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            Invoice_EditSaveAll();

        }

        private void INV_btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Invoice_EditSaveAll();
            }
        }

        private void Invoice_EditSaveAll()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                using (var scope = new System.Transactions.TransactionScope())
                {
                    var GetInvoice = from s in db.Edison_InvoiceHDRs
                                             where s.InvoiceID.Equals(textBox9.Text)
                                             select s;

                    if (GetInvoice.Any())
                    {
                        foreach (var objCourse in GetInvoice)
                        {

                            objCourse.Date = InvDate.Value.Date;

                            objCourse.DispatchNo = Convert.ToInt32(textBox2.Text);

                            objCourse.CustID = Convert.ToInt32(InvCustomerList.EditValue);


                            objCourse.TotalAmount = Convert.ToDecimal(txtInvoicingAmount.Text == "" ? "0" : txtInvoicingAmount.Text);

                            objCourse.DiscountAmount = Convert.ToDecimal(textBox3.Text == "" ? "0" : textBox3.Text);
                            objCourse.DiscountPercentage = Convert.ToDecimal(textBox4.Text == "" ? "0" : textBox4.Text);
                            objCourse.NetAmount = Convert.ToDecimal(textBox5.Text == "" ? "0" : textBox5.Text);
                            objCourse.PrevBalance = Convert.ToDecimal(textBox8.Text == "" ? "0" : textBox8.Text);
                            objCourse.GrandTotal = Convert.ToDecimal(textBox7.Text == "" ? "0" : textBox7.Text);

                            db.SubmitChanges();

                            textBox9.Text = objCourse.InvoiceID.ToString();
                        }
                    }
            

                    //dataGridView4.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                    //this.dataGridView4.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;

                    var a = from s in db.Edison_InvoiceDTLs
                            where s.InvoiceID.Equals(textBox9.Text)
                            select s;

                    if (a.Any())
                    {
                        foreach (var d in a)
                        {
                            db.Edison_InvoiceDTLs.DeleteOnSubmit(d);
                            db.SubmitChanges();
                        }
                    }



                    int i = 1;
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {


                        Edison_InvoiceDTL AddItems = new Edison_InvoiceDTL();

                        AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                        AddItems.Qty = Convert.ToInt32(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());
                        AddItems.Rate = Convert.ToDecimal(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                        AddItems.TotalAmount = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                        AddItems.DispatchNo = Convert.ToInt32(textBox2.Text);


                        var getTheSelecteddata = from s in db.Edison_Products
                                                 where s.ProductID.Equals(AddItems.PID)
                                                 select s;

                        if (getTheSelecteddata.Any())
                        {
                            foreach (var ab in getTheSelecteddata)
                            {
                                AddItems.OriginalRetailSaleRate = ab.RSSalePrice;
                                AddItems.OriginalWholeSaleRate = ab.WSSalePrice;
                                AddItems.OriginalPurchRate = ab.PurchasePrice;

                                break;
                            }
                        }
                        else
                        {
                            AddItems.OriginalRetailSaleRate = 0;
                            AddItems.OriginalWholeSaleRate = 0;
                            AddItems.OriginalPurchRate = 0;
                        }

                        AddItems.InvoiceID = Convert.ToInt32(textBox9.Text);
                        db.Edison_InvoiceDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();

                    }

                    INV_RevertState();
                    Inv_DisableAll();
                    scope.Complete();
                  
                }
                form1.RefreshForm();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error on Save " + err);
            }

        }

        private void ExitTheProduction()
        {
            try
            {
        
                    form1.RefreshForm();
                    this.Close();

               
            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message + "ExitTheProduction");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ExitTheProduction();
        }

        private void INV_btnEdit_Click(object sender, EventArgs e)
        {
            INV_EditSaveState();
            Inv_EnableAll();
            InvCustomerList.Enabled = false;


        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(searchLookUpEdit2.Text))
            //{
            //    DataClasses1DataContext db = new DataClasses1DataContext();

            //    var getTheSelecteddata = from s in db.All_Customers
            //                             join v in db.All_Cities on s.City equals v.CityID into bookingmGroup
            //                             from v in bookingmGroup.DefaultIfEmpty()
            //                             where s.CustID.Equals(searchLookUpEdit2.EditValue)
            //                             select new
            //                             {
            //                                 s.CustID,
            //                                 s.CustomerName,
            //                                 s.CustomerAddress,
            //                                 v.CityName,
            //                                 s.VanID,


            //                             };

            //    if (getTheSelecteddata.Any())
            //    {
            //        foreach (var ab in getTheSelecteddata)
            //        {
            //            textBox1.Text = ab.CustomerAddress;
            //            textBox6.Text = ab.CityName;
            //            //   searchLookUpEdit10.EditValue = ab.VanID;

            //            break;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Enter the Correct Dispatch Number");
            //        return;
            //    }
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox2.Text))
            {
                this.dispatchInvoingItemsWithStockTableAdapter.Fill(this.dataSet1.DispatchInvoingItemsWithStock, Convert.ToInt32(textBox2.Text));
            }
        }

        private void searchLookUpEdit1_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
            }
        }

        private void txtAmount_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnInvoiceListAdd.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.itemsInvoicesRateTableAdapter.Fill(this.dataSet1.ItemsInvoicesRate);

            dataGridView4.Rows.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                dataGridView4.Rows.Add(null, row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), (Convert.ToDecimal(row.Cells[2].Value)*Convert.ToDecimal(row.Cells[3].Value)).ToString());
                invoicinggridSumCalculator();

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
