using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DrugShop.Model;
using DrugShop.Core;

namespace DrugShop.UI.Info
{
    public partial class CtrlDrugCategory : UserControl
    {
        public CtrlDrugCategory()
        {
            InitializeComponent();
            this.RefreshListView();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            FrmDrugCategory frm = new FrmDrugCategory();
            frm.ShowDialog(this);
            if (frm.DialogResult==DialogResult.OK)
            {
                this.RefreshListView();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshListView();
        }
        private void RefreshListView()
        {
            ModelService modelService = new ModelService();
            List<DrugCategory> modelList = modelService.GetAllDrugCategory();
            this.FillDataGridView(modelList);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<DrugCategory> selectedModelList = this.GetSelectModelList();
                
                ModelService modelService = new ModelService();
                foreach (DrugCategory model in selectedModelList)
                {
                    modelService.DeleteDrugCategory(model, PermissionService.GetCurrentUser().Name);
                }
                this.RefreshListView();
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            try
            {
                List<DrugCategory> selectedModelList = this.GetSelectModelList();
                
                if (selectedModelList.Count > 1)
                {
                    throw new ApplicationException("请选择一个修改内容。");
                }
                ModelService modelService = new ModelService();
                FrmDrugCategory frm = new FrmDrugCategory(selectedModelList[0]);
                frm.ShowDialog(this);
                if (frm.DialogResult == DialogResult.OK)
                {
                    this.RefreshListView();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.OnError(ex);
            }
        }
        private List<DrugCategory> GetSelectModelList()
        {
            List<DrugCategory> selectedModelList = new List<DrugCategory>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cell.EditedFormattedValue != null && (bool)cell.EditedFormattedValue == true)
                {
                    DrugCategory selectedModel = (DrugCategory)row.Tag;
                    selectedModelList.Add(selectedModel);
                }
            }
            if (selectedModelList.Count == 0)
            {
                throw new ApplicationException("请选择要操作的内容。");
            }
            return selectedModelList;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchCond = this.txtSearch.Text.Trim();
            this.SearchModelList(searchCond);
        }
        private void SearchModelList(string searchCond)
        {
            ModelService modelServices = new ModelService();
            List<DrugCategory> modelList = modelServices.SearchDrugCategory(searchCond);
            this.FillDataGridView(modelList);
        }
        private void FillDataGridView(List<DrugCategory> modelList)
        {
            this.dataGridView1.Rows.Clear();
            foreach (DrugCategory model in modelList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell cell = null;
                cell = new DataGridViewCheckBoxCell();
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.ID;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Code;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Name;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Actived == true ? "激活" : "注销";
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Remark;
                row.Cells.Add(cell);
                row.Tag = model;
                this.dataGridView1.Rows.Add(row);
            }
        }
    }
}
