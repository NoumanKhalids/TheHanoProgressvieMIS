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
    public partial class Edison_Customers : Form
    {
        public Edison_Customers()
        {
            InitializeComponent();
        }

        private void Edison_Customers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.All_CustomerPhone' table. You can move, or remove it, as needed.
            this.all_CustomerPhoneTableAdapter.Fill(this.dataSet1.All_CustomerPhone);
            // TODO: This line of code loads data into the 'dataSet1.All_PhoneTitle' table. You can move, or remove it, as needed.
            this.all_PhoneTitleTableAdapter.Fill(this.dataSet1.All_PhoneTitle);
            // TODO: This line of code loads data into the 'dataSet1.Edison_Van' table. You can move, or remove it, as needed.
            this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);
            // TODO: This line of code loads data into the 'dataSet1.All_City' table. You can move, or remove it, as needed.
            this.all_CityTableAdapter.Fill(this.dataSet1.All_City);
    

        }

        private void addState()
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnRevert.Visible = true;
            btnEditSave.Visible = false;
        }

        private void revertState()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnRevert.Visible = false;
            btnEditSave.Visible = false;
        }

        private void editState()
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnRevert.Visible = true;
            btnEditSave.Visible = true;
        }

        private void clearalltextboxes()
        {
            searchLookUpEdit2.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            textBox7.Clear();

            searchLookUpEdit1.Text = "";

            searchLookUpEdit3.Text = "";

            txtOpeningBalance.Clear();
        }

        private void enableall()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            searchLookUpEdit2.Enabled = true;
            //   textBox7.Enabled = true;

            searchLookUpEdit1.Enabled = true;

            //    searchLookUpEdit3.Enabled = true;

            txtOpeningBalance.Enabled = true;
        }

        private void disableall()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

            searchLookUpEdit2.Enabled = false;
            //            textBox7.Enabled = false;

            searchLookUpEdit1.Enabled = false;

            //     searchLookUpEdit3.Enabled = false;

            txtOpeningBalance.Enabled = false;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);
            // TODO: This line of code loads data into the 'dataSet1.All_City' table. You can move, or remove it, as needed.
            this.all_CityTableAdapter.Fill(this.dataSet1.All_City);

            clearalltextboxes();
            addState();
            enableall();
            textBox2.Focus();
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            revertState();
            disableall();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.edison_VanTableAdapter.Fill(this.dataSet1.Edison_Van);
            // TODO: This line of code loads data into the 'dataSet1.All_City' table. You can move, or remove it, as needed.
            this.all_CityTableAdapter.Fill(this.dataSet1.All_City);

            editState();
            enableall();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            SaveAll();
        }

        private void btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveAll();
            }
        }


        private void SaveAll()
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                All_Customer objCourse = new All_Customer();

                objCourse.CustomerName = textBox2.Text.Trim();
                objCourse.CustomerAddress = textBox3.Text.Trim();
                objCourse.City = Convert.ToInt32(searchLookUpEdit1.EditValue);
                objCourse.InsertedDateTime = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();
                objCourse.OpeningBalance1 = (Convert.ToDecimal(txtOpeningBalance.Text == "" ? "0" : txtOpeningBalance.Text));
                objCourse.OpeningBalance2 = 0;
                objCourse.OpeningBalance3 = 0;
                
                objCourse.VanID = (Convert.ToInt32(searchLookUpEdit2.Text == "" ? "0" : searchLookUpEdit2.EditValue));

                objCourse.OpeningBalance1Date = dateTimePicker1.Value;

                db.All_Customers.InsertOnSubmit(objCourse);
                db.SubmitChanges();
  

                textBox1.Text = objCourse.CustID.ToString();

              


                revertState();
                disableall();



            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            EditSaveAll();
        }

        private void btnEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EditSaveAll();
            }
        }

        private void EditSaveAll()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var getTheSelecteddata = from s in db.All_Customers
                                     where s.CustID.Equals(textBox1.Text)
                                     select s;

            if (getTheSelecteddata.Any())
            {
                foreach (var objCourse in getTheSelecteddata)
                {

                    objCourse.EditedSystemDate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();


                    objCourse.CustomerName = textBox2.Text;
                    objCourse.CustomerAddress = textBox3.Text;
                    objCourse.City = Convert.ToInt32(searchLookUpEdit1.EditValue);
                    objCourse.OpeningBalance1 = (Convert.ToDecimal(txtOpeningBalance.Text == "" ? "0" : txtOpeningBalance.Text));
                    objCourse.VanID = (Convert.ToInt32(searchLookUpEdit2.Text == "" ? "0" : searchLookUpEdit2.EditValue));

                    objCourse.OpeningBalance1Date = dateTimePicker1.Value;

                    db.SubmitChanges();

                }
            }

            db.Dispose();
            revertState();
            disableall();

        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                var getTheSelecteddata = from s in db.All_Customers
                                         where s.CustID.Equals(textBox1.Text)
                                         select s;

                if (getTheSelecteddata.Any())
                {
                    foreach (var objCourse in getTheSelecteddata)
                    {
                        textBox2.Text = objCourse.CustomerName;
                        textBox3.Text = objCourse.CustomerAddress;
                        searchLookUpEdit1.EditValue = objCourse.City;
                        txtOpeningBalance.Text = objCourse.OpeningBalance1.ToString();
                        searchLookUpEdit2.EditValue = Convert.ToInt32(objCourse.VanID);    
                        db.SubmitChanges();

                    }
                }

                this.all_CustomerPhoneTableAdapter.Fill(this.dataSet1.All_CustomerPhone);

                db.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Focus();
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
                txtOpeningBalance.Focus();
            }
        }

        private void txtOpeningBalance_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                if(btnSave.Visible == true)
                {
                    btnSave.Focus();
                }
                else
                {
                    btnEditSave.Focus();
                }
            }
        }

        private void btnPhoneSave_Click(object sender, EventArgs e)
        {
            try
            {

                DataClasses1DataContext db = new DataClasses1DataContext();

                All_CustomersPhone objCourse = new All_CustomersPhone();

                objCourse.CustID = Convert.ToInt32(textBox1.Text);
                objCourse.TitleID = (Convert.ToInt32(searchLookUpEdit3.EditValue == "" ? "0" : searchLookUpEdit3.EditValue));
                objCourse.PersonName = textBox4.Text;
                objCourse.PhoneNo = textBox7.Text.Trim();
                objCourse.InsertedSystemDate = db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();
       
                db.All_CustomersPhones.InsertOnSubmit(objCourse);
                db.SubmitChanges();
                this.all_CustomerPhoneTableAdapter.Fill(this.dataSet1.All_CustomerPhone);

            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR " + err);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
