using System.Data;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MIS_ProgressiveDistributors
{
    public class GMSoft
    {
        public SqlConnection CN = new SqlConnection();

        public static string loginuser;


        public string PCInfo()
        {
            try
            {
                return (Environment.UserName + " | " + Environment.MachineName).ToString();
            }
            catch
            {
                return "";
            }
        }
        public void CnStr()
        {
            if (CN.State == ConnectionState.Open)
                CN.Close();
            CN.ConnectionString = global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString;
        }
        public Int32 Exec(string str)
        {
            Int32 ID = 0;
            try
            {
                CnStr();
                CN.Open();            
                SqlCommand cmd = new SqlCommand(str, CN);
                ID = Convert.ToInt32(cmd.ExecuteNonQuery());
                CN.Close();
            }
            catch (System.Exception ex)
            {
            }
            return ID;
        }
        public Int32 ExenID(string str)
        {
            Int32 ID = 0;
            try
            {
                CnStr();
                CN.Open();
                SqlCommand cmd = new SqlCommand(str, CN);
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                CN.Close();
            }
            catch (System.Exception ex)
            {
            }
            return ID;
        }
        public void fillCombo(ComboBox cmbName, string cmd)
        {
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                cmbName.ValueMember = MyDataSet.Tables[0].Columns[0].ColumnName;
                cmbName.DisplayMember = MyDataSet.Tables[0].Columns[1].ColumnName;
                cmbName.DataSource = MyDataSet.Tables[0];
                MyDataSet.Dispose();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public void fillList(ListBox listName, string cmd)
        {
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                listName.ValueMember = MyDataSet.Tables[0].Columns[0].ColumnName;
                listName.DisplayMember = MyDataSet.Tables[0].Columns[1].ColumnName;
                listName.DataSource = MyDataSet.Tables[0];
                MyDataSet.Dispose();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public void fillGrdCombo(DataGridViewComboBoxColumn cmbName, String cmd)
        {
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                cmbName.ValueMember = MyDataSet.Tables[0].Columns[0].ColumnName;
                cmbName.DisplayMember = MyDataSet.Tables[0].Columns[1].ColumnName;
                cmbName.DataSource = MyDataSet.Tables[0];
                MyDataSet.Dispose();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public void GetNum(TextBox NumBox, string cmd)
        {
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                if (MyDataSet.Tables[0].Rows[0][0].GetType().Name == "String")
                {
                    String hcode = (String)(MyDataSet.Tables[0].Rows[0][0]);
                    NumBox.Text = Convert.ToString(hcode);
                    NumBox.Tag = (String)(MyDataSet.Tables[0].Rows[0][1]);
                    MyDataSet.Dispose();
                }
                else
                {
                    Int32 hcode = (Int32)(MyDataSet.Tables[0].Rows[0][0]) + 1;
                    NumBox.Text = Convert.ToString(hcode);
                    MyDataSet.Dispose();
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        public void fillGridCbo(DataGridViewComboBoxColumn cmbName, string cmd)
        {
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                cmbName.ValueMember = MyDataSet.Tables[0].Columns[0].ColumnName;
                cmbName.DisplayMember = MyDataSet.Tables[0].Columns[1].ColumnName;
                cmbName.DataSource = MyDataSet.Tables[0];
                MyDataSet.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string CmdExe(SqlCommand Cmd)
        {
            string msg = "OK";
            try
            {
                CnStr();
                CN.Open();
                Cmd.Connection = CN;
                Cmd.CommandType = CommandType.Text;
                Cmd.ExecuteNonQuery();
                CN.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                CN.Close();
            }
            return msg;
        }
        public bool RecordChk(string cmd)
        {
            bool chk = true;
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                if (MyDataSet.Tables[0].Rows.Count >= 1)
                {
                    chk = false;
                }
                MyDataSet.Dispose();
            }
            catch (System.Exception ex)
            {
                chk = true;
            }
            return chk;
        }
        public string[] GetRecords(string cmd)
        {
            string[] R_Data = { "?", "?", "c", "d", "e", "f", "g", "h" };
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                int i = MyDataSet.Tables[0].Rows.Count - 1;
                int j = MyDataSet.Tables[0].Columns.Count - 1;
                int ss = 0;
                for (i = 0; i <= i; i++)
                {
                    for (j = 0; j <= j; j++)
                    {
                        ss = ss + 1;
                        R_Data[ss - 1] = MyDataSet.Tables[0].Rows[i][j].ToString();
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return R_Data;
        }

        public byte[] GetBytes(string cmd)
        {
            byte[] R_Data = null;
            try
            {
                DataSet MyDataSet = new DataSet();
                MyDataSet.Clear();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
                R_Data = (byte[])MyDataSet.Tables[0].Rows[0][0];
                

            }
            catch (System.Exception ex)
            {
            }
            return R_Data;
        }
        public void LockForm(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is GroupBox)
                {
                    foreach (Control ct in ctrl.Controls)
                    { LockControls(ct); }
                }
                if (ctrl is Panel)
                {
                    foreach (Control ctl in ctrl.Controls)
                    {
                        if (ctl is GroupBox)
                        {
                            foreach (Control ct in ctl.Controls)
                            { LockControls(ct);}
                        }
                    }
                }
            }
        }
        public void ULockForm(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is GroupBox)
                {
                    foreach (Control ct in ctrl.Controls)
                    { ULockControls(ct); }
                }
                if (ctrl is Panel)
                {
                    foreach (Control ctl in ctrl.Controls)
                    {
                        if (ctl is GroupBox)
                        {
                            foreach (Control ct in ctl.Controls)
                            { ULockControls(ct); }
                        }
                    }
                }
            }
        }
        private void LockControls(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).ReadOnly = true;
                ((TextBox)ctrl).BorderStyle = BorderStyle.None;
            }
            else if (ctrl is ComboBox)
            {
                ((ComboBox)ctrl).Enabled = false;
            }
            else if (ctrl is MaskedTextBox)
            {
                ((MaskedTextBox)ctrl).ReadOnly = true;
                ((MaskedTextBox)ctrl).BorderStyle = BorderStyle.None;
            }
            else if (ctrl is DateTimePicker)
            {
                ((DateTimePicker)ctrl).Enabled = false;
            }
            else if (ctrl is CheckBox)
            {
                ((CheckBox)ctrl).Enabled = false;
            }
            else if (ctrl is Button)
            {
                ((Button)ctrl).Enabled = false;
            }
            else if (ctrl is DataGridView)
            {
                ((DataGridView)ctrl).Enabled = false;
            }
        }
        private void ULockControls(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                ((TextBox)ctrl).ReadOnly = false;
                ((TextBox)ctrl).BorderStyle = BorderStyle.Fixed3D;
            }
            else if (ctrl is ComboBox)
            {
                ((ComboBox)ctrl).Enabled = true;
            }
            else if (ctrl is MaskedTextBox)
            {
                ((MaskedTextBox)ctrl).ReadOnly = false;
                ((MaskedTextBox)ctrl).BorderStyle = BorderStyle.Fixed3D;
            }
            else if (ctrl is DateTimePicker)
            {
                ((DateTimePicker)ctrl).Enabled = true;
            }
            else if (ctrl is CheckBox)
            {
                ((CheckBox)ctrl).Enabled = true;
            }
            else if (ctrl is Button)
            {
                ((Button)ctrl).Enabled = true;
            }
            else if (ctrl is DataGridView)
            {
                ((DataGridView)ctrl).Enabled = true;
            }
        }
        public void ClearForm(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is GroupBox)
                {
                    ClearGroup(((GroupBox)ctrl));
                    ClearGroupA(((GroupBox)ctrl));
                }
                if (ctrl is Panel)
                {
                    foreach (Control pctrl in ctrl.Controls)
                    {
                        if (pctrl is GroupBox)
                        {
                            ClearGroupA(((GroupBox)pctrl));
                        }
                    }
                }
            }
        }
        public void InvertColor(GroupBox GroupBox, Color Color)
        {
            foreach (Control ctrl in GroupBox.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = Color.FromArgb(Color.ToArgb() ^ 0xfffff0);
                }
                else if (ctrl is CheckBox)
                {
                    ctrl.ForeColor = Color.FromArgb(Color.ToArgb() ^ 0xfffff0);
                }
            }
        }
        public void ClearGroup(GroupBox TabCrt)
        {
            foreach (Control ctrl in TabCrt.Controls)
            {
                if (ctrl is GroupBox)
                {
                    ClearGroupA(((GroupBox)ctrl));
                }
            }
        }
        public void ClearGroupA(GroupBox TabCrt)
        {
            foreach (Control ctrl in TabCrt.Controls)
            {
                if (ctrl is TextBox)
                {
                    //ctrl.Text = "";
                    ((TextBox)ctrl).Clear();
                }
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = "";
                }
                else if (ctrl is MaskedTextBox)
                {
                    ((MaskedTextBox)ctrl).Clear();
                }
                else if (ctrl is Int32TextBox)
                {
                    ((Int32TextBox)ctrl).Clear();
                }
                else if (ctrl is DateTimePicker)
                {
                    if (((DateTimePicker)ctrl).ShowCheckBox) {((DateTimePicker)ctrl).Value = DateTime.Now;
                    ((DateTimePicker)ctrl).Checked = false; }
                }
                else if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }
                else if (ctrl is Button)
                {
                    ((Button)ctrl).BackgroundImage = null;
                }
                else if (ctrl is DataGridView)
                {
                    ((DataGridView)ctrl).Rows.Clear();
                }
            }
        }
        public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        public DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        public string CleanSQL(string Txt)
        {
            return Txt.Replace("'", "''").Replace("-", "'-");
        }
        public DataSet FillDSet(string cmd)
        {
            DataSet MyDataSet = new DataSet();
            try
            {
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(cmd, (string)global::MIS_ProgressiveDistributors.Properties.Settings.Default.ProgressiveMISConnectionString);
                MyDataAdapter.Fill(MyDataSet);
            }
            catch
            {
            }
            return MyDataSet;
        }
        public Image ByteToImg(byte[] byt)
        {
            Image img = null;
            try
            {
                using (MemoryStream stream = new MemoryStream(byt))
                {
                    img = Image.FromStream(stream);
                    stream.Close();
                }
            }
            catch (Exception ex) { }

            //return FixedSize(img, 250, 200);
            return img;
        }
        public byte[] ImageToByte(Image img)
        {
            byte[] byteArray = new byte[0];
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Close();
                    byteArray = stream.ToArray();
                }
            }
            catch (Exception ex) { }
            return byteArray;
        }
        static Image FixedSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Red);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }

    public class Int32TextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            NumberFormatInfo fi = CultureInfo.CurrentCulture.NumberFormat;
            string c = e.KeyChar.ToString();
            if (char.IsDigit(c, 0))
                return;
            if ((SelectionStart == 0) && (c.Equals(fi.NegativeSign)))
                return;
            // copy/paste
            if ((((int)e.KeyChar == 22) || ((int)e.KeyChar == 3))
                && ((ModifierKeys & Keys.Control) == Keys.Control))
                return;
            if (e.KeyChar == '\b')
                return;
            e.Handled = true;
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_PASTE = 0x0302;
            if (m.Msg == WM_PASTE)
            {
                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text))
                    return;
                if ((text.IndexOf('+') >= 0) && (SelectionStart != 0))
                    return;
                int i;
                if (!int.TryParse(text, out i)) // change this for other integer types
                    return;
                if ((i < 0) && (SelectionStart != 0))
                    return;
            }
            base.WndProc(ref m);
        }
    }
}
