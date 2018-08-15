using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DrugShop.Core;
using DrugShop.Model;

namespace DrugShop.UI
{
    public partial class FrmMainForm : Form
    {
        private User _CurrentUser { get; set; }
        public FrmMainForm()
        {
            InitializeComponent();
        }
        public FrmMainForm(User user)
        {
            InitializeComponent();
            _CurrentUser = user;
            this.tslUserName.Text = _CurrentUser.Name;
            this.tslVersion.Text = Application.ProductVersion.ToString();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog(this);
        }
        private void 销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockOut));
        }
        private void 采购ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockIn));
        }
        private void 调拨ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockTrac));
        }
        private void 库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockMgr));
        }

        private void 报表查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmStockReport));
        }

        private void 基础数据维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OpenChildForm(typeof(FrmInfo));
        }
        private void OpenChildForm(Type childType)
        {
            bool IsOpened = false;
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == childType)
                {
                    child.Activate();
                    IsOpened = true;
                    break;
                }
            }
            if (!IsOpened)
            {
                Form childFrom = (Form)Activator.CreateInstance(childType);
                childFrom.MdiParent = this;
                childFrom.WindowState = FormWindowState.Maximized;
                childFrom.Show();
            }
        }
        private void 平铺窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 个人密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmChangPwd frm = new FrmChangPwd();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void 系统配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 权限控制台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                User user = PermissionService.GetCurrentUser();
                if (user.IsAdmin)
                {
                    FrmPermission frm = new FrmPermission();
                    frm.ShowDialog(this);
                }
                else
                {
                    throw new ApplicationException("权限不足，无法执行此操作！");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
            
        }

        private void FrmMainForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
