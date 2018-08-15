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
    public partial class CtrlDrugs : UserControl
    {
        public CtrlDrugs()
        {
            InitializeComponent();
            this.RefreshListView();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            FrmDrugs frm = new FrmDrugs();
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
            List<Drugs> modelList = modelService.GetAllDrugs();
            this.FillDataGridView(modelList);
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<Drugs> selectedModelList = this.GetSelectModelList();
                
                ModelService modelService = new ModelService();
                foreach (Drugs model in selectedModelList)
                {
                    modelService.DeleteDrug(model, PermissionService.GetCurrentUser().Name);
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
                List<Drugs> selectedModelList = this.GetSelectModelList();
                
                if (selectedModelList.Count > 1)
                {
                    throw new ApplicationException("请选择一个修改内容。");
                }
                ModelService modelService = new ModelService();
                FrmDrugs frm = new FrmDrugs(selectedModelList[0]);
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
        private List<Drugs> GetSelectModelList()
        {
            List<Drugs> selectedModelList = new List<Drugs>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cell.EditedFormattedValue != null && (bool)cell.EditedFormattedValue == true)
                {
                    Drugs selectedModel = (Drugs)row.Tag;
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
            List<Drugs> modelList = modelServices.SearchDrugs(searchCond);
            this.FillDataGridView(modelList);
        }
        private void FillDataGridView(List<Drugs> modelList)
        {
            this.dataGridView1.Rows.Clear();
            foreach (Drugs model in modelList)
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
                cell.Value = model.UnitPrice;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Standard;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Unit;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.Category.Name;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = model.From.Name;
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
