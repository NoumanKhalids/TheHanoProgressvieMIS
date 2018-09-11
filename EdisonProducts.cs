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
    public partial class EdisonProducts : Form
    {
        public EdisonProducts()
        {
            InitializeComponent();
        }

        private void EdisonProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Edison_Products' table. You can move, or remove it, as needed.
            loadProductBrand();
            loadProductGrid();
            loadCategoryGrid();

        }

        private void loadProductBrand()
        {

            this.productBrandTableAdapter.Fill(this.dataSet1.ProductBrand);
            dataGridView3.ClearSelection();
        }


        private void loadProductGrid()
        {
            this.edison_ProductsTableAdapter.Fill(this.dataSet1.Edison_Products);
            dataGridView1.ClearSelection();
        }
        private void loadCategoryGrid()
        {
            this.edison_ProductsCategoryTableAdapter.Fill(this.dataSet1.Edison_ProductsCategory);
       
 
            dataGridView2.ClearSelection();
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox7.Enabled = true;
            CatAddState();

        }
        private void CatAddState()
        {
            btnCatAdd.Visible = false;
            btnCatRevert.Visible = true;
            btnCatSave.Visible = true;
            btnCatEdit.Visible = false;
            btnCatEditSave.Visible = false;
        }

        private void CatRevertState()
        {

            btnCatAdd.Visible = true;
            btnCatRevert.Visible = false;
            btnCatSave.Visible = false;
            btnCatEdit.Visible = true;
            btnCatEditSave.Visible = false;

        }


        private void CatEditSaveState()
        {
            btnCatAdd.Visible = false;
            btnCatRevert.Visible = true;
            btnCatSave.Visible = false;
            btnCatEdit.Visible = false;
            btnCatEditSave.Visible = true;
        }
        private void btnCatSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                Edison_ProductsCategory AddNew = new Edison_ProductsCategory();

                AddNew.Category = textBox7.Text.Trim();


                db.Edison_ProductsCategories.InsertOnSubmit(AddNew);
                db.SubmitChanges();

                textBox8.Text = AddNew.ProductCatID.ToString();
                textBox7.Enabled = false;
                CatRevertState();
                loadCategoryGrid();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void btnCatRevert_Click(object sender, EventArgs e)
        {
            CatRevertState();
            textBox7.Clear();
            textBox8.Clear();
            textBox7.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

                textBox8.Text = (selectedRow.Cells[0].Value).ToString();
                textBox7.Text = (selectedRow.Cells[1].Value).ToString();



            }
        }

        private void btnCatEdit_Click(object sender, EventArgs e)
        {
            CatEditSaveState();
            textBox7.Enabled = true;
            textBox7.Focus();
            
        }

        private void btnCatEditSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_ProductsCategories
                                        where d.ProductCatID.Equals(Convert.ToInt32(textBox8.Text.Trim()))
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var ab in getTheOrderDetail)
                    {

                        ab.Category = textBox7.Text.Trim();                
                        db.SubmitChanges();              
                        textBox7.Enabled = false;
                        CatRevertState();
                        loadCategoryGrid();
                        break;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void RP_AddState()
        {
            btn_RPAdd.Visible = false;
            btn_RPSave.Visible = true;
            btn_RPRevert.Visible = true;
            btn_RPEdit.Visible = false;
            btn_RPEditSave.Visible = false;
            btn_RPSearch.Visible = false;
        }


        private void RP_RevertState()
        {
            btn_RPAdd.Visible = true;
            btn_RPSave.Visible = false;
            btn_RPRevert.Visible = false;
            btn_RPEdit.Visible = true;
            btn_RPEditSave.Visible = false;
            btn_RPSearch.Visible = true;
        }



        private void RP_EditSaveState()
        {
            btn_RPAdd.Visible = false;
            btn_RPSave.Visible = false;
            btn_RPRevert.Visible = true;
            btn_RPEdit.Visible = false;
            btn_RPEditSave.Visible = true;
            btn_RPSearch.Visible = false;
        }






        private void RP_EnableAll()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            searchLookUpEdit2.Enabled = true;
            searchLookUpEdit1.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            chkStatus.Enabled = true;


            textBox12.Enabled = true;

            textBox11.Enabled = true;

        }

        private void RP_DisableAll()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            searchLookUpEdit2.Enabled = false;
            searchLookUpEdit1.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            chkStatus.Enabled = false;

            textBox12.Enabled = false;

            textBox11.Enabled = false;


        }

        private void RP_ClearAll()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            searchLookUpEdit2.Text = "";
            searchLookUpEdit1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            chkStatus.Checked = false;
            textBox12.Text = "";
            textBox11.Text = "";

        }

        private void btn_RPAdd_Click(object sender, EventArgs e)
        {
            RP_ClearAll();
            RP_EnableAll();
            RP_AddState();
            textBox2.Focus();


        }

        private void RP_Save()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            Edison_Product AddNew = new Edison_Product();

            AddNew.ProductCode = textBox2.Text.Trim();
            AddNew.ProductDescription = textBox3.Text.Trim();
            AddNew.ProductBrand = Convert.ToInt32(searchLookUpEdit2.EditValue);
            AddNew.ProductCategory = Convert.ToInt32(searchLookUpEdit1.EditValue);

            AddNew.OpeningStocks = (Convert.ToDecimal(textBox4.Text == "" ? "0" : textBox4.Text));
            AddNew.OpeningReplace = (Convert.ToDecimal(textBox12.Text == "" ? "0" : textBox12.Text));
            AddNew.PurchasePrice = (Convert.ToDecimal(textBox5.Text == "" ? "0" : textBox5.Text));
            AddNew.RSSalePrice = (Convert.ToDecimal(textBox6.Text == "" ? "0" : textBox6.Text));
            AddNew.WSSalePrice = (Convert.ToDecimal(textBox11.Text == "" ? "0" : textBox11.Text));



            if (chkStatus.Checked == true)
            {
                AddNew.Status = true;
            }
            else
            {
                AddNew.Status = false;
            }

            db.Edison_Products.InsertOnSubmit(AddNew);
            db.SubmitChanges();
            db.Dispose();
            loadProductGrid();

        }



        private void btn_RPSave_MouseClick(object sender, MouseEventArgs e)
        {
            RP_Save();
        }

        private void btn_RPSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                RP_Save();
            }
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
                searchLookUpEdit2.Focus();
                searchLookUpEdit2.ShowPopup();
            }
        }

        private void searchLookUpEdit2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
                textBox4.Focus();
            }
        }

        private void textBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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

        private void btn_RPEdit_Click(object sender, EventArgs e)
        {
            RP_EnableAll();
            RP_EditSaveState();

            textBox2.Focus();
        }

        private void btn_RPRevert_Click(object sender, EventArgs e)
        {
            RP_DisableAll();
            RP_ClearAll();
            RP_RevertState();
        }

        private void btn_RPEditSave_Click(object sender, EventArgs e)
        {

        }

        private void RP_EditSaveCommand()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();


            var getTheOrderDetail = from d in db.Edison_Products
                                    where d.ProductID.Equals(textBox1.Text.Trim())
                                    select d;

            if (getTheOrderDetail.Any())
            {
                foreach (var AddNew in getTheOrderDetail)
                {

                    AddNew.ProductCode = textBox2.Text.Trim();
                    AddNew.ProductDescription = textBox3.Text.Trim();
                    AddNew.ProductBrand = Convert.ToInt32(searchLookUpEdit2.EditValue);
                    AddNew.ProductCategory = Convert.ToInt32(searchLookUpEdit1.EditValue);
                    
                    AddNew.OpeningStocks = (Convert.ToDecimal(textBox4.Text == "" ? "0" : textBox4.Text));
                    AddNew.OpeningReplace = (Convert.ToDecimal(textBox12.Text == "" ? "0" : textBox12.Text));
                    AddNew.PurchasePrice = (Convert.ToDecimal(textBox5.Text == "" ? "0" : textBox5.Text));
                    AddNew.RSSalePrice = (Convert.ToDecimal(textBox6.Text == "" ? "0" : textBox6.Text));
                    AddNew.WSSalePrice = (Convert.ToDecimal(textBox11.Text == "" ? "0" : textBox11.Text));

                    if (chkStatus.Checked == true)
                    {
                        AddNew.Status = true;
                    }
                    else
                    {
                        AddNew.Status = false;
                    }

               
                    db.SubmitChanges();
        
                }
            }
            RP_RevertState();
            RP_DisableAll();
            loadProductGrid();
            db.Dispose();
        }
        private void btn_RPEditSave_MouseClick(object sender, MouseEventArgs e)
        {
            RP_EditSaveCommand();
        }

        private void btn_RPEditSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                RP_EditSaveCommand();
            }
        }

        int selectedrowindex = -1;

        private void getdataformgrid()
        {

            try
            {
                RP_ClearAll();

                selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

                textBox1.Text = (selectedRow.Cells[0].Value).ToString();


                if (dataGridView1.Rows[selectedrowindex].Cells[1].Value == null)
                {
                    textBox2.Clear();
                }
                else
                {
                    textBox2.Text = selectedRow.Cells[1].Value.ToString();
                }



                if (dataGridView1.Rows[selectedrowindex].Cells[2].Value == null)
                {
                    textBox3.Clear();
                }
                else
                {
                    textBox3.Text = selectedRow.Cells[2].Value.ToString();
                }



                if (dataGridView1.Rows[selectedrowindex].Cells[3].Value == null)
                {
                    searchLookUpEdit2.Text = "";
                }
                else
                {
                    searchLookUpEdit2.Text = selectedRow.Cells[3].Value.ToString();
                }



                if (dataGridView1.Rows[selectedrowindex].Cells[5].Value == null)
                {
                    searchLookUpEdit1.Text = "";
                }
                else
                {
                    searchLookUpEdit1.Text = selectedRow.Cells[5].Value.ToString();
                }



                if (dataGridView1.Rows[selectedrowindex].Cells[7].Value == null)
                {
                    textBox4.Clear();
                }
                else
                {
                    textBox4.Text = selectedRow.Cells[7].Value.ToString();
                }



                if (dataGridView1.Rows[selectedrowindex].Cells[8].Value == null)
                {
                    textBox12.Clear();
                }
                else
                {
                    textBox12.Text = selectedRow.Cells[8].Value.ToString();
                }


                if (dataGridView1.Rows[selectedrowindex].Cells[9].Value == null)
                {
                    textBox5.Clear();
                }
                else
                {
                    textBox5.Text = selectedRow.Cells[9].Value.ToString();
                }

                if (dataGridView1.Rows[selectedrowindex].Cells[10].Value == null)
                {
                    textBox6.Clear();
                }
                else
                {
                    textBox6.Text = selectedRow.Cells[10].Value.ToString();
                }


                if (dataGridView1.Rows[selectedrowindex].Cells[11].Value == null)
                {
                    textBox11.Clear();
                }
                else
                {
                    textBox11.Text = selectedRow.Cells[11].Value.ToString();
                }






                if (dataGridView1.Rows[selectedrowindex].Cells[12].Value == null)
                {
                    chkStatus.Checked = false;
                }
                else
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[selectedrowindex].Cells[12].Value) == true)
                    {
                        chkStatus.Checked = true;
                    }
                    else
                    {
                        chkStatus.Checked = false;
                    }
                }

            }
            catch (Exception err)
            {

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getdataformgrid();

        }



        private void simpleButton10_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox9.Text = "";

            PB_AddState();

            textBox9.Enabled = true;
            textBox9.Focus();

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = false;
            textBox10.Text = "";
            textBox9.Text = "";
            PB_RevertState();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            textBox9.Enabled = true;
            PB_EditSaveState();
            textBox9.Focus();            
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];

                textBox10.Text = (selectedRow.Cells[0].Value).ToString();
                textBox9.Text = (selectedRow.Cells[1].Value).ToString();



            }
        }

        private void PB_AddState()
        {
            Btn_PBAdd.Visible = false;
            Btn_PBSave.Visible = true;
            Btn_PBRevert.Visible = true;
            Btn_PBEdit.Visible = false;
            Btn_PBEditSave.Visible = false;
 
        }


        private void PB_RevertState()
        {
            Btn_PBAdd.Visible = true;
            Btn_PBSave.Visible = false;
            Btn_PBRevert.Visible = false;
            Btn_PBEdit.Visible = true;
            Btn_PBEditSave.Visible = false;
    
        }



        private void PB_EditSaveState()
        {
            Btn_PBAdd.Visible = false;
            Btn_PBSave.Visible = false;
            Btn_PBRevert.Visible = true;
            Btn_PBEdit.Visible = false;
            Btn_PBEditSave.Visible = true;


        }

        private void Btn_PBSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                Edison_ProductsBrand AddNew = new Edison_ProductsBrand();

                AddNew.BrandName = textBox9.Text.Trim();


                db.Edison_ProductsBrands.InsertOnSubmit(AddNew);
                db.SubmitChanges();

                textBox10.Text = AddNew.EdBrandID.ToString();
                textBox9.Enabled = false;
                PB_RevertState();
                loadProductBrand();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void Btn_PBEditSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();


                var getTheOrderDetail = from d in db.Edison_ProductsBrands
                                        where d.EdBrandID.Equals(textBox10.Text.Trim())
                                        select d;

                if (getTheOrderDetail.Any())
                {
                    foreach (var AddNew in getTheOrderDetail)
                    {
                        AddNew.BrandName = textBox9.Text.Trim();             
                        db.SubmitChanges();                   
                   
                    }
                }
                textBox9.Enabled = false;
                PB_RevertState();
                loadProductBrand();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.Equals(Keys.Up))
            {
                getdataformgrid();
                //  KeyUpOfProductCodeGrid();
            }


            //
            if (e.KeyCode.Equals(Keys.Down))
            {
                getdataformgrid(); 
                // KeyUpOfProductCodeGrid();
            }

        }
    }
}
