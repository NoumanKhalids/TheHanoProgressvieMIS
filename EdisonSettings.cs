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
    public partial class EdisonSettings : Form
    {
        public EdisonSettings()
        {
            InitializeComponent();
        }

        private void getClearingAgentGrid()
        {
            this.edison_ClearingAgentSettingsTableAdapter.Fill(this.dataSet1.Edison_ClearingAgentSettings);
            dataGridView3.ClearSelection();
        }
        private void getClearingExpenseCategory()
        {
            this.edison_ClearingAgentExpenseListTableAdapter.Fill(this.dataSet1.Edison_ClearingAgentExpenseList);
            dataGridView4.ClearSelection();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
   
            this.recoveryTargetTableTableAdapter.Fill(this.dataSet2.RecoveryTargetTable);
            dataGridView6.ClearSelection();

            this.salesTargetTableTableAdapter.Fill(this.dataSet2.SalesTargetTable);

            dataGridView5.ClearSelection();
           
            // TODO: This line of code loads data into the 'dataSet1.Edison_Van' table. You can move, or remove it, as needed.
            this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);
            // TODO: This line of code loads data into the 'dataSet1.Edison_Expense' table. You can move, or remove it, as needed.
            this.edison_ExpenseTableAdapter.Fill(this.dataSet1.Edison_Expense);
            dataGridView2.ClearSelection();
            // TODO: This line of code loads data into the 'dataSet1.Edison_ClearingAgentExpenseList' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dataSet1.Edison_ClearingAgentSettings' table. You can move, or remove it, as needed.
            getClearingExpenseCategory();
            getClearingAgentGrid();
        }



        private void SC_AddState()
        {
            SC_btnAdd.Visible = false;
            SC_btnSave.Visible = true;
            SC_btnEdit.Visible = false;
            SC_btnRevert.Visible = true;
            SC_btnEditSave.Visible = false;
     
        }

        private void SC_RevertState()
        {
            SC_btnAdd.Visible = true;
            SC_btnSave.Visible = false;
            SC_btnEdit.Visible = true;
            SC_btnRevert.Visible = false;
            SC_btnEditSave.Visible = false;
         
        }

        private void SC_EditState()
        {
            SC_btnAdd.Visible = false;
            SC_btnSave.Visible = false;
            SC_btnEdit.Visible = false;
            SC_btnRevert.Visible = true;
            SC_btnEditSave.Visible = true;
   
        }

        private void SC_ClearAll()
        {

            CR_txtAgentCode.Text = "";       
            CR_txtAgentName.Text = "";
            CR_txtAgentCompaniesName.Text = "";
      
        }

        private void SC_EnableAll()
        {
   
            CR_txtAgentName.Enabled = true;
            CR_txtAgentCompaniesName.Enabled = true;
 
        }

        private void SC_DisableAll()
        {
         
            CR_txtAgentName.Enabled = false;
            CR_txtAgentCompaniesName.Enabled = false;

        }
        private void SC_btnAdd_Click(object sender, EventArgs e)
        {
            SC_ClearAll();
            SC_AddState();
            SC_EnableAll();
            CR_txtAgentName.Focus();

        }

        private void CR_txtAgentName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CR_txtAgentCompaniesName.Focus();
            }
        }

        private void SC_btnSave_Click(object sender, EventArgs e)
        {

        }

        private void SC_btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            InsertThisClearingAgent();
        }

        private void SC_btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InsertThisClearingAgent();
            }
        }

        private void InsertThisClearingAgent()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                Edison_ClearingAgent objCourse = new Edison_ClearingAgent();

                objCourse.ClearingAgentName = CR_txtAgentName.Text.Trim();
                objCourse.Company = CR_txtAgentCompaniesName.Text.Trim();

                db.Edison_ClearingAgents.InsertOnSubmit(objCourse);
                db.SubmitChanges();


                CR_txtAgentCode.Text = objCourse.ClearingAgentID.ToString();



                SC_RevertState();
                SC_DisableAll();

                getClearingAgentGrid();

            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        int InvoiceSelectRow = -1;
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0 && SC_btnAdd.Visible == true)
            {

                InvoiceSelectRow = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView3.Rows[InvoiceSelectRow];


                CR_txtAgentCode.Text = (selectedRow.Cells[0].Value).ToString();

                CR_txtAgentName.Text = (selectedRow.Cells[1].Value).ToString();


                CR_txtAgentCompaniesName.Text = (selectedRow.Cells[2].Value).ToString();
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
            SC_EditSave();
        }

        private void SC_btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SC_EditSave();
            }
        }

        private void SC_EditSave()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheSelecteddata = from s in db.Edison_ClearingAgents
                                         where s.ClearingAgentID.Equals(CR_txtAgentCode.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {
                    
                        objCourse.ClearingAgentName = CR_txtAgentName.Text.Trim();
                        objCourse.Company = CR_txtAgentCompaniesName.Text.Trim();
                    
                        db.SubmitChanges();     
                        break;          
                    }

                    SC_RevertState();
                    SC_DisableAll();
                }

                getClearingAgentGrid();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void SC_btnRevert_Click(object sender, EventArgs e)
        {
            SC_RevertState();
            SC_ClearAll();
            SC_DisableAll();
        }

        private void CR_txtAgentCompaniesName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void OS_AddState()
        {
            OS_BtnAdd.Visible = false;
            OS_BtnSave.Visible = true;
            OS_BtnRevert.Visible = true;
            OS_BtnEdit.Visible = false;
            OS_BtnEditSave.Visible = false;
       
        }


        private void OS_RevertState()
        {
            OS_BtnAdd.Visible = true;
            OS_BtnSave.Visible = false;
            OS_BtnRevert.Visible = false;
            OS_BtnEdit.Visible = true;
            OS_BtnEditSave.Visible = false;
     
    
        }



        private void OS_EditSaveState()
        {
            OS_BtnAdd.Visible = false;
            OS_BtnSave.Visible = false;
            OS_BtnRevert.Visible = true;
            OS_BtnEdit.Visible = false;
            OS_BtnEditSave.Visible = true;
 
        
        }

        private void OS_EnableAll()
        {
          
            textBox4.Enabled = true;


        }

        private void OS_DisableAll()
        {
       
            textBox4.Enabled = false;
        




        }

        private void OS_ClearAll()
        {
            textBox5.Text = "";
            textBox4.Text = "";
          
        }

   
        private void OS_BtnAdd_Click(object sender, EventArgs e)
        {
            OS_AddState();
            OS_ClearAll();
            OS_EnableAll();
            textBox4.Focus();
        }

        private void OS_BtnRevert_Click(object sender, EventArgs e)
        {
            OS_DisableAll();
            OS_ClearAll();
            OS_RevertState();
        }

        private void OS_BtnEdit_Click(object sender, EventArgs e)
        {
            OS_EnableAll();
            OS_EditSaveState();
            textBox4.Focus();
        }

        private void OS_BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void OS_BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            OS_SaveData();
        }

        private void OS_BtnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                OS_SaveData();
            }
        }

        private void OS_SaveData()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                Edison_ClearingAgentExpenseList objCourse = new Edison_ClearingAgentExpenseList();

                objCourse.CA_ExpenseName = textBox4.Text.Trim();
     

                db.Edison_ClearingAgentExpenseLists.InsertOnSubmit(objCourse);
                db.SubmitChanges();


                textBox5.Text = objCourse.CA_ExpenseID.ToString();



                OS_RevertState();
                OS_DisableAll();

                getClearingExpenseCategory();

            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void OS_BtnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void OS_BtnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            OS_EditSaveData();
        }
        private void OS_BtnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                OS_EditSaveData();
            }
        }

        private void OS_EditSaveData()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheSelecteddata = from s in db.Edison_ClearingAgentExpenseLists
                                         where s.CA_ExpenseID.Equals(textBox5.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {
                        objCourse.CA_ExpenseName = textBox4.Text.Trim();                    
                        db.SubmitChanges();
                        break;          
                    }
                }

                OS_RevertState();
                OS_DisableAll();

                getClearingExpenseCategory();

            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        int InvoiceSelectRow11 = -1;
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.SelectedCells.Count > 0 && OS_BtnAdd.Visible == true)
            {
                InvoiceSelectRow11 = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView3.Rows[InvoiceSelectRow11];
                textBox5.Text = (selectedRow.Cells[0].Value).ToString();
                textBox4.Text = (selectedRow.Cells[1].Value).ToString();

            }
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
            textBox3.Enabled = true;
       

        }

        private void Inv_DisableAll()
        {

            textBox3.Enabled = false;
        }

        private void Inv_ClearAll()
        {
            textBox3.Text = "";


            textBox6.Text = "";
        }
        private void INV_btnAdd_Click(object sender, EventArgs e)
        {
            INV_AddState();
            Inv_EnableAll();
            textBox3.Focus();
        }

        private void INV_btnRevert_Click(object sender, EventArgs e)
        {
            Inv_DisableAll();
            INV_RevertState();
            Inv_ClearAll();
            
        }

        private void saveDataofExpense()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                Edison_Expense objCourse = new Edison_Expense();

                objCourse.ExpenseDescription = textBox3.Text.Trim();


                db.Edison_Expenses.InsertOnSubmit(objCourse);
                db.SubmitChanges();


                textBox6.Text = objCourse.ExpenseID.ToString();


                INV_RevertState();
                Inv_DisableAll();

                this.edison_ExpenseTableAdapter.Fill(this.dataSet1.Edison_Expense);
                dataGridView2.ClearSelection();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }
        private void INV_btnSave_Click(object sender, EventArgs e)
        {
            saveDataofExpense();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0 && INV_btnAdd.Visible == true)
            {

                InvoiceSelectRow = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[InvoiceSelectRow];

                textBox6.Text = (selectedRow.Cells[0].Value).ToString();
                textBox3.Text = (selectedRow.Cells[1].Value).ToString();

                
            }
        }

        private void INV_btnEdit_Click(object sender, EventArgs e)
        {
            INV_EditSaveState();
            Inv_EnableAll();
            textBox3.Focus();
        }

        private void INV_btnEditSave_Click(object sender, EventArgs e)
        {
            INV_EditSaveData();
        }

        private void INV_EditSaveData()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheSelecteddata = from s in db.Edison_Expenses
                                         where s.ExpenseID.Equals(textBox6.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {
                        objCourse.ExpenseDescription = textBox3.Text.Trim();
                        db.SubmitChanges();
                        break;
                    }
                }

                INV_RevertState();
                Inv_DisableAll();
                this.edison_ExpenseTableAdapter.Fill(this.dataSet1.Edison_Expense);
                dataGridView2.ClearSelection();
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void dateTimePicker1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                searchLookUpEdit1.Focus();
                searchLookUpEdit1.ShowPopup();

            }
        }

        private void searchLookUpEdit1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void simpleButton1_MouseClick(object sender, MouseEventArgs e)
        {
            InsertSalesTarget();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }


        private void InsertSalesTarget()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                Edison_SalesTargetValue objCourse = new Edison_SalesTargetValue();

                objCourse.Date = dateTimePicker1.Value.Date;
                objCourse.VanID = Convert.ToInt32(searchLookUpEdit1.EditValue);
                objCourse.SalesTargetValue = Convert.ToDecimal(textBox7.Text.Trim());


                db.Edison_SalesTargetValues.InsertOnSubmit(objCourse);
                db.SubmitChanges();

                this.salesTargetTableTableAdapter.Fill(this.dataSet2.SalesTargetTable);

                dataGridView5.ClearSelection();

            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void simpleButton1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InsertSalesTarget();
            }
        }

        private void textBox7_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                simpleButton1.Focus();
            }
        }


        private void InsertRecoveryTarget()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                Edison_RecoveryTargetValue objCourse = new Edison_RecoveryTargetValue();

                objCourse.Date = dateTimePicker2.Value.Date;
                objCourse.VanID = Convert.ToInt32(searchLookUpEdit2.EditValue);
                objCourse.RecoveryTargetValue = Convert.ToDecimal(textBox8.Text.Trim());


                db.Edison_RecoveryTargetValues.InsertOnSubmit(objCourse);
                db.SubmitChanges();


                this.recoveryTargetTableTableAdapter.Fill(this.dataSet2.RecoveryTargetTable);
                dataGridView6.ClearSelection();


            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_MouseClick(object sender, MouseEventArgs e)
        {
            InsertRecoveryTarget();
        }

        private void simpleButton3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InsertRecoveryTarget();
            }
        }

        private void dateTimePicker2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                textBox8.Focus();
            }
        }

        private void textBox8_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                simpleButton3.Focus();
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                //if (dataGridView5.SelectedRows.Count > 0 )
                //{


                //    DialogResult result1 = MessageBox.Show("Do you want to Remove it ?", "Confirm Delete", MessageBoxButtons.YesNo);

                //    if (result1 == DialogResult.Yes)
                //    {
                //        DataClasses1DataContext Del = new DataClasses1DataContext();

                //        var a = from s in Del.Edison_SalesTargetValues
                //                where s.DiscountID.Equals(DiscountRecordId)
                //                select s;

                //        if (a.Any())
                //        {
                //            foreach (var d in a)
                //            {
                //                Del.CustomerDiscounts.DeleteOnSubmit(d);
                //                break;
                //            }

                //            try
                //            {
                //                Del.SubmitChanges();
                //                Del.Dispose();
                //                ShowTheCustomerDiscount();
                //                DiscountRecordId = -1;
                //            }
                //            catch (Exception er)
                //            {
                //                MessageBox.Show(er.Message);

                //            }
                //        }
                //    }

                //}
                //else
                //{
                //    MessageBox.Show("Please Select The Discount To Remove!");
                //}
            }
        }
    }
}
