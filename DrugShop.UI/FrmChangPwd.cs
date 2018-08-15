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
    public partial class FrmChangPwd : Form
    {
        
        public FrmChangPwd()
        {
            InitializeComponent();
        }
        

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //Verify
                if (string.IsNullOrEmpty(this.txtOldPwd.Text.Trim()))
                {
                    throw new ApplicationException("原始密码不能为空");
                }
                if (string.IsNullOrEmpty(this.txtNewPwd.Text.Trim()))
                {
                    throw new ApplicationException("修改密码不能为空");
                }
                if (string.IsNullOrEmpty(this.txtVerifyPwd.Text.Trim()))
                {
                    throw new ApplicationException("确认密码不能为空");
                }
                if (this.txtNewPwd.Text!=this.txtVerifyPwd.Text)
                {
                    throw new ApplicationException("两次输入的密码不一致");
                }
                //save
                User user = PermissionService.GetCurrentUser();
                string OldPwd = this.txtOldPwd.Text.Trim();
                PermissionService service = new PermissionService();
                try
                {
                    service.Login(user.Code,OldPwd);
                }
                catch (Exception)
                {
                    throw new ApplicationException("原始密码不正确,无法修改");
                }
                user.Password = this.txtNewPwd.Text.Trim();
                service.ModifyUser(user,user.Name);
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        } 
    }
}
