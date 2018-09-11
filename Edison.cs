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
    public partial class Edison : Form
    {
        public Edison()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            EdisonProducts opennew = new EdisonProducts();
            opennew.Show();
 
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            EdisonSales opennew = new EdisonSales();
            opennew.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            EdisonSettings opennew = new EdisonSettings();
            opennew.Show();
        }

        private void Edison_Load(object sender, EventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            EdisonPurchase opennew = new EdisonPurchase();
            opennew.Show();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            Edison_Payroll makenew = new Edison_Payroll();
            makenew.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            EdisonImport opennew = new EdisonImport();
            opennew.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            EdisonSupplierLibrary opennew = new EdisonSupplierLibrary();
            opennew.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Edison_Customers opennew = new Edison_Customers();
            opennew.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            EdisonInventory opennew = new EdisonInventory();
            opennew.Show();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Edison_Reports opennew = new Edison_Reports();
            opennew.Show();
        }
    }
}
