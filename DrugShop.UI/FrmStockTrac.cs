using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DrugShop.UI.StockIn;
using DrugShop.Model;
using DrugShop.Core;

namespace DrugShop.UI
{
    public partial class FrmStockTrac : Form
    {
        public FrmStockTrac()
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
                switch (e.Node.Text)
                {
                    case "采购单录入":
                        this.AddCtrlIntoPanel(new CtrlStockInBillInput());
                        break;
                    case "":
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
