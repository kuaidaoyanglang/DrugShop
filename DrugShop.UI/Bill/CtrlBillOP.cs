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
    public partial class CtrlBillOP : UserControl
    {
        public CtrlBillOP()
        {
            InitializeComponent();
        }
        #region 公共属性
        /// <summary>
        /// 要操作的票据类型
        /// </summary>
        public BillsType BillsType{ get; set; }
       
        /// <summary>
        /// 是否显示【作废票据】的按钮
        /// </summary>
        public bool  BlankOutButtonVisible
        {
            get 
            { 
                return this.tsbBlankOut.Visible; 
            }
            set 
            { 
                this.tsbBlankOut.Visible = value; 
            } 
        }
        /// <summary>
        /// 是否显示【冲销票据】的按钮
        /// </summary>
        public bool CancelOutButtonVisible
        {
            get
            {
                return this.tsbCancelOut.Visible;
            }
            set
            {
                this.tsbCancelOut.Visible = value;
            }
        }
        public bool MakerConditionEnable
        { 
            get 
            {
                return this.cmbMaker.Enabled;
            } 
            set 
            {
                this.cmbMaker.Enabled = value;
            } 
        }
        #endregion 
        #region 公共方法
        private void DoReset()
        {
            this.dtpFrom.Value = DateTime.Now;
            this.dtpTo.Value = DateTime.Now;
            this.cmbMaker.SelectedItem = PermissionService.GetCurrentUser();
            this.txtID.Clear();
            this.DoSearch();
        }
        private void DoSearch()
        {
            //User billsMaker = (User)this.cmbMaker.SelectedItem;
            User billsMaker = PermissionService.GetCurrentUser();
            DateTime fromDate = new DateTime(this.dtpFrom.Value.Year,this.dtpFrom.Value.Month,this.dtpFrom.Value.Day,0,0,0,0);
            DateTime toDate = new DateTime(this.dtpTo.Value.Year,this.dtpTo.Value.Month,this.dtpTo.Value.Day,23,59,59,998);
            string billsID = txtID.Text.Trim();
            StockBillService stockBillService = new StockBillService();
            List<Bills> billsList = stockBillService.SearchBill(fromDate, toDate, null, null, null, null, null, billsMaker,billsID,this.BillsType);
            
            //fil billsList to dgvBilsList
            this.dgvBillsList.Rows.Clear();
            foreach (Bills bill in billsList)
            {
                if (!bill.Actived || bill.IsCancelOut || bill.IsRedBill)
                {
                    continue;
                }

                DataGridViewRow row = new DataGridViewRow();
                row.Tag = bill;
                DataGridViewCell cell = null;
                cell = new DataGridViewCheckBoxCell();
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.ID.ToString();
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Code;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Maker;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.MakeDate.ToString("yyyy-MM-dd HH:mm:ss");
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Company.Name;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Storehouse.Name;
                row.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.TotalMoney;
                row.Cells.Add(cell);


                cell = new DataGridViewTextBoxCell();
                cell.Value = bill.Remark + (bill.Actived == false ? "已作废" : "");
                row.Cells.Add(cell);

                dgvBillsList.Rows.Add(row);
            }
        }
        private void DoBlankOut()
        {
            List<Bills> selectedList = GetSelectedBills();
            StockBillService stockBillService = new StockBillService();
            foreach (Bills bill in selectedList)
            {
                Bills b = stockBillService.FindBill(bill.ID);
                stockBillService.BlankOutBill(b, "作废的票据");
            }

            this.DoReset();
        }
        private void DoCancelOut()
        {
            List<Bills> selectedList = GetSelectedBills();
            StockBillService stockBillService = new StockBillService();
            foreach (Bills bill in selectedList)
            {
                Bills b = stockBillService.FindBill(bill.ID);
                stockBillService.CancelOutBill(bill, PermissionService.GetCurrentUser().Name, DateTime.Now, "冲销的票据");
            }

            this.DoReset();
        }
        private List<Bills> GetSelectedBills()
        {
            List<Bills> selectedList = new List<Bills>();
            foreach (DataGridViewRow row in dgvBillsList.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cell.EditedFormattedValue != null && (bool)cell.EditedFormattedValue == true)
                {
                    Bills selectedOne = (Bills)row.Tag;
                    selectedList.Add(selectedOne);
                }
            }

            if (selectedList.Count == 0)
            {
                throw new ApplicationException("请先选择要操作的内容");
            }
            return selectedList;
        }
        #endregion
        #region 事件响应
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoSearch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbBlankOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoBlankOut();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbCancelOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoCancelOut();
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
        private void CtrlBillOP_Load(object sender, EventArgs e)
        {
            try
            {
                PermissionService permissionService = new PermissionService();
                this.cmbMaker.DataSource = permissionService.GetAllUsers();
                this.cmbMaker.SelectedItem = PermissionService.GetCurrentUser();
                this.DoSearch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void dgvBillsList_SelectionChanged(object sender, EventArgs e)
        {
         try
            {
                dgvBillsItemList.Rows.Clear();
                if (dgvBillsList.SelectedRows.Count > 0)
                {
                    Bills bill = (Bills)dgvBillsList.SelectedRows[0].Tag;
                    StockBillService stockBillService = new StockBillService();
                    bill = stockBillService.FindBill(bill.ID);
                    foreach (BillsItem item in bill.Items)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.Tag = item;

                        DataGridViewTextBoxCell cell = null;
                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Drugs.Code;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Drugs.Name;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.UnitPrice.ToString("0.00");
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Drugs.Category.Name;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Drugs.From.Name;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Drugs.Unit;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Drugs.Standard;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Count;
                        row.Cells.Add(cell);

                        cell = new DataGridViewTextBoxCell();
                        cell.Value = item.Money.ToString("0.00");
                        row.Cells.Add(cell);

                        dgvBillsItemList.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.DoSearch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.DoSearch();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
        #endregion
    }
}
