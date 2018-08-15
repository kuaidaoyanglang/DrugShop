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
    public partial class FrmCompany : Form
    {
        private Company Model { get; set; }
        /// <summary>
        /// 用于创建
        /// </summary>
        public FrmCompany()
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"新建客户");
        }
        /// <summary>
        /// 用于修改
        /// </summary>
        /// <param name="model"></param>
        public FrmCompany(Company model)
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"修改客户");
            this.Model = model;
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.cmbCompanyType.SelectedItem = model.CompanyType;
            this.ckbActived.Checked = model.Actived;
            this.txtRemark.Text = model.Remark;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                //save
                ModelService modelService = new ModelService();
                if (this.Model==null)//新建
                {
                    Company model = new Company();
                    model.Code = this.txtCode.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.CompanyType = (CompanyType)this.cmbCompanyType.SelectedItem;
                    model.Actived = this.ckbActived.Checked;
                    model.Remark = this.txtRemark.Text.Trim();
                    modelService.CreateCompany(model,PermissionService.GetCurrentUser().Name);
                }
                else//修改
                {
                    this.Model.Code = this.txtCode.Text.Trim();
                    this.Model.Name = this.txtName.Text.Trim();
                    this.Model.CompanyType = (CompanyType)this.cmbCompanyType.SelectedItem;
                    this.Model.Actived = this.ckbActived.Checked;
                    this.Model.Remark = this.txtRemark.Text.Trim();
                    modelService.SaveCompany(this.Model,PermissionService.GetCurrentUser().Name);
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

        private void FrmCompany_Load(object sender, EventArgs e)
        {
            try
            {
                ModelService service = new ModelService();
                List<CompanyType> ctList = service.GetAllCompanyTypes();

                this.cmbCompanyType.DataSource = ctList;
                if (this.Model == null)
                {
                    this.cmbCompanyType.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        } 
    }
}
