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
    public partial class EdisonImport : Form
    {
        public EdisonImport()
        {
            InitializeComponent();
        }

        private void refreshAll()
        {
            this.searchImportOrderCostingTableAdapter.Fill(this.dataSet1.SearchImportOrderCosting);
            this.edison_ClearingAgentTableAdapter.Fill(this.dataSet1.Edison_ClearingAgent);
            this.importOrderCostingTableAdapter.Fill(this.dataSet1.ImportOrderCosting);
            this.edison_ProductsTableAdapter.Fill(this.dataSet1.Edison_Products);
            this.supplierListsImportTableAdapter.Fill(this.dataSet1.SupplierListsImport);
            this.importCostingTableAdapter.Fill(this.dataSet1.ImportCosting);
            this.searchImportCostingTableAdapter.Fill(this.dataSet1.SearchImportCosting);
            this.bankAccountsTableTableAdapter.Fill(this.dataSet1.BankAccountsTable);
        }
        private void EdisonImport_Load(object sender, EventArgs e)
        {
      
         

            refreshAll();

        }

        private void OS_AddState()
        {
            OS_BtnAdd.Visible = false;
            OS_BtnSave.Visible = true;
            OS_BtnRevert.Visible = true;
            OS_BtnEdit.Visible = false;
            OS_BtnEditSave.Visible = false;
            OS_BtnSearch.Visible = false;
            dataGridView2.Columns[11].Visible = true;
        }


        private void OS_RevertState()
        {
            OS_BtnAdd.Visible = true;
            OS_BtnSave.Visible = false;
            OS_BtnRevert.Visible = false;
            OS_BtnEdit.Visible = true;
            OS_BtnEditSave.Visible = false;
            OS_BtnSearch.Visible = true;
            dataGridView2.Columns[9].Visible = false;

        }



        private void OS_EditSaveState()
        {
            OS_BtnAdd.Visible = false;
            OS_BtnSave.Visible = false;
            OS_BtnRevert.Visible = true;
            OS_BtnEdit.Visible = false;
            OS_BtnEditSave.Visible = true;
            OS_BtnSearch.Visible = false;
            dataGridView2.Columns[9].Visible = true;

        }

        private void OS_EnableAll()
        {
            dateTimePicker3.Enabled = true;
            searchLookUpEdit4.Enabled = true;
            textBox35.Enabled = true;
            textBox36.Enabled = true;
            dateTimePicker2.Enabled = true;
            searchLookUpEdit6.Enabled = true;
            OS_txtQtyInCartons.Enabled = true;
            OS_txtTotalQty.Enabled = true;
            OS_txtRateInDollar.Enabled = true;
            OS_txtValueinDollar.Enabled = true;
            OS_txtDollarRate.Enabled = true;
            OS_txtValueInRs.Enabled = true;
            OS_txtValuePerPcs.Enabled = true;


        }

        private void OS_DisableAll()
        {
            dateTimePicker3.Enabled = false;
            searchLookUpEdit4.Enabled = false;
            textBox35.Enabled = false;
            textBox36.Enabled = false;
            dateTimePicker2.Enabled = false;
            searchLookUpEdit6.Enabled = false;
            OS_txtQtyInCartons.Enabled = false;
            OS_txtTotalQty.Enabled = false;
            OS_txtRateInDollar.Enabled = false;
            OS_txtValueinDollar.Enabled = false;
            OS_txtDollarRate.Enabled = false;
            OS_txtValueInRs.Enabled = false;
            OS_txtValuePerPcs.Enabled = false;




        }

        private void OS_ClearAll()
        {
            textBox37.Text = "";

            dateTimePicker3.Value = DateTime.Now;
            searchLookUpEdit4.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            searchLookUpEdit6.Text = "";
            OS_txtQtyInCartons.Text = "";
            OS_txtTotalQty.Text = "";
            OS_txtRateInDollar.Text = "";
            OS_txtValueinDollar.Text = "";
            OS_txtDollarRate.Text = "";
            OS_txtValueInRs.Text = "";
            OS_txtValuePerPcs.Text = "";

            textBox52.Text = "";
            textBox53.Text = "";
            textBox51.Text = "";
            textBox50.Text = "";
            textBox49.Text = "";
            dataGridView2.Rows.Clear();
        }

        private void OS_ItemsClearAll()
        {
            OS_txtQtyInCartons.Text = "";
            OS_txtTotalQty.Text = "";
            OS_txtRateInDollar.Text = "";
            OS_txtValueinDollar.Text = "";
            OS_txtDollarRate.Text = "";
            OS_txtValueInRs.Text = "";
            OS_txtValuePerPcs.Text = "";
        }
        private void OS_BtnAdd_Click(object sender, EventArgs e)
        {
            OS_ClearAll();
            OS_EnableAll();
            OS_AddState();

            dateTimePicker3.Focus();
        }

        private void dateTimePicker3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit4.Focus();
                searchLookUpEdit4.ShowPopup();
            }
        }

        private void searchLookUpEdit4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox35.Focus();

            }
        }

        private void textBox35_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox36.Focus();
            }
        }

        private void textBox36_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker2.Focus();
            }
        }

        private void dateTimePicker2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit6.Focus();
                searchLookUpEdit6.ShowPopup();
            }
        }

        private void searchLookUpEdit6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_txtQtyInCartons.Focus();

            }
        }

        private void textBox62_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_txtTotalQty.Focus();
            }
        }

        private void textBox64_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_txtRateInDollar.Focus();
            }
        }

        private void textBox65_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_txtValueinDollar.Focus();
            }
        }

        private void textBox58_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_txtDollarRate.Focus();
            }
        }

        private void textBox67_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_txtValueInRs.Focus();
            }
        }

        private void textBox66_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (!String.IsNullOrEmpty(searchLookUpEdit6.Text))
                {
                    dataGridView2.Rows.Add(null, searchLookUpEdit6.EditValue, searchLookUpEdit6.Text, null, OS_txtQtyInCartons.Text, OS_txtTotalQty.Text, OS_txtRateInDollar.Text, OS_txtValueinDollar.Text, OS_txtDollarRate.Text, OS_txtValuePerPcs.Text, OS_txtValueInRs.Text);

                    OS_ItemsClearAll();
                    OS_SumAll();
                    searchLookUpEdit6.Focus();
                    searchLookUpEdit6.ShowPopup();



                }


            }
        }

        private void OS_SumAll()
        {
            int j = 1;

            Decimal summTotalQty = 0;
            Decimal TotalQtyinNos = 0;
            Decimal TotalValueInDollar = 0;
            Decimal TotalValueInPKRS = 0;
            Decimal TotalValuePerPcsInPKRS = 0;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[0].Value = j++;


                if (!string.IsNullOrEmpty(row.Cells[4].Value.ToString()))
                {
                    summTotalQty += Convert.ToDecimal(row.Cells[4].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                {
                    TotalQtyinNos += Convert.ToDecimal(row.Cells[5].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[7].Value.ToString()))
                {
                    TotalValueInDollar += Convert.ToDecimal(row.Cells[7].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[9].Value.ToString()))
                {
                    TotalValueInPKRS += Convert.ToDecimal(row.Cells[9].Value.ToString());
                }


                if (!string.IsNullOrEmpty(row.Cells[10].Value.ToString()))
                {
                    TotalValuePerPcsInPKRS += Convert.ToDecimal(row.Cells[10].Value.ToString());
                }


            }

            textBox52.Text = summTotalQty.ToString();
            textBox53.Text = TotalQtyinNos.ToString();
            textBox51.Text = TotalValueInDollar.ToString();
            textBox50.Text = TotalValuePerPcsInPKRS.ToString();
            textBox49.Text = TotalValueInPKRS.ToString();

        }
        private void OS_UpdateRates()
        {
            try
            {
                OS_txtValueinDollar.Text = (Convert.ToDecimal(OS_txtTotalQty.Text == "" ? "0" : OS_txtTotalQty.Text) * Convert.ToDecimal(OS_txtRateInDollar.Text == "" ? "0" : OS_txtRateInDollar.Text)).ToString("#,##0.00");

                OS_txtValueInRs.Text = (Convert.ToDecimal(OS_txtValueinDollar.Text == "" ? "0" : OS_txtValueinDollar.Text) * Convert.ToDecimal(OS_txtDollarRate.Text == "" ? "0" : OS_txtDollarRate.Text)).ToString("#,##0.00");


                OS_txtValuePerPcs.Text = (Convert.ToDecimal(OS_txtRateInDollar.Text == "" ? "0" : OS_txtRateInDollar.Text) * Convert.ToDecimal(OS_txtDollarRate.Text == "" ? "0" : OS_txtDollarRate.Text)).ToString("#,##0.00");
            }
            catch (Exception err)
            {

            }
        }


        private void textBox63_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_txtValueInRs.Focus();
            }

        }

        private void OS_txtTotalQty_TextChanged(object sender, EventArgs e)
        {
            OS_UpdateRates();
        }

        private void OS_txtRateInDollar_TextChanged(object sender, EventArgs e)
        {
            OS_UpdateRates();
        }

        private void OS_txtDollarRate_TextChanged(object sender, EventArgs e)
        {
            OS_UpdateRates();
        }

        private void searchLookUpEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void OS_SaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                Edison_ImportOrderHDR objCourse = new Edison_ImportOrderHDR();

                objCourse.OrderDate = dateTimePicker3.Value.Date;

                objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit4.EditValue);
                objCourse.ContainerNo = textBox35.Text;
                objCourse.LCNo = textBox36.Text;

                objCourse.ArrivalDate = dateTimePicker2.Value;

                //objCourse.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);

                objCourse.TotalAmount = Convert.ToDecimal(textBox51.Text);

                objCourse.Status = 0;
                //   objCourse.InsertedDatetime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                db.Edison_ImportOrderHDRs.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                textBox37.Text = objCourse.EdisonImportOrderID.ToString();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    Edison_ImportOrderDTL AddItems = new Edison_ImportOrderDTL();


                    AddItems.EdisonImportOrderID = objCourse.EdisonImportOrderID;

                    AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.QtyInCartons = Convert.ToInt32(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    AddItems.TotalQty = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems.RatesInDollar = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                    AddItems.ValueInDollar = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.DollarRate = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());

                    AddItems.ValuePerPcs = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                    AddItems.TotalValueinRs = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());



                    db.Edison_ImportOrderDTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }


                dataGridView2.Columns[11].Visible = false;
                scope.Complete();

                OS_RevertState();
                OS_DisableAll();

            }
            refreshAll();
        }

        private void OS_BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                OS_SaveAll();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }

        }

        private void OS_BtnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_SaveAll();
            }
        }

        private void OS_BtnRevert_Click(object sender, EventArgs e)
        {
            OS_ClearAll();
            OS_DisableAll();
            OS_RevertState();

        }

        private void OS_BtnEdit_Click(object sender, EventArgs e)
        {
            OS_EnableAll();
            OS_EditSaveState();
            dateTimePicker3.Focus();
        }

        private void OS_BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void OS_BtnSearch_Click(object sender, EventArgs e)
        {
            textBox37.Enabled = true;
            textBox37.Focus();
        }


        private void OS_EditSaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {

                var getTheSelecteddata = from s in db.Edison_ImportOrderHDRs
                                         where s.EdisonImportOrderID.Equals(textBox37.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {

                        objCourse.OrderDate = dateTimePicker3.Value.Date;

                        objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit4.EditValue);
                        objCourse.ContainerNo = textBox35.Text;
                        objCourse.LCNo = textBox36.Text;

                        objCourse.ArrivalDate = dateTimePicker2.Value;

                        //objCourse.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);

                        objCourse.TotalAmount = Convert.ToDecimal(textBox51.Text);

                        //   objCourse.InsertedDatetime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();


                        db.SubmitChanges();
                    }
                }




                var a = from s in db.Edison_ImportOrderDTLs
                        where s.EdisonImportOrderID.Equals(textBox37.Text.Trim())
                        select s;

                if (a.Any())
                {
                    foreach (var d in a)
                    {
                        db.Edison_ImportOrderDTLs.DeleteOnSubmit(d);
                        db.SubmitChanges();
                    }
                }



                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    Edison_ImportOrderDTL AddItems = new Edison_ImportOrderDTL();


                    AddItems.EdisonImportOrderID = Convert.ToInt32(textBox37.Text);

                    AddItems.PID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.QtyInCartons = Convert.ToDecimal(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    AddItems.TotalQty = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    AddItems.RatesInDollar = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                    AddItems.ValueInDollar = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.DollarRate = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());

                    AddItems.ValuePerPcs = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                    AddItems.TotalValueinRs = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());



                    db.Edison_ImportOrderDTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }


                dataGridView2.Columns[11].Visible = false;
                scope.Complete();

                OS_RevertState();
                OS_DisableAll();

            }
            refreshAll();
        }
        private void textBox37_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox37.Text))
            {
                dateTimePicker3.Value = DateTime.Now;
                searchLookUpEdit4.Text = "";
                textBox35.Text = "";
                textBox36.Text = "";
                dateTimePicker2.Value = DateTime.Now;
                searchLookUpEdit6.Text = "";
                OS_txtQtyInCartons.Text = "";
                OS_txtTotalQty.Text = "";
                OS_txtRateInDollar.Text = "";
                OS_txtValueinDollar.Text = "";
                OS_txtDollarRate.Text = "";
                OS_txtValueInRs.Text = "";
                OS_txtValuePerPcs.Text = "";

                textBox52.Text = "";
                textBox53.Text = "";
                textBox51.Text = "";
                textBox50.Text = "";
                textBox49.Text = "";
                dataGridView2.Rows.Clear();


                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.Edison_ImportOrderHDRs
                                         where s.EdisonImportOrderID.Equals(textBox37.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var ab in getTheSelecteddata)
                    {
                        dateTimePicker3.Value = Convert.ToDateTime(ab.OrderDate);
                        searchLookUpEdit4.EditValue = ab.SupplierID;


                        textBox35.Text = ab.ContainerNo.ToString();
                        textBox36.Text = ab.LCNo.ToString();

                        dateTimePicker2.Value = Convert.ToDateTime(ab.ArrivalDate);

                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Correct Invoice Number");
                    return;
                }


                var getTheSelecteddata1 = from s in db.Edison_ImportOrderDTLs
                                          join v in db.Edison_Products on s.PID equals v.ProductID into bookingmGroup
                                          from v in bookingmGroup.DefaultIfEmpty()
                                          where s.EdisonImportOrderID.Equals(textBox37.Text)
                                          select new
                                          {
                                              s.PID,
                                              s.QtyInCartons,
                                              s.TotalQty,
                                              s.RatesInDollar,
                                              s.ValueInDollar,
                                              s.DollarRate,
                                              s.ValuePerPcs,
                                              s.TotalValueinRs,
                                              v.ProductCode,
                                              v.ProductDescription
                                          };

                if (getTheSelecteddata1.Any())
                {
                    foreach (var ab in getTheSelecteddata1)
                    {
                        dataGridView2.Rows.Add(null, ab.PID, ab.ProductCode, ab.ProductDescription, ab.QtyInCartons, ab.TotalQty, ab.RatesInDollar, ab.ValueInDollar, ab.DollarRate, ab.ValuePerPcs, ab.TotalValueinRs);

                    }
                }

                OS_SumAll();




            }
        }

        private void OS_BtnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            OS_EditSaveAll();
        }

        private void OS_BtnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OS_EditSaveAll();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 11)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {


                    dataGridView2.Rows.RemoveAt(e.RowIndex);
                    OS_SumAll();
                }
            }
        }

        decimal getBalanceExpense = 0;
        private void searchLookUpEdit5_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit5.Text))
            {
                getBalanceExpense = 0; 

                dataGridView1.Rows.Clear();

                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_ImportOrderHDRs
                                        where d.EdisonImportOrderID.Equals(searchLookUpEdit5.EditValue)
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                        searchLookUpEdit2.EditValue = a.SupplierID;
                        dateTimePicker4.Value = Convert.ToDateTime(a.OrderDate);
                        textBox33.Text = a.ContainerNo;
                        textBox34.Text = a.LCNo;
                        dateTimePicker1.Value = Convert.ToDateTime(a.ArrivalDate);
                        break;
                    }
                }



                var getmazeeddetails = from d in db.Edison_ImportOrderDTLs
                                       join v in db.Edison_Products on d.PID equals v.ProductID into bookingmGroup
                                       from v in bookingmGroup.DefaultIfEmpty()

                                       join u in db.Edison_ImportCDDTLs on d.EdisonImportDTLID equals u.DTLID into ud
                                       from u in ud.DefaultIfEmpty()

                                       where d.EdisonImportOrderID.Equals(searchLookUpEdit5.EditValue)
                                       select new
                                       {
                                           d.SNo,
                                           d.PID,
                                           v.ProductCode,
                                           v.ProductDescription,
                                           d.QtyInCartons,
                                           d.TotalQty,
                                           d.RatesInDollar,
                                           d.ValueInDollar,
                                           d.DollarRate,
                                           d.ValuePerPcs,
                                           d.TotalValueinRs,
                                           u.ExpPerPCS,
                                       };

                if (getmazeeddetails.Any())
                {
                    foreach (var a in getmazeeddetails)
                    {
                        dataGridView1.Rows.Add(a.SNo, a.PID, a.ProductCode, a.ProductDescription, a.QtyInCartons, a.TotalQty, a.RatesInDollar, a.ValueInDollar, a.DollarRate, a.TotalValueinRs, a.ValuePerPcs, a.ExpPerPCS, Convert.ToDecimal(a.ValuePerPcs) + Convert.ToDecimal(a.ExpPerPCS), null, null, (Convert.ToDecimal(a.ValuePerPcs) + Convert.ToDecimal(a.ExpPerPCS))*Convert.ToDecimal(a.TotalQty));
                  
                    }
                }



                var getDuties = from d in db.Edison_ImportCDDTLs
                                where d.EdisonImportOrderID.Equals(searchLookUpEdit5.EditValue)
                                group d by d.EdisonImportOrderID into g
                                select new
                                {
                                    SumDutiesTaxes = g.Sum(x => x.TotalTaxes),
                                    SumCarriage = g.Sum(x => x.Carriage),
                                    SumOthers = g.Sum(x => x.Other),
                                };

                if (getDuties.Any())
                {
                    foreach (var a in getDuties)
                    {
              
                        textBox26.Text = a.SumDutiesTaxes.ToString();
                        textBox28.Text = a.SumCarriage.ToString();
                        textBox1.Text = a.SumOthers.ToString();
                        break;
                    }
                }


              

                getBalanceExpense = Convert.ToDecimal(textBox1.Text == "" ? "0" : textBox1.Text);

                int j = 1;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = j++;
                }

                getInvoiceSum();
                sumTotalExpensesInInvoice();
                dataGridView1.ClearSelection();              
            }
        }

        private void searchLookUpEdit9_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit9.Text))
            {
                dataGridView3.Rows.Clear();

                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_ImportOrderHDRs
                                        where d.EdisonImportOrderID.Equals(searchLookUpEdit9.EditValue)
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                        searchLookUpEdit7.EditValue = a.SupplierID;
                        dateTimePicker5.Value = Convert.ToDateTime(a.OrderDate);
                        textBox39.Text = a.ContainerNo;
                        textBox40.Text = a.LCNo;
                        dateTimePicker6.Value = Convert.ToDateTime(a.ArrivalDate);
                        break;
                    }
                }


                var getmazeeddetails = from d in db.Edison_ImportOrderDTLs
                                       join v in db.Edison_Products on d.PID equals v.ProductID into bookingmGroup
                                       from v in bookingmGroup.DefaultIfEmpty()
                                       where d.EdisonImportOrderID.Equals(searchLookUpEdit9.EditValue)
                                       select new
                                       {
                                           d.EdisonImportDTLID,
                                           d.SNo,
                                           d.PID,
                                           v.ProductCode,
                                           v.ProductDescription,
                                           d.QtyInCartons,
                                           d.TotalQty,

                                       };

                if (getmazeeddetails.Any())
                {
                    foreach (var a in getmazeeddetails)
                    {
                        dataGridView3.Rows.Add(a.EdisonImportDTLID, a.SNo, a.PID, a.ProductCode, a.ProductDescription, a.TotalQty);
                    }
                }
                dataGridView3.ClearSelection();



                int j = 1;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    row.Cells[1].Value = j++;
                }
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        int selectedrowindex = -1;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];

            textBox61.Text = (selectedRow.Cells[0].Value).ToString();


            if (dataGridView3.Rows[selectedrowindex].Cells[2].Value == null)
            {
                searchLookUpEdit8.Text = "";
            }
            else
            {
                searchLookUpEdit8.EditValue = selectedRow.Cells[2].Value.ToString();
            }



            if (dataGridView3.Rows[selectedrowindex].Cells[5].Value == null)
            {
                textBox44.Text = "";
            }
            else
            {
                textBox44.Text = selectedRow.Cells[5].Value.ToString();
            }




        }

        private void CD_EnabeAll()
        {
            searchLookUpEdit9.Enabled = true;
            textBox62.Enabled = true;
            textBox45.Enabled = true;
            textBox63.Enabled = true;
            textBox41.Enabled = true;
            textBox47.Enabled = true;
            textBox64.Enabled = true;
            textBox42.Enabled = true;
            textBox65.Enabled = true;
            textBox46.Enabled = true;
            textBox55.Enabled = true;
            textBox54.Enabled = true;
            textBox66.Enabled = true;
            textBox59.Enabled = true;
            textBox67.Enabled = true;
            textBox60.Enabled = true;
        }

        private void CD_DisableAll()
        {
            searchLookUpEdit9.Enabled = false;
            textBox62.Enabled = false;
            textBox45.Enabled = false;
            textBox63.Enabled = false;
            textBox41.Enabled = false;
            textBox47.Enabled = false;
            textBox64.Enabled = false;
            textBox42.Enabled = false;
            textBox65.Enabled = false;
            textBox46.Enabled = false;
            textBox55.Enabled = false;
            textBox54.Enabled = false;
            textBox66.Enabled = false;
            textBox59.Enabled = false;
            textBox67.Enabled = false;
            textBox60.Enabled = false;
        }
        private void CD_AddState()
        {
            CD_BtnAdd.Visible = false;
            CD_BtnRevert.Visible = true;
            CD_BtnSave.Visible = true;
            CD_BtnEdit.Visible = false;
            CD_BtnEditSave.Visible = false;
            CD_BtnSearch.Visible = false;
        }

        private void CD_RevertState()
        {
            CD_BtnAdd.Visible = true;
            CD_BtnRevert.Visible = false;
            CD_BtnSave.Visible = false;
            CD_BtnEdit.Visible = true;
            CD_BtnEditSave.Visible = false;
            CD_BtnSearch.Visible = true;
        }

        private void CD_EditSaveState()
        {
            CD_BtnAdd.Visible = false;
            CD_BtnRevert.Visible = true;
            CD_BtnSave.Visible = false;
            CD_BtnEdit.Visible = false;
            CD_BtnEditSave.Visible = true;
            CD_BtnSearch.Visible = false;
        }

        private void CD_ClearAll()
        {
            searchLookUpEdit10.Visible = false;
            dataGridView3.Rows.Clear();

            searchLookUpEdit9.Text = "";
            dateTimePicker5.Value = DateTime.Now;
            searchLookUpEdit7.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            dateTimePicker6.Value = DateTime.Now;


            txt_CDTotalQty.Text = "";
            txt_CDCD.Text = "";
            txt_CDSalesTax.Text = "";
            txt_CDMISC.Text = "";
            txt_CDRD.Text = "";
            txt_CDIT.Text = "";
            txt_CDTotalTaxes.Text = "";
            txt_CDCarraige.Text = "";
            txt_CDCarPerPiece.Text = "";
            txt_CDOther.Text = "";
            txt_CDTotalExpense.Text = "";

            textBox57.Text = "";
            textBox58.Text = "";
            textBox60.Text = "";
            textBox67.Text = "";
            textBox59.Text = "";
            textBox66.Text = "";
            textBox48.Text = "";
            textBox54.Text = "";
            textBox56.Text = "";
            textBox55.Text = "";
            textBox43.Text = "";
            textBox38.Text = "";
            textBox46.Text = "";
            textBox65.Text = "";
            textBox42.Text = "";
            textBox64.Text = "";
            textBox47.Text = "";
            textBox41.Text = "";
            textBox63.Text = "";
            textBox45.Text = "";
            textBox62.Text = "";

            textBox44.Text = "";
            searchLookUpEdit8.Text = "";
            textBox61.Text = "";
            dataGridView3.ClearSelection();
        }

        private void CD_BtnAdd_Click(object sender, EventArgs e)
        {
            CD_EnabeAll();
            CD_ClearAll();
            CD_AddState();
            searchLookUpEdit9.Focus();
            searchLookUpEdit9.ShowPopup();

        }

        private void textBox62_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox45.Focus();
            }
        }

        private void textBox45_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox63.Focus();
            }
        }

        private void textBox63_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox41.Focus();
            }
        }

        private void textBox41_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox47.Focus();
            }
        }

        private void textBox47_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox64.Focus();
            }
        }

        private void textBox64_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox42.Focus();
            }
        }

        private void textBox42_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox65.Focus();
            }
        }

        private void textBox65_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox46.Focus();
            }
        }

        private void textBox46_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox55.Focus();
            }
        }

        private void textBox38_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox43.Focus();
            }
        }

        private void textBox43_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox55.Focus();
            }
        }

        private void textBox55_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox54.Focus();
            }
        }

        private void textBox56_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox54.Focus();
            }
        }

        private void textBox54_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox66.Focus();
            }
        }

        private void textBox48_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox66.Focus();
            }
        }

        private void textBox59_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox67.Focus();
            }
        }

        private void textBox60_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox58.Focus();
            }
        }

        private void textBox58_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox57.Focus();
            }
        }

        private void textBox57_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox45.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {



            dataGridView3.Rows[selectedrowindex].Cells[6].Value = (textBox62.Text);
            dataGridView3.Rows[selectedrowindex].Cells[7].Value = (textBox45.Text);
            dataGridView3.Rows[selectedrowindex].Cells[8].Value = (textBox63.Text);
            dataGridView3.Rows[selectedrowindex].Cells[9].Value = (textBox41.Text);
            dataGridView3.Rows[selectedrowindex].Cells[10].Value = (textBox47.Text);
            dataGridView3.Rows[selectedrowindex].Cells[11].Value = (textBox64.Text);
            dataGridView3.Rows[selectedrowindex].Cells[12].Value = (textBox42.Text);
            dataGridView3.Rows[selectedrowindex].Cells[13].Value = (textBox65.Text);
            dataGridView3.Rows[selectedrowindex].Cells[14].Value = (textBox46.Text);
            dataGridView3.Rows[selectedrowindex].Cells[15].Value = (textBox38.Text);
            dataGridView3.Rows[selectedrowindex].Cells[16].Value = (textBox43.Text);
            dataGridView3.Rows[selectedrowindex].Cells[17].Value = (textBox55.Text);
            dataGridView3.Rows[selectedrowindex].Cells[18].Value = (textBox56.Text);
            dataGridView3.Rows[selectedrowindex].Cells[19].Value = (textBox54.Text);
            dataGridView3.Rows[selectedrowindex].Cells[20].Value = (textBox48.Text);
            dataGridView3.Rows[selectedrowindex].Cells[21].Value = (textBox66.Text);
            dataGridView3.Rows[selectedrowindex].Cells[22].Value = (textBox59.Text);
            dataGridView3.Rows[selectedrowindex].Cells[23].Value = (textBox67.Text);
            dataGridView3.Rows[selectedrowindex].Cells[24].Value = (textBox60.Text);
            dataGridView3.Rows[selectedrowindex].Cells[25].Value = (textBox58.Text);
            dataGridView3.Rows[selectedrowindex].Cells[26].Value = (textBox57.Text);


            textBox57.Text = "";
            textBox58.Text = "";
            textBox60.Text = "";
            textBox67.Text = "";
            textBox59.Text = "";
            textBox66.Text = "";
            textBox48.Text = "";
            textBox54.Text = "";
            textBox56.Text = "";
            textBox55.Text = "";
            textBox43.Text = "";
            textBox38.Text = "";
            textBox46.Text = "";
            textBox65.Text = "";
            textBox42.Text = "";
            textBox64.Text = "";
            textBox47.Text = "";
            textBox41.Text = "";
            textBox63.Text = "";
            textBox45.Text = "";
            textBox62.Text = "";

            textBox44.Text = "";
            searchLookUpEdit8.Text = "";
            textBox61.Text = "";
            dataGridView3.ClearSelection();

            CD_SumAll();
        }

        private void textBox66_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox59.Focus();
            }
        }

        private void textBox67_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox60.Focus();
            }
        }

        private void sumTaxes()
        {
            textBox38.Text = (Convert.ToDecimal(textBox45.Text == "" ? "0" : textBox45.Text) + Convert.ToDecimal(textBox41.Text == "" ? "0" : textBox41.Text) + Convert.ToDecimal(textBox47.Text == "" ? "0" : textBox47.Text) + Convert.ToDecimal(textBox42.Text == "" ? "0" : textBox42.Text) + Convert.ToDecimal(textBox46.Text == "" ? "0" : textBox46.Text)).ToString("#,##0.00");


            if (!string.IsNullOrEmpty(textBox44.Text))
            {
                textBox43.Text = (Convert.ToDecimal(textBox38.Text == "" ? "0" : textBox38.Text) / Convert.ToDecimal(textBox44.Text == "" ? "0" : textBox44.Text)).ToString("#,##0.00");

                textBox56.Text = (Convert.ToDecimal(textBox55.Text == "" ? "0" : textBox55.Text) / Convert.ToDecimal(textBox44.Text == "" ? "0" : textBox44.Text)).ToString("#,##0.00");

                textBox48.Text = (Convert.ToDecimal(textBox54.Text == "" ? "0" : textBox54.Text) / Convert.ToDecimal(textBox44.Text == "" ? "0" : textBox44.Text)).ToString("#,##0.00");


                textBox58.Text = (Convert.ToDecimal(textBox38.Text == "" ? "0" : textBox38.Text) + Convert.ToDecimal(textBox55.Text == "" ? "0" : textBox55.Text) + Convert.ToDecimal(textBox54.Text == "" ? "0" : textBox54.Text) + Convert.ToDecimal(textBox59.Text == "" ? "0" : textBox59.Text) + Convert.ToDecimal(textBox60.Text == "" ? "0" : textBox60.Text)).ToString("#,##0.00");

                textBox57.Text = (Convert.ToDecimal(textBox58.Text == "" ? "0" : textBox58.Text) / Convert.ToDecimal(textBox44.Text == "" ? "0" : textBox44.Text)).ToString("#,##0.00");
            }



            





        }
        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox55_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox54_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox66_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            sumTaxes();
        }

        private void CD_SumAll()
        {
            try
            {


                int j = 1;

                Decimal summTotalQty = 0;
                Decimal TotalQtyinNos = 0;
                Decimal TotalValueInDollar = 0;
                Decimal TotalValueInPKRS = 0;
                Decimal TotalValuePerPcsInPKRS = 0;


                Decimal TTVALUE = 0;
                Decimal TTVALUE1 = 0;


                Decimal TT1 = 0;
                Decimal TT2 = 0;
                Decimal TT3 = 0;
                Decimal TT4 = 0;


                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    row.Cells[1].Value = j++;

                    if (row.Cells[5].Value == null)
                    {
                        row.Cells[5].Value = "";
                    }

                    if (row.Cells[7].Value == null)
                    {
                        row.Cells[7].Value = "";
                    }

                    if (row.Cells[9].Value == null)
                    {
                        row.Cells[9].Value = "";
                    }

                    if (row.Cells[10].Value == null)
                    {
                        row.Cells[10].Value = "";
                    }

                    if (row.Cells[12].Value == null)
                    {
                        row.Cells[12].Value = "";
                    }

                    if (row.Cells[17].Value == null)
                    {
                        row.Cells[17].Value = "";
                    }

                    if (row.Cells[14].Value == null)
                    {
                        row.Cells[14].Value = "";
                    }

                    if (row.Cells[15].Value == null)
                    {
                        row.Cells[15].Value = "";
                    }

                    if (row.Cells[18].Value == null)
                    {
                        row.Cells[18].Value = "";
                    }

                    if (row.Cells[19].Value == null)
                    {
                        row.Cells[19].Value = "";
                    }

                    if (row.Cells[25].Value == null)
                    {
                        row.Cells[25].Value = "";
                    }

                    summTotalQty += Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    TotalQtyinNos += Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    TotalValueInDollar += Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                    TotalValueInPKRS += Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());

                    TotalValuePerPcsInPKRS += Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());

                    TTVALUE += Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                    TTVALUE1 += Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());
                    TT1 += Convert.ToDecimal(row.Cells[17].Value.ToString() == "" ? "0" : row.Cells[17].Value.ToString());
                    TT2 += Convert.ToDecimal(row.Cells[18].Value.ToString() == "" ? "0" : row.Cells[18].Value.ToString());
                    TT3 += Convert.ToDecimal(row.Cells[19].Value.ToString() == "" ? "0" : row.Cells[19].Value.ToString());
                    TT4 += Convert.ToDecimal(row.Cells[25].Value.ToString() == "" ? "0" : row.Cells[25].Value.ToString());
                }

                txt_CDTotalQty.Text = summTotalQty.ToString();

                txt_CDCD.Text = TotalQtyinNos.ToString();

                txt_CDSalesTax.Text = TotalValueInDollar.ToString();

                txt_CDMISC.Text = TotalValueInPKRS.ToString();

                txt_CDRD.Text = TotalValuePerPcsInPKRS.ToString();

                txt_CDIT.Text = TTVALUE.ToString();

                txt_CDTotalTaxes.Text = TTVALUE1.ToString();

                txt_CDCarraige.Text = TT1.ToString();
                txt_CDCarPerPiece.Text = TT2.ToString();
                txt_CDOther.Text = TT3.ToString();
                txt_CDTotalExpense.Text = TT4.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }
        private void textBox50_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {

        }

        private void CD_SaveAll()
        {

            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {

                var getTheOrderDetail = from d in db.Edison_ImportOrderHDRs
                                        where d.EdisonImportOrderID.Equals(searchLookUpEdit9.EditValue)
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                        a.Status = 1;
                        db.SubmitChanges();
                        break;
                    }
                }


                Edison_ImportCDHDR objCourse = new Edison_ImportCDHDR();


                objCourse.OrderNo = Convert.ToInt32(searchLookUpEdit9.EditValue);



                objCourse.TotalExpense = Convert.ToDecimal(txt_CDTotalExpense.Text);



                db.Edison_ImportCDHDRs.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                //textBox1.Text = objCourse.Edison_SupplierPurchID.ToString();

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {

                    Edison_ImportCDDTL AddItems = new Edison_ImportCDDTL();


                    AddItems.CD_ID = objCourse.CD_ID;
                   
                    AddItems.EdisonImportOrderID = Convert.ToInt32(searchLookUpEdit9.EditValue);


                    AddItems.DTLID = Convert.ToInt32(row.Cells[0].Value.ToString() == "" ? "0" : row.Cells[0].Value.ToString());
                    AddItems.SNo = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.PID = Convert.ToInt32(row.Cells[2].Value.ToString() == "" ? "0" : row.Cells[2].Value.ToString());
                    AddItems.Qty = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());

                    AddItems.CDPercentage = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                    AddItems.CDValue = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.STPercentage = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                    AddItems.STValue = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                    AddItems.MISC = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                    AddItems.RDPercentage = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                    AddItems.RDValue = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                    AddItems.ITPercentage = Convert.ToDecimal(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                    AddItems.ITValue = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                    AddItems.TotalTaxes = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());
                    AddItems.TotalTaxesPerPiece = Convert.ToDecimal(row.Cells[16].Value.ToString() == "" ? "0" : row.Cells[16].Value.ToString());
                    AddItems.Carriage = Convert.ToDecimal(row.Cells[17].Value.ToString() == "" ? "0" : row.Cells[17].Value.ToString());
                    AddItems.CarraigePerPiece = Convert.ToDecimal(row.Cells[18].Value.ToString() == "" ? "0" : row.Cells[18].Value.ToString());
                    AddItems.Other = Convert.ToDecimal(row.Cells[19].Value.ToString() == "" ? "0" : row.Cells[19].Value.ToString());
                    AddItems.OtherPerPiece = Convert.ToDecimal(row.Cells[20].Value.ToString() == "" ? "0" : row.Cells[20].Value.ToString());
                    AddItems.REPPercentage = Convert.ToDecimal(row.Cells[21].Value.ToString() == "" ? "0" : row.Cells[21].Value.ToString());

                    AddItems.REPValue = Convert.ToDecimal(row.Cells[22].Value.ToString() == "" ? "0" : row.Cells[22].Value.ToString());
                    AddItems.USPercentage = Convert.ToDecimal(row.Cells[23].Value.ToString() == "" ? "0" : row.Cells[23].Value.ToString());
                    AddItems.USValue = Convert.ToDecimal(row.Cells[24].Value.ToString() == "" ? "0" : row.Cells[24].Value.ToString());
                    AddItems.TotalExpense = Convert.ToDecimal(row.Cells[25].Value.ToString() == "" ? "0" : row.Cells[25].Value.ToString());
                    AddItems.ExpPerPCS = Convert.ToDecimal(row.Cells[26].Value.ToString() == "" ? "0" : row.Cells[26].Value.ToString());

                    //AddItems.CD_ID = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());


                    db.Edison_ImportCDDTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();


                    //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                }



                scope.Complete();
                CD_RevertState();
                CD_DisableAll();
            }
            refreshAll();
        }
        private void CD_BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void CD_BtnRevert_Click(object sender, EventArgs e)
        {
            CD_ClearAll();
            CD_DisableAll();
            CD_RevertState();
        }

        private void CD_BtnEdit_Click(object sender, EventArgs e)
        {
            CD_EnabeAll();
            CD_EditSaveState();
            searchLookUpEdit9.Enabled = false;

        }

        private void CD_BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            CD_SaveAll();
        }

        private void CD_BtnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CD_SaveAll();
            }
        }

        private void searchLookUpEdit10_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit10.Text))
            {
                dataGridView3.Rows.Clear();

                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_ImportOrderHDRs
                                        where d.EdisonImportOrderID.Equals(searchLookUpEdit10.EditValue)
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                        searchLookUpEdit7.EditValue = a.SupplierID;
                        dateTimePicker5.Value = Convert.ToDateTime(a.OrderDate);
                        textBox39.Text = a.ContainerNo;
                        textBox40.Text = a.LCNo;
                        dateTimePicker6.Value = Convert.ToDateTime(a.ArrivalDate);
                        break;
                    }
                }


                var getmazeeddetails = from d in db.Edison_ImportCDDTLs
                                       join v in db.Edison_Products on d.PID equals v.ProductID into bookingmGroup
                                       from v in bookingmGroup.DefaultIfEmpty()
                                       where d.EdisonImportOrderID.Equals(searchLookUpEdit10.EditValue)
                                       select new
                                       {
                                           d.DTLID,
                                           d.SNo,
                                           d.PID,
                                           v.ProductCode,
                                           v.ProductDescription,
                                           d.Qty,
                                           d.CDPercentage,
                                           d.CDValue,
                                           d.STPercentage,
                                           d.STValue,
                                           d.MISC,
                                           d.RDPercentage,
                                           d.RDValue,
                                           d.ITPercentage,
                                           d.ITValue,
                                           d.TotalTaxes,
                                           d.TotalTaxesPerPiece,
                                           d.Carriage,
                                           d.CarraigePerPiece,
                                           d.Other,
                                           d.OtherPerPiece,
                                           d.REPPercentage,
                                           d.REPValue,
                                           d.USPercentage,
                                           d.USValue,
                                           d.TotalExpense,
                                           d.ExpPerPCS,
                                           d.CD_DTL_ID,
                                       };

                if (getmazeeddetails.Any())
                {
                    foreach (var a in getmazeeddetails)
                    {
                        dataGridView3.Rows.Add(a.DTLID, a.SNo, a.PID, a.ProductCode, a.ProductDescription, a.Qty, a.CDPercentage, a.CDValue, a.STPercentage, a.STValue, a.MISC, a.RDPercentage, a.RDValue, a.ITPercentage, a.ITValue, a.TotalTaxes, a.TotalTaxesPerPiece, a.Carriage, a.CarraigePerPiece, a.Other, a.OtherPerPiece, a.REPPercentage, a.REPValue, a.USPercentage, a.USValue, a.TotalExpense, a.ExpPerPCS, a.CD_DTL_ID);
                    }
                }
                dataGridView3.ClearSelection();

                CD_SumAll();

                int j = 1;

                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    row.Cells[1].Value = j++;
                }
            }
        }

        private void CD_BtnSearch_Click(object sender, EventArgs e)
        {
            searchLookUpEdit10.Visible = true;
            searchLookUpEdit10.Focus();
        }

        private void CD_BtnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void CD_BtnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            CD_EditSaveAll();
        }

        private void CD_BtnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                CD_EditSaveAll();


            }
        }


        private void CD_EditSaveAll()
        {

            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                int GETCDID = 0;

                var getTheSelecteddata = from s in db.Edison_ImportCDHDRs
                                         where s.OrderNo.Equals(searchLookUpEdit10.EditValue)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {


                        //    objCourse.OrderNo = Convert.ToInt32(searchLookUpEdit9.EditValue);
                        GETCDID = objCourse.CD_ID;
                        objCourse.TotalExpense = Convert.ToDecimal(txt_CDTotalExpense.Text);
                        db.SubmitChanges();
                    }
                }

                    var a = from s in db.Edison_ImportCDDTLs
                            where s.EdisonImportOrderID.Equals(searchLookUpEdit10.EditValue)
                            select s;

                    if (a.Any())
                    {
                        foreach (var d in a)
                        {
                            db.Edison_ImportCDDTLs.DeleteOnSubmit(d);
                            db.SubmitChanges();
                        }
                    }


                    //textBox1.Text = objCourse.Edison_SupplierPurchID.ToString();

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {

                        Edison_ImportCDDTL AddItems = new Edison_ImportCDDTL();

                         AddItems.CD_ID = GETCDID;
                        AddItems.EdisonImportOrderID = Convert.ToInt32(searchLookUpEdit10.EditValue);

                        AddItems.DTLID = Convert.ToInt32(row.Cells[0].Value.ToString() == "" ? "0" : row.Cells[0].Value.ToString());
                        AddItems.SNo = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                        AddItems.PID = Convert.ToInt32(row.Cells[2].Value.ToString() == "" ? "0" : row.Cells[2].Value.ToString());
                        AddItems.Qty = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());

                        AddItems.CDPercentage = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                        AddItems.CDValue = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                        AddItems.STPercentage = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                        AddItems.STValue = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                        AddItems.MISC = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                        AddItems.RDPercentage = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                        AddItems.RDValue = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                        AddItems.ITPercentage = Convert.ToDecimal(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                        AddItems.ITValue = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                        AddItems.TotalTaxes = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());
                        AddItems.TotalTaxesPerPiece = Convert.ToDecimal(row.Cells[16].Value.ToString() == "" ? "0" : row.Cells[16].Value.ToString());
                        AddItems.Carriage = Convert.ToDecimal(row.Cells[17].Value.ToString() == "" ? "0" : row.Cells[17].Value.ToString());
                        AddItems.CarraigePerPiece = Convert.ToDecimal(row.Cells[18].Value.ToString() == "" ? "0" : row.Cells[18].Value.ToString());
                        AddItems.Other = Convert.ToDecimal(row.Cells[19].Value.ToString() == "" ? "0" : row.Cells[19].Value.ToString());
                        AddItems.OtherPerPiece = Convert.ToDecimal(row.Cells[20].Value.ToString() == "" ? "0" : row.Cells[20].Value.ToString());
                        AddItems.REPPercentage = Convert.ToDecimal(row.Cells[21].Value.ToString() == "" ? "0" : row.Cells[21].Value.ToString());

                        AddItems.REPValue = Convert.ToDecimal(row.Cells[22].Value.ToString() == "" ? "0" : row.Cells[22].Value.ToString());
                        AddItems.USPercentage = Convert.ToDecimal(row.Cells[23].Value.ToString() == "" ? "0" : row.Cells[23].Value.ToString());
                        AddItems.USValue = Convert.ToDecimal(row.Cells[24].Value.ToString() == "" ? "0" : row.Cells[24].Value.ToString());
                        AddItems.TotalExpense = Convert.ToDecimal(row.Cells[25].Value.ToString() == "" ? "0" : row.Cells[25].Value.ToString());
                        AddItems.ExpPerPCS = Convert.ToDecimal(row.Cells[26].Value.ToString() == "" ? "0" : row.Cells[26].Value.ToString());

                        //AddItems.CD_ID = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());


                        db.Edison_ImportCDDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();


                        //   AddItems.SRCode = Convert.ToInt32(row.Cells[11].Value.ToString());


                    }



                    scope.Complete();
                    CD_RevertState();
                    CD_DisableAll();
                

            }
            refreshAll();
        }


        int selectedrowofInvoice = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrowofInvoice = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowofInvoice];

    


            if (dataGridView1.Rows[selectedrowofInvoice].Cells[1].Value == null)
            {
                searchLookUpEdit1.Text = "";
            }
            else
            {
                searchLookUpEdit1.EditValue = selectedRow.Cells[1].Value.ToString();
            }

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
         



        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
                try
            { 
                dataGridView1.Rows[selectedrowofInvoice].Cells[13].Value = (textBox12.Text);


                dataGridView1.Rows[selectedrowofInvoice].Cells[14].Value = Convert.ToDecimal(textBox12.Text) * Convert.ToDecimal(dataGridView1.Rows[selectedrowofInvoice].Cells[5].Value);


                dataGridView1.Rows[selectedrowofInvoice].Cells[16].Value = Convert.ToDecimal(dataGridView1.Rows[selectedrowofInvoice].Cells[14].Value) - Convert.ToDecimal(dataGridView1.Rows[selectedrowofInvoice].Cells[15].Value);


                dataGridView1.Rows[selectedrowofInvoice].Cells[17].Value = (((Convert.ToDecimal(dataGridView1.Rows[selectedrowofInvoice].Cells[15].Value) / Convert.ToDecimal(dataGridView1.Rows[selectedrowofInvoice].Cells[14].Value)) * 100) - 100) * -1;

                getInvoiceSum();
            }
            catch(Exception err)
            {

            }
        }



        private void getInvoiceSum()
        {
            try
            {


                int j = 1;

                Decimal summTotalQty = 0;
                Decimal TotalQtyinNos = 0;
                Decimal TotalValueInDollar = 0;
                Decimal TotalValueInPKRS = 0;
                Decimal TotalValuePerPcsInPKRS = 0;
                Decimal TTVALUE = 0;
                Decimal TTVALUE1 = 0;
                Decimal TT1 = 0;
                Decimal TT2 = 0;
                Decimal TT3 = 0;
                Decimal TT4 = 0;

                Decimal TT5 = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = j++;

                    if (row.Cells[4].Value == null)
                    {
                        row.Cells[4].Value = "";
                    }

                    if (row.Cells[5].Value == null)
                    {
                        row.Cells[5].Value = "";
                    }

                    if (row.Cells[7].Value == null)
                    {
                        row.Cells[7].Value = "";
                    }

                    if (row.Cells[9].Value == null)
                    {
                        row.Cells[9].Value = "";
                    }

                    if (row.Cells[10].Value == null)
                    {
                        row.Cells[10].Value = "";
                    }

                    if (row.Cells[11].Value == null)
                    {
                        row.Cells[11].Value = "";
                    }

                    if (row.Cells[12].Value == null)
                    {
                        row.Cells[12].Value = "";
                    }

                    if (row.Cells[14].Value == null)
                    {
                        row.Cells[14].Value = "";
                    }

                    if (row.Cells[15].Value == null)
                    {
                        row.Cells[15].Value = "";
                    }

                    if (row.Cells[16].Value == null)
                    {
                        row.Cells[16].Value = "";
                    }

                    if (row.Cells[17].Value == null)
                    {
                        row.Cells[17].Value = "";
                    }

                    summTotalQty += Convert.ToDecimal(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    TotalQtyinNos += Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());
                    TotalValueInDollar += Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    TotalValueInPKRS += Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());

                    TotalValuePerPcsInPKRS += Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());

                    TTVALUE += Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                    TTVALUE1 += Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                
                    TT2 += Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                    TT3 += Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());
                    TT4 += Convert.ToDecimal(row.Cells[16].Value.ToString() == "" ? "0" : row.Cells[16].Value.ToString());
                    TT1 += Convert.ToDecimal(row.Cells[17].Value.ToString() == "" ? "0" : row.Cells[17].Value.ToString());

                }

                textBox17.Text = summTotalQty.ToString();
                textBox18.Text = TotalQtyinNos.ToString();
                textBox16.Text = TotalValueInDollar.ToString();
                textBox15.Text = TotalValueInPKRS.ToString();
                textBox19.Text = TotalValuePerPcsInPKRS.ToString();
                textBox20.Text = TTVALUE.ToString();
                textBox21.Text = TTVALUE1.ToString();
                textBox25.Text = TT1.ToString();
                textBox24.Text = TT2.ToString();
                textBox23.Text = TT3.ToString();
                textBox22.Text = TT4.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void sumBalanceExpensesin()
        {
            textBox1.Text = (getBalanceExpense - (Convert.ToDecimal(textBox27.Text == "" ? "0" : textBox27.Text) + Convert.ToDecimal(textBox29.Text == "" ? "0" : textBox29.Text) + Convert.ToDecimal(textBox30.Text == "" ? "0" : textBox30.Text) + Convert.ToDecimal(textBox31.Text == "" ? "0" : textBox31.Text))).ToString("#,##0.00");
            sumTotalExpensesInInvoice();
        }
        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            sumBalanceExpensesin();
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            sumBalanceExpensesin();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            sumBalanceExpensesin();
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            sumBalanceExpensesin();
        }

        private void sumTotalExpensesInInvoice()
        {
            textBox2.Text = ((Convert.ToDecimal(textBox27.Text == "" ? "0" : textBox27.Text) + Convert.ToDecimal(textBox29.Text == "" ? "0" : textBox29.Text) + Convert.ToDecimal(textBox30.Text == "" ? "0" : textBox30.Text) + Convert.ToDecimal(textBox31.Text == "" ? "0" : textBox31.Text) + Convert.ToDecimal(textBox26.Text == "" ? "0" : textBox26.Text) + Convert.ToDecimal(textBox28.Text == "" ? "0" : textBox28.Text))).ToString("#,##0.00");
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text))
              {
                if (Convert.ToDecimal(textBox1.Text) < 0)
                {
                    MessageBox.Show("Error! Balance cannot be in Minus ! ");
                    return;
                }
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
            searchLookUpEdit11.Visible = false;
            searchLookUpEdit5.Text = "";

            dateTimePicker4.Value = DateTime.Now;

            searchLookUpEdit2.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";

            searchLookUpEdit3.Text = "";

            dateTimePicker1.Value = DateTime.Now;

            searchLookUpEdit1.Text = "";
            textBox12.Text = "";

            textBox17.Text = "";
            textBox18.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox24.Text = "";
            textBox23.Text = "";
            textBox25.Text = "";

            textBox26.Text = "";
            textBox28.Text = "";
            textBox27.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox2.Text = "";

            textBox1.Text = "";
        }

        private void IC_EnableAll()
        {
            searchLookUpEdit5.Enabled = true;
            dateTimePicker1.Enabled = true;
            searchLookUpEdit3.Enabled = true;
            textBox12.Enabled = true;
            textBox27.Enabled = true;
            textBox29.Enabled = true;
            textBox30.Enabled = true;
            textBox31.Enabled = true;
        }

        private void IC_DisableAll()
        {
            searchLookUpEdit5.Enabled = false;
            dateTimePicker1.Enabled = false;
            searchLookUpEdit3.Enabled = false;
            textBox12.Enabled = false;
            textBox27.Enabled = false;
            textBox29.Enabled = false;
            textBox30.Enabled = false;
            textBox31.Enabled = false;
        }
        private void IC_BtnAdd_Click(object sender, EventArgs e)
        {
            searchLookUpEdit11.Enabled = false;
            IC_ClearAll();
            IC_AddState();
            IC_EnableAll();
            searchLookUpEdit5.Focus();
            searchLookUpEdit5.ShowPopup();
        }

        private void searchLookUpEdit5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit3.Focus();
                searchLookUpEdit3.ShowPopup();
            }
        }


        private void IC_SaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                var getTheOrderDetail = from d in db.Edison_ImportOrderHDRs
                                        where d.EdisonImportOrderID.Equals(searchLookUpEdit5.EditValue)
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                        a.Status = 2;
                        db.SubmitChanges();
                        break;
                    }
                }

                Edison_ImportCostingHDR objCourse = new Edison_ImportCostingHDR();


                objCourse.OrderNo = Convert.ToInt32(searchLookUpEdit5.EditValue);
                objCourse.ArrivalDate = dateTimePicker1.Value;
                objCourse.ClearingAgentID = Convert.ToInt32(searchLookUpEdit3.EditValue);


                objCourse.TotalValueInDollar = Convert.ToDecimal(textBox16.Text);
                objCourse.TotalValueInPak = Convert.ToDecimal(textBox15.Text);
                objCourse.TaxesDuties= Convert.ToDecimal(textBox26.Text);
                objCourse.Carriage = Convert.ToDecimal(textBox28.Text);
                objCourse.ClearingExpense = Convert.ToDecimal(textBox27.Text);
                objCourse.LabourUnloading = Convert.ToDecimal(textBox29.Text);
                objCourse.Insurance = Convert.ToDecimal(textBox30.Text);
                objCourse.LCComission = Convert.ToDecimal(textBox31.Text);
                objCourse.TotalExpense = Convert.ToDecimal(textBox2.Text);


                objCourse.ContainerNo = textBox33.Text;
                objCourse.LCNo = textBox34.Text;

                objCourse.BalanceLeft = getBalanceExpense;

                objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit2.EditValue);


                db.Edison_ImportCostingHDRs.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                //textBox1.Text = objCourse.Edison_SupplierPurchID.ToString();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    Edison_ImportCostingDTL AddItems = new Edison_ImportCostingDTL();

                    AddItems.OrderNo = Convert.ToInt32(searchLookUpEdit5.EditValue);
                    AddItems.CostingID = objCourse.CostingID;
            
                    AddItems.ProductID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.QtyInCartons = Convert.ToDecimal(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                    AddItems.QtyInNos = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());

                    AddItems.RateInDollar = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                    AddItems.ValueInDollar = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                    AddItems.DollarInRate = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                    AddItems.ValueInRs = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                    AddItems.ValuePerPcs = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                    AddItems.ExpensePerPcs = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                    AddItems.TotalCost = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                    AddItems.SalePrice = Convert.ToDecimal(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                    AddItems.ExpectedSaleValue = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                    AddItems.ContainerCost = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());
                    AddItems.TotalGP = Convert.ToDecimal(row.Cells[16].Value.ToString() == "" ? "0" : row.Cells[16].Value.ToString());
                    AddItems.GPPercentage = Convert.ToDecimal(row.Cells[17].Value.ToString() == "" ? "0" : row.Cells[17].Value.ToString());
       
                    db.Edison_ImportCostingDTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();
 
                }



                scope.Complete();
                IC_RevertState();
                IC_DisableAll();
 
            }
            refreshAll();
        }

        private void IC_BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void IC_BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            IC_SaveAll();
        }



        private void IC_BtnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IC_SaveAll();
            }
        }


        private void getLedger()
        {
            try
            {
                dataGridView4.Rows.Clear();
                dataGridView4.Refresh();

                DataClasses1DataContext db = new DataClasses1DataContext();
                db.ObjectTrackingEnabled = false;

                string code;




                DateTime cdate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                cdate = cdate.AddDays(-60);




                // ---------------------------------------------------------------
                var getopeningbalance = from w in db.Edison_Suppliers
                                        where w.SupplierID.Equals(searchLookUpEdit12.EditValue)
                                        select new
                                        {
                                            w.OpeningBalance,

                                        };


                if (getopeningbalance.Any())
                {


                    foreach (var a in getopeningbalance)
                    {
                        dataGridView4.Rows.Add(null, null, "Opening Balance", null, null, "0", "0", "0", "0", a.OpeningBalance);
                        //    this.DataSet1.Ledger.Rows.Clear();

                        code = (searchLookUpEdit12).ToString();

                        //           txtBalance.Text = Convert.ToDecimal(a.Balance).ToString("#,##0.00");


                        break;
                    }
                }
                //------------------------------------------------------------------



                var getdata = from d in db.Edison_ImportCostingHDRs
                              where d.SupplierID.Equals(searchLookUpEdit12.EditValue) && (d.ArrivalDate >= Convert.ToDateTime("2015-01-01") && d.ArrivalDate < LD_FromDate.Value.Date)
                              select new
                              {
                                  d.OrderNo,
                                  d.ArrivalDate,                                  
                                  d.TotalValueInDollar,

                              };

                if (getdata.Any())
                {


                    foreach (var a in getdata)
                    {
                        dataGridView4.Rows.Add(a.OrderNo, a.ArrivalDate, "Billing", null, null, null, a.TotalValueInDollar, "0", "0");
                    }

                }


                //var getreturn = from d in db.tbl_SaleReturnHDRs
                //                where d.CustID.Equals(searchLookUpEdit12.EditValue) && (d.Date >= Convert.ToDateTime("2015-01-01") && d.Date < LD_FromDate.Value.Date)
                //                select new
                //                {
                //                    d.SRNo,
                //                    d.Date,
                //                    d.Remarks,
                //                    d.SaleReturnAmount,
                //                    d.CustID,

                //                };

                //if (getreturn.Any())
                //{


                //    foreach (var a in getreturn)
                //    {
                //        dataGridView4.Rows.Add(a.SRNo, a.Date, "Sale Return", null, null, "0", "0", a.SaleReturnAmount);
                //    }

                //}





                var getdata2 = from f in db.Edison_ImportPayments
                               where f.SupplierID.Equals(searchLookUpEdit12.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                               select new
                               {
                                   f.IMP_PaymentID,
                                   f.Date,
                                   f.Remarks,
                                   f.AmountinDollar,
                                   f.WriteOff,


                               };

                if (getdata2.Any())
                {
                    foreach (var b in getdata2)
                    {
                        dataGridView4.Rows.Add(b.IMP_PaymentID, b.Date, "Collection", null, "0", "0", "0", b.AmountinDollar, b.WriteOff);
                        //dataGridView4.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }

                dataGridView4.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

                dataGridView4.Sort(dataGridView4.Columns[1], ListSortDirection.Ascending);
                this.dataGridView4.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;




                for (int i = 1; i < dataGridView4.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView4[6, i].Value) == 0) && ((Convert.ToDecimal(dataGridView4[7, i].Value) != 0) || (Convert.ToDecimal(dataGridView4[8, i].Value) != 0)))
                    {
                        dataGridView4[9, i].Value = Convert.ToDecimal(dataGridView4[9, i - 1].Value) - Convert.ToDecimal(dataGridView4[7, i].Value) - Convert.ToDecimal(dataGridView4[8, i].Value);
                    }
                    else
                    {
                        dataGridView4[9, i].Value = (Convert.ToDecimal(dataGridView4[6, i].Value) + Convert.ToDecimal(dataGridView4[8, i].Value) + Convert.ToDecimal(dataGridView4[9, i - 1].Value));

                    }

                }



                //--------------------------------------------------------------------------------------------------------------------------------------------------------------


                decimal getvalue = 0;


                Int32 index = dataGridView4.Rows.Count - 1;

                getvalue = Convert.ToDecimal(dataGridView4[9, index].Value);





                dataGridView4.Rows.Clear();
                dataGridView4.Refresh();


                // ---------------------------------------------------------------

                // dataGridView4.Rows.Add(null, "Opening Balance", null, null, null, null, null, null, getvalue.ToString("#,##0.00"));

                dataGridView4.Rows.Add(null, null, "Opening Balance", null, "0", "0", "0", "0", "0", getvalue.ToString("#,##0.00"), "0");


                //------------------------------------------------------------------

                DataClasses1DataContext connection = new DataClasses1DataContext();

                connection.ObjectTrackingEnabled = false;

                var getdata1 = from d in db.Edison_ImportCostingHDRs
                               where d.SupplierID.Equals(searchLookUpEdit12.EditValue) && (d.ArrivalDate >= LD_FromDate.Value.Date && d.ArrivalDate <= LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                               select new
                               {
                                   d.OrderNo,
                                   d.ArrivalDate,
                                   d.TotalValueInDollar,



                               };

                if (getdata1.Any())
                {


                    foreach (var a in getdata1)
                    {
                        dataGridView4.Rows.Add(a.OrderNo, a.ArrivalDate, "Billing", null, null, null, a.TotalValueInDollar, "0", "0");
                    }

                }




                //var getreturn1 = from f in db.tbl_SaleReturnHDRs
                //                 where f.CustID.Equals(searchLookUpEdit12.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
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
                //        dataGridView4.Rows.Add(a.SRNo, a.Date, "Sale Return", a.SRNo, null, "0", "0", a.SaleReturnAmount);
                //    }

                //}



                var getdata22 = from f in db.Edison_ImportPayments
                                where f.SupplierID.Equals(searchLookUpEdit12.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                                select new
                                {
                                    f.IMP_PaymentID,
                                    f.Date,
                                    f.Remarks,
                                    f.AmountinDollar,
                                    f.WriteOff,


                                };

                if (getdata22.Any())
                {
                    foreach (var b in getdata22)
                    {
                        dataGridView4.Rows.Add(b.IMP_PaymentID, b.Date, "Collection", null, "0", "0", "0", b.AmountinDollar, b.WriteOff);
                        //dataGridView4.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }




                dataGridView4.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";


                dataGridView4.Sort(dataGridView4.Columns[1], ListSortDirection.Ascending);
                this.dataGridView4.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;



                for (int i = 1; i < dataGridView4.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView4[6, i].Value) == 0) && ((Convert.ToDecimal(dataGridView4[7, i].Value) != 0) || (Convert.ToDecimal(dataGridView4[8, i].Value) != 0)))
                    {
                        dataGridView4[9, i].Value = Convert.ToDecimal(dataGridView4[9, i - 1].Value) - Convert.ToDecimal(dataGridView4[7, i].Value) - Convert.ToDecimal(dataGridView4[8, i].Value);
                    }
                    else
                    {
                        dataGridView4[9, i].Value = (Convert.ToDecimal(dataGridView4[6, i].Value) + Convert.ToDecimal(dataGridView4[8, i].Value) + Convert.ToDecimal(dataGridView4[9, i - 1].Value));

                    }

                }




                //for (int i = 1; i < dataGridView4.Rows.Count; i++)
                //{

                //    if ((Convert.ToDecimal(dataGridView4[5, i].Value) == 0) && ((Convert.ToDecimal(dataGridView4[6, i].Value) != 0) || (Convert.ToDecimal(dataGridView4[7, i].Value) != 0)))
                //    {
                //        dataGridView4[8, i].Value = Convert.ToDecimal(dataGridView4[8, i - 1].Value) - Convert.ToDecimal(dataGridView4[6, i].Value) - Convert.ToDecimal(dataGridView4[7, i].Value);
                //    }
                //    else
                //    {
                //        dataGridView4[8, i].Value = (Convert.ToDecimal(dataGridView4[5, i].Value) + Convert.ToDecimal(dataGridView4[7, i].Value) + Convert.ToDecimal(dataGridView4[8, i - 1].Value));

                //    }

                //}




                //foreach (DataGridViewRow Myrow in dataGridView4.Rows)
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



                //  dataGridView4.Columns[5].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView4.Columns[9].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView4.Columns[8].DefaultCellStyle.BackColor = Color.MistyRose;
                dataGridView4.Columns[7].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                dataGridView4.Columns[6].DefaultCellStyle.BackColor = Color.Khaki;

                //for (int i = 0; i < dataGridView4.Rows.Count; i++)
                //{ //                                                                                  date                                bill #                                     cases                                   bility amount                decription                                   bill amount                coll                                     writeoff                                balance
                //    //DataSet1.Ledger.AddLedgerRow(null, null, null, null, null, null, dataGridView4[0, i].Value.ToString(), dataGridView4[7, i].Value.ToString(), dataGridView4[10, i].Value.ToString(), dataGridView4[12, i].Value.ToString(), dataGridView4[16, i].Value.ToString(), dataGridView4[17, i].Value.ToString(), dataGridView4[18, i].Value.ToString(), dataGridView4[19, i].Value.ToString(), dataGridView4[20, i].Value.ToString());
                //    DataSet1.Ledger.Rows.Add(searchLookUpEdit12.EditValue, LedgerCustomerName.Text, LedgerCAddress.Text, LedgerCity.Text, LD_FromDate.Value.Date, LD_ToDate.Value.DATE, dataGridView4[0, i].Value, dataGridView4[7, i].Value, dataGridView4[10, i].Value, dataGridView4[12, i].Value, dataGridView4[16, i].Value, dataGridView4[18, i].Value, dataGridView4[19, i].Value, dataGridView4[20, i].Value, dataGridView4[21, i].Value);
                //}



                //if (!string.IsNullOrEmpty(dataGridView4.Rows[dataGridView4.RowCount - 1].Cells[10].Value.ToString()) && !string.IsNullOrEmpty(LD_Balance.Text))
                //{
                //    if (dataGridView4.Rows[dataGridView4.RowCount - 1].Cells[10].Value.ToString() != LD_Balance.Text)
                //    {
                //        panel10.BackColor = Color.Red;
                //        panel10.Visible = true;
                //    }
                //    else
                //    {
                //        panel10.Visible = false;
                //    }
                //}


                //LGR_TotalSale.Text = dataGridView4.Rows[dataGridView4.RowCount - 1].Cells[21].Value.ToString();


                dataGridView4.FirstDisplayedScrollingRowIndex = dataGridView4.RowCount - 1;


                //     sumforledger();



                //   txtPerDay.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)*7) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit12.EditValue + ") And Posted = 1")[0];

                //   txtPerWeekLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit12.EditValue + ") And Posted = 1")[0];

                //   txtPerMonthLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)/4) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + searchLookUpEdit12.EditValue + ") And Posted = 1")[0];

                dataGridView4.ClearSelection();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            getLedger();
        }

        private void searchLookUpEdit11_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchLookUpEdit11.Text))
            {
                getBalanceExpense = 0;

                dataGridView1.Rows.Clear();

                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_ImportCostingHDRs
                                        join v in db.Edison_ImportOrderHDRs on d.OrderNo equals v.EdisonImportOrderID into bookingmGroup
                                        from v in bookingmGroup.DefaultIfEmpty()
                                        where d.OrderNo.Equals(searchLookUpEdit11.EditValue)
                                        select new
                                        {
                                            d.OrderNo,
                                            d.ArrivalDate,
                                            d.ClearingAgentID,
                                            d.ContainerNo,
                                            d.LCNo,
                                            v.OrderDate,
                                            d.SupplierID,
                                            d.TaxesDuties,
                                            d.Carriage,
                                            d.ClearingExpense,
                                            d.LabourUnloading,
                                            d.Insurance,
                                            d.LCComission,
                                            d.BalanceLeft,

                                        };

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                        searchLookUpEdit2.EditValue = a.SupplierID;
                        dateTimePicker4.Value = Convert.ToDateTime(a.OrderDate);
                        textBox33.Text = a.ContainerNo;
                        textBox34.Text = a.LCNo;
                        dateTimePicker1.Value = Convert.ToDateTime(a.ArrivalDate);

                        searchLookUpEdit3.EditValue = a.ClearingAgentID;

                        textBox1.Text = a.BalanceLeft.ToString();
                        getBalanceExpense = Convert.ToDecimal(a.BalanceLeft);
                        textBox26.Text = a.TaxesDuties.ToString();
                        textBox28.Text = a.Carriage.ToString();
                        textBox27.Text = a.ClearingExpense.ToString();
                        textBox29.Text = a.LabourUnloading.ToString();
                        textBox30.Text = a.Insurance.ToString();
                        textBox31.Text = a.LCComission.ToString();

                        break;
                    }
                }



                var getmazeeddetails = from d in db.Edison_ImportCostingHDRs
                          

                                       join u in db.Edison_ImportCostingDTLs on d.OrderNo equals u.OrderNo into ud
                                       from u in ud.DefaultIfEmpty()


                                       join v in db.Edison_Products on u.ProductID equals v.ProductID into ul
                                       from v in ul.DefaultIfEmpty()

                                       where d.OrderNo.Equals(searchLookUpEdit11.EditValue)
                                       select new
                                       {
                                           u.ProductID,
                                           v.ProductCode,
                                           v.ProductDescription,
                                           u.QtyInCartons,
                                           u.QtyInNos,
                                           u.RateInDollar,
                                           u.ValueInDollar,
                                           u.DollarInRate,
                                           u.ValueInRs,
                                           u.ValuePerPcs,
                                           u.ExpensePerPcs,
                                           u.TotalCost,
                                           u.SalePrice,
                                           u.ExpectedSaleValue,
                                           u.ContainerCost,
                                           u.TotalGP,
                                           u.GPPercentage,                                           
                                       };

                if (getmazeeddetails.Any())
                {
                    foreach (var a in getmazeeddetails)
                    {
                        dataGridView1.Rows.Add(null, a.ProductID, a.ProductCode, a.ProductDescription, a.QtyInCartons, a.QtyInNos, a.RateInDollar, a.ValueInDollar, a.DollarInRate, a.ValueInRs, a.ValuePerPcs, a.ExpensePerPcs, a.TotalCost, a.SalePrice, a.ExpectedSaleValue, a.ContainerCost, a.TotalGP, a.GPPercentage);

                    }
                }



                //var getDuties = from d in db.Edison_ImportCDDTLs
                //                where d.EdisonImportOrderID.Equals(searchLookUpEdit5.EditValue)
                //                group d by d.EdisonImportOrderID into g
                //                select new
                //                {
                //                    SumDutiesTaxes = g.Sum(x => x.TotalTaxes),
                //                    SumCarriage = g.Sum(x => x.Carriage),
                //                    SumOthers = g.Sum(x => x.Other),
                //                };

                //if (getDuties.Any())
                //{
                //    foreach (var a in getDuties)
                //    {

                //        textBox26.Text = a.SumDutiesTaxes.ToString();
                //        textBox28.Text = a.SumCarriage.ToString();
                //        textBox1.Text = a.SumOthers.ToString();
                //        break;
                //    }
                //}




              

                int j = 1;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[0].Value = j++;
                }

                getInvoiceSum();
                sumTotalExpensesInInvoice();
                dataGridView1.ClearSelection();
            }
        }

        private void IC_BtnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            IC_EditSaveAll();
        }

        private void IC_BtnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                IC_EditSaveAll();
            }
        }

        private void IC_EditSaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                int CostingID = 0;

                var getTheSelecteddata = from s in db.Edison_ImportCostingHDRs
                                         where s.OrderNo.Equals(searchLookUpEdit11.EditValue)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {



                      //  objCourse.OrderNo = Convert.ToInt32(searchLookUpEdit11.EditValue);
                        objCourse.ArrivalDate = dateTimePicker1.Value;
                        objCourse.ClearingAgentID = Convert.ToInt32(searchLookUpEdit3.EditValue);


                        objCourse.TotalValueInDollar = Convert.ToDecimal(textBox16.Text);
                        objCourse.TotalValueInPak = Convert.ToDecimal(textBox15.Text);
                        objCourse.TaxesDuties = Convert.ToDecimal(textBox26.Text);
                        objCourse.Carriage = Convert.ToDecimal(textBox28.Text);
                        objCourse.ClearingExpense = Convert.ToDecimal(textBox27.Text);
                        objCourse.LabourUnloading = Convert.ToDecimal(textBox29.Text);
                        objCourse.Insurance = Convert.ToDecimal(textBox30.Text);
                        objCourse.LCComission = Convert.ToDecimal(textBox31.Text);
                        objCourse.TotalExpense = Convert.ToDecimal(textBox2.Text);


                        objCourse.ContainerNo = textBox33.Text;
                        objCourse.LCNo = textBox34.Text;

                        objCourse.BalanceLeft = getBalanceExpense;

                        objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit2.EditValue);

                        CostingID = objCourse.CostingID;

                        db.SubmitChanges();

                    }

                    var a = from s in db.Edison_ImportCostingDTLs
                            where s.OrderNo.Equals(searchLookUpEdit11.EditValue)
                            select s;

                    if (a.Any())
                    {
                        foreach (var d in a)
                        {
                            db.Edison_ImportCostingDTLs.DeleteOnSubmit(d);
                            db.SubmitChanges();
                        }
                    }


                    //textBox1.Text = objCourse.Edison_SupplierPurchID.ToString();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        Edison_ImportCostingDTL AddItems = new Edison_ImportCostingDTL();

                        AddItems.OrderNo = Convert.ToInt32(searchLookUpEdit11.EditValue);
                        AddItems.CostingID = CostingID;

                        AddItems.ProductID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                        AddItems.QtyInCartons = Convert.ToDecimal(row.Cells[4].Value.ToString() == "" ? "0" : row.Cells[4].Value.ToString());
                        AddItems.QtyInNos = Convert.ToDecimal(row.Cells[5].Value.ToString() == "" ? "0" : row.Cells[5].Value.ToString());

                        AddItems.RateInDollar = Convert.ToDecimal(row.Cells[6].Value.ToString() == "" ? "0" : row.Cells[6].Value.ToString());
                        AddItems.ValueInDollar = Convert.ToDecimal(row.Cells[7].Value.ToString() == "" ? "0" : row.Cells[7].Value.ToString());
                        AddItems.DollarInRate = Convert.ToDecimal(row.Cells[8].Value.ToString() == "" ? "0" : row.Cells[8].Value.ToString());
                        AddItems.ValueInRs = Convert.ToDecimal(row.Cells[9].Value.ToString() == "" ? "0" : row.Cells[9].Value.ToString());
                        AddItems.ValuePerPcs = Convert.ToDecimal(row.Cells[10].Value.ToString() == "" ? "0" : row.Cells[10].Value.ToString());
                        AddItems.ExpensePerPcs = Convert.ToDecimal(row.Cells[11].Value.ToString() == "" ? "0" : row.Cells[11].Value.ToString());
                        AddItems.TotalCost = Convert.ToDecimal(row.Cells[12].Value.ToString() == "" ? "0" : row.Cells[12].Value.ToString());
                        AddItems.SalePrice = Convert.ToDecimal(row.Cells[13].Value.ToString() == "" ? "0" : row.Cells[13].Value.ToString());
                        AddItems.ExpectedSaleValue = Convert.ToDecimal(row.Cells[14].Value.ToString() == "" ? "0" : row.Cells[14].Value.ToString());
                        AddItems.ContainerCost = Convert.ToDecimal(row.Cells[15].Value.ToString() == "" ? "0" : row.Cells[15].Value.ToString());
                        AddItems.TotalGP = Convert.ToDecimal(row.Cells[16].Value.ToString() == "" ? "0" : row.Cells[16].Value.ToString());
                        AddItems.GPPercentage = Convert.ToDecimal(row.Cells[17].Value.ToString() == "" ? "0" : row.Cells[17].Value.ToString());

                        db.Edison_ImportCostingDTLs.InsertOnSubmit(AddItems);
                        db.SubmitChanges();

                    }



                    scope.Complete();
                    IC_RevertState();
                    IC_DisableAll();

                }
            }
            refreshAll();
        }
        private void IC_BtnEdit_Click(object sender, EventArgs e)
        {    
            IC_EditSaveState();
            IC_EnableAll();
        }

        private void IC_BtnSearch_Click(object sender, EventArgs e)
        {
            searchLookUpEdit11.Visible = true;
            searchLookUpEdit11.Enabled = true;
            searchLookUpEdit11.Focus();
            searchLookUpEdit11.ShowPopup();
        }

        private void IC_BtnRevert_Click(object sender, EventArgs e)
        {
            searchLookUpEdit11.Enabled = false;
            searchLookUpEdit11.Visible = false;
            IC_RevertState();
            IC_DisableAll();
            IC_ClearAll();
        }

        private void OS_BtnSave_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


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
            dateTimePicker7.Value = DateTime.Now;
            searchLookUpEdit13.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox10.Text = "";
            textBox4.Text = "";
            searchLookUpEdit14.Text = "";
            textBox11.Text = "";
        }

        private void SC_EnableAll()
        {
            dateTimePicker7.Enabled = true;
            searchLookUpEdit13.Enabled = true;
            textBox9.Enabled = true;
            textBox3.Enabled = true;
            textBox10.Enabled = true;
            textBox4.Enabled = true;
            searchLookUpEdit14.Enabled = true;
            textBox11.Enabled = true;
        }

        private void SC_DisableAll()
        {
            dateTimePicker2.Enabled = false;
            searchLookUpEdit13.Enabled = false;
            textBox9.Enabled = false;
            textBox3.Enabled = false;
            textBox10.Enabled = false;
            textBox4.Enabled = false;
            searchLookUpEdit14.Enabled = false;
            textBox11.Enabled = false;
        }

        private void SC_btnAdd_Click(object sender, EventArgs e)
        {
            SC_AddState();
            SC_ClearAll();
            SC_EnableAll();
            dateTimePicker7.Focus();
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

        private void SC_SaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {



                Edison_ImportPayment objCourse = new Edison_ImportPayment();
                objCourse.Date = dateTimePicker7.Value.Date;
                objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit13.EditValue);
                objCourse.AmountinDollar = Convert.ToDecimal(textBox9.Text == "" ? "0" : textBox9.Text);
                objCourse.WriteOff = Convert.ToDecimal(textBox3.Text == "" ? "0" : textBox3.Text);
                objCourse.ExchangeRate = Convert.ToDecimal(textBox10.Text == "" ? "0" : textBox10.Text);
                objCourse.AmountInRs = Convert.ToDecimal(textBox4.Text == "" ? "0" : textBox4.Text);

                objCourse.BankID = Convert.ToInt32(searchLookUpEdit14.EditValue);

                objCourse.Remarks = textBox11.Text.Trim();



           //     objCourse.InsertedDateTime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                db.Edison_ImportPayments.InsertOnSubmit(objCourse);

                db.SubmitChanges();

                textBox8.Text = objCourse.IMP_PaymentID.ToString();

                SC_DisableAll();
                SC_RevertState();

                scope.Complete();


            }




        }

        private void dateTimePicker7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit13.Focus();
                searchLookUpEdit13.ShowPopup();

            }
        }

        private void searchLookUpEdit13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                textBox3.Focus();
            }
        }

        private void textBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }

        private void textBox10_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit14.Focus();
                searchLookUpEdit14.ShowPopup();
            }
        }

        private void searchLookUpEdit14_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        private void getSumPayment()
        {
            textBox4.Text = (((Convert.ToDecimal(textBox9.Text == "" ? "0" : textBox9.Text) + Convert.ToDecimal(textBox3.Text == "" ? "0" : textBox3.Text)) * Convert.ToDecimal(textBox10.Text == "" ? "0" : textBox10.Text))).ToString("#,##0.00");
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            getSumPayment();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            getSumPayment();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            getSumPayment();
        }

        private void SC_btnEdit_Click(object sender, EventArgs e)
        {
            SC_EnableAll();
            SC_EditState();
        }

        private void SC_btnEditSave_Click(object sender, EventArgs e)
        {

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

        private void SC_EditSaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                var getTheSelecteddata = from s in db.Edison_ImportPayments
                                         where s.IMP_PaymentID.Equals(textBox8.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {

                       // Edison_ImportPayment objCourse = new Edison_ImportPayment();
                        objCourse.Date = dateTimePicker7.Value.Date;
                        objCourse.SupplierID = Convert.ToInt32(searchLookUpEdit13.EditValue);
                        objCourse.AmountinDollar = Convert.ToDecimal(textBox9.Text == "" ? "0" : textBox9.Text);
                        objCourse.WriteOff = Convert.ToDecimal(textBox3.Text == "" ? "0" : textBox3.Text);
                        objCourse.ExchangeRate = Convert.ToDecimal(textBox10.Text == "" ? "0" : textBox10.Text);
                        objCourse.AmountInRs = Convert.ToDecimal(textBox4.Text == "" ? "0" : textBox4.Text);

                        objCourse.BankID = Convert.ToInt32(searchLookUpEdit14.EditValue);

                        objCourse.Remarks = textBox11.Text.Trim();



                        //     objCourse.InsertedDateTime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                       // db.Edison_ImportPayments.InsertOnSubmit(objCourse);

                        db.SubmitChanges();

                        textBox8.Text = objCourse.IMP_PaymentID.ToString();

                        SC_DisableAll();
                        SC_RevertState();

                        scope.Complete();

                    }
                }

              




            }




        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker7.Value = DateTime.Now;
                searchLookUpEdit13.Text = "";
                textBox9.Text = "";
                textBox3.Text = "";
                textBox10.Text = "";
                textBox4.Text = "";
                searchLookUpEdit14.Text = "";
                textBox11.Text = "";

                if (!string.IsNullOrEmpty(textBox8.Text))
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();


                    var getTheSelecteddata = from s in db.Edison_ImportPayments
                                             where s.IMP_PaymentID.Equals(textBox8.Text)
                                             select s;

                    if (getTheSelecteddata.Any())
                    {
                        foreach (var objCourse in getTheSelecteddata)
                        {
                            dateTimePicker7.Value = Convert.ToDateTime(objCourse.Date);
                            searchLookUpEdit13.EditValue = objCourse.SupplierID;
                            textBox9.Text = objCourse.AmountinDollar.ToString();
                            textBox3.Text = objCourse.WriteOff.ToString();
                            textBox10.Text = objCourse.ExchangeRate.ToString();
                            textBox4.Text = objCourse.AmountInRs.ToString();
                            searchLookUpEdit14.EditValue = Convert.ToInt32(objCourse.BankID);
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

        private void searchLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit12_EditValueChanged(object sender, EventArgs e)
        {
            getLedger();
        }

        private void OS_BtnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void SC_btnSave_Click(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit8_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}