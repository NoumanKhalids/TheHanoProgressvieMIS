using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace MIS_ProgressiveDistributors
{
    public partial class EdisonInventory : Form
    {
        public EdisonInventory()
        {
            InitializeComponent();
        }

        private void EdisonInventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet12.StocksReport' table. You can move, or remove it, as needed.
            this.stocksReportTableAdapter.Fill(this.dataSet12.StocksReport);

            this.stockAdjustmentGridTableAdapter.Fill(this.dataSet1.StockAdjustmentGrid);
            this.edison_ProductListTableAdapter.Fill(this.dataSet11.Edison_ProductList);

           

            tabControl1.Controls.Remove(tabPage2);


            // TODO: This line of code loads data into the 'dataSet1.StocksReport' table. You can move, or remove it, as needed.
            this.stocksReportTableAdapter.Fill(this.dataSet1.StocksReport);
            getStockSum();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.StocksReport' table. You can move, or remove it, as needed.
            this.stocksReportTableAdapter.Fill(this.dataSet12.StocksReport);
            getStockSum();
        }

        private void SearchCurrentStockReport()
        {
            try
            {

                DataView DV = new DataView(this.dataSet1.StocksReport);

                DV.RowFilter = "(convert(ProductCode, 'System.String') like '%" + textBox2.Text + "%' OR convert(ProductCode, 'System.String') IS Null) AND (convert(ProductDescription, 'System.String') like '%" + textBox3.Text + "%' OR convert(ProductDescription, 'System.String') IS Null) AND (BrandName like '%" + textBox4.Text + "%' OR BrandName IS Null) AND (Category like '%" + textBox5.Text + "%' OR Category IS Null ) ";
                dataGridView1.DataSource = DV;

                textBox6.Text = dataGridView1.Rows.Count.ToString();
                getStockSum();

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void getStockSum()
        {
            
          try
            {
                Decimal billing = 0;
                Decimal collection = 0;
                Decimal GetStock = 0;

                Decimal TotalSaleValue = 0;


                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (dataGridView1.Rows[i].Cells[4].Value == null)
                    {

                    }
                    else
                    {
                        billing += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    }


                    if (dataGridView1.Rows[i].Cells[5].Value == null)
                    {

                    }
                    else
                    {
                        collection += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                    }


                    if (dataGridView1.Rows[i].Cells[6].Value == null)
                    {

                    }
                    else
                    {
                        GetStock += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                    }


                    if (dataGridView1.Rows[i].Cells[8].Value == null)
                    {

                    }
                    else
                    {
                        TotalSaleValue += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value);
                    }


                }


                textBox1.Text = billing.ToString("#,##0.00");
                textBox7.Text = collection.ToString("#,##0.00");
                textBox8.Text = GetStock.ToString("#,##0.00");
                textBox9.Text = TotalSaleValue.ToString("#,##0.00");


                textBox6.Text = dataGridView1.Rows.Count.ToString();
            }   
            catch(Exception err)
            {
                MessageBox.Show("MISTAKE IN TOTAL " + err);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchCurrentStockReport();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchCurrentStockReport();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SearchCurrentStockReport();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SearchCurrentStockReport();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            this.edison_Products1TableAdapter.Fill(this.dataSet1.Edison_Products1);


            foreach (DataGridViewRow Myrow in dataGridView2.Rows)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getopeningbalance = from Edison_DispatchDTL in db.Edison_DispatchDTLs
                                        join Edison_DispatchHDR in db.Edison_DispatchHDRs on new { DispatchNo = Convert.ToInt32(Edison_DispatchDTL.DispatchNo) } equals new { DispatchNo = Edison_DispatchHDR.DispatchNo }
                                        where
                                          Convert.ToDateTime(Edison_DispatchHDR.DispatchDate) < Convert.ToDateTime(dateTimePicker1.Value.Date) &&
                                          Edison_DispatchDTL.ProductID == Convert.ToInt32(Myrow.Cells[0].Value)
                                        group Edison_DispatchDTL by new
                                        {
                                            Edison_DispatchDTL.ProductID
                                        } into g
                                        select new
                                        {
                                            g.Key.ProductID,
                                            Expr2 = (int?)(g.Sum(p => p.StockIssued) - g.Sum(p => p.StockReturn))
                                        };

                if(getopeningbalance.Any())
                {
                    foreach(var ab in getopeningbalance)
                    {
                        Myrow.Cells[3].Value = Convert.ToInt32(Myrow.Cells[2].Value) - Convert.ToInt32(ab.Expr2);

                        Myrow.Cells[5].Value = Convert.ToInt32(Myrow.Cells[2].Value) - Convert.ToInt32(ab.Expr2);
                        
                        break;
                    }
                }
                Myrow.Cells[6].Value = 0;


                var getInvoice = from Edison_DispatchDTL in db.Edison_DispatchDTLs
                                 join Edison_DispatchHDR in db.Edison_DispatchHDRs on new { DispatchNo = Convert.ToInt32(Edison_DispatchDTL.DispatchNo) } equals new { DispatchNo = Edison_DispatchHDR.DispatchNo }
                                 where
                                   Convert.ToDateTime(Edison_DispatchHDR.DispatchDate) >= Convert.ToDateTime(dateTimePicker1.Value.Date) &&
                                   Convert.ToDateTime(Edison_DispatchHDR.DispatchDate) <= Convert.ToDateTime(dateTimePicker2.Value.Date) &&
                                   Edison_DispatchDTL.ProductID == Convert.ToInt32(Myrow.Cells[0].Value)
                                 group Edison_DispatchDTL by new
                                 {
                                     Edison_DispatchDTL.ProductID
                                 } into g
                                 select new
                                 {
                                     g.Key.ProductID,
                                     Expr2 = (int?)(g.Sum(p => p.StockIssued) - g.Sum(p => p.StockReturn))
                                 };


                if (getInvoice.Any())
                {
                    foreach (var ab in getInvoice)
                    {
                        Myrow.Cells[7].Value =  Convert.ToInt32(ab.Expr2);
                        Myrow.Cells[8].Value = Convert.ToInt32(ab.Expr2);
                        break;
                    }
                }


                Myrow.Cells[9].Value = Convert.ToInt32(Myrow.Cells[3].Value) - Convert.ToInt32(Myrow.Cells[8].Value);


            }


            foreach (DataGridViewRow Myrow in dataGridView3.Rows)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getopeningbalance = from Edison_DispatchDTL in db.Edison_DispatchDTLs
                                        join Edison_DispatchHDR in db.Edison_DispatchHDRs on new { DispatchNo = Convert.ToInt32(Edison_DispatchDTL.DispatchNo) } equals new { DispatchNo = Edison_DispatchHDR.DispatchNo }
                                        where
                                          Convert.ToDateTime(Edison_DispatchHDR.DispatchDate) < Convert.ToDateTime(dateTimePicker1.Value.Date) &&
                                          Edison_DispatchDTL.ProductID == Convert.ToInt32(Myrow.Cells[0].Value)
                                        group Edison_DispatchDTL by new
                                        {
                                            Edison_DispatchDTL.ProductID
                                        } into g
                                        select new
                                        {
                                            g.Key.ProductID,
                                            Expr2 = (int?)(g.Sum(p => p.REP))
                                        };

                if (getopeningbalance.Any())
                {
                    foreach (var ab in getopeningbalance)
                    {
                        Myrow.Cells[3].Value = Convert.ToInt32(Myrow.Cells[2].Value) - Convert.ToInt32(ab.Expr2);

                        Myrow.Cells[5].Value = Convert.ToInt32(Myrow.Cells[2].Value) - Convert.ToInt32(ab.Expr2);

                        break;
                    }
                }
                Myrow.Cells[6].Value = 0;


                var getInvoice = from Edison_DispatchDTL in db.Edison_DispatchDTLs
                                 join Edison_DispatchHDR in db.Edison_DispatchHDRs on new { DispatchNo = Convert.ToInt32(Edison_DispatchDTL.DispatchNo) } equals new { DispatchNo = Edison_DispatchHDR.DispatchNo }
                                 where
                                   Convert.ToDateTime(Edison_DispatchHDR.DispatchDate) >= Convert.ToDateTime(dateTimePicker1.Value.Date) &&
                                   Convert.ToDateTime(Edison_DispatchHDR.DispatchDate) <= Convert.ToDateTime(dateTimePicker2.Value.Date) &&
                                   Edison_DispatchDTL.ProductID == Convert.ToInt32(Myrow.Cells[0].Value)
                                 group Edison_DispatchDTL by new
                                 {
                                     Edison_DispatchDTL.ProductID
                                 } into g
                                 select new
                                 {
                                     g.Key.ProductID,
                                     Expr2 = (int?)(g.Sum(p => p.REP))
                                 };


                if (getInvoice.Any())
                {
                    foreach (var ab in getInvoice)
                    {
                        Myrow.Cells[7].Value = Convert.ToInt32(ab.Expr2);
                        Myrow.Cells[8].Value = Convert.ToInt32(ab.Expr2);
                        break;
                    }
                }


                Myrow.Cells[9].Value = Convert.ToInt32(Myrow.Cells[3].Value) + Convert.ToInt32(Myrow.Cells[8].Value);
            }


            }

        private void getProductLedger()
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {

               // this.sp_AndroidSupervisorDataTableAdapter.Fill(this.DataSet1.sp_AndroidSupervisorData, Convert.ToInt32(textBox35.Text));


                this.dailyStockreportTableAdapter.Fill(this.dataSet11.DailyStockreport, dateTimePicker4.Value.Date, dateTimePicker3.Value.Date);

                this.dailyStockreportTableAdapter.Fill(this.dataSet12.DailyStockreport, dateTimePicker4.Value.Date, dateTimePicker3.Value.Date);

                this.dailyREPreportTableAdapter.Fill(this.dataSet11.DailyREPreport, dateTimePicker4.Value.Date, dateTimePicker3.Value.Date);



            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }

        }

        private void sumLedger()
        {
            try
            {
                decimal sum3 = 0;
                decimal bltyamount = 0;
                decimal totalcartons = 0;

                for (int i = 0; i < dataGridView8.Rows.Count; ++i)
                {
                    if (dataGridView8.Rows[i].Cells[6].Value == null || dataGridView8.Rows[i].Cells[6].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView8.Rows[i].Cells[6].Value.ToString()))
                    {

                    }
                    else
                    {
                        sum3 += Convert.ToDecimal(dataGridView8.Rows[i].Cells[6].Value);
                    }

                    //textBox6.Text = sum3.ToString();

                    if (dataGridView8.Rows[i].Cells[7].Value == null || dataGridView8.Rows[i].Cells[7].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView8.Rows[i].Cells[7].Value.ToString()))
                    {

                    }
                    else
                    {
                        bltyamount += Convert.ToDecimal(dataGridView8.Rows[i].Cells[7].Value);
                    }



                    if (dataGridView8.Rows[i].Cells[8].Value == null || dataGridView8.Rows[i].Cells[8].Value == DBNull.Value || String.IsNullOrWhiteSpace(dataGridView8.Rows[i].Cells[8].Value.ToString()))
                    {

                    }
                    else
                    {
                        totalcartons += Convert.ToDecimal(dataGridView8.Rows[i].Cells[8].Value);
                    }



                }


                textBox11.Text = dataGridView8.Rows[dataGridView8.RowCount - 1].Cells[9].Value.ToString();

                textBox14.Text = sum3.ToString();
                textBox13.Text = bltyamount.ToString();
                textBox12.Text = totalcartons.ToString();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            getLedger();
          
        }


        private void getLedger()
        {
            if(comboBoxEdit2.Text == "STOCK")
            {
                getStockLedger();
            }
            else if (comboBoxEdit2.Text == "REPLACEMENT")
            {
                MessageBox.Show("We are already working on Replacement Ledger! Please Wait");
            }
            else
            {
                MessageBox.Show("Please Select the Stock Type");
            }
        }


        private void getStockLedger()
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
                var getopeningbalance = from w in db.Edison_Products
                                        where w.ProductID.Equals(searchLookUpEdit6.EditValue)
                                        select new
                                        {
                                            w.OpeningStocks,

                                        };


                if (getopeningbalance.Any())
                {


                    foreach (var a in getopeningbalance)
                    {
                        dataGridView8.Rows.Add(null, null, "Opening Balance", null, null, "0", "0", "0", "0", a.OpeningStocks);
                        //    this.DataSet1.Ledger.Rows.Clear();

                        code = (searchLookUpEdit6).ToString();

                        //           txtBalance.Text = Convert.ToDecimal(a.Balance).ToString("#,##0.00");


                        break;
                    }
                }
                //------------------------------------------------------------------



                var getdata = from f in db.Edison_ImportCostingHDRs
                              join c in db.Edison_ImportCostingDTLs on f.CostingID equals c.CostingID into ps
                              from c in ps.DefaultIfEmpty()
                              where c.ProductID.Equals(searchLookUpEdit6.EditValue) && (f.ArrivalDate >= Convert.ToDateTime("2015-01-01") && f.ArrivalDate < LD_FromDate.Value.Date)
                              select new
                              {
                                  f.CostingID,
                                  f.ArrivalDate,
                                  
                                  c.QtyInNos,
                                  f.SupplierID,

                              };

                if (getdata.Any())
                {


                    foreach (var a in getdata)
                    {
                        dataGridView8.Rows.Add(a.CostingID, a.ArrivalDate, "Invoice", null, null, null, a.QtyInNos, "0", "0");
                    }

                }







                var getdata22 = from f in db.Edison_SupplierPurch_HDRs
                              join c in db.Edison_SupplierPurch_DTLs on f.Edison_SupplierPurchID equals c.Edison_SupplierPurchID into ps
                              from c in ps.DefaultIfEmpty()
                              where c.PID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date< LD_FromDate.Value.Date)
                              select new
                              {
                                  f.Edison_SupplierPurchID,
                                  f.Date,

                                  c.Qty,
                                  f.SupplierID,

                              };

                if (getdata22.Any())
                {


                    foreach (var a in getdata22)
                    {
                        dataGridView8.Rows.Add(a.Edison_SupplierPurchID, a.Date, "Invoice # " + a.Edison_SupplierPurchID, null, null, null, a.Qty, "0", "0");
                    }

                }




                var getAdjustments = from f in db.Edison_StockAdjustments
                                   where f.PID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date) && (f.StockType == "STOCK")
                                     select new
                                  {
                                      f.StockAdjustmentID,
                                      f.Date,
                                      //f.DispatchNo,
                                      f.TotalQty,
                                      f.Remarks,


                                  };

                if (getAdjustments.Any())
                {


                    foreach (var a in getAdjustments)
                    {
                        dataGridView8.Rows.Add(a.StockAdjustmentID, a.Date, "ADJUSTMENT -->" + a.Remarks, a.StockAdjustmentID, null, null, a.TotalQty, "0", "0");
                    }

                }






                var getSalesReturn = from f in db.Edison_SupplierPurchReturn_HDRs
                                  join c in db.Edison_SupplierPurchReturn_DTLs on f.Edison_SupplierPurchReturnID equals c.Edison_SupplierPurchID into ps
                                  from c in ps.DefaultIfEmpty()
                                  where c.PID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date) &&  c.StockType == "STOCK"
                                  select new
                                  {
                                      f.Edison_SupplierPurchReturnID,
                                      f.Date,
                                      //f.DispatchNo,
                                      c.Qty,
                                      


                                  };

                if (getSalesReturn.Any())
                {


                    foreach (var a in getSalesReturn)
                    {
                        dataGridView8.Rows.Add(a.Edison_SupplierPurchReturnID, a.Date, "Sales Return Details", a.Edison_SupplierPurchReturnID, null, null, "0", "0", (a.Qty));
                    }

                }



                var getreturn11 = from f in db.Edison_DispatchHDRs
                                  join c in db.Edison_DispatchDTLs on f.DispatchNo equals c.DispatchNo into ps
                                  from c in ps.DefaultIfEmpty()
                                  where c.ProductID.Equals(searchLookUpEdit6.EditValue) && (f.DispatchDate >= Convert.ToDateTime("2015-01-01") && f.DispatchDate < LD_FromDate.Value.Date)
                                  select new
                                  {
                                      f.DispatchNo,
                                      f.DispatchDate,
                                      //f.DispatchNo,
                                      c.StockIssued,
                                      c.StockReturn,
                                      

                                  };

                if (getreturn11.Any())
                {


                    foreach (var a in getreturn11)
                    {
                        dataGridView8.Rows.Add(a.DispatchNo, a.DispatchDate, "Dispatch Details", a.DispatchNo, null, null, "0", "0", (a.StockIssued - a.StockReturn));
                    }

                }


                //var getdata2 = from f in db.Edison_DispatchPayments
                //               where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                //               select new
                //               {
                //                   f.PaymentID,
                //                   f.Date,
                //                   //f.Remarks,
                //                   f.Amount,
                //                   // f.Write


                //               };

                //if (getdata2.Any())
                //{
                //    foreach (var b in getdata2)
                //    {
                //        dataGridView8.Rows.Add(b.PaymentID, b.Date, "Collection", null, "0", "0", "0", b.Amount, "0");
                //        //dataGridView8.DefaultCellStyle.ForeColor = Color.Blue;
                //    }
                //}

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



                var getdata1 = from f in db.Edison_ImportCostingHDRs
                              join c in db.Edison_ImportCostingDTLs on f.CostingID equals c.CostingID into ps
                              from c in ps.DefaultIfEmpty()
                              where c.ProductID.Equals(searchLookUpEdit6.EditValue) && (f.ArrivalDate >= LD_FromDate.Value.Date) && f.ArrivalDate <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                              select new
                              {
                                  f.CostingID,
                                  f.ArrivalDate,

                                  c.QtyInNos,
                                  f.SupplierID,

                              };

                if (getdata1.Any())
                {


                    foreach (var a in getdata1)
                    {
                        dataGridView8.Rows.Add(a.CostingID, a.ArrivalDate, "Import Costing Invoice # " + a.CostingID, null, null, null, a.QtyInNos, "0", "0");
                    }

                }

                var getdata223 = from f in db.Edison_SupplierPurch_HDRs
                                join c in db.Edison_SupplierPurch_DTLs on f.Edison_SupplierPurchID equals c.Edison_SupplierPurchID into ps
                                from c in ps.DefaultIfEmpty()
                                 where c.PID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                                 select new
                                {
                                    f.Edison_SupplierPurchID,
                                    f.Date,
                                    c.Qty,
                                    f.SupplierID,

                                };

                if (getdata223.Any())
                {


                    foreach (var a in getdata223)
                    {
                        dataGridView8.Rows.Add(a.Edison_SupplierPurchID, a.Date, "Supplier Purchase # " + a.Edison_SupplierPurchID, null, null, null, a.Qty, "0", "0");
                    }

                }





                var getAdjustments11 = from f in db.Edison_StockAdjustments
                                     where f.PID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) && (f.StockType == "STOCK")
                                       select new
                                     {
                                         f.StockAdjustmentID,
                                         f.Date,
                                         //f.DispatchNo,
                                         f.TotalQty,
                                         f.Remarks,


                                     };

                if (getAdjustments11.Any())
                {


                    foreach (var a in getAdjustments11)
                    {
                        dataGridView8.Rows.Add(a.StockAdjustmentID, a.Date, "ADJUSTMENT -->" + a.Remarks, a.StockAdjustmentID, null, null, a.TotalQty, "0", "0");
                    }

                }




                var getreturn1 = from f in db.Edison_DispatchHDRs
                                  join c in db.Edison_DispatchDTLs on f.DispatchNo equals c.DispatchNo into ps
                                  from c in ps.DefaultIfEmpty()
                                  where c.ProductID.Equals(searchLookUpEdit6.EditValue) && (f.DispatchDate >= LD_FromDate.Value.Date) && f.DispatchDate <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                                  select new
                                  {
                                      f.DispatchNo,
                                      f.DispatchDate,
                                      //f.DispatchNo,
                                      c.StockIssued,
                                      c.StockReturn,


                                  };

                if (getreturn1.Any())
                {


                    foreach (var a in getreturn1)
                    {
                        dataGridView8.Rows.Add(a.DispatchNo, a.DispatchDate, "Dispatch # " + a.DispatchNo, a.DispatchNo, null, null, "0", "0", (a.StockIssued - a.StockReturn));
                    }

                }




                var getSalesReturn11 = from f in db.Edison_SupplierPurchReturn_HDRs
                                     join c in db.Edison_SupplierPurchReturn_DTLs on f.Edison_SupplierPurchReturnID equals c.Edison_SupplierPurchID into ps
                                     from c in ps.DefaultIfEmpty()
                                     where c.PID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)) && c.StockType == "STOCK"
                                     select new
                                     {
                                         f.Edison_SupplierPurchReturnID,
                                         f.Date,
                                         //f.DispatchNo,
                                         c.Qty,



                                     };

                if (getSalesReturn11.Any())
                {


                    foreach (var a in getSalesReturn11)
                    {
                        dataGridView8.Rows.Add(a.Edison_SupplierPurchReturnID, a.Date, "Sales Return # " + a.Edison_SupplierPurchReturnID , a.Edison_SupplierPurchReturnID, null, null, "0", "0", (a.Qty));
                    }

                }



                //var getdata22 = from f in db.Edison_DispatchPayments
                //                where f.CustID.Equals(searchLookUpEdit6.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                //                select new
                //                {
                //                    f.PaymentID,
                //                    f.Date,
                //                    //f.Remarks,
                //                    f.Amount,
                //                    // f.Write


                //                };

                //if (getdata22.Any())
                //{
                //    foreach (var b in getdata22)
                //    {
                //        dataGridView8.Rows.Add(b.PaymentID, b.Date, "Collection", null, "0", "0", "0", b.Amount, "0");
                //        //dataGridView8.DefaultCellStyle.ForeColor = Color.Blue;
                //    }
                //}




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




                textBox11.BackColor = Color.Beige;
                textBox12.BackColor = Color.MistyRose;
                textBox13.BackColor = Color.LightSkyBlue;
                textBox14.BackColor = Color.Khaki;
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

                sumLedger();
                dataGridView8.ClearSelection();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string[] sp = new string[] { "DailyStockreport " + dateTimePicker1.Value.Date + "," + dateTimePicker2 .Value.Date};
            ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DailyStockReport.rdlc", null,null,null);
            Viewer.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            string[] sp = new string[] { "DailyStockreport '" + dateTimePicker4.Value.Date.ToString("yyyy-MM-dd") + "','" + dateTimePicker3.Value.Date.ToString("yyyy-MM-dd") + "'", "DailyREPreport '" + dateTimePicker4.Value.Date.ToString("yyyy-MM-dd") + "','" + dateTimePicker3.Value.Date.ToString("yyyy-MM-dd") + "'" };
            ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DailyStockReport.rdlc", "", "", "");
            Viewer.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            string[] sp = new string[] { "Edison_Stock"};
            ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.CurrentStockPositionValue.rdlc", "", "", "");
            Viewer.ShowDialog();
        }

        private void dataGridView13_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void AdjustmentAddState()
        {

            INV_btnAdd.Visible = false;
            INV_btnSave.Visible = true;
            INV_btnRevert.Visible = true;
        }

        private void AdjustmentRevertState()
        {

            INV_btnAdd.Visible = true;
            INV_btnSave.Visible = false;
            INV_btnRevert.Visible = false;
        }

        private void AdjustmentClearAll()
        {
            comboBoxEdit1.Text = "";
            searchLookUpEdit1.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox3.Text = "";
        }

        private void AdjusmentEnableState()
        {
            comboBoxEdit1.Enabled = true;
            dateTimePicker5.Enabled = true;
            searchLookUpEdit1.Enabled = true;
            textBox24.Enabled = true;
            textBox25.Enabled = true;
        }

        private void AdjusmentDisableState()
        {
            comboBoxEdit1.Enabled = false;
            dateTimePicker5.Enabled = false;
            searchLookUpEdit1.Enabled = false;
            textBox24.Enabled = false;
            textBox25.Enabled = false;
        }

        private void INV_btnAdd_Click(object sender, EventArgs e)
        {
            AdjustmentAddState();
            AdjustmentClearAll();
            AdjusmentEnableState();

            this.stockAdjustmentGridTableAdapter.Fill(this.dataSet1.StockAdjustmentGrid);
            this.edison_ProductListTableAdapter.Fill(this.dataSet11.Edison_ProductList);

            dateTimePicker5.Focus();
        }

        private void INV_btnRevert_Click(object sender, EventArgs e)
        {
            AdjustmentRevertState();
            AdjustmentClearAll();
            AdjusmentEnableState();
        }

        private void INV_btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveAdjustments()
        {
            try
            {
                if (!string.IsNullOrEmpty(searchLookUpEdit1.Text) && !string.IsNullOrEmpty(textBox24.Text))
                {




                    using (TransactionScope scope = new TransactionScope())
                    {
                        DataClasses1DataContext db = new DataClasses1DataContext();



                        Edison_StockAdjustment AddNew = new Edison_StockAdjustment();

                        AddNew.Date = dateTimePicker5.Value;

                        AddNew.PID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                        AddNew.TotalQty = Convert.ToInt32(textBox24.Text == "" ? "0" : textBox24.Text);
                        AddNew.Remarks = textBox25.Text.Trim();
                        AddNew.StockType = comboBoxEdit1.Text.Trim();

                        db.Edison_StockAdjustments.InsertOnSubmit(AddNew);
                        db.SubmitChanges();

                        db.Dispose();
                        scope.Complete();


                        //MessageBox.Show("Confirmation Message! Stock Has been Added/Removed");

                    }

                }

                AdjustmentRevertState();
                AdjusmentDisableState();


                this.stockAdjustmentGridTableAdapter.Fill(this.dataSet1.StockAdjustmentGrid);
                this.edison_ProductListTableAdapter.Fill(this.dataSet11.Edison_ProductList);


                INV_btnAdd.Focus();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void dateTimePicker5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                comboBoxEdit1.Focus();
                comboBoxEdit1.ShowPopup();
            }
        }

        private void textBox24_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
            {
                textBox25.Focus();
            }

        }

        private void textBox25_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                INV_btnSave.Focus();
            }
        }

        private void INV_btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            SaveAdjustments();
        }

        private void INV_btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveAdjustments();
            }
        }

        private void comboBoxEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox24.Focus();
            }
        }
    }
}
