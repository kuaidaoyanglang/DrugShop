using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrugShop.UI.Reports
{
    public partial class FrmChildReport : Form
    {
        private int _BillID;

        public FrmChildReport()
        {
            InitializeComponent();
        }

        public FrmChildReport(int billId)
        {
            _BillID = billId;
            InitializeComponent();
            this.ctrlReport1.ReportTemplateFile = System.IO.Path.Combine(Application.StartupPath, "ReportTemplate/MySalesBillItem.rdlc");
        }


        private void FrmChildReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.ctrlReport1.DoSerch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
    }
}
