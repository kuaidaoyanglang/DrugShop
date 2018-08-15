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

namespace DrugShop.UI.Info
{
    public partial class FrmCompanyType : Form
    {
        private CompanyType Model { get; set; }
        /// <summary>
        /// 用于创建
        /// </summary>
        public FrmCompanyType()
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"新建客户类别");
        }
        /// <summary>
        /// 用于修改
        /// </summary>
        /// <param name="model"></param>
        public FrmCompanyType(CompanyType model)
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"修改客户类别");
            this.Model = model;
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.ckbActived.Checked = model.Actived;
            this.txtRemark.Text = model.Remark;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //Verify
                if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
                {
                    throw new ApplicationException("编码不能为空");
                }
                if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
                {
                    throw new ApplicationException("名称不能为空");
                }
                //save
                ModelService modelService = new ModelService();
                if (this.Model==null)//新建
                {
                    CompanyType model = new CompanyType();
                    model.Code = this.txtCode.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.Actived = this.ckbActived.Checked;
                    model.Remark = this.txtRemark.Text.Trim();
                    modelService.CreateCompanyType(model,PermissionService.GetCurrentUser().Name);
                }
                else//修改
                {
                    this.Model.Code = this.txtCode.Text.Trim();
                    this.Model.Name = this.txtName.Text.Trim();
                    this.Model.Actived = this.ckbActived.Checked;
                    this.Model.Remark = this.txtRemark.Text.Trim();
                    modelService.SaveCompanyType(this.Model,PermissionService.GetCurrentUser().Name);
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
