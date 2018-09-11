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
    public partial class EdisonSupplierLibrary : Form
    {
        public EdisonSupplierLibrary()
        {
            InitializeComponent();
        }

        private void EdisonSupplierLibrary_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.SupplierLists' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'dataSet1.All_Country' table. You can move, or remove it, as needed.
            this.all_CountryTableAdapter.Fill(this.dataSet1.All_Country);

        }

       private void EnableAll()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            searchLookUpEdit1.Enabled = true;
            radioLocal.Enabled = true;
            radioImport.Enabled = true;
            textBox5.Enabled = true;
            textBox4.Enabled = true;
        }

        private void DisableAll()
        {
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            searchLookUpEdit1.Enabled = false;
            radioLocal.Enabled = false;
            radioImport.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
        }

        private void ClearAll()
        {

            textBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            searchLookUpEdit1.Text = "";
            radioLocal.Checked = false;
            radioImport.Checked = false;
            textBox5.Text = "";
        }

        private void AddState()
        {
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnRevert.Visible = true;
            btnEdit.Visible = false;
            btnEditSave.Visible = false;
            btnSearch.Visible = false;

        }

        private void RevertState()
        {
            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnRevert.Visible = false;
            btnEdit.Visible = true;
            btnEditSave.Visible = true;
            btnSearch.Visible = true;
        }

        
        private void EditState()
        {
            btnAdd.Visible = false;
            btnSave.Visible = false;
            btnRevert.Visible = true;
            btnEdit.Visible = false;
            btnEditSave.Visible = true;
            btnSearch.Visible = false;
        }

    

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearAll();
            EnableAll();
            AddState();
            textBox2.Focus();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            DisableAll();
            ClearAll();
            RevertState();

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
        private void SaveRegisteredSupplier()
        {
            try
            {

                if(radioLocal.Checked == true || radioImport.Checked == true)
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();

                    Edison_Supplier AddNew = new Edison_Supplier();
                    AddNew.InsertedDateTime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();

                    AddNew.SupplierName = textBox2.Text.Trim();
                    AddNew.SupplierAddress = textBox3.Text.Trim();
                    AddNew.SupplierCountry = Convert.ToInt32(searchLookUpEdit1.EditValue);
                    AddNew.Remarks = textBox5.Text.Trim();
                    AddNew.OpeningBalance = Convert.ToDecimal(textBox4.Text.Trim() == "" ? "0" : textBox4.Text.Trim());

                    if (radioLocal.Checked == true)
                    {
                        AddNew.SupplierType = "Local";
                    }
                    else
                    {
                        AddNew.SupplierType = "Import";
                    }

                    db.Edison_Suppliers.InsertOnSubmit(AddNew);
                    db.SubmitChanges();

                    textBox1.Text = AddNew.SupplierID.ToString();

                    DisableAll();
                    RevertState();
                }
                else
                {
                    MessageBox.Show("Please Select the Supplier Type");
                }
               
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            SaveRegisteredSupplier();
        }

        private void btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveRegisteredSupplier();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableAll();
            EditState();
            textBox2.Focus();          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Focus();
            textBox1.SelectAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void EditUpdateSave()
        {
            try
            {
                if (radioLocal.Checked == true || radioImport.Checked == true)
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();

                    var getTheOrderDetail = from d in db.Edison_Suppliers
                                            where d.SupplierID.Equals(Convert.ToInt32(textBox1.Text))
                                            select d;

                    if (getTheOrderDetail.Any())
                    {
                        foreach (var AddNew in getTheOrderDetail)
                        {


                            AddNew.SupplierName = textBox2.Text.Trim();
                            AddNew.SupplierAddress = textBox3.Text.Trim();
                            AddNew.SupplierCountry = Convert.ToInt32(searchLookUpEdit1.EditValue);
                            AddNew.Remarks = textBox5.Text.Trim();
                            AddNew.OpeningBalance = Convert.ToDecimal(textBox4.Text.Trim() == "" ? "0" : textBox4.Text.Trim());


                            if (radioLocal.Checked == true)
                            {
                                AddNew.SupplierType = "Local";
                            }
                            else
                            {
                                AddNew.SupplierType = "Import";
                            }

                            db.SubmitChanges();


                        }
                        DisableAll();
                        RevertState();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Supplier Type");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }
        private void btnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            EditUpdateSave();
        }

        private void btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EditUpdateSave();
            }
        }

        private void textBox5_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(btnSave.Visible == true)
                {
                    btnSave.Focus();

                }
                else if (btnEditSave.Visible == true)
                {
                    btnEditSave.Focus();
                }
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox1.Text))
            {
                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_Suppliers
                                        where d.SupplierID.Equals(Convert.ToInt32(textBox1.Text))
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var a in getTheOrderDetail)
                    {
                        textBox2.Text = a.SupplierName;
                        textBox3.Text = a.SupplierAddress;

                        searchLookUpEdit1.EditValue = a.SupplierCountry;

                        textBox5.Text = a.Remarks;

                        if(a.SupplierType == "Local")
                        {
                            radioLocal.Checked = true;
                            radioImport.Checked = false;
                        }
                        else if (a.SupplierType == "Import")
                        {
                            radioLocal.Checked = false;
                            radioImport.Checked = true;
                        }


                        break;
                    }
                }

                db.Dispose();


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.supplierListsTableAdapter.Fill(this.dataSet1.SupplierLists);
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {

        }
    }
}
