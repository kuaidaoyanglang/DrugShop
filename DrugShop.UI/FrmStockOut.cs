using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DrugShop.UI.Bill;
using DrugShop.Model;
using DrugShop.Core;
using DrugShop.UI.Reports;

namespace DrugShop.UI
{
    public partial class FrmStockOut : Form
    {
        private const string BILL_TYPE = "销售开票";
        public FrmStockOut()
        {
            InitializeComponent();
        }
        private void FrmStockIn_Load(object sender, EventArgs e)
        {
            ///把功能菜单全部打开
            this.treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
                {
                    lblDescription.Text = e.Node.Tag == null ? "" : e.Node.Tag.ToString();
                }
                PermissionService service = new PermissionService();
                if (e.Node.Parent != null)
                {
                    if (!service.IsUserAccess(e.Node.Text))
                    {
                        throw new ApplicationException("没有权限，无法执行此操作");
                    }
                }
                BillsType billsType = new CacheService().GetBillsType(BILL_TYPE);
                switch (e.Node.Text)
                {
                    case "销售单录入":
                        CtrlBillInput ctrlBillInput = new CtrlBillInput();
                        ctrlBillInput.BillsType = billsType;
                        this.AddCtrlIntoPanel(ctrlBillInput);
                        break;
                    case "作废我的销售单":
                        CtrlBillOP ctrlBillOPBlank = new CtrlBillOP();
                        ctrlBillOPBlank.BillsType = billsType;
                        ctrlBillOPBlank.BlankOutButtonVisible = true;
                        ctrlBillOPBlank.CancelOutButtonVisible = false;
                        ctrlBillOPBlank.MakerConditionEnable = true;
                        this.AddCtrlIntoPanel(ctrlBillOPBlank);
                        break;
                    case "冲销我的销售单":
                        CtrlBillOP ctrlBillOPCancel = new CtrlBillOP();
                        ctrlBillOPCancel.BillsType = billsType;
                        ctrlBillOPCancel.BlankOutButtonVisible = false;
                        ctrlBillOPCancel.CancelOutButtonVisible = true;
                        ctrlBillOPCancel.MakerConditionEnable = true;
                        this.AddCtrlIntoPanel(ctrlBillOPCancel);
                        break;
                    case "查询我的销售单":
                        CtrlReport ctrlReportSearch = new CtrlReport();
                        ctrlReportSearch.ReportTemplateFile = System.IO.Path.Combine(Application.StartupPath, @"ReportTemplate/MySalesBills.rdlc");
                        this.AddCtrlIntoPanel(ctrlReportSearch);
                        break;
                    case "作废全部销售单":
                        CtrlBillOP ctrlBillOPBlankAll = new CtrlBillOP();
                        ctrlBillOPBlankAll.BillsType = billsType;
                        ctrlBillOPBlankAll.BlankOutButtonVisible = true;
                        ctrlBillOPBlankAll.CancelOutButtonVisible = false;
                        ctrlBillOPBlankAll.MakerConditionEnable = true;
                        this.AddCtrlIntoPanel(ctrlBillOPBlankAll);
                        break;
                    case "冲销全部销售单":
                        CtrlBillOP ctrlBillOPCancelALL = new CtrlBillOP();
                        ctrlBillOPCancelALL.BillsType = billsType;
                        ctrlBillOPCancelALL.BlankOutButtonVisible = false;
                        ctrlBillOPCancelALL.CancelOutButtonVisible = true;
                        ctrlBillOPCancelALL.MakerConditionEnable = true;
                        this.AddCtrlIntoPanel(ctrlBillOPCancelALL);
                        break;
                    case "查询全部销售单":
                        CtrlBillOP ctrlBillOPSearchAll = new CtrlBillOP();
                        ctrlBillOPSearchAll.BillsType = billsType;
                        ctrlBillOPSearchAll.BlankOutButtonVisible = false;
                        ctrlBillOPSearchAll.CancelOutButtonVisible = true;
                        ctrlBillOPSearchAll.MakerConditionEnable = true;
                        this.AddCtrlIntoPanel(ctrlBillOPSearchAll);
                        break;
                    case "客户退货单录入":
                        CtrlBillInput ctrlBillInputReturn = new CtrlBillInput();
                        ctrlBillInputReturn.BillsType = new CacheService().GetBillsType("客方退货");
                        this.AddCtrlIntoPanel(ctrlBillInputReturn);
                        break;
                    case "客户退货单作废":
                        CtrlBillOP ctrlBillOPBlankReturn = new CtrlBillOP();
                        ctrlBillOPBlankReturn.BillsType = new CacheService().GetBillsType("己方退货");
                        ctrlBillOPBlankReturn.BlankOutButtonVisible = true;
                        ctrlBillOPBlankReturn.CancelOutButtonVisible = false;
                        ctrlBillOPBlankReturn.MakerConditionEnable = true;
                        this.AddCtrlIntoPanel(ctrlBillOPBlankReturn);
                        break;
                    case "客户退货单查询":

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
        private void AddCtrlIntoPanel(UserControl ctrl)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
        }

        private void tsbShowTree_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = false;
        }

        private void tsbHideTree_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel1Collapsed = true;
        }

    }
}
