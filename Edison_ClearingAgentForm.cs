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
    public partial class Edison_ClearingAgentForm : Form
    {
        public Edison_ClearingAgentForm()
        {
            InitializeComponent();
        }

        private void Edison_ClearingAgentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Edison_ClearingAgentExpenseList' table. You can move, or remove it, as needed.
            this.edison_ClearingAgentExpenseListTableAdapter.Fill(this.dataSet1.Edison_ClearingAgentExpenseList);
            // TODO: This line of code loads data into the 'dataSet1.Edison_ClearingAgentSettings' table. You can move, or remove it, as needed.
            this.edison_ClearingAgentSettingsTableAdapter.Fill(this.dataSet1.Edison_ClearingAgentSettings);

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
            CR_txtAgentCode.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            searchLookUpEdit1.Text = "";
            CR_txtAgentCompaniesName.Text = "";
            searchLookUpEdit2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox16.Text = "";    
        }

        private void SC_EnableAll()
        {
            CR_txtAgentCode.Enabled = true;
            dateTimePicker1.Enabled = true; 
            searchLookUpEdit1.Enabled = true;
            CR_txtAgentCompaniesName.Enabled = true;
            searchLookUpEdit2.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox16.Enabled = true;

         
        }

        private void SC_DisableAll()
        {
            CR_txtAgentCode.Enabled = false;
            dateTimePicker1.Enabled = false;
            searchLookUpEdit1.Enabled = false;
            CR_txtAgentCompaniesName.Enabled = false;
            searchLookUpEdit2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox16.Enabled = false;

        }

        private void SC_btnAdd_Click(object sender, EventArgs e)
        {
            SC_ClearAll();
            SC_EnableAll();
            SC_AddState();
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
            if(e.KeyCode == Keys.Enter)
            {
                
                searchLookUpEdit2.Focus();
                searchLookUpEdit2.ShowPopup();
            }
        }

        private void searchLookUpEdit2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void btnColAdd_Click(object sender, EventArgs e)
        {

        }
        private void SC_AddItems()
        {
            

            dataGridView1.Rows.Add(null, searchLookUpEdit2.EditValue, searchLookUpEdit2.Text, textBox1.Text);
            searchLookUpEdit2.Text = "";
            textBox1.Text = "";
            SC_Sumcalculator();
        }

        private void SC_Sumcalculator()
        {
            int j = 1;

            Decimal summTotalQty = 0;
            Decimal TotalQtyinNos = 0;


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = j++;




                if (!string.IsNullOrEmpty(row.Cells[9].Value.ToString()))
                {
                    TotalQtyinNos += Convert.ToDecimal(row.Cells[9].Value.ToString());
                }

            }

          
            textBox16.Text = TotalQtyinNos.ToString();

            textBox2.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnColAdd_MouseClick(object sender, MouseEventArgs e)
        {
            SC_AddItems();
        }

        private void btnColAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SC_AddItems();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {


                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    SC_Sumcalculator();


                }
            }
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(searchLookUpEdit1.Text))
            {
                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_ClearingAgents
                                        where d.ClearingAgentID.Equals(searchLookUpEdit1.EditValue)
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                    
                        CR_txtAgentCompaniesName.Text = a.Company;
                   
                        break;
                    }
                }
            }

        }

        private void SC_btnSave_Click(object sender, EventArgs e)
        {

        }

        private void SaveInvoiceOfClearingAgent()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            using (var scope = new System.Transactions.TransactionScope())
            {


                Edison_ClearingAgentINV_HDR objCourse = new Edison_ClearingAgentINV_HDR();

                objCourse.Date = Convert.ToDateTime(dateTimePicker1.Value);


                objCourse.ClearingAgentID = Convert.ToInt32(searchLookUpEdit1.EditValue);

                objCourse.TotalAmount = Convert.ToDecimal(textBox16.Text);



                db.Edison_ClearingAgentINV_HDRs.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                CR_txtAgentCode.Text = objCourse.CA_InvID.ToString();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    Edison_ClearingAgentINV_DTL AddItems = new Edison_ClearingAgentINV_DTL();


                    AddItems.CA_InvID = objCourse.CA_InvID;
                                      
                    AddItems.ExpenseListID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
                    AddItems.ExpenseAmount = Convert.ToInt32(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());                   
                    db.Edison_ClearingAgentINV_DTLs.InsertOnSubmit(AddItems);
                    db.SubmitChanges();

                }



                scope.Complete();
                SC_RevertState();
                SC_DisableAll();
            }
            
        }

        private void SC_btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            SaveInvoiceOfClearingAgent();
        }

        private void SC_btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveInvoiceOfClearingAgent();
            }
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

        }

        private void SC_btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

            }
        }

        private void SC_EditSaveInvoiceOfClearingAgent()
        {
           // DataClasses1DataContext db = new DataClasses1DataContext();

            //using (var scope = new System.Transactions.TransactionScope())
            //{



            //    var getTheSelecteddata = from s in db.Edison_ClearingAgentINV_HDRs
            //                             where s.ClearingAgentID.Equals(textBox30.Text)
            //                             select s;

            //    if (getTheSelecteddata.Any())
            //    {
            //        foreach (var ab in getTheSelecteddata)
            //        {
            //            dateTimePicker3.Value = Convert.ToDateTime(ab.Date);
            //            textBox29.Text = ab.DispatchNo.ToString();
            //            searchLookUpEdit11.EditValue = Convert.ToInt32(ab.CustID);
            //            break;
            //        }
            //    }

            //    Edison_ClearingAgentINV_HDR objCourse = new Edison_ClearingAgentINV_HDR();

            //    objCourse.Date = Convert.ToDateTime(dateTimePicker1.Value);


            //    objCourse.ClearingAgentID = Convert.ToInt32(searchLookUpEdit1.EditValue);

            //    objCourse.TotalAmount = Convert.ToDecimal(textBox16.Text);



            //    db.Edison_ClearingAgentINV_HDRs.InsertOnSubmit(objCourse);
            //    db.SubmitChanges();

            //    CR_txtAgentCode.Text = objCourse.CA_InvID.ToString();

            //    foreach (DataGridViewRow row in dataGridView1.Rows)
            //    {

            //        Edison_ClearingAgentINV_DTL AddItems = new Edison_ClearingAgentINV_DTL();


            //        AddItems.CA_InvID = objCourse.CA_InvID;

            //        AddItems.ExpenseListID = Convert.ToInt32(row.Cells[1].Value.ToString() == "" ? "0" : row.Cells[1].Value.ToString());
            //        AddItems.ExpenseAmount = Convert.ToInt32(row.Cells[3].Value.ToString() == "" ? "0" : row.Cells[3].Value.ToString());
            //        db.Edison_ClearingAgentINV_DTLs.InsertOnSubmit(AddItems);
            //        db.SubmitChanges();

            //    }



            //    scope.Complete();
            //    SC_RevertState();
            //    SC_DisableAll();
            //}

        }
    }
}
