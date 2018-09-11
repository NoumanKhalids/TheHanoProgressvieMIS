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
    public partial class ReportViewer : Form
    {

        private GMSoft GM = new GMSoft();
        public ReportViewer(string[] sp, string rtp, string sectorreport, string cityreport, string agentname)
        {
            InitializeComponent();
            sector = sectorreport;
            city = cityreport;
            agent = agentname;

            RunReport(sp, rtp);
        }



        private string sector;
        private string city;
        private string agent;
        private string p1;
        private string p2;
        private string p3;
        private string p4;

        private void ReportViewer_Load(object sender, EventArgs e)
        {

            this.rptViewer.RefreshReport();
        }


        private void RunReport(string[] sp, string rtp)
        {
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.ReportEmbeddedResource = rtp;

            //if(rtp != "MetalTech.NoPaymentReport.rdlc")
            //{
            for (int i = 1; i <= sp.Length; i++)
            {
                ReportDataSource ds = new ReportDataSource("DataSet" + i, GM.FillDSet(sp[i - 1]).Tables[0]);
                rptViewer.LocalReport.DataSources.Add(ds);
            }
            //}
            //else
            //{
            //    ReportDataSource rprtDTSource = new ReportDataSource();
            //    rprtDTSource.Name = "DataSet1";
            //    rprtDTSource.Value = DataSet1.Nopaymentreport;
            //    rptViewer.LocalReport.DataSources.Add(rprtDTSource);
            //}




            ReportParameter param3 = new ReportParameter();
            param3 = new ReportParameter("PrintedBy", GMSoft.loginuser, false);

            //Sector
            ReportParameter param1 = new ReportParameter();
            param1 = new ReportParameter("ReportParameter1", sector, false);
            //City
            ReportParameter param2 = new ReportParameter();
            param2 = new ReportParameter("City", city, false);
            //Agent
            ReportParameter param4 = new ReportParameter();
            param4 = new ReportParameter("Agent", agent, false);

            if (GMSoft.loginuser == "")
            {

            }
            else
            {
             //   rptViewer.LocalReport.SetParameters(param3);
            }


            if (sector == "")
            {

            }
            else
            {
                rptViewer.LocalReport.SetParameters(param1);
            }

            if (city == "")
            {

            }
            else
            {
                rptViewer.LocalReport.SetParameters(param2);
            }

            if (agent == "")
            {

            }
            else
            {
                rptViewer.LocalReport.SetParameters(param4);
            }






            this.rptViewer.RefreshReport();
        }



    }
}
