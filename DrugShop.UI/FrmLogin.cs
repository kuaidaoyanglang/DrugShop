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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            #region 皮肤设置
            this.skinEngine1.SkinFile = @"../theme/WaveColor1.ssk";
            if (string.IsNullOrEmpty(this.skinEngine1.SkinFile) || !System.IO.File.Exists(skinEngine1.SkinFile))
            {
                this.skinEngine1.Active = false; // 设置不加载皮肤
                this.skinEngine1.SkinAllForm = true; // 设置皮肤只在主窗体显示，不加载于其他所有的窗体
            }
            #endregion

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                PermissionService service = new PermissionService();
                cmbUser.DataSource = service.GetAllUsers();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                PermissionService service = new PermissionService();
                User user = (User)this.cmbUser.SelectedItem;
                string password = this.txtPassword.Text;

                if (string.IsNullOrEmpty(password) || user == null)
                {
                    throw new ApplicationException("用户名和密码不能为空！");
                }
                service.Login(user.Code, password);
                FrmMainForm frm = new FrmMainForm(user);
                this.DialogResult = DialogResult.OK;
                this.Hide();
                frm.Show(this);
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

    }
}
