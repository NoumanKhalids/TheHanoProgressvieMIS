using Microsoft.Reporting.WinForms;
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
    public partial class Edison_Reports : Form
    {
        public Edison_Reports()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string[] sp = new string[] { "DayConsolidate '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "', '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'" , "DayConsolidatePrev '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "', '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'", "DayConsolidateSale '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "', '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'" };
            //ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DaywiseConsolidate.rdlc", "", "", "");
            //Viewer.ShowDialog();

            string[] sp = new string[] { "DailySaleSummary '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "', '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'", "Sp_SalesTargetValue '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'", "Sp_RecoveryTargetValue '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'", "Sp_UpToDateSummary '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'", "Sp_SalesDetail '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'", "Sp_RecoveryDetails '" + dateTimePicker1.Value.Date.ToString("yyyy-MM-dd") + "'" };

            //string[] sp = new string[] { "sp_OrderFrmHDR " + SavedOrderNo.Text, "sp_OrderFrmDTL " + SavedOrderNo.Text, "select dbo.fn_OrderSiz(" + SavedOrderNo.Text + ") as Packing" };

            ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DailySaleSummary.rdlc", "", "", "");
            Viewer.ShowDialog(); 
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //this.invoicingItemsTableAdapter.Fill(this.dataSet1.InvoicingItems, Convert.ToInt32(InvDispatchNo.EditValue));
            this.dailySaleSummaryTableAdapter.Fill(this.dataSet1.DailySaleSummary, dateTimePicker1.Value.Date, dateTimePicker1.Value.Date);


        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {

            string[] sp = new string[] { "DailySeperateDetailVanWise '" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd") + "', '" + dateTimePicker3.Value.Date.ToString("yyyy-MM-dd") + "'," + searchLookUpEdit1.EditValue };

            //string[] sp = new string[] { "sp_OrderFrmHDR " + SavedOrderNo.Text, "sp_OrderFrmDTL " + SavedOrderNo.Text, "select dbo.fn_OrderSiz(" + SavedOrderNo.Text + ") as Packing" };

            ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DailySeperateDetailVanWise.rdlc", "", "", "");
            Viewer.ShowDialog();
        }

        private void Edison_Reports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Edison_Van' table. You can move, or remove it, as needed.
            this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);

            this.reportViewer1.RefreshReport();
        }


        string code = "";
        string Name = "";
        string Address = "";
        private void getLedger()
        {
            try
            {
                dataGridView8.Rows.Clear();
                dataGridView8.Refresh();

                DataClasses1DataContext db = new DataClasses1DataContext();
                db.ObjectTrackingEnabled = false;

             




                DateTime cdate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                cdate = cdate.AddDays(-60);



                var GetCustomerVanWise = from w in db.All_Customers
                                        where w.VanID.Equals(searchLookUpEdit2.EditValue)
                                        select new
                                        {
                                            w.CustID,
                                            w.CustomerName,
                                            w.CustomerAddress,
                                        };


                if (GetCustomerVanWise.Any())
                {


                    foreach (var abs in GetCustomerVanWise)
                    {

                        code = abs.CustID.ToString();

                        Name = abs.CustomerName.ToString();

                        Address = abs.CustomerAddress.ToString();

                //    dataGridView1.Rows.Add(null, null, "Opening Balance", null, null, "0", "0", "0", "0", a.OpeningBalance1);
                //    this.DataSet1.Ledger.Rows.Clear();

                //code = (searchLookUpEdit6).ToString();

                //           txtBalance.Text = Convert.ToDecimal(a.Balance).ToString("#,##0.00");


                // break;




                // ---------------------------------------------------------------
                var getopeningbalance = from w in db.All_Customers
                                        where w.CustID.Equals(code)
                                        select new
                                        {
                                            w.OpeningBalance1,

                                        };


                if (getopeningbalance.Any())
                {


                    foreach (var a in getopeningbalance)
                    {
                        dataGridView1.Rows.Add(null, null, "Opening Balance", null, null, "0", "0", "0", "0", a.OpeningBalance1);
                        //    this.DataSet1.Ledger.Rows.Clear();

                      //  code = (searchLookUpEdit6).ToString();

                        //           txtBalance.Text = Convert.ToDecimal(a.Balance).ToString("#,##0.00");


                        break;
                    }
                }
                //------------------------------------------------------------------



                var getdata = from f in db.Edison_InvoiceHDRs
                              where f.CustID.Equals(code) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
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
                        dataGridView1.Rows.Add(a.InvoiceID, a.Date, "Invoice", a.DispatchNo, null, null, a.TotalAmount, "0", "0");
                    }

                }



                var getreturn11 = from f in db.Edison_SalesReturnHDRs
                                  where f.CustID.Equals(code) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
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
                        dataGridView1.Rows.Add(a.SalesReturnID, a.Date, "Sale Return", a.DispatchNo, null, null, "0", "0", a.TotalAmount);
                    }

                }


                var getdata2 = from f in db.Edison_DispatchPayments
                               where f.CustID.Equals(code) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
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
                        dataGridView1.Rows.Add(b.PaymentID, b.Date, "Collection", null, "0", "0", "0", b.Amount, "0");
                        //dataGridView1.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }

                dataGridView1.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";

                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
                this.dataGridView1.Columns[1].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;




                for (int i = 1; i < dataGridView1.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView1[6, i].Value) == 0) && ((Convert.ToDecimal(dataGridView1[7, i].Value) != 0) || (Convert.ToDecimal(dataGridView1[8, i].Value) != 0)))
                    {
                        dataGridView1[9, i].Value = Convert.ToDecimal(dataGridView1[9, i - 1].Value) - Convert.ToDecimal(dataGridView1[7, i].Value) - Convert.ToDecimal(dataGridView1[8, i].Value);
                    }
                    else
                    {
                        dataGridView1[9, i].Value = (Convert.ToDecimal(dataGridView1[6, i].Value) + Convert.ToDecimal(dataGridView1[8, i].Value) + Convert.ToDecimal(dataGridView1[9, i - 1].Value));

                    }

                }



                //--------------------------------------------------------------------------------------------------------------------------------------------------------------


                decimal getvalue = 0;


                Int32 index = dataGridView1.Rows.Count - 1;

                getvalue = Convert.ToDecimal(dataGridView1[9, index].Value);





                        dataGridView1.Rows.Clear();
                dataGridView1.Refresh();


                // ---------------------------------------------------------------

                // dataGridView8.Rows.Add(null, "Opening Balance", null, null, null, null, null, null, getvalue.ToString("#,##0.00"));

                dataGridView8.Rows.Add(null, null, "Opening Balance", null, "0", "0", "0", "0", "0", getvalue.ToString("#,##0.00"), "0", code, Name, Address);


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
                //               where g.Key.CustID == Convert.ToInt32(code) &&
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
                               where f.CustID.Equals(code) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
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
                        dataGridView8.Rows.Add(a.InvoiceID, a.Date, "Invoice (Dispatch # " + a.DispatchNo + ")", a.InvoiceID, null, null, a.TotalAmount, "0", "0", null, null, code, Name, Address);
                    }

                }






                var getreturn1 = from f in db.Edison_SalesReturnHDRs
                                 where f.CustID.Equals(code) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
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
                        dataGridView8.Rows.Add(a.SalesReturnID, a.Date, "Sale Return", a.DispatchNo, null, null, "0", "0", a.TotalAmount, null,null, code,Name, Address);
                    }

                }


                var getdata22 = from f in db.Edison_DispatchPayments
                                where f.CustID.Equals(code) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
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
                        dataGridView8.Rows.Add(b.PaymentID, b.Date, "Collection", null, "0", "0", "0", b.Amount, "0", null,null,code,Name,Address);
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
                //    DataSet1.Ledger.Rows.Add(code, LedgerCustomerName.Text, LedgerCAddress.Text, LedgerCity.Text, LD_FromDate.Value.Date, LD_ToDate.Value.DATE, dataGridView8[0, i].Value, dataGridView8[7, i].Value, dataGridView8[10, i].Value, dataGridView8[12, i].Value, dataGridView8[16, i].Value, dataGridView8[18, i].Value, dataGridView8[19, i].Value, dataGridView8[20, i].Value, dataGridView8[21, i].Value);
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



                //   txtPerDay.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)*7) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + code + ") And Posted = 1")[0];

                //   txtPerWeekLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + code + ") And Posted = 1")[0];

                //   txtPerMonthLedger.Text = GM.GetRecords("SELECT  CAST(Sum(CollectionAmount)/((DATEDIFF(d, Min(Date), getdate())/7)/4) as decimal(18,2)) as Average FROM CustomerCollection WHERE (Code =" + code + ") And Posted = 1")[0];

                dataGridView8.ClearSelection();

                        foreach (DataGridViewRow row in dataGridView8.Rows)
                        {
                            if(dataGridView8.Rows.Count > 0)
                            {
                                dataGridView2.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value, row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value, row.Cells[13].Value);
                            }
                            //  currQty += row.Cells["qty"].Value;
                           
                            //More code here
                        }
                        dataGridView2.Rows.Add(null, null, null, null, null, null, null, null, null, null, null, null, null, null);
                        dataGridView8.Rows.Clear();



                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
           



            if (reportViewer1.Visible == false)
            {
                reportViewer1.Visible = true;
                getLedger();


                this.dataSet2.CustomerLedgerPrintFromTo.Rows.Clear();

                foreach (DataGridViewRow Row in dataGridView2.Rows)
                {
                    this.dataSet2.CustomerLedgerPrintFromTo.Rows.Add((dataGridView2.Rows[Row.Index].Cells[0].Value), (dataGridView2.Rows[Row.Index].Cells[1].Value), (dataGridView2.Rows[Row.Index].Cells[2].Value), (dataGridView2.Rows[Row.Index].Cells[3].Value), (dataGridView2.Rows[Row.Index].Cells[4].Value), (dataGridView2.Rows[Row.Index].Cells[5].Value), (dataGridView2.Rows[Row.Index].Cells[6].Value), (dataGridView2.Rows[Row.Index].Cells[7].Value), (dataGridView2.Rows[Row.Index].Cells[8].Value), (dataGridView2.Rows[Row.Index].Cells[9].Value), (dataGridView2.Rows[Row.Index].Cells[10].Value), (dataGridView2.Rows[Row.Index].Cells[11].Value), (dataGridView2.Rows[Row.Index].Cells[12].Value), (dataGridView2.Rows[Row.Index].Cells[13].Value));
                }


                this.reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.Reset();
                reportViewer1.LocalReport.ReportEmbeddedResource = "MIS_ProgressiveDistributors.VanwiseLedgerReport.rdlc";

                //  searchstatus();

                ReportDataSource rprtDTSource = new ReportDataSource();
                rprtDTSource.Name = "DataSet1";
                rprtDTSource.Value = this.dataSet2.CustomerLedgerPrintFromTo;
                this.reportViewer1.LocalReport.DataSources.Add(rprtDTSource);
                this.reportViewer1.RefreshReport();

            }
            else
            {
                reportViewer1.Visible = false;
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            string[] sp = new string[] { "sp_Edison_ProductConsolidate '" + dateTimePicker5.Value.Date.ToString("yyyy-MM-dd") + "', '" + dateTimePicker4.Value.Date.ToString("yyyy-MM-dd") + "'", "sp_Edison_ProductConsolidatePrev '" + dateTimePicker5.Value.Date.ToString("yyyy-MM-dd") + "'", "DailySalesDetails '" + dateTimePicker5.Value.Date.ToString("yyyy-MM-dd") + "'", "DailySalesDetailsPrev '" + dateTimePicker5.Value.Date.ToString("yyyy-MM-dd") + "'" };

            //string[] sp = new string[] { "sp_OrderFrmHDR " + SavedOrderNo.Text, "sp_OrderFrmDTL " + SavedOrderNo.Text, "select dbo.fn_OrderSiz(" + SavedOrderNo.Text + ") as Packing" };

            ReportViewer Viewer = new ReportViewer(sp, "MIS_ProgressiveDistributors.DailyConsolidate.rdlc", "", "", "");
            Viewer.ShowDialog();
        }
    }
}
