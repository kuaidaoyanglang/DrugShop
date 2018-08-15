using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DrugShop.Model;
using DrugShop.Core;

namespace DrugShop.UI
{
    public partial class FrmInfo : Form
    {
        public FrmInfo()
        {
            InitializeComponent();
        }

        private void FrmInfo_Load(object sender, EventArgs e)
        {
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
                
                switch (e.Node.Text)
                {
                    case "仓库":
                        AddCtrlIntoPanel(new Info.CtrlStorehouse());
                        break;
                    case "药品":
                        AddCtrlIntoPanel(new Info.CtrlDrugs());
                        break;
                    case "药品类别":
                        AddCtrlIntoPanel(new Info.CtrlDrugCategory());
                        break;
                    case "药品产地":
                        AddCtrlIntoPanel(new Info.CtrlDrugFrom());
                        break;
                    case "客户":
                        AddCtrlIntoPanel(new Info.CtrlCompany());
                        break;
                    case "客户类别":
                        AddCtrlIntoPanel(new Info.CtrlCompanyType());
                        break;
                    case "票据类别":
                        AddCtrlIntoPanel(new Info.CtrlBillsType());
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
