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
    public partial class AllBanks : Form
    {
        public AllBanks()
        {
            InitializeComponent();
        }

        private void SaveBankAccount()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                All_BankAccountsTable AddNew = new All_BankAccountsTable();

                AddNew.SystemDate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                AddNew.Title = textBox2.Text.Trim();
                AddNew.AccountNo = textBox3.Text.Trim();
                AddNew.BankID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                AddNew.Branch = textBox4.Text.Trim();
                AddNew.BranchCode = textBox5.Text.Trim();

                if(!string.IsNullOrEmpty(textBox6.Text))
                {
                    AddNew.OpeningBalance = Convert.ToDecimal(textBox6.Text);
                }
                else
                {
                    AddNew.OpeningBalance = 0;
                }
              



                if (checkBox1.Checked == true)
                {
                    AddNew.Discountinued = true;
                }
                else
                {
                    AddNew.Discountinued = false;
                }

                db.All_BankAccountsTables.InsertOnSubmit(AddNew);
                db.SubmitChanges();

                this.all_BanksTableAdapter.Fill(this.dataSet1.All_Banks);
                this.bankAccountsTableTableAdapter.Fill(this.dataSet1.BankAccountsTable);

                RegisterDisableAll();
                RegisterRevertState();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }
        private void btnRegSave_Click(object sender, EventArgs e)
        {
   
        }

        private void AllBanks_Load(object sender, EventArgs e)
        {        
            this.all_BanksTableAdapter.Fill(this.dataSet1.All_Banks);
            this.bankAccountsTableTableAdapter.Fill(this.dataSet1.BankAccountsTable);

        }

        private void RegisterClearAll()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            searchLookUpEdit1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            checkBox1.Checked = false;

        }

        private void RegisterEnableAll()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;

            searchLookUpEdit1.Enabled = true;

            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void RegisterDisableAll()
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;

            searchLookUpEdit1.Enabled = false;

            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void RegisterAddState()
        {
            btnRegAdd.Visible = false;
            btnRegRevert.Visible = true;
            btnRegSave.Visible = true;
            btnRegEdit.Visible = false;
            btnRegEditSave.Visible = false;
        }

        private void RegisterRevertState()
        {

            btnRegAdd.Visible = true;
            btnRegRevert.Visible = false;
            btnRegSave.Visible = false;
            btnRegEdit.Visible = true;
            btnRegEditSave.Visible = false;

        }


        private void RegisterEditSaveState()
        {
            btnRegAdd.Visible = false;
            btnRegRevert.Visible = true;
            btnRegSave.Visible = false;
            btnRegEdit.Visible = false;
            btnRegEditSave.Visible = true;
        }

        private void btnRegAdd_Click(object sender, EventArgs e)
        {
            RegisterAddState();
            RegisterEnableAll();
            textBox2.Focus();
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                searchLookUpEdit1.Focus();
                searchLookUpEdit1.ShowPopup();
            }
        }

        private void searchLookUpEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();

            }
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void btnRegSave_MouseClick(object sender, MouseEventArgs e)
        {
            SaveBankAccount();
        }

        private void btnRegSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveBankAccount();
            }
        }

        private void textBox6_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(btnRegSave.Visible == true)
                {
                    btnRegSave.Focus();
                }
                else if (btnRegEditSave.Visible == true)
                {
                    btnRegEditSave.Focus();
                }
            }
        }

        private void btnRegRevert_Click(object sender, EventArgs e)
        {
            RegisterRevertState();
            RegisterDisableAll();
        }

        private void btnRegEdit_Click(object sender, EventArgs e)
        {
            RegisterEditSaveState();
            RegisterEnableAll();
            textBox2.Focus();
        }

      

        private void btnRegEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            EditSaveUpdate();
        }

        private void btnRegEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EditSaveUpdate();
            }
        }

        int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                id = Convert.ToInt32(selectedRow.Cells[0].Value);




                DataClasses1DataContext db;
                db = new DataClasses1DataContext();




                var getTheOrderDetail = from d in db.All_BankAccountsTables
                                        where d.Code.Equals(Convert.ToInt32(selectedRow.Cells[0].Value))
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach(var ab in getTheOrderDetail)
                    {
                        textBox1.Text = ab.Code.ToString();
                        textBox2.Text = ab.Title.ToString();
                        textBox3.Text = ab.AccountNo.ToString();
                        searchLookUpEdit1.EditValue = ab.BankID.ToString();
                        textBox4.Text = ab.Branch.ToString();
                        textBox5.Text = ab.BranchCode.ToString();
                        textBox6.Text = ab.OpeningBalance.ToString();

                        if(ab.Discountinued == true)
                        {
                            checkBox1.Checked = true;
                        }
                        else if(ab.Discountinued == false)
                        {
                            checkBox1.Checked = false;
                        }

                        break;
                    }

            


                }
                else
                {
                    //textBox1.Text = "";
                    //textBox2.Text = "";
                    //textBox3.Text = "";
                    //searchLookUpEdit1.EditValue = "";
                    //textBox4.Text = "";
                    //textBox5.Text = "";
                    //textBox6.Text = "";
                }

            }
        }

        private void btnRegEditSave_Click(object sender, EventArgs e)
        {

        }

        private void btnRegSave_Click_1(object sender, EventArgs e)
        {

        }

        private void EditSaveUpdate()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheOrderDetail = from d in db.All_BankAccountsTables
                                        where d.Code.Equals(Convert.ToInt32(textBox1.Text))
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var AddNew in getTheOrderDetail)
                    {

                     //   AddNew.SystemDate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                        AddNew.Title = textBox2.Text.Trim();
                        AddNew.AccountNo = textBox3.Text.Trim();
                        AddNew.BankID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                        AddNew.Branch = textBox4.Text.Trim();
                        AddNew.BranchCode = textBox5.Text.Trim();

                        if (!string.IsNullOrEmpty(textBox6.Text))
                        {
                            AddNew.OpeningBalance = Convert.ToDecimal(textBox6.Text);
                        }
                        else
                        {
                            AddNew.OpeningBalance = 0;
                        }




                        if (checkBox1.Checked == true)
                        {
                            AddNew.Discountinued = true;
                        }
                        else
                        {
                            AddNew.Discountinued = false;
                        }
                    }

                    db.SubmitChanges();

                    this.all_BanksTableAdapter.Fill(this.dataSet1.All_Banks);
                    this.bankAccountsTableTableAdapter.Fill(this.dataSet1.BankAccountsTable);

                    RegisterDisableAll();
                    RegisterRevertState();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void btnWDRAdd_Click(object sender, EventArgs e)
        {
            WDRClearAll();
            WDREnableAll();
            WithDrawalAddState();
            searchLookUpEdit2.Focus();
            searchLookUpEdit2.ShowPopup();
        }

        private void WDRClearAll()
        {
            textBox8.Text = "";
            searchLookUpEdit2.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
        }

        private void WDREnableAll()
        {
            searchLookUpEdit2.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
        }

        private void WDRDisableAll()
        {
            searchLookUpEdit2.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
        }

        private void searchLookUpEdit2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if(e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
            }


        }

        private void textBox11_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox12.Focus();
            }

        }

        private void textBox12_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
            }
        }

        private void textBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           

            if (e.KeyCode == Keys.Enter)
            {
                if (btnWDRSave.Visible == true)
                {
                    btnWDRSave.Focus();
                }
                else if (btnWDREditSave.Visible == true)
                {
                    btnWDREditSave.Focus();
                }
            }
        }


        private void WDRSave()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                All_BankAccountsWithdrawal AddNew = new All_BankAccountsWithdrawal();

                AddNew.SystemDate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                AddNew.BankID = Convert.ToInt32(searchLookUpEdit2.EditValue);

                AddNew.ChequeAmount = (Convert.ToDecimal(textBox11.Text == "" ? "0" : textBox11.Text));
                AddNew.TaxDeduction = (Convert.ToDecimal(textBox12.Text == "" ? "0" : textBox12.Text));

                AddNew.Remarks = textBox13.Text.Trim();
                          

                db.All_BankAccountsWithdrawals.InsertOnSubmit(AddNew);
                db.SubmitChanges();

                textBox8.Text = AddNew.BankWithDrawID.ToString() ;

                WDRDisableAll();
                WithDrawalRevertState();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void WDREditSave()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheOrderDetail = from d in db.All_BankAccountsWithdrawals
                                        where d.BankWithDrawID.Equals(Convert.ToInt32(textBox8.Text))
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var AddNew in getTheOrderDetail)
                    {

                       // AddNew.SystemDate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                        AddNew.BankID = Convert.ToInt32(searchLookUpEdit2.EditValue);

                     
                        AddNew.ChequeAmount = (Convert.ToDecimal(textBox11.Text == "" ? "0" : textBox11.Text));
                        AddNew.TaxDeduction = (Convert.ToDecimal(textBox12.Text == "" ? "0" : textBox12.Text));
                        AddNew.Remarks = textBox13.Text.Trim();

                        db.SubmitChanges();
                    }
                }

                WDRDisableAll();
                WithDrawalRevertState();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }


        private void btnWDRSave_MouseClick(object sender, MouseEventArgs e)
        {
            WDRSave();
        }

        private void btnWDRSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                WDRSave();
            }
        }

        private void btnWDREdit_Click(object sender, EventArgs e)
        {
            WithDrawalEditSaveState();
            WDREnableAll();
            searchLookUpEdit2.Focus();

        }

        private void searchLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (searchLookUpEdit2.Text == "")
            {
                textBox9.Text = "";
                textBox10.Text = "";
            }
            else
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheOrderDetail = from d in db.All_BankAccountsTables

                                        join c in db.All_Banks on d.BankID equals c.BankID into ps
                                        from c in ps.DefaultIfEmpty()

                                        where d.Code.Equals(searchLookUpEdit2.EditValue)
                                        select new
                                        {
                                            d.AccountNo,
                                            c.BankName,
                                        };

                if (getTheOrderDetail.Any())
                {
                    foreach (var AddNew in getTheOrderDetail)
                    {
                        textBox9.Text = AddNew.AccountNo.ToString();
                        textBox10.Text = AddNew.BankName.ToString();
                        break;
                    }
                }

            }
        }

        private void btnWDREditSave_MouseClick(object sender, MouseEventArgs e)
        {
            WDREditSave();
        }

        private void btnWDREditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                WDREditSave();
            }
        }

        private void WithDrawalAddState()
        {
            btnWDRAdd.Visible = false;
            btnWDRRevert.Visible = true;
            btnWDRSave.Visible = true;
            btnWDREdit.Visible = false;
            btnWDREditSave.Visible = false;
        }

        private void WithDrawalRevertState()
        {

            btnWDRAdd.Visible = true;
            btnWDRRevert.Visible = false;
            btnWDRSave.Visible = false;
            btnWDREdit.Visible = true;
            btnWDREditSave.Visible = false;

        }


        private void WithDrawalEditSaveState()
        {
            btnWDRAdd.Visible = false;
            btnWDRRevert.Visible = true;
            btnWDRSave.Visible = false;
            btnWDREdit.Visible = false;
            btnWDREditSave.Visible = true;
        }

        private void btnWDRRevert_Click(object sender, EventArgs e)
        {
            WithDrawalRevertState();
            WDRClearAll();
            WDRDisableAll();

        }

        private void btnWDRSave_Click(object sender, EventArgs e)
        {

        }

        private void btnWDREditSave_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchLookUpEdit2.Focus();
                searchLookUpEdit2.ShowPopup();

            }
        }

        private void btnWDRSearch_Click(object sender, EventArgs e)
        {
            textBox8.Enabled = true;
            textBox8.Focus();
        }

        private void getwithdrawals()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var getTheOrderDetail = from d in db.All_BankAccountsWithdrawals
                                    where d.BankWithDrawID.Equals(Convert.ToInt32(textBox8.Text))
                                    select d;

            if (getTheOrderDetail.Any())
            {
                foreach (var a in getTheOrderDetail)
                {
                    searchLookUpEdit2.EditValue = a.BankID.ToString();
                    textBox11.Text = a.ChequeAmount.ToString();
                    textBox12.Text = a.TaxDeduction.ToString();
                    textBox13.Text = a.Remarks.ToString();
                    break;
                }
            }
            else
            {
                searchLookUpEdit2.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";

                MessageBox.Show("Entry Not Found");
            }

            db.Dispose();
        }
        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getwithdrawals();
            }
        }

        private void searchLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            if (searchLookUpEdit3.Text == "")
            {
                textBox9.Text = "";
                textBox10.Text = "";
            }
            else
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheOrderDetail = from d in db.All_BankAccountsTables

                                        join c in db.All_Banks on d.BankID equals c.BankID into ps
                                        from c in ps.DefaultIfEmpty()

                                        where d.Code.Equals(searchLookUpEdit3.EditValue)
                                        select new
                                        {
                                            d.AccountNo,
                                            c.BankName,
                                        };

                if (getTheOrderDetail.Any())
                {
                    foreach (var AddNew in getTheOrderDetail)
                    {
                        textBox18.Text = AddNew.AccountNo.ToString();
                        textBox17.Text = AddNew.BankName.ToString();
                        break;
                    }
                }

            }
        }

        private void searchLookUpEdit3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox16.Focus();
            }
        }

        private void textBox16_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox14.Focus();
            }
        }


        private void DPEnableAll()
        {
            dateTimePicker2.Enabled = true;
            searchLookUpEdit3.Enabled = true;
            textBox16.Enabled = true;
            textBox14.Enabled = true;
        }

        private void DPDisableAll()
        {
            dateTimePicker2.Enabled = false;
            searchLookUpEdit3.Enabled = false;
            textBox16.Enabled = false;
            textBox14.Enabled = false;
        }

        private void DPClearAll()
        {
            dateTimePicker2.Value = DateTime.Now;

            searchLookUpEdit3.Text = "";
            textBox16.Text = "";
            textBox14.Text = "";

            textBox19.Text = "";
            textBox18.Text = "";
            textBox17.Text = "";
        }




        private void btnDPSave_MouseClick(object sender, MouseEventArgs e)
        {
            DPSave();
        }

        private void btnDPSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DPSave();

            }
        }

        private void DPSave()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                All_BankDeposit AddNew = new All_BankDeposit();

                AddNew.SystemDate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                AddNew.Date = dateTimePicker2.Value;

                AddNew.BankID = Convert.ToInt32(searchLookUpEdit3.EditValue);

                AddNew.DepositedAmount = (Convert.ToDecimal(textBox16.Text == "" ? "0" : textBox16.Text));


                AddNew.Remarks = textBox14.Text.Trim();


                db.All_BankDeposits.InsertOnSubmit(AddNew);
                db.SubmitChanges();

                textBox19.Text = AddNew.BankDepositID.ToString();

                DPDisableAll();
                DPRevertState();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void DPAddState()
        {
            btnDPAdd.Visible = false;
            btnDPRevert.Visible = true;
            btnDPSave.Visible = true;
            btnDPEdit.Visible = false;
            btnDPEditSave.Visible = false;
        }

        private void DPRevertState()
        {

            btnDPAdd.Visible = true;
            btnDPRevert.Visible = false;
            btnDPSave.Visible = false;
            btnDPEdit.Visible = true;
            btnDPEditSave.Visible = false;

        }


        private void DPEditSaveState()
        {
            btnDPAdd.Visible = false;
            btnDPRevert.Visible = true;
            btnDPSave.Visible = false;
            btnDPEdit.Visible = false;
            btnDPEditSave.Visible = true;
        }

        private void btnDPSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDPRevert_Click(object sender, EventArgs e)
        {
            DPDisableAll();
            DPClearAll();
            DPRevertState();
        }

        private void btnDPAdd_Click(object sender, EventArgs e)
        {
            DPAddState();
            DPEnableAll();
            DPClearAll();
            dateTimePicker2.Focus();
        }

        private void btnDPEdit_Click(object sender, EventArgs e)
        {
            DPEditSaveState();
            DPEnableAll();
            dateTimePicker2.Focus();
        }

        private void btnDPEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            DPEditSave();
        }

        private void btnDPEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
     if(e.KeyCode == Keys.Enter)
            {
                DPEditSave();
            }
        }

        private void DPEditSave()
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

            
                var getTheOrderDetail = from d in db.All_BankDeposits
                                        where d.BankDepositID.Equals(Convert.ToInt32(textBox19.Text))
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var AddNew in getTheOrderDetail)
                    {
                        AddNew.Date = dateTimePicker2.Value;
                        AddNew.BankID = Convert.ToInt32(searchLookUpEdit3.EditValue);
                        AddNew.DepositedAmount = (Convert.ToDecimal(textBox16.Text == "" ? "0" : textBox16.Text));
                        AddNew.Remarks = textBox14.Text.Trim();
            
                        db.SubmitChanges();                 
                    }
            

                    DPDisableAll();
                    DPRevertState();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void btnDPSearch_Click(object sender, EventArgs e)
        {
            textBox19.Enabled = true;
            textBox19.Focus();
            textBox19.SelectAll();
        }

        private void getdepositsinfo()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();


            var getTheOrderDetail = from d in db.All_BankDeposits
                                    where d.BankDepositID.Equals(Convert.ToInt32(textBox19.Text))
                                    select d;

            if (getTheOrderDetail.Any())
            {
                foreach (var a in getTheOrderDetail)
                {
                    dateTimePicker2.Value = Convert.ToDateTime(a.Date);
                    searchLookUpEdit3.EditValue = a.BankID;
                    textBox16.Text = a.DepositedAmount.ToString();
                    textBox14.Text = a.Remarks;
                    break;
                }
            }

            db.Dispose();
        }
        private void textBox19_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                getdepositsinfo();
            }
        }

        private void btnLedgerSearch_Click(object sender, EventArgs e)
        {
            GetLedger();
        }

        private void GetLedger()
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
                var getopeningbalance = from w in db.All_BankAccountsTables
                                        where w.Code.Equals(searchLookUpEdit4.EditValue)
                                        select new
                                        {
                                            w.OpeningBalance,                                    
                                        };


                if (getopeningbalance.Any())
                {


                    foreach (var a in getopeningbalance)
                    {
                        dataGridView2.Rows.Add(null, "Opening Balance", "0", "0", "0", a.OpeningBalance);
                        //    this.DataSet1.Ledger.Rows.Clear();

                        code = (searchLookUpEdit4).ToString();

                     //   txtBalance.Text = Convert.ToDecimal(a.Balance).ToString("#,##0.00");


                        break;
                    }
                }
                //------------------------------------------------------------------



                var getdata = from d in db.All_BankDeposits
                              where d.BankID.Equals(searchLookUpEdit4.EditValue) && (d.Date >= Convert.ToDateTime("2015-01-01") && d.Date < LD_FromDate.Value.Date)
                              select new
                              {
                                  d.BankDepositID,
                                  d.Date,
                                  d.Remarks,
                                  d.DepositedAmount,

                              };

                if (getdata.Any())
                {


                    foreach (var a in getdata)
                    {
                        dataGridView2.Rows.Add(a.Date, "DEPOSITED AMOUNT", a.DepositedAmount, "0", "0", "0", a.BankDepositID);
                    }

                }


                var getdata2 = from f in db.All_BankAccountsWithdrawals
                               where f.BankID.Equals(searchLookUpEdit4.EditValue) && (f.Date >= Convert.ToDateTime("2015-01-01") && f.Date < LD_FromDate.Value.Date)
                               select new
                               {
                                   f.Date,
                                   f.Remarks,
                                   f.ChequeAmount,
                                   f.TaxDeduction,                         
                               };

                if (getdata2.Any())
                {
                    foreach (var b in getdata2)
                    {
                        dataGridView2.Rows.Add(b.Date, "CASH WITHDRAWAL", "0", b.ChequeAmount, b.TaxDeduction, "0");
                        //dataGridView2.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }

                dataGridView2.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";

                dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);
                this.dataGridView2.Columns[0].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;




                for (int i = 1; i < dataGridView2.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView2[2, i].Value) == 0) && ((Convert.ToDecimal(dataGridView2[3, i].Value) != 0) || (Convert.ToDecimal(dataGridView2[4, i].Value) != 0)))
                    {
                        dataGridView2[5, i].Value = Convert.ToDecimal(dataGridView2[5, i - 1].Value) - Convert.ToDecimal(dataGridView2[3, i].Value) - Convert.ToDecimal(dataGridView2[4, i].Value);
                    }
                    else
                    {
                        dataGridView2[5, i].Value = (Convert.ToDecimal(dataGridView2[2, i].Value) + Convert.ToDecimal(dataGridView2[4, i].Value) + Convert.ToDecimal(dataGridView2[5, i - 1].Value));

                    }

                }



                //--------------------------------------------------------------------------------------------------------------------------------------------------------------


                decimal getvalue = 0;


                Int32 index = dataGridView2.Rows.Count - 1;

                getvalue = Convert.ToDecimal(dataGridView2[5, index].Value);





                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();


                // ---------------------------------------------------------------

                // dataGridView2.Rows.Add(null, "Opening Balance", null, null, null, null, null, null, getvalue.ToString("#,##0.00"));
                

                dataGridView2.Rows.Add(null, "Opening Balance", "0", "0", "0", getvalue.ToString("#,##0.00"));

                //------------------------------------------------------------------

                DataClasses1DataContext connection = new DataClasses1DataContext();

                connection.ObjectTrackingEnabled = false;


                var getdata1 = from d in db.All_BankDeposits
                              where d.BankID.Equals(searchLookUpEdit4.EditValue) && (d.Date >= LD_FromDate.Value.Date && d.Date <= LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                               select new
                               {
                                   d.BankDepositID,
                                   d.Date,
                                   d.Remarks,
                                   d.DepositedAmount,

                               };

                if (getdata1.Any())
                {


                    foreach (var a in getdata1)
                    {
                        dataGridView2.Rows.Add(a.Date, "DEPOSITED AMOUNT", a.DepositedAmount, "0", "0", "0", a.BankDepositID);
                    }

                }




       


                var getdata22 = from f in db.All_BankAccountsWithdrawals
                                where f.BankID.Equals(searchLookUpEdit4.EditValue) && (f.Date >= LD_FromDate.Value.Date) && f.Date <= (LD_ToDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59))
                                select new
                                {
                                    f.BankWithDrawID,
                                    f.Date,
                                    f.Remarks,
                                    f.ChequeAmount,
                                    f.TaxDeduction,
                                };

                if (getdata22.Any())
                {
                    foreach (var b in getdata22)
                    {
                        dataGridView2.Rows.Add(b.Date, "CASH WITHDRAWAL", "0", b.ChequeAmount, b.TaxDeduction, "0");
                        //dataGridView2.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }




                dataGridView2.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";


                dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);
                this.dataGridView2.Columns[0].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;



                for (int i = 1; i < dataGridView2.Rows.Count; i++)
                {

                    if ((Convert.ToDecimal(dataGridView2[2, i].Value) == 0) && ((Convert.ToDecimal(dataGridView2[3, i].Value) != 0) || (Convert.ToDecimal(dataGridView2[4, i].Value) != 0)))
                    {
                        dataGridView2[5, i].Value = Convert.ToDecimal(dataGridView2[5, i - 1].Value) - Convert.ToDecimal(dataGridView2[3, i].Value) - Convert.ToDecimal(dataGridView2[4, i].Value);
                    }
                    else
                    {
                        dataGridView2[5, i].Value = (Convert.ToDecimal(dataGridView2[2, i].Value) + Convert.ToDecimal(dataGridView2[4, i].Value) + Convert.ToDecimal(dataGridView2[5, i - 1].Value));

                    }

                }

                //for (int i = 1; i < dataGridView2.Rows.Count; i++)
                //{

                //    if ((Convert.ToDecimal(dataGridView2[5, i].Value) == 0) && (Convert.ToDecimal(dataGridView2[6, i].Value) != 0))
                //    {
                //        dataGridView2[8, i].Value = Convert.ToDecimal(dataGridView2[8, i - 1].Value) - Convert.ToDecimal(dataGridView2[6, i].Value);
                //    }
                //    else
                //    {
                //        dataGridView2[8, i].Value = (Convert.ToDecimal(dataGridView2[5, i].Value) + Convert.ToDecimal(dataGridView2[8, i - 1].Value));

                //    }

                //}

                foreach (DataGridViewRow Myrow in dataGridView2.Rows)
                {            //Here 2 cell is target value and 1 cell is Volume



                    //if (Convert.ToInt32(Myrow.Cells[9].Value) == 1)// Or your condition 
                    //{
                    //    Myrow.DefaultCellStyle.ForeColor = Color.Green;
                    //}


                    //if (Convert.ToInt32(Myrow.Cells[9].Value) == 2)// Or your condition 
                    //{
                    //    Myrow.DefaultCellStyle.ForeColor = Color.Blue;
                    //}

                }

                //        if ((Myrow.Cells[22].Value) == null)
                //        {
                //            Myrow.DefaultCellStyle.ForeColor = Color.Blue;
                //        }

                //    }



                //    if (Convert.ToDecimal(Myrow.Cells[19].Value) > 0)// Or your condition 
                //    {
                //        Myrow.DefaultCellStyle.ForeColor = Color.Black;
                //    }

                //    if (Convert.ToDecimal(Myrow.Cells[20].Value) > 0 && Myrow.Cells[4].Value.Equals("S/R"))// Or your condition 
                //    {
                //        Myrow.DefaultCellStyle.ForeColor = Color.MediumPurple;
                //    }

                //    if (Convert.ToDecimal(Myrow.Cells[20].Value) > 0 && Convert.ToDecimal(Myrow.Cells[19].Value) <= 0 && Myrow.Cells[4].Value.Equals("Cash"))// Or your condition 
                //    {
                //        Myrow.DefaultCellStyle.ForeColor = Color.Red;
                //    }

                //    if (Convert.ToInt32(Myrow.Cells[15].Value) > 0)// Or your condition 
                //    {
                //        Myrow.DefaultCellStyle.ForeColor = Color.Green;
                //    }

                //}

                //  dataGridView2.Columns[5].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView2.Columns[5].DefaultCellStyle.BackColor = Color.Beige;
                dataGridView2.Columns[4].DefaultCellStyle.BackColor = Color.MistyRose;
                dataGridView2.Columns[3].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                dataGridView2.Columns[2].DefaultCellStyle.BackColor = Color.Khaki;

                textBox15.BackColor = Color.Khaki;

                textBox20.BackColor = Color.LightSkyBlue;
                textBox21.BackColor = Color.MistyRose;

                textBox22.BackColor = Color.Beige;

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
                sumforledger();


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

        string invoicenofromledger;
        string collectionnofromledger;
        string salereturn;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows[e.RowIndex].Cells[6].Value != null)// && dataGridView2.CurrentCell.ColumnIndex.Equals(6))
                {
                    invoicenofromledger = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                }

                if (dataGridView2.Rows[e.RowIndex].Cells[6].Value != null)// && dataGridView2.CurrentCell.ColumnIndex.Equals(6))
                {
                    collectionnofromledger = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
            }
            catch(Exception err)
            {
                
            }
         

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Equals("Deposit"))
            {
                if (btnDPAdd.Visible == true)
                {
                    textBox19.Text = invoicenofromledger;

                    if (!string.IsNullOrEmpty(textBox19.Text.Trim()))
                    {
                        getdepositsinfo();
                    }

                }
            }

            
             if (tabControl1.SelectedTab.Name.Equals("Withdrawal"))
            {
                if (btnWDRAdd.Visible == true)
                {
                    textBox8.Text = invoicenofromledger;

                    if (!string.IsNullOrEmpty(textBox8.Text.Trim()))
                    {
                        getwithdrawals();
                    }

                }
            }


        }


        private void sumforledger()
        {
            Decimal totalcases = 0;
            Decimal billing = 0;
            Decimal collection = 0;
            Decimal writeoff = 0;

            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                if (dataGridView2.Rows[i].Cells[2].Value == null)
                {

                }
                else
                {
                    billing += Convert.ToDecimal(dataGridView2.Rows[i].Cells[2].Value);
                }


                if (dataGridView2.Rows[i].Cells[3].Value == null)
                {

                }
                else
                {
                    collection += Convert.ToDecimal(dataGridView2.Rows[i].Cells[3].Value);
                }


                if (dataGridView2.Rows[i].Cells[4].Value == null)
                {

                }
                else
                {
                    writeoff += Convert.ToDecimal(dataGridView2.Rows[i].Cells[4].Value);
                }


            



            }


            textBox15.Text = billing.ToString("#,##0.00");
            textBox20.Text = collection.ToString("#,##0.00");
            textBox21.Text = writeoff.ToString("#,##0.00");
//            LGR_TotalCases.Text = totalcases.ToString();

            decimal getvalue = 0;
            Int32 index = dataGridView2.Rows.Count - 1;
            textBox22.Text = (Convert.ToDecimal(dataGridView2[5, index].Value)).ToString("#,##0.00");
        }

        private void Deposit_Click(object sender, EventArgs e)
        {

        }

        private void btnDPEditSave_Click(object sender, EventArgs e)
        {

        }
    }
}
