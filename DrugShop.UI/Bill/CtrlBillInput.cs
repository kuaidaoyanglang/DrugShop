using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DrugShop.Model;
using DrugShop.Core;

namespace DrugShop.UI.Bill
{
    public partial class CtrlBillInput : UserControl
    {
        public CtrlBillInput()
        {
            InitializeComponent();
        }
        #region 公共属性
        /// <summary>
        /// 单据类型
        /// </summary>
        public BillsType BillsType { get; set; }
        private CompanyType _CompanyType;
        public CompanyType CompanyType 
        {
            get 
            { 
                return _CompanyType;
            }
            set
            {
                _CompanyType = value;
                CacheService cacheService = new CacheService();
                this.cmbCompany.DataSource = cacheService.GetAllCompanyByType(_CompanyType);
                this.cmbCompany.SelectedItem = null;
            }
        }
        #endregion
        #region 公共方法
        /// <summary>
        /// 保存单据并修改库存
        /// </summary>
        public void DoSave()
        {
            //verify
            if (cmbCompany.SelectedItem == null)
            {
                throw new ApplicationException("请指定关联单位");
            }
            if (cmbStorehouse.SelectedItem == null)
            {
                throw new ApplicationException("请指定仓库");
            }
            if (dgvDrugsList.Rows.Count <= 1)
            {
                throw new ApplicationException("请指定药品");
            }
            //Contruct Model
            Bills bill = new Bills();
            bill.BillsType = this.BillsType;
            bill.Actived = true;
            bill.Code = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            bill.Company = (Company)cmbCompany.SelectedItem;
            bill.IsCancelOut = false;
            bill.IsRedBill = false;
            bill.MakeDate = this.dtpMakeDate.Value;
            bill.CreateDate = DateTime.Now;
            bill.Maker = this.txtMaker.Text.Trim();
            bill.Storehouse = (Storehouse)this.cmbStorehouse.SelectedItem;
            bill.Remark = this.txtRemark.Text.Trim();
            foreach (DataGridViewRow row in dgvDrugsList.Rows)
            {
                if (row.Tag!=null)
                {
                    BillsItem billsItem = (BillsItem)row.Tag;
                    if (billsItem.Remark==null)
                    {
                        billsItem.Remark = "没有备注";
                    }
                    bill.Items.Add(billsItem);
                }
            }
            //Do Save
            StockBillService stockBillService = new StockBillService();
            stockBillService.MakeBill(bill);
            if (MessageBox.Show("保存成功，是否打印单据？", "打印提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new PrintService().PrintBill(bill);
            }
            this.DoReset();
        }
        
        /// <summary>
        /// 重置当前画面并准备录入下一条单据
        /// </summary>
        public void DoNextBill()
        {
            this.DoReset();
        }
        /// <summary>
        /// 重置画面
        /// </summary>
        public void DoReset()
        {
            this.dtpMakeDate.Value = DateTime.Now;
            this.txtMaker.Text = PermissionService.GetCurrentUser().Name;
            this.txtRemark.Clear();
            this.dgvDrugsList.Rows.Clear();
        }
        #endregion
        #region 工具按钮事件
        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoSave();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoNextBill();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoReset();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
        #endregion

        private void dgvDrugsList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dgvDrugsList.Rows[e.RowIndex];
                object value = this.dgvDrugsList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == null)
                {
                    return;
                }
                BillsItem item = null;
                switch (e.ColumnIndex)
                {
                    case 0://输入药品编码
                        string drugCode = value.ToString();
                        ModelService modelService = new ModelService();
                        Drugs drug = modelService.GetDrugsByCode(drugCode);
                        //Fill drugs info into datagridview row
                        if (drug == null)
                        {
                            throw new ApplicationException("编码错误，没有匹配的药物");
                        }
                        DataGridViewTextBoxCell cell = null;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = drug.Name;
                        row.Cells[1] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = drug.UnitPrice;
                        row.Cells[2] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = drug.Standard;
                        row.Cells[3] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = drug.Unit;
                        row.Cells[4] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = drug.Category.Name;
                        row.Cells[5] = cell;

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = drug.From.Name;
                        row.Cells[6] = cell;
                       
                        //add BillsItem into row's tag
                        item = (BillsItem)row.Tag;
                        if (item == null)
                        {
                            item = new BillsItem();
                            row.Tag = item;
                        }
                        item.Drugs = drug;
                        item.UnitPrice = drug.UnitPrice;
                        break;
                    case 2://输入单价编码
                        decimal unitPrice = decimal.Parse(value.ToString());
                        item = (BillsItem)row.Tag;
                        if (item == null)
                        {
                            item = new BillsItem();
                            row.Tag = item;
                        }
                        item.UnitPrice = unitPrice;
                        if (item.Count != 0 && item.UnitPrice != 0)
                        {
                            row.Cells[8].Value = item.Count * item.UnitPrice;
                            item.Money = decimal.Parse(row.Cells[8].Value.ToString());
                        }
                        break;
                    case 7://输入数量编码
                        int count = int.Parse(value.ToString());
                        item = (BillsItem)row.Tag;
                        if (item == null)
                        {
                            item = new BillsItem();
                            row.Tag = item;
                        }
                        item.Count = count;
                        if (item.Count != 0 && item.UnitPrice  != 0)
                        {
                            row.Cells[8].Value = item.Count * item.UnitPrice;
                            item.Money = decimal.Parse(row.Cells[8].Value.ToString());
                        }
                        break;
                    
                    case 8://输入金额编码
                        decimal money = decimal.Parse(value.ToString());
                        item = (BillsItem)row.Tag;
                        if (item == null)
                        {
                            item = new BillsItem();
                            row.Tag = item;
                        }
                        item.Money = money;
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

        private void CtrlBillInput_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtMaker.Text = PermissionService.GetCurrentUser().Name;
                CacheService cacheService=new CacheService();
                this.cmbCompany.DataSource = cacheService.GetAllCompanies();
                this.cmbStorehouse.DataSource = cacheService.GetAllStorehouse();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

    }
}
