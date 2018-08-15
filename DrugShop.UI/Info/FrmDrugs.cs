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
    public partial class FrmDrugs : Form
    {
        private Drugs Model { get; set; }
        /// <summary>
        /// 用于创建
        /// </summary>
        public FrmDrugs()
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"新建药品");
        }
        /// <summary>
        /// 用于修改
        /// </summary>
        /// <param name="model"></param>
        public FrmDrugs(Drugs model)
        {
            InitializeComponent();
            this.Text = string.Format(this.Text,"修改药品");
            this.Model = model;
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.txtUnitPrice.Text = model.UnitPrice.ToString();
            this.txtStandard.Text = model.Standard;
            this.txtUnit.Text = model.Unit;
            this.cmbCategory.SelectedItem = model.Category;
            this.cmbFrom.SelectedItem = model.From;
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
                if (string.IsNullOrEmpty(this.txtUnit.Text.Trim()))
                {
                    throw new ApplicationException("单位不能为空");
                }
                if (string.IsNullOrEmpty(this.txtStandard.Text.Trim()))
                {
                    throw new ApplicationException("规格不能为空");
                }
                if (this.cmbCategory.SelectedItem == null)
                {
                    throw new ApplicationException("品种不能为空");
                }
                if (this.cmbFrom.SelectedItem == null)
                {
                    throw new ApplicationException("产地不能为空");
                }
                //save
                ModelService modelService = new ModelService();
                if (this.Model==null)//新建
                {
                    Drugs model = new Drugs();
                    model.Code = this.txtCode.Text.Trim();
                    model.Name = this.txtName.Text.Trim();
                    model.UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text.Trim());
                    model.Standard = this.txtStandard.Text.Trim();
                    model.Unit = this.txtUnit.Text.Trim();
                    model.From = (DrugFrom)this.cmbFrom.SelectedItem;
                    model.Category = (DrugCategory)this.cmbCategory.SelectedItem;
                    model.Actived = this.ckbActived.Checked;
                    model.Remark = this.txtRemark.Text.Trim();
                    modelService.CreateDrug(model,PermissionService.GetCurrentUser().Name);
                }
                else//修改
                {
                    this.Model.Code = this.txtCode.Text.Trim();
                    this.Model.Name = this.txtName.Text.Trim();
                    this.Model.UnitPrice = Convert.ToDecimal(this.txtUnitPrice.Text.Trim());
                    this.Model.Standard = this.txtStandard.Text.Trim();
                    this.Model.Unit = this.txtUnit.Text.Trim();
                    this.Model.From = (DrugFrom)this.cmbFrom.SelectedItem;
                    this.Model.Category = (DrugCategory)this.cmbCategory.SelectedItem;
                    this.Model.Actived = this.ckbActived.Checked;
                    this.Model.Remark = this.txtRemark.Text.Trim();
                    modelService.SaveDrug(this.Model,PermissionService.GetCurrentUser().Name);
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

        private void FrmDrugs_Load(object sender, EventArgs e)
        {
            try
            {
                ModelService service = new ModelService();
                List<DrugFrom> fList = service.GetAllDrugFrom();
                List<DrugCategory> cList = service.GetAllDrugCategory();

                this.cmbFrom.DataSource = fList;
                this.cmbCategory.DataSource = cList;
                if (this.Model == null)
                {
                    this.cmbFrom.SelectedItem = null;
                    this.cmbCategory.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        } 
    }
}
