using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS_ProgressiveDistributors
{
    public partial class Edison_Payroll : Form
    {
        public Edison_Payroll()
        {
            InitializeComponent();
        }


        private void InsertNewEmployee()
        {
            try
            {


                using (var scope = new System.Transactions.TransactionScope())
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();

                    Edison_EmployeeInfo objCourse = new Edison_EmployeeInfo();

                    objCourse.EmployeeName = txtEmpName.Text.Trim();

                    objCourse.FatherName = txtEmpFatherName.Text.Trim();

                    objCourse.MotherName = txtEmpMotherName.Text.Trim();

                    objCourse.CNIC = txtCNICNo.Text.Trim();

                    objCourse.CurrentAddress = txtCurrentAddress.Text.Trim();

                    objCourse.DOB = dateDOB.Value;

                    objCourse.Education = txtEducation.Text.Trim();

                    objCourse.DesignationID = Convert.ToInt32(ComboDesignation.EditValue);

                    if (dateJoiningDate.Checked == true)
                    {
                        objCourse.JoinDate = dateJoiningDate.Value;
                    }

                    if (dateLeavingDate.Checked == true)
                    {
                        objCourse.LeavingDate = dateLeavingDate.Value;
                    }


                    objCourse.DepartmentID = Convert.ToInt32(ComboDepart.EditValue);

                    objCourse.RefferedBy = txtRefferedBy.Text.Trim();

                    objCourse.BasicSalary = Convert.ToInt32(txtBasicSalary.Text.Trim());


                    objCourse.Percentage = Convert.ToDecimal(txtCommisionPercentage.Text.Trim());

                    objCourse.Remarks = txtRemarks.Text.Trim();

                    objCourse.TotalAdvanceAmount = 0;


                    db.Edison_EmployeeInfos.InsertOnSubmit(objCourse);
                    db.SubmitChanges();


                    txtEmpCode.Text = objCourse.EmployeeID.ToString();

                    //Adding Phone Number Now



                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Edison_EmployeePhoneDetail AddPhoneNo = new Edison_EmployeePhoneDetail();
                        AddPhoneNo.EmpCode = Convert.ToInt32(txtEmpCode.Text);

                        if ((row.Cells[1].Value == null))
                        {

                        }
                        else
                        {
                            if (row.Cells[0].Value == null)
                            {

                            }
                            else
                            {
                                AddPhoneNo.EmployeePerson = (row.Cells[0].Value.ToString());
                            }


                            AddPhoneNo.PhoneNo = (row.Cells[1].Value.ToString());

                            db.Edison_EmployeePhoneDetails.InsertOnSubmit(AddPhoneNo);
                            db.SubmitChanges();
                        }


                    }


                    //Adding Pictures of Employee, CNIC FRONT & CNIC BACK
                    var getlist = from t in db.Edison_EmployeeDatas
                                  where t.EmpCode.Equals(txtEmpCode.Text.Trim())
                                  select t;

                    if (getlist.Any())
                    {

                        foreach (var ab in getlist)
                        {

                            if (picEmp.BackgroundImage != null)
                            {
                                byte[] file_byte = ImageToByteArray(picEmp.BackgroundImage);

                                System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);

                                ab.eImageFace = file_binary;

                                db.SubmitChanges();
                            }

                            if (CNICFront.BackgroundImage != null)
                            {
                                byte[] file_byte1 = ImageToByteArray(CNICFront.BackgroundImage);

                                System.Data.Linq.Binary file_binary1 = new System.Data.Linq.Binary(file_byte1);

                                ab.eImageCNICF = file_binary1;

                                db.SubmitChanges();


                            }


                            if (CNICBack.BackgroundImage != null)
                            {
                                byte[] file_byte2 = ImageToByteArray(CNICBack.BackgroundImage);

                                System.Data.Linq.Binary file_binary2 = new System.Data.Linq.Binary(file_byte2);

                                ab.eImageCNICB = file_binary2;

                                db.SubmitChanges();


                            }
                            break;


                        }
                    }
                    else
                    {


                        if (picEmp.BackgroundImage != null || (CNICFront.BackgroundImage != null) || (CNICBack.BackgroundImage != null))
                        {
                            Edison_EmployeeData AddNew = new Edison_EmployeeData();

                            if (picEmp.BackgroundImage != null)
                            {
                                byte[] file_byte = ImageToByteArray(picEmp.BackgroundImage);
                                System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
                                AddNew.eImageFace = file_binary;
                            }

                            if ((CNICFront.BackgroundImage != null))
                            {
                                byte[] file_byte = ImageToByteArray(CNICFront.BackgroundImage);
                                System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
                                AddNew.eImageCNICF = file_binary;
                            }


                            if ((CNICBack.BackgroundImage != null))
                            {
                                byte[] file_byte = ImageToByteArray(CNICBack.BackgroundImage);
                                System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
                                AddNew.eImageCNICB = file_binary;
                            }


                            AddNew.EmpCode = Convert.ToInt32(txtEmpCode.Text.Trim());

                            db.Edison_EmployeeDatas.InsertOnSubmit(AddNew);
                            db.SubmitChanges();
                        }

                    }


                    scope.Complete();

                }
                RevertStateEmpInfo();
                disableEmployeeAll();
                dataGridView1.ClearSelection();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        //MemoryStream tmpStream = new MemoryStream();
        //byte[] imgBytes = new byte[400];
        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        private void txtEmpName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmpFatherName.Focus();
            }
        }

        private void txtEmpFatherName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmpMotherName.Focus();
            }
        }

        private void txtEmpMotherName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCNICNo.Focus();
            }
        }

        private void txtCNICNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCurrentAddress.Focus();
            }
        }

        private void txtCurrentAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateDOB.Focus();
            }
        }

        private void dateDOB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEducation.Focus();
            }
        }

        private void txtEducation_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboDesignation.Focus();
                ComboDesignation.ShowPopup();
            }
        }

        private void ComboDesignation_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateJoiningDate.Focus();
            }

        }

        private void dateJoiningDate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateLeavingDate.Focus();
            }
        }

        private void dateLeavingDate_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboDepart.Focus();
                ComboDepart.ShowPopup();
            }
        }

        private void ComboDepart_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRefferedBy.Focus();
            }

        }

        private void txtRefferedBy_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBasicSalary.Focus();
            }
        }

        private void txtBasicSalary_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCommisionPercentage.Focus();
            }
        }

        private void txtCommisionPercentage_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtRemarks_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private void picEmp_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Jpeg Files(*.Jpeg)|*.jpg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    picEmp.BackgroundImage = new Bitmap(dlg.FileName);
                    picturechange = true;
                }


            }
        }

        private void ClearAllEmployeeInfo()
        {
            picturechange = false;
            cnicFchange = false;
            cnincBchange = false;

            txtEmpName.Text = "";
            txtEmpFatherName.Text = "";

            txtEmpMotherName.Text = "";
            txtCNICNo.Text = "";

            txtCurrentAddress.Text = "";

            dateDOB.Text = "";

            txtEducation.Text = "";

            ComboDesignation.Text = "";

            dateJoiningDate.Text = "";

            dateLeavingDate.Text = "";

            ComboDepart.Text = "";

            txtRefferedBy.Text = "";

            txtBasicSalary.Text = "";


            txtCommisionPercentage.Text = "";
            txtRemarks.Text = "";

            dataGridView1.Rows.Clear();

            picEmp.BackgroundImage = null;

            CNICFront.BackgroundImage = null;
            CNICBack.BackgroundImage = null;

            picEmp.Image = null;
            CNICFront.Image = null;
            CNICBack.Image = null;

        }

        private void enableEmployeeAll()
        {
            txtEmpName.Enabled = true;
            txtEmpFatherName.Enabled = true;

            txtEmpMotherName.Enabled = true;
            txtCNICNo.Enabled = true;

            txtCurrentAddress.Enabled = true;

            dateDOB.Enabled = true;

            txtEducation.Enabled = true;

            ComboDesignation.Enabled = true;

            dateJoiningDate.Enabled = true;

            dateLeavingDate.Enabled = true;

            ComboDepart.Enabled = true;

            txtRefferedBy.Enabled = true;

            txtBasicSalary.Enabled = true;


            txtCommisionPercentage.Enabled = true;
            txtRemarks.Enabled = true;

            dataGridView1.Enabled = true;

            picEmp.Enabled = true;

            CNICFront.Enabled = true;
            CNICBack.Enabled = true;

        }

        private void disableEmployeeAll()
        {
            txtEmpName.Enabled = false;
            txtEmpFatherName.Enabled = false;

            txtEmpMotherName.Enabled = false;
            txtCNICNo.Enabled = false;

            txtCurrentAddress.Enabled = false;

            dateDOB.Enabled = false;

            txtEducation.Enabled = false;

            ComboDesignation.Enabled = false;

            dateJoiningDate.Enabled = false;

            dateLeavingDate.Enabled = false;

            ComboDepart.Enabled = false;

            txtRefferedBy.Enabled = false;

            txtBasicSalary.Enabled = false;


            txtCommisionPercentage.Enabled = false;
            txtRemarks.Enabled = false;

            dataGridView1.Enabled = false;

            picEmp.Enabled = false;

            CNICFront.Enabled = false;
            CNICBack.Enabled = false;

        }

        private void AddStateEmpInfo()
        {
            btnEmpInfoAdd.Visible = false;
            btnEmpInfoSave.Visible = true;
            btnEmpInfoEdit.Visible = false;
            btnEmpInfoRevert.Visible = true;
            btnEmpInfoAddEditSave.Visible = false;
            btnEmpInfoSearch.Visible = false;
        }

        private void RevertStateEmpInfo()
        {
            btnEmpInfoAdd.Visible = true;
            btnEmpInfoSave.Visible = false;
            btnEmpInfoEdit.Visible = true;
            btnEmpInfoRevert.Visible = false;
            btnEmpInfoAddEditSave.Visible = false;
            btnEmpInfoSearch.Visible = true;
        }

        private void EditSaveStateEmpInfo()
        {
            btnEmpInfoAdd.Visible = false;
            btnEmpInfoSave.Visible = false;
            btnEmpInfoEdit.Visible = false;
            btnEmpInfoRevert.Visible = true;
            btnEmpInfoAddEditSave.Visible = true;
            btnEmpInfoSearch.Visible = false;
        }
        private void getempdata()
        {
            DataClasses1DataContext Connection = new DataClasses1DataContext();

            var getProducts = from g in Connection.Edison_EmployeeInfos
                              where g.EmployeeID.Equals(txtEmpCode.Text.Trim())
                              select g;

            if (getProducts.Any())
            {
                foreach (var ab in getProducts)
                {
                    txtEmpName.Text = ab.EmployeeName;
                    txtEmpFatherName.Text = ab.FatherName;
                    txtEmpMotherName.Text = ab.MotherName;
                    txtCNICNo.Text = ab.CNIC;
                    txtCurrentAddress.Text = ab.CurrentAddress;

                    if (ab.DOB.ToString() != "")
                    {
                        dateDOB.Text = (ab.DOB).ToString();
                        dtp_EnabledChanged(dateDOB, null);
                    }

                    txtEducation.Text = ab.Education;
                    ComboDesignation.EditValue = ab.DesignationID;

                    if (ab.JoinDate.ToString() != "")
                    {
                        dateJoiningDate.Text = (ab.JoinDate).ToString();
                        dtp_EnabledChanged(dateJoiningDate, null);

                    }

                    if (ab.LeavingDate.ToString() != "")
                    {
                        dateLeavingDate.Text = (ab.LeavingDate).ToString();
                        dtp_EnabledChanged(dateLeavingDate, null);

                    }

                    ComboDepart.EditValue = ab.DepartmentID;
                    txtRefferedBy.Text = ab.RefferedBy;

                    txtBasicSalary.Text = (ab.BasicSalary).ToString();
                    txtCommisionPercentage.Text = ab.Percentage.ToString();

                    txtRemarks.Text = ab.Remarks;
                }

            }
            else
            {
                MessageBox.Show("No Record Found !");
                return;
            }

            //Show Phone No

            var getPhoneNo = from g in Connection.Edison_EmployeePhoneDetails
                             where g.EmpCode.Equals(txtEmpCode.Text.Trim())
                             select g;

            if (getPhoneNo.Any())
            {
                foreach (var ab in getPhoneNo)
                {
                    dataGridView1.Rows.Add(ab.EmployeePerson, ab.PhoneNo);
                }

            }

            // Get as single image from the database
            var img = (from image in Connection.Edison_EmployeeDatas
                       where image.EmpCode.Equals(txtEmpCode.Text.Trim())
                       select image);

            if (img.Any())
            {
                foreach (var abc in img)
                {
                    // Convert the byte[] to an System.Drawing.Image
                    if (abc.eImageFace != null)
                    {
                        picEmp.BackgroundImage = ByteArrayToImage(abc.eImageFace.ToArray());
                        picEmp.BackgroundImageLayout = ImageLayout.Zoom;
                        //  this.picEmp.Siz = PictureBoxSizeMode.Zoom;
                    }

                    if (abc.eImageCNICF != null)
                    {
                        CNICFront.BackgroundImage = ByteArrayToImage(abc.eImageCNICF.ToArray());
                        CNICFront.BackgroundImageLayout = ImageLayout.Zoom;
                    }


                    if (abc.eImageCNICB != null)
                    {
                        CNICBack.BackgroundImage = ByteArrayToImage(abc.eImageCNICB.ToArray());
                        CNICBack.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }


        }

        bool picturechange = false;
        bool cnicFchange = false;
        bool cnincBchange = false;
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void txtEmpCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ClearAllEmployeeInfo();
                    getempdata();
                }
            }
            catch(Exception err)
            {

            }
            
        }

        private void CNICFront_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Jpeg Files(*.Jpeg)|*.jpg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CNICFront.BackgroundImage = new Bitmap(dlg.FileName);
                    cnicFchange = true;
                }




            }
        }

        private void CNICBack_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Jpeg Files(*.Jpeg)|*.jpg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CNICBack.BackgroundImage = new Bitmap(dlg.FileName);
                    cnincBchange = true;
                }


            }
        }

    

        private void btnEmpInfoAdd_Click(object sender, EventArgs e)
        {
            ClearAllEmployeeInfo();
            AddStateEmpInfo();
            enableEmployeeAll();
            txtEmpName.Focus();
        }

        private void btnEmpInfoSearch_Click(object sender, EventArgs e)
        {
            ClearAllEmployeeInfo();
            txtEmpCode.Enabled = true;
            txtEmpCode.Focus();
        }

        private void btnEmpInfoEdit_Click(object sender, EventArgs e)
        {
            EditSaveStateEmpInfo();
            enableEmployeeAll();
        }

        private void btnEmpInfoRevert_Click(object sender, EventArgs e)
        {
            RevertStateEmpInfo();
            disableEmployeeAll();
            ClearAllEmployeeInfo();
        }

        private void btnEmpInfoSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpInfoSave_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                InsertNewEmployee();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error ");
            }
        }

        private void btnEmpInfoSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    InsertNewEmployee();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error ");
                }
            }
        }

        private void btnEmpInfoAddEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            EditSaveEmployeeInfo();
        }

        private void btnEmpInfoAddEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                EditSaveEmployeeInfo();
            }
        }

        private void EditSaveEmployeeInfo()
        {
            try
            {


                using (var scope = new System.Transactions.TransactionScope())
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    //Adding Pictures of Employee, CNIC FRONT & CNIC BACK
                    var getEmpdata = from t in db.Edison_EmployeeInfos
                                     where t.EmployeeID.Equals(txtEmpCode.Text.Trim())
                                     select t;

                    if (getEmpdata.Any())
                    {
                        foreach (var objCourse in getEmpdata)
                        {

                            objCourse.EmployeeName = txtEmpName.Text.Trim();

                            objCourse.FatherName = txtEmpFatherName.Text.Trim();

                            objCourse.MotherName = txtEmpMotherName.Text.Trim();

                            objCourse.CNIC = txtCNICNo.Text.Trim();

                            objCourse.CurrentAddress = txtCurrentAddress.Text.Trim();

                            objCourse.DOB = dateDOB.Value;

                            objCourse.Education = txtEducation.Text.Trim();

                            objCourse.DesignationID = Convert.ToInt32(ComboDesignation.EditValue);

                            if (dateJoiningDate.Checked == true)
                            {
                                objCourse.JoinDate = dateJoiningDate.Value;
                            }

                            if (dateLeavingDate.Checked == true)
                            {
                                objCourse.LeavingDate = dateLeavingDate.Value;
                            }


                            objCourse.DepartmentID = Convert.ToInt32(ComboDepart.EditValue);

                            objCourse.RefferedBy = txtRefferedBy.Text.Trim();

                            objCourse.BasicSalary = Convert.ToInt32(txtBasicSalary.Text.Trim());


                            objCourse.Percentage = Convert.ToDecimal(txtCommisionPercentage.Text.Trim());

                            objCourse.Remarks = txtRemarks.Text.Trim();

                            db.SubmitChanges();


                            //  txtEmpCode.Text = objCourse.EmployeeID.ToString();

                        }
                    }

                    var aa = from s in db.Edison_EmployeePhoneDetails
                             where s.EmpCode.Equals(txtEmpCode.Text.Trim())
                             select s;

                    if (aa.Any())
                    {
                        foreach (var dd in aa)
                        {
                            db.Edison_EmployeePhoneDetails.DeleteOnSubmit(dd);
                            db.SubmitChanges();
                        }
                    }



                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Edison_EmployeePhoneDetail AddPhoneNo = new Edison_EmployeePhoneDetail();
                        AddPhoneNo.EmpCode = Convert.ToInt32(txtEmpCode.Text);

                        if ((row.Cells[1].Value == null))
                        {

                        }
                        else
                        {
                            if (row.Cells[0].Value == null)
                            {

                            }
                            else
                            {
                                AddPhoneNo.EmployeePerson = (row.Cells[0].Value.ToString());
                            }


                            AddPhoneNo.PhoneNo = (row.Cells[1].Value.ToString());

                            db.Edison_EmployeePhoneDetails.InsertOnSubmit(AddPhoneNo);
                            db.SubmitChanges();
                        }


                    }


                    //var aab = from s in db.Edison_EmployeeDatas
                    //         where s.EmpCode.Equals(txtEmpCode.Text.Trim())
                    //         select s;

                    //if (aab.Any())
                    //{
                    //    foreach (var dd in aab)
                    //    {
                    //        db.Edison_EmployeeDatas.DeleteOnSubmit(dd);
                    //        db.SubmitChanges();
                    //    }
                    //}


                    //Adding Pictures of Employee, CNIC FRONT & CNIC BACK
                    var getlist = from t in db.Edison_EmployeeDatas
                                  where t.EmpCode.Equals(txtEmpCode.Text.Trim())
                                  select t;

                    if (getlist.Any())
                    {

                        foreach (var ab in getlist)
                        {

                            if (picEmp.BackgroundImage != null)
                            {
                                if (picturechange == true)
                                {
                                    ab.eImageFace = null;

                                    byte[] file_byte = ImageToByteArray(picEmp.BackgroundImage);

                                    System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);

                                    ab.eImageFace = file_binary;

                                    db.SubmitChanges();
                                }

                            }

                            if (CNICFront.BackgroundImage != null)
                            {
                                if (cnicFchange == true)
                                {
                                    ab.eImageCNICF = null;

                                    byte[] file_byte = ImageToByteArray(CNICFront.BackgroundImage);

                                    System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);

                                    ab.eImageCNICF = file_binary;

                                    db.SubmitChanges();
                                }

                            }


                            if (CNICBack.BackgroundImage != null)
                            {
                                if (cnincBchange == true)
                                {
                                    ab.eImageCNICB = null;

                                    byte[] file_byte = ImageToByteArray(CNICBack.BackgroundImage);

                                    System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);

                                    ab.eImageCNICB = file_binary;

                                    db.SubmitChanges();
                                }

                            }
                            break;


                        }
                    }
                    else
                    {


                        if (picEmp.BackgroundImage != null || (CNICFront.BackgroundImage != null) || (CNICBack.BackgroundImage != null))
                        {
                            Edison_EmployeeData AddNew = new Edison_EmployeeData();

                            if (picEmp.BackgroundImage != null)
                            {
                                if (picturechange == true)
                                {
                                    byte[] file_byte1 = ImageToByteArray(picEmp.BackgroundImage);
                                    System.Data.Linq.Binary file_binary1 = new System.Data.Linq.Binary(file_byte1);
                                    AddNew.eImageFace = file_binary1;
                                }
                            }

                            if ((CNICFront.BackgroundImage != null))
                            {
                                if (cnicFchange == true)
                                {
                                    byte[] file_byte2 = ImageToByteArray(CNICFront.BackgroundImage);
                                    System.Data.Linq.Binary file_binary2 = new System.Data.Linq.Binary(file_byte2);
                                    AddNew.eImageCNICF = file_binary2;
                                }
                            }


                            if ((CNICBack.BackgroundImage != null))
                            {
                                if (cnincBchange == true)
                                {
                                    byte[] file_byte3 = ImageToByteArray(CNICBack.BackgroundImage);
                                    System.Data.Linq.Binary file_binary3 = new System.Data.Linq.Binary(file_byte3);
                                    AddNew.eImageCNICB = file_binary3;
                                }
                            }


                            AddNew.EmpCode = Convert.ToInt32(txtEmpCode.Text.Trim());

                            db.Edison_EmployeeDatas.InsertOnSubmit(AddNew);
                            db.SubmitChanges();
                        }

                    }


                    scope.Complete();

                }
                RevertStateEmpInfo();
                disableEmployeeAll();
                dataGridView1.ClearSelection();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void dtp_EnabledChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            if (dtp.Checked) { dtp.CustomFormat = "dd MMMM yyyy"; } else { dtp.CustomFormat = " "; }
        }

        private void Edison_Payroll_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.EmployeLists' table. You can move, or remove it, as needed.
            this.employeListsTableAdapter.Fill(this.dataSet1.EmployeLists);
            // TODO: This line of code loads data into the 'dataSet1.Edison_Departments' table. You can move, or remove it, as needed.
            this.edison_DepartmentsTableAdapter.Fill(this.dataSet1.Edison_Departments);
            // TODO: This line of code loads data into the 'dataSet1.Edison_Designation' table. You can move, or remove it, as needed.
            this.edison_DesignationTableAdapter.Fill(this.dataSet1.Edison_Designation);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.employeListsTableAdapter.Fill(this.dataSet1.EmployeLists);
        }

        private void SearchEmployeeList()
        {
            try
            {

                DataView DV = new DataView(this.dataSet1.EmployeLists);

                DV.RowFilter = "(convert(EmployeeID, 'System.String') like '%" + textBox4.Text + "%' OR convert(EmployeeID, 'System.String') IS Null) AND (convert(EmployeeName, 'System.String') like '%" + textBox1.Text + "%' OR convert(EmployeeName, 'System.String') IS Null) AND (DesignationName like '%" + textBox2.Text + "%' OR DesignationName IS Null) AND (DepartmentName like '%" + textBox3.Text + "%' OR DepartmentName IS Null ) ";
                dataGridView2.DataSource = DV;

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SearchEmployeeList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchEmployeeList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchEmployeeList();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchEmployeeList();
        }
    }
}
