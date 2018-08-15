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
    public partial class FrmUser : Form
    {
        private User Model { get; set; }
        /// <summary>
        /// 用于创建
        /// </summary>
        public FrmUser()
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"新建用户");
        }
        /// <summary>
        /// 用于修改
        /// </summary>
        /// <param name="model"></param>
        public FrmUser(User model)
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"修改用户");
            this.Model = model;
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.txtPassword.Text = model.Password;
            this.ckbIsAdmin.Checked = model.IsAdmin;
            this.ckbActived.Checked = model.Actived;
            this.txtRemark.Text = model.Remark;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //save
                PermissionService service = new PermissionService();
                if (this.Model==null)//新建
                {
                    User model = new User();
                    model.Code = this.txtCode.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.Password = this.txtPassword.Text.Trim();
                    model.IsAdmin = this.ckbIsAdmin.Checked;
                    model.Actived = this.ckbActived.Checked;
                    model.Remark = this.txtRemark.Text.Trim();
                    service.CreateUser(model,PermissionService.GetCurrentUser().Name);
                }
                else//修改
                {
                    this.Model.Code = this.txtCode.Text.Trim();
                    this.Model.Name = this.txtName.Text.Trim();
                    this.Model.Password = this.txtPassword.Text.Trim();
                    this.Model.IsAdmin = this.ckbIsAdmin.Checked;
                    this.Model.Actived = this.ckbActived.Checked;
                    this.Model.Remark = this.txtRemark.Text.Trim();
                    service.ModifyUser(this.Model,PermissionService.GetCurrentUser().Name);
                }
                //close diaglog
                this.DialogResult = DialogResult.OK;
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
