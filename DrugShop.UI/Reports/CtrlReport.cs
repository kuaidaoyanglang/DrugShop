using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DrugShop.UI.DataEntity;
using DrugShop.UI.DataEntity.DataSetBillsTableAdapters;
using DrugShop.Core;

namespace DrugShop.UI.Reports
{
    public partial class CtrlReport : UserControl
    {

        public CtrlReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取或设置报表模板全名
        /// </summary>
        public string ReportTemplateFile { get; set; }
        /// <summary>
        /// 是否支持透视报表能来
        /// </summary>
        public bool IsSupportChildReport { get; set; }

        public void DoSerch()
        {
            this.ReportViewer.LocalReport.ReportEmbeddedResource = "DrugShop.UI.ReportTemplate.MySalesBills.rdlc";
            this.ReportViewer.Refresh();
        }

        private void ReprotInitialize()
        {
           
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {

            try
            {
                this.DoSerch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }



      

        private void tsbExport_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
           
        }

    }
}
