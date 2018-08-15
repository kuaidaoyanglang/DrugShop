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
    public partial class FrmBillsType : Form
    {
        private BillsType Model { get; set; }
        /// <summary>
        /// 用于创建
        /// </summary>
        public FrmBillsType()
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"新建类别");
        }
        /// <summary>
        /// 用于修改
        /// </summary>
        /// <param name="model"></param>
        public FrmBillsType(BillsType model)
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"修改类别");
            this.Model = model;
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.ckbIsOut.Checked = model.IsOut;
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
                    BillsType model = new BillsType();
                    model.Code = this.txtCode.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.IsOut = this.ckbIsOut.Checked;
                    model.Actived = this.ckbActived.Checked;
                    model.Remark = this.txtRemark.Text.Trim();
                    modelService.CreateBillsType(model,PermissionService.GetCurrentUser().Name);
                }
                else//修改
                {
                    this.Model.Code = this.txtCode.Text.Trim();
                    this.Model.Name = this.txtName.Text.Trim();
                    this.Model.IsOut = this.ckbIsOut.Checked;
                    this.Model.Actived = this.ckbActived.Checked;
                    this.Model.Remark = this.txtRemark.Text.Trim();
                    modelService.SaveBillsType(this.Model,PermissionService.GetCurrentUser().Name);
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
